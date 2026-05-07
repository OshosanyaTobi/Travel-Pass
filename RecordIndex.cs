using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;

namespace TravelPass
{
    // A single indexed passenger record stored in the search index.
    public class IndexEntry
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
        public string PhotoPath         { get; set; }
    }

    // Manages the local search index: build, save, load, query.
    // Index file: <flightsRoot>\search_index.json
    // Sync URL config: <flightsRoot>\search_sync_url.txt
    public static class RecordIndex
    {
        private const string IndexFileName  = "search_index.json";
        private const string SyncUrlFile    = "search_sync_url.txt";

        public static DateTime LastBuilt   { get; private set; }
        public static int      RecordCount { get; private set; }

        private static List<IndexEntry> _entries;

        // ------------------------------------------------------------------ //
        //  Public API                                                          //
        // ------------------------------------------------------------------ //

        public static string GetIndexPath(string flightsRoot)
        {
            return Path.Combine(flightsRoot, IndexFileName);
        }

        public static List<IndexEntry> GetEntries()
        {
            return _entries;
        }

        // Load index from disk. Returns false if the file does not exist yet.
        public static bool Load(string flightsRoot)
        {
            string path = GetIndexPath(flightsRoot);
            if (!File.Exists(path)) { _entries = null; return false; }

            try
            {
                string json = File.ReadAllText(path, Encoding.UTF8);
                DateTime built;
                _entries    = ParseIndexJson(json, out built);
                LastBuilt   = built;
                RecordCount = _entries.Count;
                return true;
            }
            catch
            {
                _entries = null;
                return false;
            }
        }

        // Crawl flightsRoot and build a fresh index, then save to disk.
        // progress(done, total) is called periodically for UI progress bars.
        public static void Build(string flightsRoot, Action<int, int> progress = null)
        {
            _entries = new List<IndexEntry>();

            if (!Directory.Exists(flightsRoot)) return;

            // Count total record dirs first so we can report progress.
            string[] flightDirs = Directory.GetDirectories(flightsRoot);
            int total = 0;
            foreach (string fd in flightDirs)
            {
                string rd = Path.Combine(fd, "Records");
                if (Directory.Exists(rd))
                    total += Directory.GetDirectories(rd).Length;
            }

            int done = 0;
            foreach (string flightDir in flightDirs)
            {
                string recordsDir = Path.Combine(flightDir, "Records");
                if (!Directory.Exists(recordsDir)) continue;

                foreach (string recordDir in Directory.GetDirectories(recordsDir))
                {
                    try
                    {
                        IndexEntry entry = ReadEntry(recordDir);
                        if (entry != null) _entries.Add(entry);
                    }
                    catch { }

                    done++;
                    if (progress != null && done % 10 == 0)
                        progress(done, total);
                }
            }

            if (progress != null) progress(total, total);

            LastBuilt   = DateTime.Now;
            RecordCount = _entries.Count;
            Save(flightsRoot);
        }

        // Add or update a single record entry without a full rebuild.
        // Called automatically each time AddRecord saves a new scan.
        public static void AddOrUpdateEntry(string recordDir, string flightsRoot)
        {
            if (_entries == null)
            {
                bool loaded = Load(flightsRoot);
                if (!loaded) _entries = new List<IndexEntry>();
            }

            // Remove any existing entry for this folder so we don't duplicate.
            string normalized = recordDir.Trim();
            _entries.RemoveAll(e =>
                string.Equals(e.RecordFolderPath, normalized,
                    StringComparison.OrdinalIgnoreCase));

            IndexEntry entry = ReadEntry(normalized);
            if (entry != null)
            {
                _entries.Add(entry);
                LastBuilt   = DateTime.Now;
                RecordCount = _entries.Count;
                Save(flightsRoot);
            }
        }

        // Save the in-memory index to disk.
        public static void Save(string flightsRoot)
        {
            string path = GetIndexPath(flightsRoot);
            string json = SerializeIndex(_entries, LastBuilt);
            File.WriteAllText(path, json, Encoding.UTF8);
        }

        // Filter loaded entries against search criteria.
        public static List<IndexEntry> Search(SearchCriteria criteria)
        {
            List<IndexEntry> results = new List<IndexEntry>();
            if (_entries == null) return results;

            foreach (IndexEntry e in _entries)
            {
                if (MatchesCriteria(e, criteria))
                    results.Add(e);
            }
            return results;
        }

        // Read the configured sync URL (null if not set).
        public static string GetSyncUrl(string flightsRoot)
        {
            string path = Path.Combine(flightsRoot, SyncUrlFile);
            if (!File.Exists(path)) return null;
            return File.ReadAllText(path, Encoding.UTF8).Trim();
        }

        // Persist a new sync URL.
        public static void SetSyncUrl(string flightsRoot, string url)
        {
            File.WriteAllText(Path.Combine(flightsRoot, SyncUrlFile), url ?? "",
                Encoding.UTF8);
        }

        // ------------------------------------------------------------------ //
        //  Record reading                                                      //
        // ------------------------------------------------------------------ //

        private static IndexEntry ReadEntry(string recordDir)
        {
            IndexEntry e = new IndexEntry { RecordFolderPath = recordDir.Trim() };

            string detailsPath = Path.Combine(recordDir, "Record Details.travlr");
            if (File.Exists(detailsPath))
            {
                foreach (string line in File.ReadAllLines(detailsPath))
                {
                    string key, val;
                    SplitLine(line, out key, out val);
                    switch (key)
                    {
                        case "Recorded by_Name":        e.RecordedByName   = val; break;
                        case "Recorded by_Email":       e.RecordedByEmail  = val; break;
                        case "Scanned Passport Number": e.PassportNumber   = val; break;
                        case "Scanned Passport Name":   e.PassportName     = val; break;
                        case "Date-Time Recorded":      e.DateTimeRecorded = val; break;
                        case "Flight From":             e.FlightFrom       = val; break;
                        case "Flight To":               e.FlightTo         = val; break;
                        case "Final Destination":       e.FinalDestination = val; break;
                    }
                }
            }

            string scansDir = Path.Combine(recordDir, "Scans");
            if (!Directory.Exists(scansDir)) return e;

            foreach (string scanFolder in Directory.GetDirectories(scansDir))
            {
                string fn = Path.GetFileName(scanFolder).ToUpper();
                e.DocumentType = fn.StartsWith("VISA_")     ? "VISA"
                               : fn.StartsWith("PASSPORT_") ? "PASSPORT"
                               : "OTHER";

                string mrzPath = Path.Combine(scanFolder, "MRZ Scan",
                                              "MRZ Codeline Details.travlr");
                if (File.Exists(mrzPath))
                {
                    foreach (string line in File.ReadAllLines(mrzPath))
                    {
                        string key, val;
                        SplitLine(line, out key, out val);
                        switch (key)
                        {
                            case "Nationality":    e.Nationality = val; break;
                            case "Date of expiry": e.DocExpiry   = val; break;
                        }
                    }
                }

                string valPath = Path.Combine(scanFolder, "Passport Validation Details.travlr");
                if (!File.Exists(valPath))
                    valPath = Path.Combine(scanFolder, "Visa Validation Details.travlr");

                if (File.Exists(valPath))
                {
                    foreach (string line in File.ReadAllLines(valPath))
                    {
                        string key, val;
                        SplitLine(line, out key, out val);
                        switch (key)
                        {
                            case "Passed":            e.ValidationPassed = val; break;
                            case "RFID availability": e.RFIDStatus       = val; break;
                            case "isPostDated":       e.IsPostDated      = val; break;
                            case "isFlagged":         e.IsFlagged        = val; break;
                            case "Visa Start Date":   e.VisaStartDate    = val; break;
                        }
                    }
                }

                // Capture the first photo file found (for future image search).
                foreach (string ext in new[] { "*.jpg", "*.jpeg", "*.png", "*.bmp" })
                {
                    string[] photos = Directory.GetFiles(scanFolder, ext,
                        SearchOption.TopDirectoryOnly);
                    if (photos.Length > 0) { e.PhotoPath = photos[0]; break; }
                }

                break; // only process the first scan folder per record
            }

            return e;
        }

        private static void SplitLine(string line, out string key, out string val)
        {
            int idx = line.IndexOf('=');
            if (idx < 0) { key = line.Trim(); val = ""; return; }
            key = line.Substring(0, idx).Trim();
            val = line.Substring(idx + 1).Trim().Trim('"');
        }

        // ------------------------------------------------------------------ //
        //  Criteria matching (mirrors AISearchEngine.MatchesCriteria)          //
        // ------------------------------------------------------------------ //

        private static bool MatchesCriteria(IndexEntry e, SearchCriteria c)
        {
            if (!string.IsNullOrEmpty(c.Nationality))
            {
                if (string.IsNullOrEmpty(e.Nationality)) return false;
                if (e.Nationality.Trim().ToUpper().IndexOf(c.Nationality.ToUpper()) < 0)
                    return false;
            }
            if (!string.IsNullOrEmpty(c.DocumentType))
            {
                if (string.IsNullOrEmpty(e.DocumentType)) return false;
                if (!e.DocumentType.Trim().ToUpper().Equals(c.DocumentType.ToUpper()))
                    return false;
            }
            if (c.DateFrom.HasValue || c.DateTo.HasValue)
            {
                DateTime recorded;
                if (!TryParseDate(e.DateTimeRecorded, out recorded)) return false;
                if (c.DateFrom.HasValue && recorded.Date < c.DateFrom.Value.Date) return false;
                if (c.DateTo.HasValue   && recorded.Date > c.DateTo.Value.Date)   return false;
            }
            if (!string.IsNullOrEmpty(c.NameContains))
            {
                bool match =
                    (!string.IsNullOrEmpty(e.PassportName) &&
                     e.PassportName.IndexOf(c.NameContains,
                         StringComparison.OrdinalIgnoreCase) >= 0) ||
                    (!string.IsNullOrEmpty(e.RecordedByName) &&
                     e.RecordedByName.IndexOf(c.NameContains,
                         StringComparison.OrdinalIgnoreCase) >= 0);
                if (!match) return false;
            }
            if (!string.IsNullOrEmpty(c.PassportNumber))
            {
                if (string.IsNullOrEmpty(e.PassportNumber)) return false;
                if (e.PassportNumber.IndexOf(c.PassportNumber,
                        StringComparison.OrdinalIgnoreCase) < 0) return false;
            }
            if (c.RequireFailedRFID.HasValue && c.RequireFailedRFID.Value)
            {
                if (string.IsNullOrEmpty(e.RFIDStatus) ||
                    !e.RFIDStatus.Trim().ToUpper().Contains("ERROR")) return false;
            }
            if (c.RequireFlagged.HasValue && c.RequireFlagged.Value)
            {
                if (string.IsNullOrEmpty(e.IsFlagged) ||
                    (!e.IsFlagged.Trim().ToUpper().Contains("TRUE") &&
                     !e.IsFlagged.Trim().ToUpper().Contains("YES"))) return false;
            }
            if (c.RequirePostDated.HasValue && c.RequirePostDated.Value)
            {
                if (string.IsNullOrEmpty(e.IsPostDated) ||
                    (!e.IsPostDated.Trim().ToUpper().Contains("TRUE") &&
                     !e.IsPostDated.Trim().ToUpper().Contains("YES"))) return false;
            }
            if (c.RequireFailed.HasValue)
            {
                bool passed = !string.IsNullOrEmpty(e.ValidationPassed) &&
                              e.ValidationPassed.Trim().ToUpper().Contains("TRUE");
                if (c.RequireFailed.Value  && passed)  return false;
                if (!c.RequireFailed.Value && !passed) return false;
            }
            if (!string.IsNullOrEmpty(c.FlightFrom))
            {
                if (string.IsNullOrEmpty(e.FlightFrom)) return false;
                if (e.FlightFrom.IndexOf(c.FlightFrom,
                        StringComparison.OrdinalIgnoreCase) < 0) return false;
            }
            if (!string.IsNullOrEmpty(c.FlightTo))
            {
                if (string.IsNullOrEmpty(e.FlightTo)) return false;
                if (e.FlightTo.IndexOf(c.FlightTo,
                        StringComparison.OrdinalIgnoreCase) < 0) return false;
            }
            return true;
        }

        private static bool TryParseDate(string s, out DateTime result)
        {
            result = DateTime.MinValue;
            if (string.IsNullOrEmpty(s)) return false;
            string[] fmts = {
                "dd MMM yyyy HH:mm:ss", "dd MMM yyyy",
                "d MMM yyyy HH:mm:ss",  "d MMM yyyy",
                "dd/MM/yyyy HH:mm:ss",  "dd/MM/yyyy",
                "MM/dd/yyyy", "yyyy-MM-dd",
            };
            return DateTime.TryParseExact(s.Trim(), fmts,
                System.Globalization.CultureInfo.InvariantCulture,
                System.Globalization.DateTimeStyles.None, out result);
        }

        // ------------------------------------------------------------------ //
        //  Minimal JSON serialization (no external dependencies)               //
        // ------------------------------------------------------------------ //

        private static string SerializeIndex(List<IndexEntry> entries, DateTime built)
        {
            var sb = new StringBuilder();
            sb.Append("{\n\"built\":\"");
            sb.Append(JE(built.ToString("yyyy-MM-ddTHH:mm:ss")));
            sb.Append("\",\n\"records\":[\n");

            for (int i = 0; i < entries.Count; i++)
            {
                IndexEntry e = entries[i];
                sb.Append("{");
                F(sb, "recordFolderPath", e.RecordFolderPath);
                F(sb, "recordedByName",   e.RecordedByName);
                F(sb, "recordedByEmail",  e.RecordedByEmail);
                F(sb, "passportNumber",   e.PassportNumber);
                F(sb, "passportName",     e.PassportName);
                F(sb, "dateTimeRecorded", e.DateTimeRecorded);
                F(sb, "flightFrom",       e.FlightFrom);
                F(sb, "flightTo",         e.FlightTo);
                F(sb, "finalDestination", e.FinalDestination);
                F(sb, "nationality",      e.Nationality);
                F(sb, "documentType",     e.DocumentType);
                F(sb, "validationPassed", e.ValidationPassed);
                F(sb, "rfidStatus",       e.RFIDStatus);
                F(sb, "isPostDated",      e.IsPostDated);
                F(sb, "isFlagged",        e.IsFlagged);
                F(sb, "visaStartDate",    e.VisaStartDate);
                F(sb, "docExpiry",        e.DocExpiry);
                F(sb, "photoPath",        e.PhotoPath, last: true);
                sb.Append("}");
                if (i < entries.Count - 1) sb.Append(",");
                sb.Append("\n");
            }
            sb.Append("]\n}");
            return sb.ToString();
        }

        private static void F(StringBuilder sb, string key, string val, bool last = false)
        {
            sb.Append("\"").Append(key).Append("\":\"")
              .Append(JE(val ?? "")).Append("\"");
            if (!last) sb.Append(",");
        }

        private static string JE(string s)
        {
            if (string.IsNullOrEmpty(s)) return "";
            return s.Replace("\\", "\\\\")
                    .Replace("\"", "\\\"")
                    .Replace("\n", "\\n")
                    .Replace("\r", "\\r")
                    .Replace("\t", "\\t");
        }

        private static List<IndexEntry> ParseIndexJson(string json, out DateTime built)
        {
            built = DateTime.MinValue;

            Match bm = Regex.Match(json, "\"built\"\\s*:\\s*\"([^\"]+)\"");
            if (bm.Success)
                DateTime.TryParseExact(bm.Groups[1].Value, "yyyy-MM-ddTHH:mm:ss",
                    System.Globalization.CultureInfo.InvariantCulture,
                    System.Globalization.DateTimeStyles.None, out built);

            var entries = new List<IndexEntry>();

            int arrStart = json.IndexOf("\"records\"");
            if (arrStart < 0) return entries;
            arrStart = json.IndexOf('[', arrStart);
            if (arrStart < 0) return entries;

            int i = arrStart + 1;
            while (i < json.Length)
            {
                while (i < json.Length && (json[i] == ' ' || json[i] == '\t' ||
                       json[i] == '\n' || json[i] == '\r' || json[i] == ',')) i++;

                if (i >= json.Length || json[i] == ']') break;
                if (json[i] != '{') { i++; continue; }

                int depth = 0, start = i;
                while (i < json.Length)
                {
                    char ch = json[i];
                    if (ch == '{') { depth++; i++; }
                    else if (ch == '}') { depth--; i++; if (depth == 0) break; }
                    else if (ch == '"')
                    {
                        i++;
                        while (i < json.Length && json[i] != '"')
                        {
                            if (json[i] == '\\') i++;
                            i++;
                        }
                        i++;
                    }
                    else i++;
                }

                entries.Add(ParseEntry(json.Substring(start, i - start)));
            }

            return entries;
        }

        private static IndexEntry ParseEntry(string obj)
        {
            return new IndexEntry
            {
                RecordFolderPath = GS(obj, "recordFolderPath"),
                RecordedByName   = GS(obj, "recordedByName"),
                RecordedByEmail  = GS(obj, "recordedByEmail"),
                PassportNumber   = GS(obj, "passportNumber"),
                PassportName     = GS(obj, "passportName"),
                DateTimeRecorded = GS(obj, "dateTimeRecorded"),
                FlightFrom       = GS(obj, "flightFrom"),
                FlightTo         = GS(obj, "flightTo"),
                FinalDestination = GS(obj, "finalDestination"),
                Nationality      = GS(obj, "nationality"),
                DocumentType     = GS(obj, "documentType"),
                ValidationPassed = GS(obj, "validationPassed"),
                RFIDStatus       = GS(obj, "rfidStatus"),
                IsPostDated      = GS(obj, "isPostDated"),
                IsFlagged        = GS(obj, "isFlagged"),
                VisaStartDate    = GS(obj, "visaStartDate"),
                DocExpiry        = GS(obj, "docExpiry"),
                PhotoPath        = GS(obj, "photoPath"),
            };
        }

        private static string GS(string json, string key)
        {
            Match m = Regex.Match(json,
                "\"" + Regex.Escape(key) + "\"\\s*:\\s*\"((?:[^\"\\\\]|\\\\.)*)\"");
            if (!m.Success) return null;
            return m.Groups[1].Value
                .Replace("\\\"", "\"").Replace("\\\\", "\\")
                .Replace("\\n", "\n").Replace("\\r", "\r").Replace("\\t", "\t");
        }
    }
}
