using System;
using System.Globalization;
using System.Text.RegularExpressions;

namespace TravelPass
{
    /// <summary>
    /// Detects post-dated visas by extracting the validity start date from
    /// MRZ optional data and the raw codeline.
    ///
    /// ICAO Machine Readable Visa (MRV-A / MRV-B) formats often encode the
    /// visa validity start date as YYMMDD in the optional data field of Line 2.
    /// Some issuers prefix the six digits with a type indicator ('D', 'V', etc.).
    /// </summary>
    public static class PostDatedVisaDetector
    {
        // ICAO document type prefixes that indicate a visa document.
        private static readonly string[] VisaDocTypePrefixes = { "V", "MRV", "VIS" };

        /// <summary>
        /// Returns true when the supplied document-type string represents a visa.
        /// </summary>
        public static bool IsVisaDocType(string docType)
        {
            if (string.IsNullOrEmpty(docType))
                return false;

            string upper = docType.Trim().ToUpper();
            foreach (string prefix in VisaDocTypePrefixes)
            {
                if (upper.StartsWith(prefix))
                    return true;
            }
            return false;
        }

        /// <summary>
        /// Attempts to extract a validity start date from the MRZ optional data
        /// field.  Returns true and sets <paramref name="startDate"/> when a
        /// plausible date is found; otherwise returns false.
        /// </summary>
        public static bool TryExtractStartDate(string optionalData, out DateTime startDate)
        {
            startDate = DateTime.MinValue;

            if (string.IsNullOrEmpty(optionalData))
                return false;

            // Strip MRZ filler characters and whitespace.
            string cleaned = optionalData.Replace("<", "").Trim();

            if (cleaned.Length < 6)
                return false;

            // Attempt 1: YYMMDD from the very start of the optional data.
            if (TryParseYYMMDD(cleaned.Substring(0, 6), out startDate))
                return true;

            // Attempt 2: Some issuers prefix the date with a single letter indicator.
            if (cleaned.Length >= 7 && char.IsLetter(cleaned[0]))
            {
                if (TryParseYYMMDD(cleaned.Substring(1, 6), out startDate))
                    return true;
            }

            // Attempt 3: Scan the optional data for an embedded 6-digit sequence
            // that produces a plausible near-future date (post-dated scenario).
            MatchCollection matches = Regex.Matches(cleaned, @"\d{6}");
            foreach (Match m in matches)
            {
                DateTime candidate;
                if (TryParseYYMMDD(m.Value, out candidate))
                {
                    // Only accept dates within a sensible window: up to 5 years ahead.
                    if (candidate > DateTime.Today && candidate <= DateTime.Today.AddYears(5))
                    {
                        startDate = candidate;
                        return true;
                    }
                    // Also accept recent past dates as legitimate start-date fields.
                    if (candidate >= DateTime.Today.AddYears(-3) && candidate <= DateTime.Today)
                    {
                        startDate = candidate;
                        return true;
                    }
                }
            }

            return false;
        }

        /// <summary>
        /// Returns true when <paramref name="startDate"/> lies after today,
        /// meaning the visa is not yet valid.
        /// </summary>
        public static bool IsPostDated(DateTime startDate)
        {
            return startDate.Date > DateTime.Today;
        }

        /// <summary>
        /// Returns a human-readable status string for display in the UI.
        /// </summary>
        public static string GetStatusText(DateTime startDate)
        {
            if (startDate == DateTime.MinValue)
                return "";

            if (IsPostDated(startDate))
            {
                int daysRemaining = (startDate.Date - DateTime.Today).Days;
                if (daysRemaining == 1)
                    return "POST-DATED VISA – Valid from tomorrow (" +
                           startDate.ToString("dd MMM yyyy") + ")";
                return "POST-DATED VISA – Valid from " +
                       startDate.ToString("dd MMM yyyy") +
                       " (" + daysRemaining + " days)";
            }

            return "Visa Start Date: " + startDate.ToString("dd MMM yyyy");
        }

        // Parses a 6-character YYMMDD string into a DateTime using the current
        // culture's two-digit year expansion rules.
        private static bool TryParseYYMMDD(string s, out DateTime result)
        {
            result = DateTime.MinValue;

            if (s == null || s.Length < 6)
                return false;

            // Every character must be a decimal digit.
            foreach (char c in s)
            {
                if (!char.IsDigit(c))
                    return false;
            }

            int yy = int.Parse(s.Substring(0, 2));
            int mm = int.Parse(s.Substring(2, 2));
            int dd = int.Parse(s.Substring(4, 2));

            if (mm < 1 || mm > 12)
                return false;
            if (dd < 1 || dd > 31)
                return false;

            int year = CultureInfo.CurrentCulture.Calendar.ToFourDigitYear(yy);

            try
            {
                result = new DateTime(year, mm, dd);

                // Plausibility: start dates should be within ±10 years of today.
                if (result.Year < DateTime.Today.Year - 10 ||
                    result.Year > DateTime.Today.Year + 10)
                {
                    result = DateTime.MinValue;
                    return false;
                }

                return true;
            }
            catch
            {
                result = DateTime.MinValue;
                return false;
            }
        }
    }
}
