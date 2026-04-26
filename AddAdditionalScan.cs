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
    public partial class AddAdditionalScan : Form
    {
        public AddAdditionalScan()
        {
            InitializeComponent();
        }

        private void add_scan_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private bool _isDonePressed = false;
        public bool isDonePressed {
            get { return _isDonePressed; }
            set { this._isDonePressed = value; }
        }
        private void done_scanning_Click(object sender, EventArgs e)
        {
            isDonePressed = true;
            this.Close();
        }
    }
}
