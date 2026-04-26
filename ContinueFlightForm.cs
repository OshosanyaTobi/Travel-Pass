using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Collections;
using System.Linq;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace TravelPass
{
    public partial class ContinueFlightForm : Form
    {

        //Hashtable hashtable = new Hashtable();

        public ContinueFlightForm()
        {
            InitializeComponent();
        }

        private string pers_role_ = "";
        public String Pers_ROLE {
            get { return pers_role_; }
            set { this.pers_role_ = value; }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private string fullname = "";
        public String FullName
        {
            get { return fullname; }
            set { this.fullname = value; }
        }

        private string pers_id_ = "";
        public String Pers_ID
        {
            get { return pers_id_; }
            set { this.pers_id_ = value; }
        }

        private void ok_Click(object sender, EventArgs e)
        {
            ContinueFlightList continueFlightList = new ContinueFlightList();
            continueFlightList.FilterFlightNumber = "Flight"+filter_flight_number.Text.ToString();
            continueFlightList.FullName = fullname;
            continueFlightList.Pers_ID = pers_id_;
            continueFlightList.Pers_ROLE = pers_role_;
            this.Hide();
            continueFlightList.ShowDialog();
            if (continueFlightList.Result == "CONTINUE FLIGHT BUTTON PRESSED") {
                result = "CONTINUE FLIGHT BUTTON PRESSED";
                this.Close();
            }
        }

        private string result;
        public String Result {
            get { return this.result; }
            set { this.result = value; }
        }

        private void filter_flight_number_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                ok.PerformClick();
            }
        }

        
        private void ContinueFlightForm_Load(object sender, EventArgs e)
        {
            //    string appPath = Path.GetDirectoryName(Application.ExecutablePath);
            //    Console.WriteLine(appPath);

            //    //flight_airports data setup
            //    var collection_of_objects =
            //        (from line in File.ReadAllLines("C:/Users/ALML/Documents/TravelPass/TravelPass/airports.dat").Skip(1)
            //         let parts = line.Split(',')
            //         select new
            //         {
            //             airport_name = parts[1],
            //             airport_country = parts[3],
            //             airport_code = parts[4],
            //         }
            //        ).ToList();
            //    string[] airport_data = new string[collection_of_objects.Count];

            //    for (int i = 0; i < collection_of_objects.Count; i++)
            //    {
            //        airport_data[i] = collection_of_objects[i].airport_code.Trim(new Char[] { '"' }) + "," + collection_of_objects[i].airport_name.Trim(new Char[] { '"' });
            //        try
            //        {
            //            hashtable.Add(airport_data[i].ToString().Trim(), collection_of_objects[i].airport_country.ToString().Trim());
            //        }
            //        catch (Exception ex)
            //        {
            //            Console.WriteLine(ex.ToString());
            //        }
            //    }
            //    filter_flight_from.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            //    filter_flight_from.AutoCompleteCustomSource.AddRange(airport_data);
            //    filter_flight_to.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            //    filter_flight_to.AutoCompleteCustomSource.AddRange(airport_data);


        }

        private void ContinueFlightForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape) {
                Close();
            };
        }
}
}
