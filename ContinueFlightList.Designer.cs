namespace TravelPass
{
    partial class ContinueFlightList
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ContinueFlightList));
            this.flightsDataGrid = new System.Windows.Forms.DataGridView();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btn_smart_search = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.flight_combo = new System.Windows.Forms.ComboBox();
            this.search_btn = new System.Windows.Forms.Button();
            this.search_box = new System.Windows.Forms.TextBox();
            this.go_to_flight = new System.Windows.Forms.Button();
            this.flight_date_box = new System.Windows.Forms.TextBox();
            this.flight_to_box = new System.Windows.Forms.TextBox();
            this.flight_created_by_box = new System.Windows.Forms.TextBox();
            this.flight_airline_box = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.flight_from_box = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.flight_name_box = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.flightsDataGrid)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // flightsDataGrid
            // 
            this.flightsDataGrid.AllowUserToAddRows = false;
            this.flightsDataGrid.AllowUserToDeleteRows = false;
            this.flightsDataGrid.AllowUserToOrderColumns = true;
            this.flightsDataGrid.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.flightsDataGrid.BackgroundColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.flightsDataGrid.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.flightsDataGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.flightsDataGrid.Location = new System.Drawing.Point(12, 135);
            this.flightsDataGrid.Name = "flightsDataGrid";
            this.flightsDataGrid.RowHeadersWidth = 51;
            this.flightsDataGrid.Size = new System.Drawing.Size(1006, 315);
            this.flightsDataGrid.TabIndex = 0;
            this.flightsDataGrid.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.flightsDataGrid_CellClick);
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.groupBox2);
            this.groupBox1.Controls.Add(this.btn_smart_search);
            this.groupBox1.Controls.Add(this.go_to_flight);
            this.groupBox1.Controls.Add(this.flight_date_box);
            this.groupBox1.Controls.Add(this.flight_to_box);
            this.groupBox1.Controls.Add(this.flight_created_by_box);
            this.groupBox1.Controls.Add(this.flight_airline_box);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.flight_from_box);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.flight_name_box);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.groupBox1.Location = new System.Drawing.Point(10, 11);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1008, 115);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Flight Details";
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.groupBox2.Controls.Add(this.flight_combo);
            this.groupBox2.Controls.Add(this.search_btn);
            this.groupBox2.Controls.Add(this.search_box);
            this.groupBox2.Location = new System.Drawing.Point(724, 10);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(266, 97);
            this.groupBox2.TabIndex = 27;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Search";
            // 
            // flight_combo
            // 
            this.flight_combo.FormattingEnabled = true;
            this.flight_combo.Items.AddRange(new object[] {
            "Flight Name",
            "Created_By Name",
            "Created_By Email",
            "Flight From",
            "Flight To",
            "Flight Airline",
            "Flight Date Created",
            "Flight Date",
            "Flight Type",
            "Flight Number",
            "Country From",
            "Flight Depart Time",
            "Flight Depart Terminal",
            "Flight Folder Path",
            "Country To",
            "Flight Arrive Time",
            "Flight Arrive Terminal",
            "Flight Length",
            "Flight Class",
            "Scanned Passport Number",
            "Scanned Passport Name"});
            this.flight_combo.Location = new System.Drawing.Point(9, 21);
            this.flight_combo.Name = "flight_combo";
            this.flight_combo.Size = new System.Drawing.Size(160, 23);
            this.flight_combo.TabIndex = 2;
            this.flight_combo.Text = "Flight Name";
            // 
            // search_btn
            // 
            this.search_btn.BackColor = System.Drawing.Color.White;
            this.search_btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.search_btn.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.search_btn.Location = new System.Drawing.Point(183, 42);
            this.search_btn.Name = "search_btn";
            this.search_btn.Size = new System.Drawing.Size(75, 23);
            this.search_btn.TabIndex = 26;
            this.search_btn.Text = "Search";
            this.search_btn.UseVisualStyleBackColor = false;
            this.search_btn.Click += new System.EventHandler(this.search_btn_Click);
            // 
            // search_box
            // 
            this.search_box.Location = new System.Drawing.Point(9, 62);
            this.search_box.Name = "search_box";
            this.search_box.Size = new System.Drawing.Size(160, 21);
            this.search_box.TabIndex = 1;
            this.search_box.KeyDown += new System.Windows.Forms.KeyEventHandler(this.search_box_KeyDown);
            // 
            // go_to_flight
            // 
            this.go_to_flight.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(140)))), ((int)(((byte)(0)))));
            this.go_to_flight.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.go_to_flight.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.go_to_flight.ForeColor = System.Drawing.Color.White;
            this.go_to_flight.Location = new System.Drawing.Point(13, 49);
            this.go_to_flight.Name = "go_to_flight";
            this.go_to_flight.Size = new System.Drawing.Size(112, 33);
            this.go_to_flight.TabIndex = 25;
            this.go_to_flight.Text = "Go to Flight";
            this.go_to_flight.UseVisualStyleBackColor = false;
            this.go_to_flight.Click += new System.EventHandler(this.go_to_flight_Click);
            //
            // btn_smart_search
            //
            this.btn_smart_search.Text      = "Smart Search";
            this.btn_smart_search.Location  = new System.Drawing.Point(13, 82);
            this.btn_smart_search.Size      = new System.Drawing.Size(112, 25);
            this.btn_smart_search.BackColor = System.Drawing.Color.FromArgb(0, 102, 204);
            this.btn_smart_search.ForeColor = System.Drawing.Color.White;
            this.btn_smart_search.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_smart_search.Font      = new System.Drawing.Font("Microsoft Sans Serif", 8.5F, System.Drawing.FontStyle.Bold);
            this.btn_smart_search.TabIndex  = 28;
            this.btn_smart_search.Click    += new System.EventHandler(this.btn_smart_search_Click);
            //
            // flight_date_box
            //
            this.flight_date_box.Location = new System.Drawing.Point(331, 74);
            this.flight_date_box.Name = "flight_date_box";
            this.flight_date_box.Size = new System.Drawing.Size(167, 21);
            this.flight_date_box.TabIndex = 1;
            // 
            // flight_to_box
            // 
            this.flight_to_box.Location = new System.Drawing.Point(152, 74);
            this.flight_to_box.Name = "flight_to_box";
            this.flight_to_box.Size = new System.Drawing.Size(167, 21);
            this.flight_to_box.TabIndex = 1;
            // 
            // flight_created_by_box
            // 
            this.flight_created_by_box.Location = new System.Drawing.Point(510, 74);
            this.flight_created_by_box.Name = "flight_created_by_box";
            this.flight_created_by_box.Size = new System.Drawing.Size(167, 21);
            this.flight_created_by_box.TabIndex = 1;
            // 
            // flight_airline_box
            // 
            this.flight_airline_box.Location = new System.Drawing.Point(329, 31);
            this.flight_airline_box.Name = "flight_airline_box";
            this.flight_airline_box.Size = new System.Drawing.Size(167, 21);
            this.flight_airline_box.TabIndex = 1;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.label6.Location = new System.Drawing.Point(328, 60);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(58, 13);
            this.label6.TabIndex = 0;
            this.label6.Text = "Flight Date";
            // 
            // flight_from_box
            // 
            this.flight_from_box.Location = new System.Drawing.Point(150, 31);
            this.flight_from_box.Name = "flight_from_box";
            this.flight_from_box.Size = new System.Drawing.Size(167, 21);
            this.flight_from_box.TabIndex = 1;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.label4.Location = new System.Drawing.Point(149, 60);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(48, 13);
            this.label4.TabIndex = 0;
            this.label4.Text = "Flight To";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.label5.Location = new System.Drawing.Point(327, 17);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(63, 13);
            this.label5.TabIndex = 0;
            this.label5.Text = "Flight Airline";
            // 
            // flight_name_box
            // 
            this.flight_name_box.Location = new System.Drawing.Point(508, 31);
            this.flight_name_box.Name = "flight_name_box";
            this.flight_name_box.Size = new System.Drawing.Size(167, 21);
            this.flight_name_box.TabIndex = 1;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.label3.Location = new System.Drawing.Point(147, 17);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(58, 13);
            this.label3.TabIndex = 0;
            this.label3.Text = "Flight From";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.label2.Location = new System.Drawing.Point(508, 60);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(87, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Flight Created By";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.label1.Location = new System.Drawing.Point(507, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(63, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Flight Name";
            // 
            // ContinueFlightList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.ClientSize = new System.Drawing.Size(1032, 461);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.flightsDataGrid);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(1037, 489);
            this.Name = "ContinueFlightList";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Flights List";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.ContinueFlightList_FormClosed);
            this.Load += new System.EventHandler(this.ContinueFlightList_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ContinueFlightList_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.flightsDataGrid)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView flightsDataGrid;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox flight_date_box;
        private System.Windows.Forms.TextBox flight_to_box;
        private System.Windows.Forms.TextBox flight_created_by_box;
        private System.Windows.Forms.TextBox flight_airline_box;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox flight_from_box;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox flight_name_box;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button go_to_flight;
        private System.Windows.Forms.Button btn_smart_search;
        private System.Windows.Forms.Button search_btn;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ComboBox flight_combo;
        private System.Windows.Forms.TextBox search_box;
        private System.Windows.Forms.Timer timer1;
    }
}