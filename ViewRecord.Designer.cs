namespace TravelPass
{
    partial class ViewRecord
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ViewRecord));
            this.scan_type = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.bunifuImageButton2 = new Bunifu.Framework.UI.BunifuImageButton();
            this.label3 = new System.Windows.Forms.Label();
            this.profilingDetails = new Bunifu.Framework.UI.BunifuFlatButton();
            this.rfid_scan = new Bunifu.Framework.UI.BunifuFlatButton();
            this.view_images = new Bunifu.Framework.UI.BunifuFlatButton();
            this.mrz_scan = new Bunifu.Framework.UI.BunifuFlatButton();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.mrzScan1 = new TravelPass.MRZScan();
            this.viewImages1 = new TravelPass.ViewImages();
            this.rfidScan1 = new TravelPass.RFIDScan();
            this.is_flagged = new System.Windows.Forms.Label();
            this.profilingDetails1 = new TravelPass.ProfilingDetails();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bunifuImageButton2)).BeginInit();
            this.SuspendLayout();
            // 
            // scan_type
            // 
            this.scan_type.AutoSize = true;
            this.scan_type.Font = new System.Drawing.Font("Microsoft Sans Serif", 25F, System.Drawing.FontStyle.Bold);
            this.scan_type.Location = new System.Drawing.Point(4, 4);
            this.scan_type.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.scan_type.Name = "scan_type";
            this.scan_type.Size = new System.Drawing.Size(0, 48);
            this.scan_type.TabIndex = 55;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.panel1.Controls.Add(this.bunifuImageButton2);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.profilingDetails);
            this.panel1.Controls.Add(this.rfid_scan);
            this.panel1.Controls.Add(this.view_images);
            this.panel1.Controls.Add(this.mrz_scan);
            this.panel1.Controls.Add(this.panel3);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Location = new System.Drawing.Point(0, 55);
            this.panel1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(237, 533);
            this.panel1.TabIndex = 52;
            // 
            // bunifuImageButton2
            // 
            this.bunifuImageButton2.BackColor = System.Drawing.Color.Transparent;
            this.bunifuImageButton2.Image = ((System.Drawing.Image)(resources.GetObject("bunifuImageButton2.Image")));
            this.bunifuImageButton2.ImageActive = null;
            this.bunifuImageButton2.Location = new System.Drawing.Point(81, 442);
            this.bunifuImageButton2.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.bunifuImageButton2.Name = "bunifuImageButton2";
            this.bunifuImageButton2.Size = new System.Drawing.Size(72, 60);
            this.bunifuImageButton2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.bunifuImageButton2.TabIndex = 48;
            this.bunifuImageButton2.TabStop = false;
            this.bunifuImageButton2.Zoom = 10;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Calibri Light", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(80, 506);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(71, 29);
            this.label3.TabIndex = 47;
            this.label3.Text = "ALML";
            // 
            // profilingDetails
            // 
            this.profilingDetails.Activecolor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.profilingDetails.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.profilingDetails.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.profilingDetails.BorderRadius = 0;
            this.profilingDetails.ButtonText = "Profiling Details";
            this.profilingDetails.Cursor = System.Windows.Forms.Cursors.Hand;
            this.profilingDetails.Iconcolor = System.Drawing.Color.Transparent;
            this.profilingDetails.Iconimage = ((System.Drawing.Image)(resources.GetObject("profilingDetails.Iconimage")));
            this.profilingDetails.Iconimage_right = null;
            this.profilingDetails.Iconimage_right_Selected = null;
            this.profilingDetails.Iconimage_Selected = null;
            this.profilingDetails.IconZoom = 90D;
            this.profilingDetails.IsTab = false;
            this.profilingDetails.Location = new System.Drawing.Point(-17, 271);
            this.profilingDetails.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.profilingDetails.Name = "profilingDetails";
            this.profilingDetails.Normalcolor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.profilingDetails.OnHovercolor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.profilingDetails.OnHoverTextColor = System.Drawing.Color.White;
            this.profilingDetails.selected = false;
            this.profilingDetails.Size = new System.Drawing.Size(255, 85);
            this.profilingDetails.TabIndex = 44;
            this.profilingDetails.Textcolor = System.Drawing.Color.White;
            this.profilingDetails.TextFont = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.profilingDetails.Click += new System.EventHandler(this.profiling_details_Click);
            // 
            // rfid_scan
            // 
            this.rfid_scan.Activecolor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.rfid_scan.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.rfid_scan.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.rfid_scan.BorderRadius = 0;
            this.rfid_scan.ButtonText = "RFID Scan";
            this.rfid_scan.Cursor = System.Windows.Forms.Cursors.Hand;
            this.rfid_scan.Iconcolor = System.Drawing.Color.Transparent;
            this.rfid_scan.Iconimage = ((System.Drawing.Image)(resources.GetObject("rfid_scan.Iconimage")));
            this.rfid_scan.Iconimage_right = null;
            this.rfid_scan.Iconimage_right_Selected = null;
            this.rfid_scan.Iconimage_Selected = null;
            this.rfid_scan.IconZoom = 90D;
            this.rfid_scan.IsTab = false;
            this.rfid_scan.Location = new System.Drawing.Point(-15, 174);
            this.rfid_scan.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.rfid_scan.Name = "rfid_scan";
            this.rfid_scan.Normalcolor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.rfid_scan.OnHovercolor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.rfid_scan.OnHoverTextColor = System.Drawing.Color.White;
            this.rfid_scan.selected = false;
            this.rfid_scan.Size = new System.Drawing.Size(255, 85);
            this.rfid_scan.TabIndex = 44;
            this.rfid_scan.Textcolor = System.Drawing.Color.White;
            this.rfid_scan.TextFont = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rfid_scan.Click += new System.EventHandler(this.rfid_scan_Click);
            // 
            // view_images
            // 
            this.view_images.Activecolor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.view_images.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.view_images.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.view_images.BorderRadius = 0;
            this.view_images.ButtonText = "View Images";
            this.view_images.Cursor = System.Windows.Forms.Cursors.Hand;
            this.view_images.Iconcolor = System.Drawing.Color.Transparent;
            this.view_images.Iconimage = ((System.Drawing.Image)(resources.GetObject("view_images.Iconimage")));
            this.view_images.Iconimage_right = null;
            this.view_images.Iconimage_right_Selected = null;
            this.view_images.Iconimage_Selected = null;
            this.view_images.IconZoom = 90D;
            this.view_images.IsTab = false;
            this.view_images.Location = new System.Drawing.Point(-16, 84);
            this.view_images.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.view_images.Name = "view_images";
            this.view_images.Normalcolor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.view_images.OnHovercolor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.view_images.OnHoverTextColor = System.Drawing.Color.White;
            this.view_images.selected = false;
            this.view_images.Size = new System.Drawing.Size(255, 85);
            this.view_images.TabIndex = 44;
            this.view_images.Textcolor = System.Drawing.Color.White;
            this.view_images.TextFont = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.view_images.Click += new System.EventHandler(this.view_images_Click);
            // 
            // mrz_scan
            // 
            this.mrz_scan.Activecolor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.mrz_scan.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.mrz_scan.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.mrz_scan.BorderRadius = 0;
            this.mrz_scan.ButtonText = "MRZ Scan";
            this.mrz_scan.Cursor = System.Windows.Forms.Cursors.Hand;
            this.mrz_scan.Iconcolor = System.Drawing.Color.Transparent;
            this.mrz_scan.Iconimage = ((System.Drawing.Image)(resources.GetObject("mrz_scan.Iconimage")));
            this.mrz_scan.Iconimage_right = null;
            this.mrz_scan.Iconimage_right_Selected = null;
            this.mrz_scan.Iconimage_Selected = null;
            this.mrz_scan.IconZoom = 90D;
            this.mrz_scan.IsTab = false;
            this.mrz_scan.Location = new System.Drawing.Point(-16, -1);
            this.mrz_scan.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.mrz_scan.Name = "mrz_scan";
            this.mrz_scan.Normalcolor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.mrz_scan.OnHovercolor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.mrz_scan.OnHoverTextColor = System.Drawing.Color.White;
            this.mrz_scan.selected = false;
            this.mrz_scan.Size = new System.Drawing.Size(255, 87);
            this.mrz_scan.TabIndex = 44;
            this.mrz_scan.Textcolor = System.Drawing.Color.White;
            this.mrz_scan.TextFont = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mrz_scan.Click += new System.EventHandler(this.mrz_scan_Click);
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.White;
            this.panel3.Location = new System.Drawing.Point(-1, 176);
            this.panel3.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(268, 2);
            this.panel3.TabIndex = 45;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.White;
            this.panel2.Location = new System.Drawing.Point(0, 84);
            this.panel2.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(268, 2);
            this.panel2.TabIndex = 45;
            // 
            // mrzScan1
            // 
            this.mrzScan1.BackColor = System.Drawing.Color.White;
            this.mrzScan1.Bitmap_ = null;
            this.mrzScan1.Location = new System.Drawing.Point(241, 57);
            this.mrzScan1.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.mrzScan1.Name = "mrzScan1";
            this.mrzScan1.Size = new System.Drawing.Size(811, 533);
            this.mrzScan1.TabIndex = 56;
            this.mrzScan1.Load += new System.EventHandler(this.mrzScan1_Load);
            // 
            // viewImages1
            // 
            this.viewImages1.BackColor = System.Drawing.Color.White;
            this.viewImages1.Location = new System.Drawing.Point(236, 57);
            this.viewImages1.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.viewImages1.Name = "viewImages1";
            this.viewImages1.Size = new System.Drawing.Size(817, 533);
            this.viewImages1.TabIndex = 58;
            // 
            // rfidScan1
            // 
            this.rfidScan1.BackColor = System.Drawing.Color.White;
            this.rfidScan1.Location = new System.Drawing.Point(236, 57);
            this.rfidScan1.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.rfidScan1.Name = "rfidScan1";
            this.rfidScan1.Size = new System.Drawing.Size(817, 533);
            this.rfidScan1.TabIndex = 57;
            // 
            // is_flagged
            // 
            this.is_flagged.AutoSize = true;
            this.is_flagged.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Bold);
            this.is_flagged.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(140)))), ((int)(((byte)(0)))));
            this.is_flagged.Location = new System.Drawing.Point(809, 4);
            this.is_flagged.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.is_flagged.Name = "is_flagged";
            this.is_flagged.Size = new System.Drawing.Size(0, 26);
            this.is_flagged.TabIndex = 55;
            // 
            // profilingDetails1
            // 
            this.profilingDetails1.BackColor = System.Drawing.Color.White;
            this.profilingDetails1.Location = new System.Drawing.Point(236, 54);
            this.profilingDetails1.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.profilingDetails1.Name = "profilingDetails1";
            this.profilingDetails1.Size = new System.Drawing.Size(817, 533);
            this.profilingDetails1.TabIndex = 59;
            // 
            // ViewRecord
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1055, 590);
            this.Controls.Add(this.is_flagged);
            this.Controls.Add(this.scan_type);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.mrzScan1);
            this.Controls.Add(this.viewImages1);
            this.Controls.Add(this.rfidScan1);
            this.Controls.Add(this.profilingDetails1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ViewRecord";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.ViewRecord_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ViewRecord_KeyDown);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bunifuImageButton2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion 

        public System.Windows.Forms.Label scan_type;
        private System.Windows.Forms.Panel panel1;
        private Bunifu.Framework.UI.BunifuImageButton bunifuImageButton2;
        private System.Windows.Forms.Label label3;
        private Bunifu.Framework.UI.BunifuFlatButton rfid_scan;
        private Bunifu.Framework.UI.BunifuFlatButton view_images;
        private Bunifu.Framework.UI.BunifuFlatButton mrz_scan;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel2;
        private MRZScan mrzScan1;
        private ViewImages viewImages1;
        private RFIDScan rfidScan1;
        public System.Windows.Forms.Label is_flagged;
        private Bunifu.Framework.UI.BunifuFlatButton profilingDetails;
        private ProfilingDetails profilingDetails1;
    }
}