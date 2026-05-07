using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;

namespace TravelPass
{
    // Structured representation of a parsed natural language search query.
    public class SearchCriteria
    {
        public string Nationality       { get; set; }  // ISO 3166-1 alpha-3, e.g. "NGA"
        public string DocumentType      { get; set; }  // "PASSPORT", "VISA", or null for any
        public DateTime? DateFrom       { get; set; }
        public DateTime? DateTo         { get; set; }
        public string NameContains      { get; set; }
        public string PassportNumber    { get; set; }
        public bool? RequireFailedRFID  { get; set; }
        public bool? RequireFlagged     { get; set; }
        public bool? RequirePostDated   { get; set; }
        public bool? RequireFailed      { get; set; }  // overall validation result
        public bool? RequireExpired     { get; set; }
        public bool? RequireUVFailed    { get; set; }
        public bool? RequireIRFailed    { get; set; }
        public string FlightTo          { get; set; }
        public string FlightFrom        { get; set; }
        public string RawQuery          { get; set; }  // original user text
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
        //  Ollama configuration                                                //
        // ------------------------------------------------------------------ //
        private const string OllamaUrl   = "http://localhost:11434/api/generate";
        private const string OllamaModel = "llama3.2";
        private const int    TimeoutMs   = 30000; // 30 seconds

        // Keywords that trigger natural-language routing.
        private static readonly string[] NLKeywords =
        {
            "last week", "last month", "last year", "last day", "last days",
            "this week", "this month", "this year",
            "yesterday", "today",
            "failed", "invalid", "flagged", "rfid", "uv mismatch",
            "ir mismatch", "uv fail", "ir fail", "post-dated", "post dated",
            "expired", "all ", "show ", "find ", " with ", " having ",
            " and ", "passports", "visas", "scanned", "nigerian", "british",
            "french", "german", "american", "canadian", "chinese", "indian",
            "ghanaian", "kenyan", "south african"
        };

        // ------------------------------------------------------------------ //
        //  Public API                                                          //
        // ------------------------------------------------------------------ //

        /// <summary>
        /// Returns true when query looks like natural language rather than a
        /// simple column value (passport number, name fragment, etc.).
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

            // Queries with more than two words are treated as natural language.
            return lower.Trim().Split(' ').Length > 2;
        }

        /// <summary>
        /// Sends an image to Ollama llava, extracts document info, and returns
        /// a SearchCriteria that can be used to search the index.
        /// Requires the llava model: ollama pull llava
        /// </summary>
        public static SearchCriteria ParseImageQuery(string imagePath)
        {
            SearchCriteria c = new SearchCriteria { RawQuery = "[image: " + Path.GetFileName(imagePath) + "]" };

            byte[] imageBytes = File.ReadAllBytes(imagePath);
            string base64Image = Convert.ToBase64String(imageBytes);

            string prompt =
                "This image shows a passport, visa, or travel document. " +
                "Extract all readable information and return ONLY a JSON object with these exact fields " +
                "(use null for any field not visible or readable):\n" +
                "  nationality      - ISO 3166-1 alpha-3 code (e.g. \"NGA\", \"GBR\") or null\n" +
                "  documentType     - \"PASSPORT\", \"VISA\", or null\n" +
                "  nameContains     - surname and given names as a single string or null\n" +
                "  passportNumber   - document number or null\n" +
                "Return only the JSON object, nothing else.";

            string ollamaJson = CallOllamaWithImage(prompt, base64Image);
            return ParseOllamaResponse(ollamaJson, c.RawQuery);
        }

        /// <summary>
        /// Sends query to Ollama and returns a populated SearchCriteria.
        /// Throws if Ollama is unreachable so the caller can show a message.
        /// </summary>
        public static SearchCriteria ParseQuery(string query)
        {
            SearchCriteria c = new SearchCriteria { RawQuery = query };

            if (string.IsNullOrEmpty(query))
                return c;

            string prompt      = BuildPrompt(query);
            string ollamaJson  = CallOllama(prompt);       // throws on network error
            return ParseOllamaResponse(ollamaJson, query);
        }

        /// <summary>
        /// Searches all flight record folders under flightsRoot and returns
        /// records that satisfy criteria.
        /// </summary>
        public static List<AISearchResult> Search(SearchCriteria criteria, string flightsRoot)
        {
            List<AISearchResult> results = new List<AISearchResult>();

            if (!Directory.Exists(flightsRoot))
                return results;

            try
            {
                foreach (string flightFolder in Directory.GetDirectories(flightsRoot))
                {
                    string recordsDir = Path.Combine(flightFolder, "Records");

                    if (!Directory.Exists(recordsDir))
                        continue;

                    foreach (string recordDir in Directory.GetDirectories(recordsDir))
                    {
                        try
                        {
                            AISearchResult record = ReadRecord(recordDir);

                            if (record != null && MatchesCriteria(record, criteria))
                                results.Add(record);
                        }
                        catch { }
                    }
                }
            }
            catch { }

            return results;
        }

        /// <summary>
        /// Converts results into a DataTable for the DataGridView.
        /// First nine columns match the standard VRecord layout.
        /// </summary>
        public static DataTable ToDataTable(List<AISearchResult> results)
        {
            DataTable dt = new DataTable();

            dt.Columns.Add("RECORD_FOLDER_PATH", typeof(string));
            dt.Columns.Add("RECORDED_BY_NAME",   typeof(string));
            dt.Columns.Add("RECORDED_BY_EMAIL",  typeof(string));
            dt.Columns.Add("PASSPORT_NUMBER",    typeof(string));
            dt.Columns.Add("PASSPORT_NAME",      typeof(string));
            dt.Columns.Add("DATE_TIME_RECORDED", typeof(string));
            dt.Columns.Add("FLIGHT_FROM",        typeof(string));
            dt.Columns.Add("FLIGHT_TO",          typeof(string));
            dt.Columns.Add("FINAL_DESTINATION",  typeof(string));
            dt.Columns.Add("NATIONALITY",        typeof(string));
            dt.Columns.Add("DOC_TYPE",           typeof(string));
            dt.Columns.Add("VALIDATION",         typeof(string));
            dt.Columns.Add("RFID_STATUS",        typeof(string));
            dt.Columns.Add("POST_DATED",         typeof(string));
            dt.Columns.Add("FLAGGED",            typeof(string));

            foreach (AISearchResult r in results)
            {
                dt.Rows.Add(
                    r.RecordFolderPath ?? "",
                    r.RecordedByName   ?? "",
                    r.RecordedByEmail  ?? "",
                    r.PassportNumber   ?? "",
                    r.PassportName     ?? "",
                    r.DateTimeRecorded ?? "",
                    r.FlightFrom       ?? "",
                    r.FlightTo         ?? "",
                    r.FinalDestination ?? "",
                    r.Nationality      ?? "",
                    r.DocumentType     ?? "",
                    r.ValidationPassed ?? "",
                    r.RFIDStatus       ?? "",
                    r.IsPostDated      ?? "",
                    r.IsFlagged        ?? ""
                );
            }

            return dt;
        }

        // ------------------------------------------------------------------ //
        //  Ollama – prompt building and HTTP call                              //
        // ------------------------------------------------------------------ //

        private static string BuildPrompt(string query)
        {
            return
                "You are a search assistant for an airport passport control system. " +
                "Today's date is " + DateTime.Today.ToString("yyyy-MM-dd") + ". " +
                "Extract search criteria from the user query below and return ONLY a JSON object " +
                "with these exact fields (use null for any field not mentioned):\n" +
                "  nationality      - ISO 3166-1 alpha-3 code (e.g. \"NGA\" for Nigerian, \"GBR\" for British) or null\n" +
                "  documentType     - \"PASSPORT\", \"VISA\", or null\n" +
                "  dateFrom         - \"yyyy-MM-dd\" or null\n" +
                "  dateTo           - \"yyyy-MM-dd\" or null\n" +
                "  requireFailed    - true (failed/invalid), false (passed/valid), or null\n" +
                "  requireFlagged   - true if looking for flagged persons, else null\n" +
                "  requirePostDated - true if looking for post-dated visas, else null\n" +
                "  requireFailedRFID- true if looking for RFID failures, else null\n" +
                "  nameContains     - person name string or null\n" +
                "  passportNumber   - specific document number or null\n" +
                "  flightFrom       - departure city or airport or null\n" +
                "  flightTo         - destination city or airport or null\n\n" +
                "User query: \"" + EscapeJsonString(query) + "\"\n\n" +
                "Return only the JSON object, nothing else.";
        }

        private static string CallOllama(string prompt)
        {
            string requestBody =
                "{\"model\":\"" + OllamaModel + "\"," +
                "\"prompt\":\"" + EscapeJsonString(prompt) + "\"," +
                "\"stream\":false," +
                "\"format\":\"json\"}";

            return PostToOllama(requestBody, TimeoutMs);
        }

        // Image variant — uses llava model and embeds a base64 image.
        private static string CallOllamaWithImage(string prompt, string base64Image)
        {
            string requestBody =
                "{\"model\":\"llava\"," +
                "\"prompt\":\"" + EscapeJsonString(prompt) + "\"," +
                "\"images\":[\"" + base64Image + "\"]," +
                "\"stream\":false," +
                "\"format\":\"json\"}";

            return PostToOllama(requestBody, 60000); // images take longer
        }

        private static string PostToOllama(string requestBody, int timeoutMs)
        {
            byte[] data = Encoding.UTF8.GetBytes(requestBody);

            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(OllamaUrl);
            request.Method        = "POST";
            request.ContentType   = "application/json";
            request.ContentLength = data.Length;
            request.Timeout       = timeoutMs;

            using (Stream s = request.GetRequestStream())
                s.Write(data, 0, data.Length);

            using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
            using (StreamReader reader = new StreamReader(response.GetResponseStream(), Encoding.UTF8))
                return reader.ReadToEnd();
        }

        // ------------------------------------------------------------------ //
        //  Ollama response parsing                                             //
        // ------------------------------------------------------------------ //

        private static SearchCriteria ParseOllamaResponse(string ollamaJson, string originalQuery)
        {
            SearchCriteria c = new SearchCriteria { RawQuery = originalQuery };

            // Ollama wraps the model output in a "response" field.
            string inner = ExtractResponseField(ollamaJson);

            if (string.IsNullOrEmpty(inner))
                return c;

            // The model may include surrounding text; find the JSON object.
            inner = ExtractJsonBlock(inner);

            c.Nationality       = NullIfEmpty(ExtractJsonString(inner, "nationality"));
            c.DocumentType      = NullIfEmpty(ExtractJsonString(inner, "documentType"));
            c.NameContains      = NullIfEmpty(ExtractJsonString(inner, "nameContains"));
            c.PassportNumber    = NullIfEmpty(ExtractJsonString(inner, "passportNumber"));
            c.FlightFrom        = NullIfEmpty(ExtractJsonString(inner, "flightFrom"));
            c.FlightTo          = NullIfEmpty(ExtractJsonString(inner, "flightTo"));
            c.DateFrom          = ExtractJsonDate(inner, "dateFrom");
            c.DateTo            = ExtractJsonDate(inner, "dateTo");
            c.RequireFailed     = ExtractJsonBool(inner, "requireFailed");
            c.RequireFlagged    = ExtractJsonBool(inner, "requireFlagged");
            c.RequirePostDated  = ExtractJsonBool(inner, "requirePostDated");
            c.RequireFailedRFID = ExtractJsonBool(inner, "requireFailedRFID");

            return c;
        }

        // Extracts the value of the "response" key from Ollama's wrapper JSON.
        private static string ExtractResponseField(string json)
        {
            // The response field may span multiple lines; use a simple scan.
            int idx = json.IndexOf("\"response\"");
            if (idx < 0) return json; // already unwrapped

            int colon = json.IndexOf(':', idx);
            if (colon < 0) return json;

            // Skip whitespace after colon.
            int valueStart = colon + 1;
            while (valueStart < json.Length && json[valueStart] == ' ')
                valueStart++;

            if (valueStart >= json.Length) return "";

            if (json[valueStart] == '"')
            {
                // Quoted string value – extract and unescape.
                StringBuilder sb = new StringBuilder();
                int i = valueStart + 1;
                while (i < json.Length && json[i] != '"')
                {
                    if (json[i] == '\\' && i + 1 < json.Length)
                    {
                        char next = json[i + 1];
                        switch (next)
                        {
                            case '"':  sb.Append('"');  i += 2; break;
                            case '\\': sb.Append('\\'); i += 2; break;
                            case 'n':  sb.Append('\n'); i += 2; break;
                            case 'r':  sb.Append('\r'); i += 2; break;
                            case 't':  sb.Append('\t'); i += 2; break;
                            default:   sb.Append(next); i += 2; break;
                        }
                    }
                    else
                    {
                        sb.Append(json[i++]);
                    }
                }
                return sb.ToString();
            }
            else if (json[valueStart] == '{')
            {
                // Inline JSON object – find matching closing brace.
                return ExtractJsonBlock(json.Substring(valueStart));
            }

            return json;
        }

        // Returns the first complete {...} block found in text.
        private static string ExtractJsonBlock(string text)
        {
            int start = text.IndexOf('{');
            if (start < 0) return text;

            int depth = 0;
            for (int i = start; i < text.Length; i++)
            {
                if (text[i] == '{') depth++;
                else if (text[i] == '}') { depth--; if (depth == 0) return text.Substring(start, i - start + 1); }
            }

            return text.Substring(start);
        }

        // Extracts a string value for the given key from a flat JSON object.
        private static string ExtractJsonString(string json, string key)
        {
            Match m = Regex.Match(json,
                "\"" + Regex.Escape(key) + "\"\\s*:\\s*(?:\"((?:[^\"\\\\]|\\\\.)*)\"|null)",
                RegexOptions.IgnoreCase);

            if (!m.Success) return null;
            if (!m.Groups[1].Success) return null; // was null

            // Unescape simple sequences.
            return m.Groups[1].Value
                .Replace("\\\"", "\"")
                .Replace("\\\\", "\\")
                .Replace("\\n",  "\n")
                .Trim();
        }

        // Extracts a bool? value for the given key from a flat JSON object.
        private static bool? ExtractJsonBool(string json, string key)
        {
            Match m = Regex.Match(json,
                "\"" + Regex.Escape(key) + "\"\\s*:\\s*(true|false|null)",
                RegexOptions.IgnoreCase);

            if (!m.Success) return null;

            switch (m.Groups[1].Value.ToLower())
            {
                case "true":  return true;
                case "false": return false;
                default:      return null;
            }
        }

        // Extracts a DateTime? value for the given key (expects "yyyy-MM-dd").
        private static DateTime? ExtractJsonDate(string json, string key)
        {
            string s = ExtractJsonString(json, key);
            if (string.IsNullOrEmpty(s)) return null;

            DateTime d;
            if (DateTime.TryParseExact(s.Trim(), "yyyy-MM-dd",
                System.Globalization.CultureInfo.InvariantCulture,
                System.Globalization.DateTimeStyles.None, out d))
                return d;

            return null;
        }

        // Escapes a string for embedding inside a JSON string value.
        private static string EscapeJsonString(string s)
        {
            if (s == null) return "";
            return s
                .Replace("\\", "\\\\")
                .Replace("\"", "\\\"")
                .Replace("\n", "\\n")
                .Replace("\r", "\\r")
                .Replace("\t", "\\t");
        }

        private static string NullIfEmpty(string s)
        {
            return string.IsNullOrWhiteSpace(s) ? null : s;
        }

        // ------------------------------------------------------------------ //
        //  File reading                                                        //
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
                    string key, val;
                    SplitTravlrLine(line, out key, out val);

                    switch (key)
                    {
                        case "Recorded by_Name":        result.RecordedByName   = val; break;
                        case "Recorded by_Email":       result.RecordedByEmail  = val; break;
                        case "Scanned Passport Number": result.PassportNumber   = val; break;
                        case "Scanned Passport Name":   result.PassportName     = val; break;
                        case "Date-Time Recorded":      result.DateTimeRecorded = val; break;
                        case "Flight From":             result.FlightFrom       = val; break;
                        case "Flight To":               result.FlightTo         = val; break;
                        case "Final Destination":       result.FinalDestination = val; break;
                    }
                }
            }

            string scansDir = Path.Combine(recordDir, "Scans");

            if (Directory.Exists(scansDir))
            {
                foreach (string scanFolder in Directory.GetDirectories(scansDir))
                {
                    string folderName = Path.GetFileName(scanFolder).ToUpper();

                    if (folderName.StartsWith("PASSPORT_"))
                        result.DocumentType = "PASSPORT";
                    else if (folderName.StartsWith("VISA_"))
                        result.DocumentType = "VISA";
                    else
                        result.DocumentType = "OTHER";

                    string mrzPath = Path.Combine(scanFolder, "MRZ Scan",
                                                  "MRZ Codeline Details.travlr");

                    if (File.Exists(mrzPath))
                    {
                        foreach (string line in File.ReadAllLines(mrzPath))
                        {
                            string key, val;
                            SplitTravlrLine(line, out key, out val);

                            switch (key)
                            {
                                case "Nationality":    result.Nationality = val; break;
                                case "Date of expiry": result.DocExpiry   = val; break;
                            }
                        }
                    }

                    string validationPath = Path.Combine(scanFolder,
                                                         "Passport Validation Details.travlr");

                    if (!File.Exists(validationPath))
                        validationPath = Path.Combine(scanFolder,
                                                      "Visa Validation Details.travlr");

                    if (File.Exists(validationPath))
                    {
                        foreach (string line in File.ReadAllLines(validationPath))
                        {
                            string key, val;
                            SplitTravlrLine(line, out key, out val);

                            switch (key)
                            {
                                case "Passed":            result.ValidationPassed = val; break;
                                case "RFID availability": result.RFIDStatus       = val; break;
                                case "isPostDated":       result.IsPostDated      = val; break;
                                case "isFlagged":         result.IsFlagged        = val; break;
                                case "Visa Start Date":   result.VisaStartDate    = val; break;
                            }
                        }
                    }

                    break; // use first scan folder only
                }
            }

            return result;
        }

        // Splits "Key = Value" on the first '=' only (handles paths with '=').
        private static void SplitTravlrLine(string line, out string key, out string val)
        {
            int idx = line.IndexOf('=');

            if (idx < 0) { key = line.Trim(); val = ""; return; }

            key = line.Substring(0, idx).Trim();
            val = line.Substring(idx + 1).Trim().Trim('"');
        }

        // ------------------------------------------------------------------ //
        //  Criteria matching                                                   //
        // ------------------------------------------------------------------ //

        private static bool MatchesCriteria(AISearchResult r, SearchCriteria c)
        {
            if (!string.IsNullOrEmpty(c.Nationality))
            {
                if (string.IsNullOrEmpty(r.Nationality)) return false;
                if (!r.Nationality.Trim().ToUpper().Contains(c.Nationality.ToUpper())) return false;
            }

            if (!string.IsNullOrEmpty(c.DocumentType))
            {
                if (string.IsNullOrEmpty(r.DocumentType)) return false;
                if (!r.DocumentType.Trim().ToUpper().Equals(c.DocumentType.ToUpper())) return false;
            }

            if (c.DateFrom.HasValue || c.DateTo.HasValue)
            {
                DateTime recorded;
                if (!TryParseRecordedDate(r.DateTimeRecorded, out recorded)) return false;
                if (c.DateFrom.HasValue && recorded.Date < c.DateFrom.Value.Date) return false;
                if (c.DateTo.HasValue   && recorded.Date > c.DateTo.Value.Date)   return false;
            }

            if (!string.IsNullOrEmpty(c.NameContains))
            {
                bool nameMatch =
                    (!string.IsNullOrEmpty(r.PassportName) &&
                     r.PassportName.IndexOf(c.NameContains, StringComparison.OrdinalIgnoreCase) >= 0) ||
                    (!string.IsNullOrEmpty(r.RecordedByName) &&
                     r.RecordedByName.IndexOf(c.NameContains, StringComparison.OrdinalIgnoreCase) >= 0);
                if (!nameMatch) return false;
            }

            if (!string.IsNullOrEmpty(c.PassportNumber))
            {
                if (string.IsNullOrEmpty(r.PassportNumber)) return false;
                if (r.PassportNumber.IndexOf(c.PassportNumber, StringComparison.OrdinalIgnoreCase) < 0)
                    return false;
            }

            if (c.RequireFailedRFID.HasValue && c.RequireFailedRFID.Value)
            {
                if (string.IsNullOrEmpty(r.RFIDStatus) ||
                    !r.RFIDStatus.Trim().ToUpper().Contains("ERROR"))
                    return false;
            }

            if (c.RequireFlagged.HasValue && c.RequireFlagged.Value)
            {
                if (string.IsNullOrEmpty(r.IsFlagged) ||
                    (!r.IsFlagged.Trim().ToUpper().Contains("TRUE") &&
                     !r.IsFlagged.Trim().ToUpper().Contains("YES")))
                    return false;
            }

            if (c.RequirePostDated.HasValue && c.RequirePostDated.Value)
            {
                if (string.IsNullOrEmpty(r.IsPostDated) ||
                    (!r.IsPostDated.Trim().ToUpper().Contains("TRUE") &&
                     !r.IsPostDated.Trim().ToUpper().Contains("YES")))
                    return false;
            }

            if (c.RequireFailed.HasValue)
            {
                bool passed =
                    !string.IsNullOrEmpty(r.ValidationPassed) &&
                    r.ValidationPassed.Trim().ToUpper().Contains("TRUE");

                if (c.RequireFailed.Value  && passed)  return false;
                if (!c.RequireFailed.Value && !passed) return false;
            }

            if (!string.IsNullOrEmpty(c.FlightFrom))
            {
                if (string.IsNullOrEmpty(r.FlightFrom)) return false;
                if (r.FlightFrom.IndexOf(c.FlightFrom, StringComparison.OrdinalIgnoreCase) < 0)
                    return false;
            }

            if (!string.IsNullOrEmpty(c.FlightTo))
            {
                if (string.IsNullOrEmpty(r.FlightTo)) return false;
                if (r.FlightTo.IndexOf(c.FlightTo, StringComparison.OrdinalIgnoreCase) < 0)
                    return false;
            }

            return true;
        }

        // ------------------------------------------------------------------ //
        //  Date parsing                                                        //
        // ------------------------------------------------------------------ //

        private static bool TryParseRecordedDate(string dateStr, out DateTime result)
        {
            result = DateTime.MinValue;

            if (string.IsNullOrEmpty(dateStr)) return false;

            string[] formats =
            {
                "dd MMM yyyy HH:mm:ss", "dd MMM yyyy",
                "d MMM yyyy HH:mm:ss",  "d MMM yyyy",
                "dd/MM/yyyy HH:mm:ss",  "dd/MM/yyyy",
                "MM/dd/yyyy", "yyyy-MM-dd",
            };

            return DateTime.TryParseExact(
                dateStr.Trim(), formats,
                System.Globalization.CultureInfo.InvariantCulture,
                System.Globalization.DateTimeStyles.None,
                out result);
        }
    }
}
