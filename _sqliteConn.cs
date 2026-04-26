using ADODB;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using TravelPass.Properties;
using Microsoft.Office.Interop.Excel;

namespace TravelPass
{
    class _SQLite
    {
        static String databaseFilePath = System.Windows.Forms.Application.StartupPath + "\\data.db";
        public static String external_upload_folder = System.Windows.Forms.Application.StartupPath + "\\Externally Managed Folder";
        public static String connStr = "DRIVER=SQLite3 ODBC Driver;Database=" + databaseFilePath + ";Version=3;";

        [DllImport("ODBCCP32.DLL")]
        private static extern int SQLConfigDataSource(int hwndParent, int ByValfRequest, string lpszDriver, string lpszAttributes);

        public static void CreateDSN()
        {

            try
            {
                int intRet;
                String strDriver;
                String Attributes;

                strDriver = "SQLite3 ODBC Driver";
                Attributes = "SERVER=(local)" + ((Char)0).ToString();
                //Attributes = Attributes + "DESCRIPTION=" + ((Char)0).ToString();
                Attributes = Attributes + "DSN=TravelPassSqlite" + ((Char)0).ToString();
                Attributes = Attributes + "DATABASE=" + databaseFilePath + ((Char)0).ToString();
                intRet = SQLConfigDataSource(0, 1, strDriver, Attributes);
            }
            catch { };
        }

        public static void Connect() {

            try
            {

                String root_folder = "c:\\Travelpass";
                String root_folder_for_log = "c:\\Travelpass Files";
                String flight_folder = root_folder + "\\Flights";
                String log_folder = root_folder_for_log + "\\log files";

                if (!Directory.Exists(root_folder)) Directory.CreateDirectory(root_folder);
                if (!Directory.Exists(root_folder)) Directory.CreateDirectory(root_folder_for_log);
                if (!Directory.Exists(flight_folder)) Directory.CreateDirectory(flight_folder);
                if (!Directory.Exists(log_folder)) Directory.CreateDirectory(log_folder);
                if (!Directory.Exists(external_upload_folder)) Directory.CreateDirectory(external_upload_folder);
                
                CreateDSN();
                if (!File.Exists(databaseFilePath))
                {
                    File.WriteAllBytes(databaseFilePath, Resources.data);
                };

                Connection conn = new Connection();
                conn.Open(connStr, null, null, 0);

                #region Creating new user if none exist
                Recordset rs = new Recordset();
                rs.Open("SELECT * FROM tblUsers", connStr, CursorTypeEnum.adOpenKeyset, LockTypeEnum.adLockOptimistic, 0);
                if (rs.RecordCount <= 0)
                {
                    rs.AddNew(new Object[]
                              {
                                "userID",
                                "userName",
                                "firstName",
                                "lastName",
                                "roleID",
                                "password"
                               },
                               new Object[]
                               {
                                 "admin",
                                 "admin",
                                 "System",
                                 "Administrator",
                                 "Admin",
                                 _Encryption.Encrypt("admin")
                               });

                    rs.AddNew(new Object[]
                              {
                                "userID",
                                "userName",
                                "firstName",
                                "lastName",
                                "roleID",
                                "password"
                               },
                               new Object[]
                               {
                                 "user",
                                 "user",
                                 "System",
                                 "User",
                                 "User",
                                 _Encryption.Encrypt("user")
                               });
                };
                rs.Close();
                #endregion Creating new user if none exist

                #region Fetching from the [tblFlaggedDocuments] and setting the value for [_Public.flagged_doc_owners]

                _Public.flagged_doc_owners = new List<_FlaggedDocOwner>();
                _DocOwner doc_owner;
                rs = new Recordset();
                rs.Open("SELECT * FROM tblFlaggedDocuments", connStr, CursorTypeEnum.adOpenKeyset, LockTypeEnum.adLockOptimistic, 0);
                if (rs.RecordCount > 0)
                {
                    rs.MoveFirst();
                    do {

                        doc_owner = new _DocOwner(
                                                    rs.Fields["family_name"].Value.ToString(),
                                                    rs.Fields["given_names"].Value.ToString(),
                                                    rs.Fields["gender"].Value.ToString(),
                                                    rs.Fields["dob"].Value is DBNull || rs.Fields["dob"].Value.ToString().Trim() == "" ? new DateTime(1960, 10, 01) : Convert.ToDateTime(rs.Fields["dob"].Value.ToString()),
                                                    rs.Fields["document_type"].Value.ToString(),
                                                    rs.Fields["document_number"].Value.ToString()
                                                   );

                        _Public.flagged_doc_owners.Add(new _FlaggedDocOwner(doc_owner, Convert.ToInt32(rs.Fields["flag_year"].Value), Convert.ToString(rs.Fields["flag_reason"].Value)));
                        
                        rs.MoveNext();
                    } while (!rs.EOF);
                }
                else {

                    String[,] _arr = new String[,] {
                                                    { "BANDERAS", "LILIAN", "FEMALE", "31/12/1960", "Nigerian Passport", "A012345" },
                                                    { "DEMO", "PERSON", "MALE", "31/12/1960", "Nigerian Passport", "A022345" },
                    };

                    for (int j = 0; j < _arr.GetLength(0); j++)
                    {
                        doc_owner = new _DocOwner(_arr[j, 0], _arr[j, 1], _arr[j, 2], DateTime.ParseExact(_arr[j, 3], "dd/MM/yyyy", System.Globalization.DateTimeFormatInfo.InvariantInfo), _arr[j, 4], _arr[j, 5]);
                        _Public.flagged_doc_owners.Add(new _FlaggedDocOwner(doc_owner, 1960, "NIL"));
                    };

                };
                rs.Close();
                #endregion Fetching from the [tblFlaggedDocuments] and setting the value for [_Public.flagged_doc_owners]

                #region Fetching from the [tblFlightDefinitions] and setting the value for [_Public.predefined_flight_definitions]
                _Public.predefined_flight_definitions = new Dictionary<String, _FlightDefinition>();
                _FlightDefinition predefined_flight_definition;
                rs = new Recordset();
                rs.Open("SELECT * FROM tblFlightDefinitions", connStr, CursorTypeEnum.adOpenKeyset, LockTypeEnum.adLockOptimistic, 0);
                if (rs.RecordCount > 0)
                {
                    rs.MoveFirst();
                    do {

                        predefined_flight_definition = new _FlightDefinition(
                                                                                rs.Fields["flight_id"].Value.ToString(),
                                                                                rs.Fields["airline_name"].Value.ToString(),
                                                                                rs.Fields["flight_airport_departure"].Value.ToString(),
                                                                                rs.Fields["flight_airport_destination"].Value.ToString(),
                                                                                rs.Fields["flight_country_departure"].Value.ToString(),
                                                                                rs.Fields["flight_country_destination"].Value.ToString(),
                                                                                rs.Fields["departure_terminal"].Value.ToString(),
                                                                                rs.Fields["arrival_terminal"].Value.ToString(),
                                                                                rs.Fields["flight_departure_time"].Value.ToString(),
                                                                                rs.Fields["flight_arrival_time"].Value.ToString(),
                                                                                rs.Fields["aircraft_name"].Value.ToString(),
                                                                                Convert.ToDouble(rs.Fields["flight_duration"].Value)
                                                                                );
                        
                        _Public.predefined_flight_definitions.Add(rs.Fields["flight_id"].Value.ToString(), predefined_flight_definition);
                        
                        rs.MoveNext();
                    } while (!rs.EOF);
                }
                else {

                    #region Adding the default definition to the list
                    /*First Item*/
                    predefined_flight_definition = new _FlightDefinition(
                                                                            "VS652",
                                                                            "Virgin Atlantic Airways-VS",
                                                                            "LOS-Murtala Muhammed International Airport",
                                                                            "LHR-London Heathrow Airport",
                                                                            "Nigeria",
                                                                            "United Kingdom",
                                                                            "LOS",
                                                                            "LHR3",
                                                                            "10:05",
                                                                            "16:05",
                                                                            "Airbus A340-600",
                                                                            6);

                    _Public.predefined_flight_definitions.Add(predefined_flight_definition.flight_id, predefined_flight_definition);

                    /*Second Item*/
                    predefined_flight_definition = new _FlightDefinition(
                                                                            "AT554",
                                                                            "Royal Air Maroc-AT",
                                                                            "LOS-Murtala Muhammed International Airport",
                                                                            "CMN-Mohammed V International Airport",
                                                                            "Nigeria",
                                                                            "Morocco",
                                                                            "LOS",
                                                                            "MAR",
                                                                            "06:30",
                                                                            "11:30",
                                                                            "Boeing 737-800",
                                                                            5);

                    _Public.predefined_flight_definitions.Add(predefined_flight_definition.flight_id, predefined_flight_definition);
                    
                    /*Third Item*/
                    predefined_flight_definition = new _FlightDefinition(
                                                                            "VS412",
                                                                            "Virgin Atlantic Airways-VS",
                                                                            "LOS-Murtala Muhammed International Airport",
                                                                            "LHR-London Heathrow Airport",
                                                                            "Nigeria",
                                                                            "United Kingdom",
                                                                            "LOS",
                                                                            "LHR3",
                                                                            "10:05",
                                                                            "16:05",
                                                                            "Airbus A330-300",
                                                                            6);

                    _Public.predefined_flight_definitions.Add(predefined_flight_definition.flight_id, predefined_flight_definition);

                    /*Fourth Item*/
                    predefined_flight_definition = new _FlightDefinition(
                                                                                "VS412(2)",
                                                                                "Virgin Atlantic Airways-VS",
                                                                                "LOS-Murtala Muhammed International Airport",
                                                                                "LHR-London Heathrow Airport",
                                                                                "Nigeria",
                                                                                "United Kingdom",
                                                                                "LOS",
                                                                                "LHR3",
                                                                                "10:05",
                                                                                "16:05",
                                                                                "Airbus A350-1000",
                                                                                6);

                    _Public.predefined_flight_definitions.Add(predefined_flight_definition.flight_id, predefined_flight_definition);

                    #endregion Adding the default definition to the list

                };
                rs.Close();
                #endregion Fetching from the [tblFlightDefinitions] and setting the value for [_Public.predefined_flight_definitions]

            }
            catch (Exception)
            {
            }
        }
    }
}
