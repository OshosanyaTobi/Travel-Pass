using ADODB;
using Microsoft.Office.Interop.Excel;
using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace TravelPass
{
    public partial class ContinueWithAdminUpload : Form
    {
        bool foundPersonnel = false;
        string pers_id = "";
        string pers_role = "";
        string pers_name = "";
        int insertedID = 0;

        int click_tracker = 0;

        public ContinueWithAdminUpload()
        {
            InitializeComponent();
            //System.IO.Directory.SetCurrentDirectory(Application.StartupPath); //iC<>deiDesign
            _SQLite.Connect();
        }

        private void cancel_Click(object sender, EventArgs e)
        {
            this.Close();
            this.Dispose();
        }

        private void UploadFlaggedPassengers()
        {
            #region For now, this snippet will help me upload from a static excel containing the information I want
            String strExcelFileName = _SQLite.external_upload_folder + "\\travelpass_flagged_docs.xlsx";

            if (!File.Exists(strExcelFileName)) return;

            Microsoft.Office.Interop.Excel.Application xcelApp;
            Workbook xcelWorkBook;
            Worksheet xcelWorksheet;
            Range xcelRange;

            xcelApp = new Microsoft.Office.Interop.Excel.Application();
            xcelWorkBook = xcelApp.Workbooks.Open(strExcelFileName, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing);

            xcelWorksheet = (Worksheet) xcelWorkBook.Worksheets["alert"];
            xcelRange = xcelWorksheet.UsedRange;

            String flg_surname;
            String flg_other_names;
            DateTime flg_dob;
            String flg_passport_type;
            String flg_passport_number;
            int flg_entry_year;
            String flg_reason;

            Recordset rs = new Recordset();
            rs.Open("DELETE FROM tblFlaggedDocuments", _SQLite.connStr, CursorTypeEnum.adOpenKeyset, LockTypeEnum.adLockOptimistic, 0);


            for (int j = 3; j < xcelRange.Rows.Count + 1; j++) {
                flg_surname = Convert.ToString((Object)(xcelWorksheet.Cells[j, 1] as Range).Value2).Trim().Replace("'", "-");
                flg_other_names = Convert.ToString((Object)(xcelWorksheet.Cells[j, 2] as Range).Value2).Trim().Replace("'", "-");
                try {
                    flg_dob = DateTime.ParseExact(Convert.ToString((Object)(xcelWorksheet.Cells[j, 3] as Range).Value2).Trim().Replace("'", "-"), "dd/MM/yyyy", System.Globalization.DateTimeFormatInfo.InvariantInfo);
                } catch (Exception) {
                    flg_dob = new DateTime(1901, 01, 01);
                };
                flg_passport_type = Convert.ToString((Object)(xcelWorksheet.Cells[j, 4] as Range).Value2).Trim().Replace("'", "-");
                flg_passport_number = Convert.ToString((Object)(xcelWorksheet.Cells[j, 5] as Range).Value2).Trim().Replace("'", "-");
                try {
                    flg_entry_year = Convert.ToInt32(Convert.ToString((Object)(xcelWorksheet.Cells[j, 6] as Range).Value2).Trim().Replace("'", "-"));
                } catch {
                    flg_entry_year = 1906;
                };
                flg_reason = Convert.ToString((Object)(xcelWorksheet.Cells[j, 7] as Range).Value2).Trim().Replace("'", "-");

                rs.Open("INSERT INTO tblFlaggedDocuments (" + 
                        "family_name, " +
                        "given_names, " +
                        "gender, " +
                        "dob, " +
                        "document_type, " +
                        "document_number, " + 
                        "flag_year, " + 
                        "flag_reason, " + 
                        "flag_by) VALUES (" + 
                        "'" + flg_surname + "', " +
                        "'" + flg_other_names + "', " +
                        "'MALE', " + //Just for now
                        "'" + flg_dob.ToString("yyyy-MM-dd") + "', " +
                        "'" + flg_passport_type + "', " +
                        "'" + flg_passport_number + "', " +
                        flg_entry_year.ToString() + ", " +
                        "'" + flg_reason + "', " +
                        "'admin')", _SQLite.connStr, CursorTypeEnum.adOpenKeyset, LockTypeEnum.adLockOptimistic, 0);
            };

            xcelApp.Quit();
            #endregion For now, this snippet will help me upload from a static excel containing the information I want

        }

        private void UploadUserAccount()
        {
            Microsoft.Office.Interop.Excel.Application xcelApp;
            Workbook xcelWorkBook;
            Worksheet xcelWorksheet;
            Range xcelRange;

            String strExcelFileName = _SQLite.external_upload_folder + "\\updated_user_accounts.xlsx";

            try {
                xcelApp = new Microsoft.Office.Interop.Excel.Application();
                xcelWorkBook = xcelApp.Workbooks.Open(strExcelFileName, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing);
            } catch (Exception) {
                this.Cursor = Cursors.Default;
                return;
            };

            xcelWorksheet = (Worksheet)xcelWorkBook.Worksheets["Sheet1"];
            xcelRange = xcelWorksheet.UsedRange;

            String user_id = "";
            String user_role = "";
            String user_password = "";

            String first_name = "";
            String last_name = "";
            String[] user_full_names;
            Recordset rs = new Recordset();

            try {

                rs.Open("DELETE FROM tblUsers", _SQLite.connStr, CursorTypeEnum.adOpenKeyset, LockTypeEnum.adLockOptimistic, 0);

                for (int j = 2; j < xcelRange.Rows.Count + 1; j++) {
                    user_full_names = Convert.ToString((Object)(xcelWorksheet.Cells[j, 1] as Range).Value2).Trim().Replace("'", "-").Split(' ');
                    user_id = Convert.ToString((Object)(xcelWorksheet.Cells[j, 2] as Range).Value2).Trim().Replace("'", "-");
                    user_password = Convert.ToString((Object)(xcelWorksheet.Cells[j, 3] as Range).Value2).Trim().Replace("'", "-");
                    user_password = _Encryption.Encrypt(user_password);

                    user_role = Convert.ToString((Object)(xcelWorksheet.Cells[j, 4] as Range).Value2).Trim().Replace("'", "-");
                    
                    first_name = user_full_names[0];
                    if (user_full_names.Length > 1) {
                        last_name = user_full_names[1];
                    } else {
                        last_name = "";
                    };

                    rs.Open("INSERT INTO tblUsers (" +
                            "userID, " +
                            "userName, " +
                            "firstName, " +
                            "lastName, " +
                            "roleID, " +
                            "password) VALUES (" +
                            "'" + user_id + "', " +
                            "'" + user_id + "', " +
                            "'" + first_name + "', " +
                            "'" + last_name + "', " +
                            "'" + user_role + "', " +
                            "'" + user_password + "')", _SQLite.connStr, CursorTypeEnum.adOpenKeyset, LockTypeEnum.adLockOptimistic, 0);

                };
            } catch (Exception) {
                return;
            };

            xcelApp.Quit();
        }

        private void continue__Click(object sender, EventArgs e)
        {
            
            if (signin_pwd_textbox.Text != "TravelPass"){
                MessageBox.Show("Wrong Pass Phrase!", "Incorrect Credentials", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            };

            if (MessageBox.Show("Please ensure you copy the required files in the described folder, do you wish to contine with this operation?", "Continue with operation", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question) != DialogResult.Yes) {
                return;
            };

            this.Cursor = Cursors.WaitCursor;

            UploadFlaggedPassengers();

            UploadUserAccount();

            this.Cursor = Cursors.Default;

            MessageBox.Show("Operation Completed", "Done", MessageBoxButtons.OK, MessageBoxIcon.Information);

            Close();
        }

        private void signin_pwd_textbox_Leave(object sender, EventArgs e)
        {
            if (signin_pwd_textbox.Text.Length == 0)
            {
                signin_pwd_textbox.Text = "Password";
                signin_pwd_textbox.ForeColor = SystemColors.GrayText;
            }
        }

        private void signin_pwd_textbox_Enter(object sender, EventArgs e)
        {
            if (signin_pwd_textbox.Text == "Password")
            {
                signin_pwd_textbox.Text = "";
                signin_pwd_textbox.ForeColor = SystemColors.WindowText;
            }
        }

        private void SignInTravelPass_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                continue_.PerformClick();
            }
        }

    }
}
