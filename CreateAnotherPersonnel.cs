using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace TravelPass
{
    public partial class CreateAnotherPersonnel : Form
    {
        public CreateAnotherPersonnel()
        {
            InitializeComponent();
        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void create_personnel_button_Click(object sender, EventArgs e)
        {
            SetupUserClass setUpClass = new SetupUserClass();
            setUpClass.Show();
            this.Close();
        }

        private void signIn_Click(object sender, EventArgs e)
        {
            SignInTravelPass signInTravelPass = new SignInTravelPass();
            signInTravelPass.Show();
            this.Close();
        }

        private void quitSetup_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
