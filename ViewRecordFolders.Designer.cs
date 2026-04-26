namespace TravelPass
{
    partial class ViewRecordFolders
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ViewRecordFolders));
            this.scansDataGrid = new System.Windows.Forms.DataGridView();
            this.bunifuImageButton2 = new Bunifu.Framework.UI.BunifuImageButton();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.add_new_scan = new System.Windows.Forms.Button();
            this.go_to = new System.Windows.Forms.Button();
            this.scan_type_label = new System.Windows.Forms.Label();
            this.delete_scan = new System.Windows.Forms.Button();
            this.copyToFolder = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.scansDataGrid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bunifuImageButton2)).BeginInit();
            this.SuspendLayout();
            // 
            // scansDataGrid
            // 
            this.scansDataGrid.BackgroundColor = System.Drawing.Color.WhiteSmoke;
            this.scansDataGrid.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.scansDataGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.scansDataGrid.GridColor = System.Drawing.Color.WhiteSmoke;
            this.scansDataGrid.Location = new System.Drawing.Point(16, 133);
            this.scansDataGrid.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.scansDataGrid.Name = "scansDataGrid";
            this.scansDataGrid.ReadOnly = true;
            this.scansDataGrid.RowHeadersWidth = 130;
            this.scansDataGrid.Size = new System.Drawing.Size(804, 418);
            this.scansDataGrid.StandardTab = true;
            this.scansDataGrid.TabIndex = 0;
            this.scansDataGrid.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.scansDataGrid_CellClick);
            this.scansDataGrid.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.scansDataGrid_CellContentClick);
            // 
            // bunifuImageButton2
            // 
            this.bunifuImageButton2.BackColor = System.Drawing.Color.White;
            this.bunifuImageButton2.Image = global::TravelPass.Properties.Resources.newpng;
            this.bunifuImageButton2.ImageActive = null;
            this.bunifuImageButton2.Location = new System.Drawing.Point(16, 15);
            this.bunifuImageButton2.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.bunifuImageButton2.Name = "bunifuImageButton2";
            this.bunifuImageButton2.Size = new System.Drawing.Size(72, 60);
            this.bunifuImageButton2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.bunifuImageButton2.TabIndex = 50;
            this.bunifuImageButton2.TabStop = false;
            this.bunifuImageButton2.Zoom = 10;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Calibri Light", 11F, System.Drawing.FontStyle.Bold);
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.label3.Location = new System.Drawing.Point(96, 38);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(66, 23);
            this.label3.TabIndex = 49;
            this.label3.Text = "SCANS";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Calibri Light", 11F, System.Drawing.FontStyle.Bold);
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.label1.Location = new System.Drawing.Point(96, 15);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(57, 23);
            this.label1.TabIndex = 49;
            this.label1.Text = "ALML";
            // 
            // label6
            // 
            this.label6.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label6.Location = new System.Drawing.Point(184, 0);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(3, 80);
            this.label6.TabIndex = 51;
            // 
            // label2
            // 
            this.label2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label2.Location = new System.Drawing.Point(525, 0);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(3, 80);
            this.label2.TabIndex = 51;
            // 
            // add_new_scan
            // 
            this.add_new_scan.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.add_new_scan.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(140)))), ((int)(((byte)(0)))));
            this.add_new_scan.Location = new System.Drawing.Point(559, 42);
            this.add_new_scan.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.add_new_scan.Name = "add_new_scan";
            this.add_new_scan.Size = new System.Drawing.Size(248, 33);
            this.add_new_scan.TabIndex = 52;
            this.add_new_scan.Text = "ADD SCAN";
            this.add_new_scan.UseVisualStyleBackColor = true;
            this.add_new_scan.Click += new System.EventHandler(this.add_new_scan_Click);
            // 
            // go_to
            // 
            this.go_to.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.go_to.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(140)))), ((int)(((byte)(0)))));
            this.go_to.Location = new System.Drawing.Point(196, 42);
            this.go_to.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.go_to.Name = "go_to";
            this.go_to.Size = new System.Drawing.Size(320, 34);
            this.go_to.TabIndex = 52;
            this.go_to.Text = "VIEW ITEM";
            this.go_to.UseVisualStyleBackColor = true;
            this.go_to.Click += new System.EventHandler(this.go_to_Click);
            // 
            // scan_type_label
            // 
            this.scan_type_label.AutoSize = true;
            this.scan_type_label.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold);
            this.scan_type_label.Location = new System.Drawing.Point(197, 5);
            this.scan_type_label.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.scan_type_label.Name = "scan_type_label";
            this.scan_type_label.Size = new System.Drawing.Size(0, 29);
            this.scan_type_label.TabIndex = 53;
            // 
            // delete_scan
            // 
            this.delete_scan.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.delete_scan.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.delete_scan.Location = new System.Drawing.Point(559, 4);
            this.delete_scan.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.delete_scan.Name = "delete_scan";
            this.delete_scan.Size = new System.Drawing.Size(248, 33);
            this.delete_scan.TabIndex = 52;
            this.delete_scan.Text = "DELETE SCAN";
            this.delete_scan.UseVisualStyleBackColor = true;
            this.delete_scan.Click += new System.EventHandler(this.delete_scan_Click);
            // 
            // copyToFolder
            // 
            this.copyToFolder.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.copyToFolder.ForeColor = System.Drawing.Color.Black;
            this.copyToFolder.Location = new System.Drawing.Point(16, 92);
            this.copyToFolder.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.copyToFolder.Name = "copyToFolder";
            this.copyToFolder.Size = new System.Drawing.Size(340, 33);
            this.copyToFolder.TabIndex = 52;
            this.copyToFolder.Text = "COPY SCANS TO ...";
            this.copyToFolder.UseVisualStyleBackColor = true;
            this.copyToFolder.Click += new System.EventHandler(this.copy_to_Click);
            // 
            // ViewRecordFolders
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(836, 566);
            this.Controls.Add(this.scan_type_label);
            this.Controls.Add(this.go_to);
            this.Controls.Add(this.copyToFolder);
            this.Controls.Add(this.delete_scan);
            this.Controls.Add(this.add_new_scan);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.bunifuImageButton2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.scansDataGrid);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ViewRecordFolders";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Scans";
            this.Load += new System.EventHandler(this.ViewRecordFolders_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ViewRecordFolders_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.scansDataGrid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bunifuImageButton2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView scansDataGrid;
        private Bunifu.Framework.UI.BunifuImageButton bunifuImageButton2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button add_new_scan;
        private System.Windows.Forms.Button go_to;
        private System.Windows.Forms.Label scan_type_label;
        private System.Windows.Forms.Button delete_scan;
        private System.Windows.Forms.Button copyToFolder;
    }
}