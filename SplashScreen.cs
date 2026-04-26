using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace TravelPass
{
    public partial class SplashScreen : Form
    {
        bool foundAdmin = false;
        private BackgroundWorker _bw;
        public SplashScreen()
        {
            InitializeComponent();
            progressBar1.Style = ProgressBarStyle.Marquee;
            progressBar1.MarqueeAnimationSpeed = 30;
            attn_string.Text = "Please wait, starting up ...";
            _bw = new BackgroundWorker
            {
                WorkerReportsProgress = true,
                WorkerSupportsCancellation = true
            };
            _bw.DoWork += bw_DoWork;
            _bw.ProgressChanged += bw_ProgressChanged;
            _bw.RunWorkerCompleted += bw_RunWorkerCompleted;

            _bw.RunWorkerAsync(2000);

            //if (_bw.IsBusy) _bw.CancelAsync();
        }

        private void SplashScreen_Load(object sender, EventArgs e)
        {

        }

        private void SplashScreen_Shown(object sender, EventArgs e)
        {
            
        }
        

        private void connect_to_database() {
            // Get connection.
            string connString = @"Data Source=192.168.1.100\SQLEXPRESS,1433;Network Library=DBMSSOCN;Initial Catalog=TravelPassDB;User ID=sa;Password=123456789";
            SqlConnection connection = new SqlConnection(connString);
            Console.WriteLine(connection.PacketSize);
            try
            {
                connection.Open();
                MethodInvoker mi = delegate {
                    attn_string.Text = "Please wait, connecting to Database ...";
                };

                if (InvokeRequired)
                    this.Invoke(mi);
                QueryAdminPersonnel(connection);
                
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex);
                Console.WriteLine(ex.StackTrace);
                DialogResult dResult = MessageBox.Show("Error while connecting to Database",
                                                        "Error Report",
                                                        MessageBoxButtons.OK,
                                                        MessageBoxIcon.Error,
                                                        MessageBoxDefaultButton.Button1,
                                                        MessageBoxOptions.RightAlign,
                                                        false);
                if (dResult == DialogResult.OK) {
                    Application.Exit();
                }
            }
            finally
            {
                // Close connection.
                connection.Close();
                // Dispose object, freeing Resources.
                connection.Dispose();
            }
        }

        private void QueryAdminPersonnel(SqlConnection conn)
        {
            string sql = "SELECT PERS_ROLE FROM PERSONNEL";
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;
            cmd.CommandText = sql;
            using (DbDataReader reader = cmd.ExecuteReader())
            {
                if (reader.HasRows)
                {
                    Console.WriteLine(reader.FieldCount + "");
                    while (reader.Read())
                    {
                        //attn_string.Text = "Connected successfully, cleaning this up ...";
                        MethodInvoker mi = delegate
                        {
                            attn_string.Text = "Connected successfully, cleaning this up ...";
                        };

                        if (InvokeRequired)
                            this.Invoke(mi);
                        int roleIndex = reader.GetOrdinal("PERS_ROLE");
                        string role = reader.GetString(roleIndex);
                        Console.WriteLine("*****************");
                        Console.WriteLine("PERS_ROLE:" + role);
                        if (role.ToLower().Equals("admin"))
                        {
                            foundAdmin = true;
                            break;
                        }
                    }
                    if (!foundAdmin)
                    {
                        MethodInvoker mi = delegate
                        {
                            this.Hide();
                            SetupUserClass setupUserClass = new SetupUserClass();
                            setupUserClass.Show();
                            Console.WriteLine("SetupUserClass showing");
                        };

                        if (InvokeRequired)
                            this.Invoke(mi);

                    }
                    //if foundAdmin = true;
                    else
                    {
                        MethodInvoker mi = delegate
                        {
                            this.Hide();
                            SignInTravelPass signInTravelPass = new SignInTravelPass();
                            signInTravelPass.Show();
                            Console.WriteLine("SignInTravelPass showing");
                        };

                        if (InvokeRequired)
                            this.Invoke(mi);

                    }
                }
                else {
                    Console.WriteLine(reader.FieldCount + "");
                    MethodInvoker mi = delegate
                    {
                        this.Hide();
                        SetupUserClass setupUserClass = new SetupUserClass();
                        setupUserClass.Show();
                        Console.WriteLine("SetupUserClass showing");
                    };

                    if (InvokeRequired)
                        this.Invoke(mi);
                }
            }

        }

        private void bw_DoWork(object sender, DoWorkEventArgs e)
        {
            connect_to_database();
        }

        private void bw_RunWorkerCompleted(object sender,
                                           RunWorkerCompletedEventArgs e)
        {
            
        }

        private void bw_ProgressChanged(object sender,
                                        ProgressChangedEventArgs e)
        {
            //attn_string.Text = "Please wait, connecting to Database ...";
        }

    }
}
