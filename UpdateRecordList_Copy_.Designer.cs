namespace TravelPass
{
    partial class UpdateRecordList_Copy_
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UpdateRecordList_Copy_));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnExportToExcel = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.record_combo = new System.Windows.Forms.ComboBox();
            this.search_btn = new System.Windows.Forms.Button();
            this.search_box = new System.Windows.Forms.TextBox();
            this.final_dest_box_ = new System.Windows.Forms.TextBox();
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
            this.groupBox1.BackColor = System.Drawing.Color.White;
            this.groupBox1.Controls.Add(this.btnExportToExcel);
            this.groupBox1.Controls.Add(this.groupBox2);
            this.groupBox1.Controls.Add(this.final_dest_box_);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1094, 117);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Record Details";
            this.groupBox1.Enter += new System.EventHandler(this.groupBox1_Enter);
            // 
            // btnExportToExcel
            // 
            this.btnExportToExcel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.btnExportToExcel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExportToExcel.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold);
            this.btnExportToExcel.ForeColor = System.Drawing.Color.White;
            this.btnExportToExcel.Location = new System.Drawing.Point(12, 80);
            this.btnExportToExcel.Name = "btnExportToExcel";
            this.btnExportToExcel.Size = new System.Drawing.Size(119, 29);
            this.btnExportToExcel.TabIndex = 29;
            this.btnExportToExcel.Text = "Export Data To Excel";
            this.btnExportToExcel.UseVisualStyleBackColor = false;
            this.btnExportToExcel.Visible = false;
            this.btnExportToExcel.Click += new System.EventHandler(this.btnExportToExcel_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.record_combo);
            this.groupBox2.Controls.Add(this.search_btn);
            this.groupBox2.Controls.Add(this.search_box);
            this.groupBox2.Location = new System.Drawing.Point(822, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(266, 97);
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
            this.record_combo.Location = new System.Drawing.Point(9, 21);
            this.record_combo.Name = "record_combo";
            this.record_combo.Size = new System.Drawing.Size(160, 23);
            this.record_combo.TabIndex = 2;
            this.record_combo.Text = "Recorded_by Name";
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
            // 
            // final_dest_box_
            // 
            this.final_dest_box_.Location = new System.Drawing.Point(606, 72);
            this.final_dest_box_.Name = "final_dest_box_";
            this.final_dest_box_.Size = new System.Drawing.Size(206, 21);
            this.final_dest_box_.TabIndex = 1;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.label6.Location = new System.Drawing.Point(602, 56);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(85, 13);
            this.label6.TabIndex = 0;
            this.label6.Text = "Final Destination";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.label4.Location = new System.Drawing.Point(142, 56);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(48, 13);
            this.label4.TabIndex = 0;
            this.label4.Text = "Flight To";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.label5.Location = new System.Drawing.Point(603, 15);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(106, 13);
            this.label5.TabIndex = 0;
            this.label5.Text = "Date-Time Recorded";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.label3.Location = new System.Drawing.Point(142, 15);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(100, 13);
            this.label3.TabIndex = 0;
            this.label3.Text = "Recorded By_Email";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.label2.Location = new System.Drawing.Point(371, 56);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(58, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Flight From";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.label1.Location = new System.Drawing.Point(371, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(102, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Recorded by_Name";
            // 
            // recordsDataGrid
            // 
            this.recordsDataGrid.BackgroundColor = System.Drawing.Color.WhiteSmoke;
            this.recordsDataGrid.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.recordsDataGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.recordsDataGrid.Location = new System.Drawing.Point(12, 115);
            this.recordsDataGrid.Name = "recordsDataGrid";
            this.recordsDataGrid.RowHeadersWidth = 200;
            this.recordsDataGrid.Size = new System.Drawing.Size(1071, 431);
            this.recordsDataGrid.TabIndex = 2;
            this.recordsDataGrid.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.recordsDataGrid_CellClick);
            this.recordsDataGrid.RowsAdded += new System.Windows.Forms.DataGridViewRowsAddedEventHandler(this.recordsDataGrid_RowsAdded);
            this.recordsDataGrid.RowsRemoved += new System.Windows.Forms.DataGridViewRowsRemovedEventHandler(this.recordsDataGrid_RowsRemoved);
            // 
            // UpdateRecordList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1094, 558);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.recordsDataGrid);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(2);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "UpdateRecordList";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Records List";
            this.Load += new System.EventHandler(this.UpdateRecordList_Load);
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
        private System.Windows.Forms.Button btnExportToExcel;
    }
}









