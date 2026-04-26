namespace TravelPass
{
    partial class UpdateRecordList
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UpdateRecordList));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnExportData = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.record_combo = new System.Windows.Forms.ComboBox();
            this.search_btn = new System.Windows.Forms.Button();
            this.search_box = new System.Windows.Forms.TextBox();
            this.view_record__ = new System.Windows.Forms.Button();
            this.final_dest_box_ = new System.Windows.Forms.TextBox();
            this.flight_to_box_ = new System.Windows.Forms.TextBox();
            this.flight_from_box_ = new System.Windows.Forms.TextBox();
            this.datetime_recorded_box_ = new System.Windows.Forms.TextBox();
            this.recordedby_email_box_ = new System.Windows.Forms.TextBox();
            this.recordedby_name_box_ = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.recordsDataGrid = new System.Windows.Forms.DataGridView();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.recordsDataGrid)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.groupBox1.Controls.Add(this.btnExportData);
            this.groupBox1.Controls.Add(this.groupBox2);
            this.groupBox1.Controls.Add(this.view_record__);
            this.groupBox1.Controls.Add(this.final_dest_box_);
            this.groupBox1.Controls.Add(this.flight_to_box_);
            this.groupBox1.Controls.Add(this.flight_from_box_);
            this.groupBox1.Controls.Add(this.datetime_recorded_box_);
            this.groupBox1.Controls.Add(this.recordedby_email_box_);
            this.groupBox1.Controls.Add(this.recordedby_name_box_);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox1.Size = new System.Drawing.Size(1459, 144);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Record Details";
            this.groupBox1.Enter += new System.EventHandler(this.groupBox1_Enter);
            // 
            // btnExportData
            // 
            this.btnExportData.BackColor = System.Drawing.Color.White;
            this.btnExportData.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnExportData.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnExportData.FlatAppearance.BorderColor = System.Drawing.Color.DimGray;
            this.btnExportData.FlatAppearance.BorderSize = 0;
            this.btnExportData.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExportData.Font = new System.Drawing.Font("Calibri", 10F);
            this.btnExportData.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(112)))), ((int)(((byte)(67)))));
            this.btnExportData.Image = ((System.Drawing.Image)(resources.GetObject("btnExportData.Image")));
            this.btnExportData.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnExportData.Location = new System.Drawing.Point(16, 82);
            this.btnExportData.Margin = new System.Windows.Forms.Padding(0);
            this.btnExportData.Name = "btnExportData";
            this.btnExportData.Size = new System.Drawing.Size(211, 30);
            this.btnExportData.TabIndex = 378;
            this.btnExportData.Text = "  Export Visible Data";
            this.btnExportData.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnExportData.UseVisualStyleBackColor = false;
            this.btnExportData.Click += new System.EventHandler(this.btnExportData_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.record_combo);
            this.groupBox2.Controls.Add(this.search_btn);
            this.groupBox2.Controls.Add(this.search_box);
            this.groupBox2.Location = new System.Drawing.Point(1017, 15);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox2.Size = new System.Drawing.Size(347, 113);
            this.groupBox2.TabIndex = 28;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Search";
            // 
            // record_combo
            // 
            this.record_combo.FormattingEnabled = true;
            this.record_combo.Items.AddRange(new object[] {
            "Record Folder Path",
            "Recorded_by Name",
            "Recorded_by Email",
            "Scanned Passport Number",
            "Scanned Passport Name",
            "Date Time Recorded",
            "Flight From",
            "Flight To",
            "Final Destination"});
            this.record_combo.Location = new System.Drawing.Point(12, 26);
            this.record_combo.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.record_combo.Name = "record_combo";
            this.record_combo.Size = new System.Drawing.Size(212, 26);
            this.record_combo.TabIndex = 2;
            this.record_combo.Text = "Recorded_by Name";
            // 
            // search_btn
            // 
            this.search_btn.BackColor = System.Drawing.Color.White;
            this.search_btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.search_btn.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.search_btn.Location = new System.Drawing.Point(244, 52);
            this.search_btn.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.search_btn.Name = "search_btn";
            this.search_btn.Size = new System.Drawing.Size(100, 28);
            this.search_btn.TabIndex = 26;
            this.search_btn.Text = "Search";
            this.search_btn.UseVisualStyleBackColor = false;
            this.search_btn.Click += new System.EventHandler(this.search_btn_Click);
            // 
            // search_box
            // 
            this.search_box.Location = new System.Drawing.Point(12, 76);
            this.search_box.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.search_box.Name = "search_box";
            this.search_box.Size = new System.Drawing.Size(212, 24);
            this.search_box.TabIndex = 1;
            this.search_box.KeyDown += new System.Windows.Forms.KeyEventHandler(this.search_box_KeyDown);
            // 
            // view_record__
            // 
            this.view_record__.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(140)))), ((int)(((byte)(0)))));
            this.view_record__.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.view_record__.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.view_record__.ForeColor = System.Drawing.Color.White;
            this.view_record__.Location = new System.Drawing.Point(16, 34);
            this.view_record__.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.view_record__.Name = "view_record__";
            this.view_record__.Size = new System.Drawing.Size(211, 37);
            this.view_record__.TabIndex = 26;
            this.view_record__.Text = "View Record";
            this.view_record__.UseVisualStyleBackColor = false;
            this.view_record__.Click += new System.EventHandler(this.view_record__Click);
            // 
            // final_dest_box_
            // 
            this.final_dest_box_.Location = new System.Drawing.Point(784, 89);
            this.final_dest_box_.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.final_dest_box_.Name = "final_dest_box_";
            this.final_dest_box_.Size = new System.Drawing.Size(224, 24);
            this.final_dest_box_.TabIndex = 1;
            // 
            // flight_to_box_
            // 
            this.flight_to_box_.Location = new System.Drawing.Point(275, 89);
            this.flight_to_box_.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.flight_to_box_.Name = "flight_to_box_";
            this.flight_to_box_.Size = new System.Drawing.Size(224, 24);
            this.flight_to_box_.TabIndex = 1;
            // 
            // flight_from_box_
            // 
            this.flight_from_box_.Location = new System.Drawing.Point(528, 89);
            this.flight_from_box_.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.flight_from_box_.Name = "flight_from_box_";
            this.flight_from_box_.Size = new System.Drawing.Size(224, 24);
            this.flight_from_box_.TabIndex = 1;
            // 
            // datetime_recorded_box_
            // 
            this.datetime_recorded_box_.Location = new System.Drawing.Point(784, 39);
            this.datetime_recorded_box_.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.datetime_recorded_box_.Name = "datetime_recorded_box_";
            this.datetime_recorded_box_.Size = new System.Drawing.Size(224, 24);
            this.datetime_recorded_box_.TabIndex = 1;
            // 
            // recordedby_email_box_
            // 
            this.recordedby_email_box_.Location = new System.Drawing.Point(275, 39);
            this.recordedby_email_box_.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.recordedby_email_box_.Name = "recordedby_email_box_";
            this.recordedby_email_box_.Size = new System.Drawing.Size(224, 24);
            this.recordedby_email_box_.TabIndex = 1;
            // 
            // recordedby_name_box_
            // 
            this.recordedby_name_box_.Location = new System.Drawing.Point(527, 39);
            this.recordedby_name_box_.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.recordedby_name_box_.Name = "recordedby_name_box_";
            this.recordedby_name_box_.Size = new System.Drawing.Size(224, 24);
            this.recordedby_name_box_.TabIndex = 1;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.label6.Location = new System.Drawing.Point(779, 69);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(113, 17);
            this.label6.TabIndex = 0;
            this.label6.Text = "Final Destination";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.label4.Location = new System.Drawing.Point(271, 69);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(63, 17);
            this.label4.TabIndex = 0;
            this.label4.Text = "Flight To";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.label5.Location = new System.Drawing.Point(780, 18);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(140, 17);
            this.label5.TabIndex = 0;
            this.label5.Text = "Date-Time Recorded";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.label3.Location = new System.Drawing.Point(271, 18);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(132, 17);
            this.label3.TabIndex = 0;
            this.label3.Text = "Recorded By_Email";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.label2.Location = new System.Drawing.Point(523, 69);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(78, 17);
            this.label2.TabIndex = 0;
            this.label2.Text = "Flight From";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.label1.Location = new System.Drawing.Point(523, 18);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(134, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "Recorded by_Name";
            // 
            // recordsDataGrid
            // 
            this.recordsDataGrid.BackgroundColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.recordsDataGrid.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.recordsDataGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.recordsDataGrid.Location = new System.Drawing.Point(16, 142);
            this.recordsDataGrid.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.recordsDataGrid.Name = "recordsDataGrid";
            this.recordsDataGrid.RowHeadersWidth = 200;
            this.recordsDataGrid.Size = new System.Drawing.Size(1344, 411);
            this.recordsDataGrid.TabIndex = 2;
            this.recordsDataGrid.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.recordsDataGrid_CellClick);
            this.recordsDataGrid.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.recordsDataGrid_CellContentClick);
            // 
            // UpdateRecordList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.ClientSize = new System.Drawing.Size(1376, 567);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.recordsDataGrid);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "UpdateRecordList";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Records List";
            this.Load += new System.EventHandler(this.UpdateRecordList_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.UpdateRecordList_KeyDown);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.recordsDataGrid)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private static System.Windows.Forms.Button view_record;
        private static System.Windows.Forms.TextBox final_dest_box;
        private static System.Windows.Forms.TextBox flight_to_box;
        private static System.Windows.Forms.TextBox flight_from_box;
        private static System.Windows.Forms.TextBox datetime_recorded_box;
        private System.Windows.Forms.Label label6;
        private static System.Windows.Forms.TextBox recordedby_email_box;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private static System.Windows.Forms.TextBox recordedby_name_box;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView recordsDataGrid;
        private static System.Windows.Forms.Button view_record_;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ComboBox record_combo;
        private System.Windows.Forms.Button search_btn;
        private System.Windows.Forms.TextBox search_box;
        private System.Windows.Forms.TextBox final_dest_box_;
        private System.Windows.Forms.TextBox flight_to_box_;
        private System.Windows.Forms.TextBox flight_from_box_;
        private System.Windows.Forms.TextBox datetime_recorded_box_;
        private System.Windows.Forms.TextBox recordedby_email_box_;
        private System.Windows.Forms.TextBox recordedby_name_box_;
        internal System.Windows.Forms.Button btnExportData;
        private System.Windows.Forms.Button view_record__;
    }
}









