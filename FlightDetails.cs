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
    public partial class FlightDetails : Form
    {
        public FlightDetails()
        {
            InitializeComponent();
        }

        private Flight flightDetails_;
        public Flight FlightDetails_ {
            get { return flightDetails_; }
            set { this.flightDetails_ = value; }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void FlightDetails_Load(object sender, EventArgs e)
        {
            this.flight_name_label.Text = "Flight " + flightDetails_.FlightNumber;
            this.flight_class.Text = flightDetails_.FlightClass;
            this.textBox1.Text = flightDetails_.FolderName;
            this.textBox2.Text = flightDetails_.CreatedBy_Name;
            this.textBox3.Text = flightDetails_.CreatedBy_Email;
            this.textBox4.Text = flightDetails_.DateTimeCreated;
            this.textBox5.Text = flightDetails_.FlightDate;
            this.textBox6.Text = flightDetails_.FlightAirline;
            this.textBox7.Text = flightDetails_.FlightNumber;
            this.textBox8.Text = flightDetails_.FlightFrom;
            this.textBox9.Text = flightDetails_.CountryFrom;
            this.textBox10.Text = flightDetails_.FlightDepartTime;
            this.textBox11.Text = flightDetails_.FlightDepartTerm;
            this.textBox12.Text = flightDetails_.FlightTo;
            this.textBox13.Text = flightDetails_.CountryTo;
            this.textBox14.Text = flightDetails_.FlightArriveTime;
            this.textBox15.Text = flightDetails_.FlightArriveTerm;
            this.textBox16.Text = flightDetails_.FlightType;
            this.textBox17.Text = flightDetails_.FlightLength;
        }

        private void FlightDetails_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape) Close();
        }
    }
}
