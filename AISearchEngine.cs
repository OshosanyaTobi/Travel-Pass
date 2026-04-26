using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Text.RegularExpressions;

namespace TravelPass
{
    // Structured representation of a parsed natural language search query.
    public class SearchCriteria
    {
        public string Nationality      { get; set; }  // ISO 3166-1 alpha-3, e.g. "NGA"
        public string DocumentType     { get; set; }  // "PASSPORT", "VISA", or null for any
        public DateTime? DateFrom      { get; set; }
        public DateTime? DateTo        { get; set; }
        public string NameContains     { get; set; }
        public string PassportNumber   { get; set; }
        public bool? RequireFailedRFID { get; set; }
        public bool? RequireFlagged    { get; set; }
        public bool? RequirePostDated  { get; set; }
        public bool? RequireFailed     { get; set; }  // overall validation result
        public bool? RequireExpired    { get; set; }
        public bool? RequireUVFailed   { get; set; }
        public bool? RequireIRFailed   { get; set; }
        public string FlightTo         { get; set; }
        public string FlightFrom       { get; set; }
        public string RawQuery         { get; set; }  // original user text
    }

    // Enriched record data returned from a search.
    public class AISearchResult
    {
        public string RecordFolderPath  { get; set; }
        public string RecordedByName    { get; set; }
        public string RecordedByEmail   { get; set; }
        public string PassportNumber    { get; set; }
        public string PassportName      { get; set; }
        public string DateTimeRecorded  { get; set; }
        public string FlightFrom        { get; set; }
        public string FlightTo          { get; set; }
        public string FinalDestination  { get; set; }
        // Enriched fields from MRZ / validation files.
        public string Nationality       { get; set; }
        public string DocumentType      { get; set; }
        public string ValidationPassed  { get; set; }
        public string RFIDStatus        { get; set; }
        public string IsPostDated       { get; set; }
        public string IsFlagged         { get; set; }
        public string VisaStartDate     { get; set; }
        public string DocExpiry         { get; set; }
    }

    public static class AISearchEngine
    {
        // ------------------------------------------------------------------ //
        //  Nationality adjective / country-name → ISO 3166-1 alpha-3 mapping //
        // ------------------------------------------------------------------ //
        private static readonly Dictionary<string, string> NationalityMap =
            new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase)
        {
            // Africa
            { "nigerian",           "NGA" }, { "nigeria",            "NGA" },
            { "ghanaian",           "GHA" }, { "ghana",              "GHA" },
            { "kenyan",             "KEN" }, { "kenya",              "KEN" },
            { "south african",      "ZAF" }, { "south africa",       "ZAF" },
            { "ethiopian",          "ETH" }, { "ethiopia",           "ETH" },
            { "tanzanian",          "TZA" }, { "tanzania",           "TZA" },
            { "ugandan",            "UGA" }, { "uganda",             "UGA" },
            { "rwandan",            "RWA" }, { "rwanda",             "RWA" },
            { "zambian",            "ZMB" }, { "zambia",             "ZMB" },
            { "zimbabwean",         "ZWE" }, { "zimbabwe",           "ZWE" },
            { "cameroonian",        "CMR" }, { "cameroon",           "CMR" },
            { "senegalese",         "SEN" }, { "senegal",            "SEN" },
            { "ivorian",            "CIV" }, { "ivory coast",        "CIV" }, { "cote d'ivoire", "CIV" },
            { "gambian",            "GMB" }, { "gambia",             "GMB" },
            { "sierra leonean",     "SLE" }, { "sierra leone",       "SLE" },
            { "liberian",           "LBR" }, { "liberia",            "LBR" },
            { "malian",             "MLI" }, { "mali",               "MLI" },
            { "guinean",            "GIN" }, { "guinea",             "GIN" },
            { "beninese",           "BEN" }, { "benin",              "BEN" },
            { "togolese",           "TGO" }, { "togo",               "TGO" },
            { "burkinabe",          "BFA" }, { "burkina faso",       "BFA" },
            { "nigerien",           "NER" }, { "niger",              "NER" },
            { "congolese",          "COD" }, { "drc",                "COD" },
            { "angolan",            "AGO" }, { "angola",             "AGO" },
            { "mozambican",         "MOZ" }, { "mozambique",         "MOZ" },
            { "malawian",           "MWI" }, { "malawi",             "MWI" },
            { "botswanan",          "BWA" }, { "botswana",           "BWA" },
            { "namibian",           "NAM" }, { "namibia",            "NAM" },
            { "egyptian",           "EGY" }, { "egypt",              "EGY" },
            { "moroccan",           "MAR" }, { "morocco",            "MAR" },
            { "algerian",           "DZA" }, { "algeria",            "DZA" },
            { "tunisian",           "TUN" }, { "tunisia",            "TUN" },
            { "libyan",             "LBY" }, { "libya",              "LBY" },
            { "sudanese",           "SDN" }, { "sudan",              "SDN" },
            { "somali",             "SOM" }, { "somalia",            "SOM" },
            // Middle East
            { "emirati",            "ARE" }, { "uae",                "ARE" }, { "united arab emirates", "ARE" },
            { "saudi",              "SAU" }, { "saudi arabian",      "SAU" }, { "saudi arabia", "SAU" },
            { "qatari",             "QAT" }, { "qatar",              "QAT" },
            { "kuwaiti",            "KWT" }, { "kuwait",             "KWT" },
            { "bahraini",           "BHR" }, { "bahrain",            "BHR" },
            { "omani",              "OMN" }, { "oman",               "OMN" },
            { "jordanian",          "JOR" }, { "jordan",             "JOR" },
            { "lebanese",           "LBN" }, { "lebanon",            "LBN" },
            { "syrian",             "SYR" }, { "syria",              "SYR" },
            { "iraqi",              "IRQ" }, { "iraq",               "IRQ" },
            { "iranian",            "IRN" }, { "iran",               "IRN" },
            { "israeli",            "ISR" }, { "israel",             "ISR" },
            { "yemeni",             "YEM" }, { "yemen",              "YEM" },
            // Europe
            { "british",            "GBR" }, { "uk",                 "GBR" }, { "united kingdom", "GBR" }, { "britain", "GBR" },
            { "french",             "FRA" }, { "france",             "FRA" },
            { "german",             "DEU" }, { "germany",            "DEU" },
            { "italian",            "ITA" }, { "italy",              "ITA" },
            { "spanish",            "ESP" }, { "spain",              "ESP" },
            { "portuguese",         "PRT" }, { "portugal",           "PRT" },
            { "dutch",              "NLD" }, { "netherlands",        "NLD" }, { "holland", "NLD" },
            { "belgian",            "BEL" }, { "belgium",            "BEL" },
            { "swiss",              "CHE" }, { "switzerland",        "CHE" },
            { "austrian",           "AUT" }, { "austria",            "AUT" },
            { "swedish",            "SWE" }, { "sweden",             "SWE" },
            { "norwegian",          "NOR" }, { "norway",             "NOR" },
            { "danish",             "DNK" }, { "denmark",            "DNK" },
            { "finnish",            "FIN" }, { "finland",            "FIN" },
            { "polish",             "POL" }, { "poland",             "POL" },
            { "romanian",           "ROU" }, { "romania",            "ROU" },
            { "greek",              "GRC" }, { "greece",             "GRC" },
            { "turkish",            "TUR" }, { "turkey",             "TUR" },
            { "russian",            "RUS" }, { "russia",             "RUS" },
            { "ukrainian",          "UKR" }, { "ukraine",            "UKR" },
            { "czech",              "CZE" }, { "czechia",            "CZE" },
            { "hungarian",          "HUN" }, { "hungary",            "HUN" },
            // Americas
            { "american",           "USA" }, { "us",                 "USA" }, { "usa",     "USA" }, { "united states", "USA" },
            { "canadian",           "CAN" }, { "canada",             "CAN" },
            { "brazilian",          "BRA" }, { "brazil",             "BRA" },
            { "argentine",          "ARG" }, { "argentinian",        "ARG" }, { "argentina", "ARG" },
            { "colombian",          "COL" }, { "colombia",           "COL" },
            { "mexican",            "MEX" }, { "mexico",             "MEX" },
            { "peruvian",           "PER" }, { "peru",               "PER" },
            { "venezuelan",         "VEN" }, { "venezuela",          "VEN" },
            { "chilean",            "CHL" }, { "chile",              "CHL" },
            { "cuban",              "CUB" }, { "cuba",               "CUB" },
            // Asia-Pacific
            { "indian",             "IND" }, { "india",              "IND" },
            { "pakistani",          "PAK" }, { "pakistan",           "PAK" },
            { "bangladeshi",        "BGD" }, { "bangladesh",         "BGD" },
            { "chinese",            "CHN" }, { "china",              "CHN" },
            { "japanese",           "JPN" }, { "japan",              "JPN" },
            { "korean",             "KOR" }, { "south korean",       "KOR" }, { "south korea", "KOR" },
            { "thai",               "THA" }, { "thailand",           "THA" },
            { "indonesian",         "IDN" }, { "indonesia",          "IDN" },
            { "malaysian",          "MYS" }, { "malaysia",           "MYS" },
            { "filipino",           "PHL" }, { "philippine",         "PHL" }, { "philippines", "PHL" },
            { "vietnamese",         "VNM" }, { "vietnam",            "VNM" },
            { "singaporean",        "SGP" }, { "singapore",          "SGP" },
            { "sri lankan",         "LKA" }, { "sri lanka",          "LKA" },
            { "nepali",             "NPL" }, { "nepal",              "NPL" },
            { "australian",         "AUS" }, { "australia",          "AUS" },
            { "new zealander",      "NZL" }, { "new zealand",        "NZL" },
        };

        // Keywords that indicate the query should be interpreted as natural language.
        private static readonly string[] NLKeywords =
        {
            "last week", "last month", "last year", "last day", "last days",
            "this week", "this month", "this year",
            "yesterday", "today",
            "failed", "invalid", "flagged", "rfid", "uv mismatch",
            "ir mismatch", "uv fail", "ir fail", "post-dated", "post dated",
            "expired", "all ", "show ", "find ", " with ", " having ",
            " and ", "passports", "visas", "scanned"
        };

        // Month names for date parsing.
        private static readonly string[] MonthNames =
        {
            "january","february","march","april","may","june",
            "july","august","september","october","november","december"
        };

        // ------------------------------------------------------------------ //
        //  Public API                                                          //
        // ------------------------------------------------------------------ //

        /// <summary>
        /// Returns true when <paramref name="query"/> contains natural-language
        /// features (temporal phrases, validation terms, nationality adjectives).
        /// </summary>
        public static bool IsNaturalLanguageQuery(string query)
        {
            if (string.IsNullOrEmpty(query))
                return false;

            string lower = query.Trim().ToLower();

            foreach (string kw in NLKeywords)
            {
                if (lower.Contains(kw))
                    return true;
            }

            // Any recognised nationality adjective.
            foreach (string key in NationalityMap.Keys)
            {
                if (lower.Contains(key.ToLower()))
                    return true;
            }

            return false;
        }

        /// <summary>
        /// Parses a free-form user query into a <see cref="SearchCriteria"/>
        /// object.
        /// </summary>
        public static SearchCriteria ParseQuery(string query)
        {
            SearchCriteria c = new SearchCriteria();
            c.RawQuery = query;

            if (string.IsNullOrEmpty(query))
                return c;

            string q = query.Trim();

            ExtractNationality(q, c);
            ExtractDocumentType(q, c);
            ExtractDateRange(q, c);
            ExtractValidationFlags(q, c);
            ExtractNameOrNumber(q, c);
            ExtractFlightRoute(q, c);

            return c;
        }

        /// <summary>
        /// Searches all flight record folders under <paramref name="flightsRoot"/>
        /// and returns records that satisfy <paramref name="criteria"/>.
        /// Pass the parent of the Flights directory (e.g. c:\Travelpass\Flights).
        /// </summary>
        public static List<AISearchResult> Search(SearchCriteria criteria, string flightsRoot)
        {
            List<AISearchResult> results = new List<AISearchResult>();

            if (!Directory.Exists(flightsRoot))
                return results;

            try
            {
                string[] flightFolders = Directory.GetDirectories(flightsRoot);

                foreach (string flightFolder in flightFolders)
                {
                    string recordsDir = Path.Combine(flightFolder, "Records");

                    if (!Directory.Exists(recordsDir))
                        continue;

                    string[] recordFolders = Directory.GetDirectories(recordsDir);

                    foreach (string recordDir in recordFolders)
                    {
                        try
                        {
                            AISearchResult record = ReadRecord(recordDir);

                            if (record != null && MatchesCriteria(record, criteria))
                                results.Add(record);
                        }
                        catch
                        {
                            // Skip unreadable record folders silently.
                        }
                    }
                }
            }
            catch
            {
                // Return whatever was collected before the error.
            }

            return results;
        }

        /// <summary>
        /// Converts a list of <see cref="AISearchResult"/> objects into a
        /// <see cref="DataTable"/> suitable for binding to a DataGridView.
        /// The first nine columns match the layout of the standard VRecord grid
        /// so existing click handlers remain compatible.
        /// </summary>
        public static DataTable ToDataTable(List<AISearchResult> results)
        {
            DataTable dt = new DataTable();

            // Core columns (must match VRecord column order used in UpdateRecordList).
            dt.Columns.Add("RECORD_FOLDER_PATH",  typeof(string));
            dt.Columns.Add("RECORDED_BY_NAME",    typeof(string));
            dt.Columns.Add("RECORDED_BY_EMAIL",   typeof(string));
            dt.Columns.Add("PASSPORT_NUMBER",     typeof(string));
            dt.Columns.Add("PASSPORT_NAME",       typeof(string));
            dt.Columns.Add("DATE_TIME_RECORDED",  typeof(string));
            dt.Columns.Add("FLIGHT_FROM",         typeof(string));
            dt.Columns.Add("FLIGHT_TO",           typeof(string));
            dt.Columns.Add("FINAL_DESTINATION",   typeof(string));
            // Enriched columns.
            dt.Columns.Add("NATIONALITY",         typeof(string));
            dt.Columns.Add("DOC_TYPE",            typeof(string));
            dt.Columns.Add("VALIDATION",          typeof(string));
            dt.Columns.Add("RFID_STATUS",         typeof(string));
            dt.Columns.Add("POST_DATED",          typeof(string));
            dt.Columns.Add("FLAGGED",             typeof(string));

            foreach (AISearchResult r in results)
            {
                dt.Rows.Add(
                    r.RecordFolderPath  ?? "",
                    r.RecordedByName    ?? "",
                    r.RecordedByEmail   ?? "",
                    r.PassportNumber    ?? "",
                    r.PassportName      ?? "",
                    r.DateTimeRecorded  ?? "",
                    r.FlightFrom        ?? "",
                    r.FlightTo          ?? "",
                    r.FinalDestination  ?? "",
                    r.Nationality       ?? "",
                    r.DocumentType      ?? "",
                    r.ValidationPassed  ?? "",
                    r.RFIDStatus        ?? "",
                    r.IsPostDated       ?? "",
                    r.IsFlagged         ?? ""
                );
            }

            return dt;
        }

        // ------------------------------------------------------------------ //
        //  Private – file reading                                              //
        // ------------------------------------------------------------------ //

        private static AISearchResult ReadRecord(string recordDir)
        {
            AISearchResult result = new AISearchResult();
            result.RecordFolderPath = recordDir.Trim();

            string recordDetailsPath = Path.Combine(recordDir, "Record Details.travlr");

            if (File.Exists(recordDetailsPath))
            {
                foreach (string line in File.ReadAllLines(recordDetailsPath))
                {
                    string key;
                    string val;
                    SplitTravlrLine(line, out key, out val);

                    switch (key)
                    {
                        case "Recorded by_Name":       result.RecordedByName   = val; break;
                        case "Recorded by_Email":      result.RecordedByEmail  = val; break;
                        case "Scanned Passport Number": result.PassportNumber  = val; break;
                        case "Scanned Passport Name":  result.PassportName     = val; break;
                        case "Date-Time Recorded":     result.DateTimeRecorded = val; break;
                        case "Flight From":            result.FlightFrom       = val; break;
                        case "Flight To":              result.FlightTo         = val; break;
                        case "Final Destination":      result.FinalDestination = val; break;
                    }
                }
            }

            // Enrich with MRZ and validation data from the Scans sub-folder.
            string scansDir = Path.Combine(recordDir, "Scans");

            if (Directory.Exists(scansDir))
            {
                string[] scanFolders = Directory.GetDirectories(scansDir);

                foreach (string scanFolder in scanFolders)
                {
                    string folderName = Path.GetFileName(scanFolder).ToUpper();

                    if (folderName.StartsWith("PASSPORT_"))
                        result.DocumentType = "PASSPORT";
                    else if (folderName.StartsWith("VISA_"))
                        result.DocumentType = "VISA";
                    else
                        result.DocumentType = "OTHER";

                    // MRZ Codeline Details
                    string mrzPath = Path.Combine(scanFolder, "MRZ Scan",
                                                  "MRZ Codeline Details.travlr");

                    if (File.Exists(mrzPath))
                    {
                        foreach (string line in File.ReadAllLines(mrzPath))
                        {
                            string key;
                            string val;
                            SplitTravlrLine(line, out key, out val);

                            switch (key)
                            {
                                case "Nationality":       result.Nationality = val; break;
                                case "Date of expiry":    result.DocExpiry   = val; break;
                            }
                        }
                    }

                    // Validation Details (Passport or Visa)
                    string validationPath = Path.Combine(scanFolder,
                                                         "Passport Validation Details.travlr");

                    if (!File.Exists(validationPath))
                        validationPath = Path.Combine(scanFolder,
                                                      "Visa Validation Details.travlr");

                    if (File.Exists(validationPath))
                    {
                        foreach (string line in File.ReadAllLines(validationPath))
                        {
                            string key;
                            string val;
                            SplitTravlrLine(line, out key, out val);

                            switch (key)
                            {
                                case "Passed":             result.ValidationPassed = val; break;
                                case "RFID availability":  result.RFIDStatus       = val; break;
                                case "isPostDated":        result.IsPostDated      = val; break;
                                case "isFlagged":          result.IsFlagged        = val; break;
                                case "Visa Start Date":    result.VisaStartDate    = val; break;
                            }
                        }
                    }

                    // Use the first scan folder's data; break after enriching.
                    break;
                }
            }

            return result;
        }

        // Splits a .travlr "Key = Value" line into trimmed key and value parts.
        // Handles paths that contain '=' by splitting only on the first '='.
        private static void SplitTravlrLine(string line, out string key, out string val)
        {
            int idx = line.IndexOf('=');

            if (idx < 0)
            {
                key = line.Trim();
                val = "";
                return;
            }

            key = line.Substring(0, idx).Trim();
            val = line.Substring(idx + 1).Trim().Trim('"');
        }

        // ------------------------------------------------------------------ //
        //  Private – criteria matching                                         //
        // ------------------------------------------------------------------ //

        private static bool MatchesCriteria(AISearchResult r, SearchCriteria c)
        {
            // Nationality filter
            if (!string.IsNullOrEmpty(c.Nationality))
            {
                if (string.IsNullOrEmpty(r.Nationality))
                    return false;

                if (!r.Nationality.Trim().ToUpper().Contains(c.Nationality.ToUpper()))
                    return false;
            }

            // Document type filter
            if (!string.IsNullOrEmpty(c.DocumentType))
            {
                if (string.IsNullOrEmpty(r.DocumentType))
                    return false;

                if (!r.DocumentType.Trim().ToUpper().Equals(c.DocumentType.ToUpper()))
                    return false;
            }

            // Date range filter (against Date-Time Recorded)
            if (c.DateFrom.HasValue || c.DateTo.HasValue)
            {
                DateTime recorded;

                if (!TryParseRecordedDate(r.DateTimeRecorded, out recorded))
                    return false;

                if (c.DateFrom.HasValue && recorded.Date < c.DateFrom.Value.Date)
                    return false;

                if (c.DateTo.HasValue && recorded.Date > c.DateTo.Value.Date)
                    return false;
            }

            // Name filter
            if (!string.IsNullOrEmpty(c.NameContains))
            {
                bool nameMatch =
                    (!string.IsNullOrEmpty(r.PassportName) &&
                     r.PassportName.IndexOf(c.NameContains,
                                            StringComparison.OrdinalIgnoreCase) >= 0) ||
                    (!string.IsNullOrEmpty(r.RecordedByName) &&
                     r.RecordedByName.IndexOf(c.NameContains,
                                              StringComparison.OrdinalIgnoreCase) >= 0);

                if (!nameMatch)
                    return false;
            }

            // Passport number filter
            if (!string.IsNullOrEmpty(c.PassportNumber))
            {
                if (string.IsNullOrEmpty(r.PassportNumber))
                    return false;

                if (r.PassportNumber.IndexOf(c.PassportNumber,
                                             StringComparison.OrdinalIgnoreCase) < 0)
                    return false;
            }

            // RFID failed filter
            if (c.RequireFailedRFID.HasValue && c.RequireFailedRFID.Value)
            {
                if (string.IsNullOrEmpty(r.RFIDStatus) ||
                    !r.RFIDStatus.Trim().ToUpper().Contains("ERROR"))
                    return false;
            }

            // Flagged filter
            if (c.RequireFlagged.HasValue && c.RequireFlagged.Value)
            {
                if (string.IsNullOrEmpty(r.IsFlagged) ||
                    !r.IsFlagged.Trim().ToUpper().Contains("TRUE") &&
                    !r.IsFlagged.Trim().ToUpper().Contains("YES"))
                    return false;
            }

            // Post-dated filter
            if (c.RequirePostDated.HasValue && c.RequirePostDated.Value)
            {
                if (string.IsNullOrEmpty(r.IsPostDated) ||
                    !r.IsPostDated.Trim().ToUpper().Contains("TRUE") &&
                    !r.IsPostDated.Trim().ToUpper().Contains("YES"))
                    return false;
            }

            // Overall validation failed filter
            if (c.RequireFailed.HasValue)
            {
                bool recordPassed =
                    !string.IsNullOrEmpty(r.ValidationPassed) &&
                    r.ValidationPassed.Trim().ToUpper().Contains("TRUE");

                if (c.RequireFailed.Value && recordPassed)
                    return false;

                if (!c.RequireFailed.Value && !recordPassed)
                    return false;
            }

            // Flight route filters
            if (!string.IsNullOrEmpty(c.FlightFrom))
            {
                if (string.IsNullOrEmpty(r.FlightFrom))
                    return false;

                if (r.FlightFrom.IndexOf(c.FlightFrom,
                                         StringComparison.OrdinalIgnoreCase) < 0)
                    return false;
            }

            if (!string.IsNullOrEmpty(c.FlightTo))
            {
                if (string.IsNullOrEmpty(r.FlightTo))
                    return false;

                if (r.FlightTo.IndexOf(c.FlightTo,
                                       StringComparison.OrdinalIgnoreCase) < 0)
                    return false;
            }

            return true;
        }

        // ------------------------------------------------------------------ //
        //  Private – query parsing helpers                                     //
        // ------------------------------------------------------------------ //

        private static void ExtractNationality(string query, SearchCriteria c)
        {
            string lower = query.ToLower();

            // Try multi-word entries first (longer keys have higher specificity).
            List<string> keys = new List<string>(NationalityMap.Keys);
            keys.Sort(delegate(string a, string b) { return b.Length.CompareTo(a.Length); });

            foreach (string key in keys)
            {
                if (lower.Contains(key.ToLower()))
                {
                    c.Nationality = NationalityMap[key];
                    return;
                }
            }

            // Also accept bare 3-letter ISO codes (e.g. "NGA", "GBR").
            Match isoMatch = Regex.Match(query, @"\b([A-Z]{3})\b");

            if (isoMatch.Success)
            {
                // Exclude known non-nationality tokens.
                string code = isoMatch.Groups[1].Value;

                if (!code.Equals("MRZ") && !code.Equals("PDF") &&
                    !code.Equals("UV") && !code.Equals("IR") &&
                    !code.Equals("OK") && !code.Equals("ALL"))
                {
                    c.Nationality = code;
                }
            }
        }

        private static void ExtractDocumentType(string query, SearchCriteria c)
        {
            string lower = query.ToLower();

            if (lower.Contains("passport"))
            {
                c.DocumentType = "PASSPORT";
            }
            else if (lower.Contains("visa"))
            {
                c.DocumentType = "VISA";
            }
            else if (lower.Contains("residence permit") ||
                     lower.Contains("id card") ||
                     lower.Contains("permit"))
            {
                c.DocumentType = "OTHER";
            }
        }

        private static void ExtractDateRange(string query, SearchCriteria c)
        {
            string lower = query.ToLower();
            DateTime today = DateTime.Today;

            // "last N days/weeks/months"
            Match mN = Regex.Match(lower,
                @"last\s+(\d+)\s+(day|days|week|weeks|month|months|year|years)");

            if (mN.Success)
            {
                int n = int.Parse(mN.Groups[1].Value);
                string unit = mN.Groups[2].Value;

                if (unit.StartsWith("day"))
                {
                    c.DateFrom = today.AddDays(-n);
                }
                else if (unit.StartsWith("week"))
                {
                    c.DateFrom = today.AddDays(-7 * n);
                }
                else if (unit.StartsWith("month"))
                {
                    c.DateFrom = today.AddMonths(-n);
                }
                else if (unit.StartsWith("year"))
                {
                    c.DateFrom = today.AddYears(-n);
                }

                c.DateTo = today;
                return;
            }

            // "last week"
            if (Regex.IsMatch(lower, @"\blast\s+week\b"))
            {
                c.DateFrom = today.AddDays(-7);
                c.DateTo   = today;
                return;
            }

            // "last month"
            if (Regex.IsMatch(lower, @"\blast\s+month\b"))
            {
                c.DateFrom = today.AddMonths(-1);
                c.DateTo   = today;
                return;
            }

            // "last year"
            if (Regex.IsMatch(lower, @"\blast\s+year\b"))
            {
                c.DateFrom = today.AddYears(-1);
                c.DateTo   = today;
                return;
            }

            // "this week"
            if (Regex.IsMatch(lower, @"\bthis\s+week\b"))
            {
                int daysSinceMonday = ((int)today.DayOfWeek + 6) % 7;
                c.DateFrom = today.AddDays(-daysSinceMonday);
                c.DateTo   = today;
                return;
            }

            // "this month"
            if (Regex.IsMatch(lower, @"\bthis\s+month\b"))
            {
                c.DateFrom = new DateTime(today.Year, today.Month, 1);
                c.DateTo   = today;
                return;
            }

            // "yesterday"
            if (Regex.IsMatch(lower, @"\byesterday\b"))
            {
                c.DateFrom = today.AddDays(-1);
                c.DateTo   = today.AddDays(-1);
                return;
            }

            // "today"
            if (Regex.IsMatch(lower, @"\btoday\b"))
            {
                c.DateFrom = today;
                c.DateTo   = today;
                return;
            }

            // "in [month] [year]" or "in [month]"
            for (int i = 0; i < MonthNames.Length; i++)
            {
                string monthName = MonthNames[i];

                if (!lower.Contains(monthName))
                    continue;

                int month     = i + 1;
                int year      = today.Year;

                Match yMatch = Regex.Match(lower,
                    monthName + @"\s+(\d{4})");

                if (yMatch.Success)
                    year = int.Parse(yMatch.Groups[1].Value);

                try
                {
                    c.DateFrom = new DateTime(year, month, 1);
                    c.DateTo   = new DateTime(year, month,
                                              DateTime.DaysInMonth(year, month));
                }
                catch { }

                return;
            }

            // "in [year]"
            Match yearOnly = Regex.Match(lower, @"\bin\s+(\d{4})\b");

            if (yearOnly.Success)
            {
                int year = int.Parse(yearOnly.Groups[1].Value);

                try
                {
                    c.DateFrom = new DateTime(year, 1, 1);
                    c.DateTo   = new DateTime(year, 12, 31);
                }
                catch { }
            }
        }

        private static void ExtractValidationFlags(string query, SearchCriteria c)
        {
            string lower = query.ToLower();

            // RFID failure
            if (lower.Contains("failed rfid") || lower.Contains("rfid fail") ||
                lower.Contains("rfid error") || lower.Contains("rfid check fail") ||
                Regex.IsMatch(lower, @"fail(ed)?\s+rfid") ||
                Regex.IsMatch(lower, @"rfid\b.{0,15}fail") ||
                Regex.IsMatch(lower, @"no\s+rfid"))
            {
                c.RequireFailedRFID = true;
            }

            // UV mismatch
            if (lower.Contains("uv mismatch") || lower.Contains("uv fail") ||
                lower.Contains("uv error") || Regex.IsMatch(lower, @"uv\b.{0,10}fail"))
            {
                c.RequireUVFailed = true;
            }

            // IR mismatch
            if (lower.Contains("ir mismatch") || lower.Contains("ir fail") ||
                lower.Contains("ir error") || Regex.IsMatch(lower, @"ir\b.{0,10}fail"))
            {
                c.RequireIRFailed = true;
            }

            // Flagged
            if (lower.Contains("flagged"))
            {
                c.RequireFlagged = true;
            }

            // Post-dated visa
            if (lower.Contains("post-dated") || lower.Contains("post dated") ||
                lower.Contains("future visa") || lower.Contains("not yet valid") ||
                Regex.IsMatch(lower, @"visa.{0,20}future"))
            {
                c.RequirePostDated = true;
            }

            // Overall failed / invalid
            if (Regex.IsMatch(lower, @"\b(fail(ed)?|invalid)\b") &&
                !lower.Contains("rfid") && !lower.Contains("uv") &&
                !lower.Contains("ir "))
            {
                c.RequireFailed = true;
            }

            // Explicitly passed / valid
            if (Regex.IsMatch(lower, @"\b(pass(ed)?|valid)\b") &&
                !lower.Contains("invalid") && !lower.Contains("not valid") &&
                !lower.Contains("post"))
            {
                c.RequireFailed = false;
            }

            // Expired
            if (Regex.IsMatch(lower, @"\bexpired\b"))
            {
                c.RequireExpired = true;
            }
        }

        private static void ExtractNameOrNumber(string query, SearchCriteria c)
        {
            // Explicit name patterns: "named X", "surname X", "with name X"
            Match namedMatch = Regex.Match(query,
                @"(?:named?|surname|with name|called|for)\s+([A-Za-z][A-Za-z\s\-']{1,30})",
                RegexOptions.IgnoreCase);

            if (namedMatch.Success)
            {
                c.NameContains = namedMatch.Groups[1].Value.Trim();
                return;
            }

            // Passport / document number: 6–12 uppercase alphanumeric characters
            Match numMatch = Regex.Match(query, @"\b([A-Z]{1,3}\d{5,9}|\d[A-Z0-9]{6,10})\b");

            if (numMatch.Success)
            {
                c.PassportNumber = numMatch.Groups[1].Value.Trim();
            }
        }

        private static void ExtractFlightRoute(string query, SearchCriteria c)
        {
            // "from X" or "departing X"
            Match fromMatch = Regex.Match(query,
                @"(?:from|departing)\s+([A-Za-z][A-Za-z\s]{2,20}?)(?:\s+to|\s+and|\s*$|,)",
                RegexOptions.IgnoreCase);

            if (fromMatch.Success)
                c.FlightFrom = fromMatch.Groups[1].Value.Trim();

            // "to X" or "arriving X" or "bound for X"
            Match toMatch = Regex.Match(query,
                @"(?:\bto\b|arriving|bound for)\s+([A-Za-z][A-Za-z\s]{2,20}?)(?:\s+from|\s+and|\s*$|,)",
                RegexOptions.IgnoreCase);

            if (toMatch.Success)
                c.FlightTo = toMatch.Groups[1].Value.Trim();
        }

        // ------------------------------------------------------------------ //
        //  Private – date parsing helper                                       //
        // ------------------------------------------------------------------ //

        // Tries to parse a "dd MMM yyyy HH:mm:ss" date as stored in
        // "Date-Time Recorded" travlr fields.
        private static bool TryParseRecordedDate(string dateStr, out DateTime result)
        {
            result = DateTime.MinValue;

            if (string.IsNullOrEmpty(dateStr))
                return false;

            string[] formats =
            {
                "dd MMM yyyy HH:mm:ss",
                "dd MMM yyyy",
                "d MMM yyyy HH:mm:ss",
                "d MMM yyyy",
                "dd/MM/yyyy HH:mm:ss",
                "dd/MM/yyyy",
                "MM/dd/yyyy",
                "yyyy-MM-dd",
            };

            return DateTime.TryParseExact(
                dateStr.Trim(),
                formats,
                System.Globalization.CultureInfo.InvariantCulture,
                System.Globalization.DateTimeStyles.None,
                out result);
        }
    }
}
