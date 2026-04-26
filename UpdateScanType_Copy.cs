using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace TravelPass
{
    public partial class UpdateScanType_Copy : Form
    {
        public UpdateScanType_Copy()
        {
            InitializeComponent();
        }

        private void UpdateScanType_Load(object sender, EventArgs e)
        {

        }

        public bool pressedCancel = false;
        private string scan_type_;
        public String ScanType {
            get { return scan_type_; }
            set { this.scan_type_ = value; }
        }

        private void ok_Click(object sender, EventArgs e)
        {
            if (scan_type.Text.Length > 1) {
                this.scan_type_ = scan_type.Text.ToString();
                this.Close();
            }
            else {
                DialogResult dResult = MessageBox.Show("Please type in a valid Scan Type",
                                                            "Error Report",
                                                            MessageBoxButtons.OK,
                                                            MessageBoxIcon.Error,
                                                            MessageBoxDefaultButton.Button1,
                                                            MessageBoxOptions.RightAlign,
                                                            false);
            }
        }

        private void cancel_Click(object sender, EventArgs e)
        {
            pressedCancel = true;
            this.Close();
        }
    }
}
