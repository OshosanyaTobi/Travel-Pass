namespace TravelPass
{
    partial class AddRecord
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AddRecord));
            this.label24 = new System.Windows.Forms.Label();
            this.flight_from = new System.Windows.Forms.TextBox();
            this.label25 = new System.Windows.Forms.Label();
            this.flight_to = new System.Windows.Forms.TextBox();
            this.label26 = new System.Windows.Forms.Label();
            this.final_dest = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.label27 = new System.Windows.Forms.Label();
            this.connected_tview = new System.Windows.Forms.Label();
            this.label29 = new System.Windows.Forms.Label();
            this.state_tview = new System.Windows.Forms.Label();
            this.not_connected_tview = new System.Windows.Forms.Label();
            this.label28 = new System.Windows.Forms.Label();
            this.last_event_tview = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.panel1 = new System.Windows.Forms.Panel();
            this.bunifuImageButton2 = new Bunifu.Framework.UI.BunifuImageButton();
            this.label3 = new System.Windows.Forms.Label();
            this.adjust_settings = new Bunifu.Framework.UI.BunifuFlatButton();
            this.rfid_scan = new Bunifu.Framework.UI.BunifuFlatButton();
            this.view_images = new Bunifu.Framework.UI.BunifuFlatButton();
            this.panel4 = new System.Windows.Forms.Panel();
            this.mrz_scan = new Bunifu.Framework.UI.BunifuFlatButton();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.timer2 = new System.Windows.Forms.Timer(this.components);
            this.timer3 = new System.Windows.Forms.Timer(this.components);
            this.done_scan = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.class_combo = new System.Windows.Forms.ComboBox();
            this.doc_type = new System.Windows.Forms.TextBox();
            this.cil_box = new System.Windows.Forms.NumericUpDown();
            this.label4 = new System.Windows.Forms.Label();
            this.hl_box = new System.Windows.Forms.NumericUpDown();
            this.passenger_name = new System.Windows.Forms.Label();
            this.cancel_btn = new System.Windows.Forms.Button();
            this.save_scan = new Bunifu.Framework.UI.BunifuFlatButton();
            this.mrzScan1 = new TravelPass.MRZScan();
            this.viewImages1 = new TravelPass.ViewImages();
            this.rfidScan1 = new TravelPass.RFIDScan();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bunifuImageButton2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cil_box)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.hl_box)).BeginInit();
            this.SuspendLayout();
            // 
            // label24
            // 
            this.label24.AutoSize = true;
            this.label24.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.label24.Location = new System.Drawing.Point(16, 74);
            this.label24.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(94, 20);
            this.label24.TabIndex = 35;
            this.label24.Text = "&Flight From";
            // 
            // flight_from
            // 
            this.flight_from.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.flight_from.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.flight_from.Location = new System.Drawing.Point(16, 98);
            this.flight_from.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.flight_from.Name = "flight_from";
            this.flight_from.Size = new System.Drawing.Size(219, 22);
            this.flight_from.TabIndex = 36;
            this.flight_from.TextChanged += new System.EventHandler(this.flight_from_TextChanged);
            // 
            // label25
            // 
            this.label25.AutoSize = true;
            this.label25.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.label25.Location = new System.Drawing.Point(257, 74);
            this.label25.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(74, 20);
            this.label25.TabIndex = 35;
            this.label25.Text = "&Flight To";
            // 
            // flight_to
            // 
            this.flight_to.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.flight_to.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.flight_to.Location = new System.Drawing.Point(261, 98);
            this.flight_to.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.flight_to.Name = "flight_to";
            this.flight_to.Size = new System.Drawing.Size(219, 22);
            this.flight_to.TabIndex = 36;
            // 
            // label26
            // 
            this.label26.AutoSize = true;
            this.label26.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.label26.Location = new System.Drawing.Point(503, 74);
            this.label26.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label26.Name = "label26";
            this.label26.Size = new System.Drawing.Size(135, 20);
            this.label26.TabIndex = 35;
            this.label26.Text = "&Final Destination";
            // 
            // final_dest
            // 
            this.final_dest.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.final_dest.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.final_dest.Location = new System.Drawing.Point(507, 98);
            this.final_dest.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.final_dest.Name = "final_dest";
            this.final_dest.Size = new System.Drawing.Size(219, 22);
            this.final_dest.TabIndex = 36;
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(150)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.button1.Font = new System.Drawing.Font("Microsoft JhengHei UI Light", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.button1.Location = new System.Drawing.Point(1233, 644);
            this.button1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(305, 43);
            this.button1.TabIndex = 40;
            this.button1.Text = "Check if flagged";
            this.button1.UseVisualStyleBackColor = false;
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(150)))));
            this.button2.Font = new System.Drawing.Font("Microsoft JhengHei UI Light", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.button2.Location = new System.Drawing.Point(1233, 708);
            this.button2.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(305, 46);
            this.button2.TabIndex = 40;
            this.button2.Text = "Add additional passport or VISA";
            this.button2.UseVisualStyleBackColor = false;
            // 
            // label27
            // 
            this.label27.AutoSize = true;
            this.label27.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label27.Location = new System.Drawing.Point(3, 7);
            this.label27.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label27.Name = "label27";
            this.label27.Size = new System.Drawing.Size(91, 17);
            this.label27.TabIndex = 41;
            this.label27.Text = "SCANNER :";
            // 
            // connected_tview
            // 
            this.connected_tview.AutoSize = true;
            this.connected_tview.BackColor = System.Drawing.Color.Green;
            this.connected_tview.ForeColor = System.Drawing.Color.White;
            this.connected_tview.Location = new System.Drawing.Point(100, 4);
            this.connected_tview.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.connected_tview.Name = "connected_tview";
            this.connected_tview.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.connected_tview.Size = new System.Drawing.Size(131, 25);
            this.connected_tview.TabIndex = 42;
            this.connected_tview.Text = "Device Connected";
            // 
            // label29
            // 
            this.label29.AutoSize = true;
            this.label29.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label29.Location = new System.Drawing.Point(257, 7);
            this.label29.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label29.Name = "label29";
            this.label29.Size = new System.Drawing.Size(151, 17);
            this.label29.TabIndex = 41;
            this.label29.Text = "SCANNER STATE : ";
            // 
            // state_tview
            // 
            this.state_tview.AutoSize = true;
            this.state_tview.BackColor = System.Drawing.Color.White;
            this.state_tview.ForeColor = System.Drawing.Color.Black;
            this.state_tview.Location = new System.Drawing.Point(416, 4);
            this.state_tview.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.state_tview.Name = "state_tview";
            this.state_tview.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.state_tview.Size = new System.Drawing.Size(8, 25);
            this.state_tview.TabIndex = 42;
            // 
            // not_connected_tview
            // 
            this.not_connected_tview.AutoSize = true;
            this.not_connected_tview.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.not_connected_tview.ForeColor = System.Drawing.Color.White;
            this.not_connected_tview.Location = new System.Drawing.Point(100, 4);
            this.not_connected_tview.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.not_connected_tview.Name = "not_connected_tview";
            this.not_connected_tview.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.not_connected_tview.Size = new System.Drawing.Size(149, 25);
            this.not_connected_tview.TabIndex = 42;
            this.not_connected_tview.Text = "Device Disconnected";
            this.not_connected_tview.Click += new System.EventHandler(this.not_connected_tview_Click);
            // 
            // label28
            // 
            this.label28.AutoSize = true;
            this.label28.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label28.Location = new System.Drawing.Point(573, 7);
            this.label28.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label28.Name = "label28";
            this.label28.Size = new System.Drawing.Size(118, 17);
            this.label28.TabIndex = 41;
            this.label28.Text = "LAST EVENT : ";
            this.label28.Visible = false;
            this.label28.Click += new System.EventHandler(this.label28_Click);
            // 
            // last_event_tview
            // 
            this.last_event_tview.AutoSize = true;
            this.last_event_tview.BackColor = System.Drawing.Color.White;
            this.last_event_tview.ForeColor = System.Drawing.Color.Black;
            this.last_event_tview.Location = new System.Drawing.Point(691, 4);
            this.last_event_tview.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.last_event_tview.Name = "last_event_tview";
            this.last_event_tview.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.last_event_tview.Size = new System.Drawing.Size(144, 25);
            this.last_event_tview.TabIndex = 42;
            this.last_event_tview.Text = "Listening to scanner";
            this.last_event_tview.Visible = false;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.panel1.Controls.Add(this.bunifuImageButton2);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.adjust_settings);
            this.panel1.Controls.Add(this.rfid_scan);
            this.panel1.Controls.Add(this.view_images);
            this.panel1.Controls.Add(this.panel4);
            this.panel1.Controls.Add(this.mrz_scan);
            this.panel1.Controls.Add(this.panel3);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Location = new System.Drawing.Point(0, 187);
            this.panel1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(237, 533);
            this.panel1.TabIndex = 43;
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
            // adjust_settings
            // 
            this.adjust_settings.Activecolor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.adjust_settings.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.adjust_settings.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.adjust_settings.BorderRadius = 0;
            this.adjust_settings.ButtonText = "RFID Settings";
            this.adjust_settings.Cursor = System.Windows.Forms.Cursors.Hand;
            this.adjust_settings.Iconcolor = System.Drawing.Color.Transparent;
            this.adjust_settings.Iconimage = ((System.Drawing.Image)(resources.GetObject("adjust_settings.Iconimage")));
            this.adjust_settings.Iconimage_right = null;
            this.adjust_settings.Iconimage_right_Selected = null;
            this.adjust_settings.Iconimage_Selected = null;
            this.adjust_settings.IconZoom = 90D;
            this.adjust_settings.IsTab = false;
            this.adjust_settings.Location = new System.Drawing.Point(-15, 258);
            this.adjust_settings.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.adjust_settings.Name = "adjust_settings";
            this.adjust_settings.Normalcolor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.adjust_settings.OnHovercolor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.adjust_settings.OnHoverTextColor = System.Drawing.Color.White;
            this.adjust_settings.selected = false;
            this.adjust_settings.Size = new System.Drawing.Size(253, 84);
            this.adjust_settings.TabIndex = 44;
            this.adjust_settings.Textcolor = System.Drawing.Color.White;
            this.adjust_settings.TextFont = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.adjust_settings.Click += new System.EventHandler(this.adjust_settings_Click);
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
            this.rfid_scan.Location = new System.Drawing.Point(-16, 171);
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
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.White;
            this.panel4.Location = new System.Drawing.Point(-1, 268);
            this.panel4.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(268, 2);
            this.panel4.TabIndex = 45;
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
            // done_scan
            // 
            this.done_scan.BackColor = System.Drawing.Color.White;
            this.done_scan.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.done_scan.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.done_scan.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.done_scan.Location = new System.Drawing.Point(811, 4);
            this.done_scan.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.done_scan.Name = "done_scan";
            this.done_scan.Size = new System.Drawing.Size(236, 48);
            this.done_scan.TabIndex = 49;
            this.done_scan.Text = "DONE";
            this.done_scan.UseVisualStyleBackColor = false;
            this.done_scan.Click += new System.EventHandler(this.done_scan_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.label1.Location = new System.Drawing.Point(712, 133);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(143, 20);
            this.label1.TabIndex = 35;
            this.label1.Text = "&Check In Luggage";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.label2.Location = new System.Drawing.Point(748, 74);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(98, 20);
            this.label2.TabIndex = 35;
            this.label2.Text = "&Flight Class";
            // 
            // class_combo
            // 
            this.class_combo.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.class_combo.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.class_combo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.class_combo.FormattingEnabled = true;
            this.class_combo.Items.AddRange(new object[] {
            "Upper",
            "Premium Economy",
            "Economy"});
            this.class_combo.Location = new System.Drawing.Point(752, 95);
            this.class_combo.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.class_combo.Name = "class_combo";
            this.class_combo.Size = new System.Drawing.Size(219, 26);
            this.class_combo.TabIndex = 51;
            this.class_combo.Text = "Business";
            this.class_combo.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // doc_type
            // 
            this.doc_type.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.doc_type.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.doc_type.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold);
            this.doc_type.Location = new System.Drawing.Point(16, 145);
            this.doc_type.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.doc_type.Name = "doc_type";
            this.doc_type.Size = new System.Drawing.Size(513, 34);
            this.doc_type.TabIndex = 52;
            // 
            // cil_box
            // 
            this.cil_box.Location = new System.Drawing.Point(716, 155);
            this.cil_box.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cil_box.Name = "cil_box";
            this.cil_box.Size = new System.Drawing.Size(160, 22);
            this.cil_box.TabIndex = 53;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.label4.Location = new System.Drawing.Point(533, 133);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(118, 20);
            this.label4.TabIndex = 35;
            this.label4.Text = "&Hand Luggage";
            // 
            // hl_box
            // 
            this.hl_box.Location = new System.Drawing.Point(537, 155);
            this.hl_box.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.hl_box.Name = "hl_box";
            this.hl_box.Size = new System.Drawing.Size(160, 22);
            this.hl_box.TabIndex = 53;
            // 
            // passenger_name
            // 
            this.passenger_name.AutoSize = true;
            this.passenger_name.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Bold);
            this.passenger_name.Location = new System.Drawing.Point(9, 36);
            this.passenger_name.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.passenger_name.Name = "passenger_name";
            this.passenger_name.Size = new System.Drawing.Size(0, 31);
            this.passenger_name.TabIndex = 54;
            this.passenger_name.Visible = false;
            // 
            // cancel_btn
            // 
            this.cancel_btn.BackColor = System.Drawing.Color.White;
            this.cancel_btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cancel_btn.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.cancel_btn.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.cancel_btn.Location = new System.Drawing.Point(913, 133);
            this.cancel_btn.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cancel_btn.Name = "cancel_btn";
            this.cancel_btn.Size = new System.Drawing.Size(133, 47);
            this.cancel_btn.TabIndex = 49;
            this.cancel_btn.Text = "CANCEL";
            this.cancel_btn.UseVisualStyleBackColor = false;
            this.cancel_btn.Click += new System.EventHandler(this.cancel_scan_Click);
            // 
            // save_scan
            // 
            this.save_scan.Activecolor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(90)))), ((int)(((byte)(0)))));
            this.save_scan.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.save_scan.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.save_scan.BorderRadius = 0;
            this.save_scan.ButtonText = "ADD";
            this.save_scan.Cursor = System.Windows.Forms.Cursors.Hand;
            this.save_scan.Iconcolor = System.Drawing.Color.Transparent;
            this.save_scan.Iconimage = ((System.Drawing.Image)(resources.GetObject("save_scan.Iconimage")));
            this.save_scan.Iconimage_right = null;
            this.save_scan.Iconimage_right_Selected = null;
            this.save_scan.Iconimage_Selected = null;
            this.save_scan.IconZoom = 90D;
            this.save_scan.IsTab = false;
            this.save_scan.Location = new System.Drawing.Point(764, 138);
            this.save_scan.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.save_scan.Name = "save_scan";
            this.save_scan.Normalcolor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.save_scan.OnHovercolor = System.Drawing.Color.DarkGreen;
            this.save_scan.OnHoverTextColor = System.Drawing.Color.White;
            this.save_scan.selected = false;
            this.save_scan.Size = new System.Drawing.Size(140, 41);
            this.save_scan.TabIndex = 44;
            this.save_scan.Textcolor = System.Drawing.Color.White;
            this.save_scan.TextFont = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.save_scan.Visible = false;
            this.save_scan.Click += new System.EventHandler(this.save_scan_Click);
            // 
            // mrzScan1
            // 
            this.mrzScan1.BackColor = System.Drawing.Color.White;
            this.mrzScan1.Bitmap_ = null;
            this.mrzScan1.Location = new System.Drawing.Point(241, 186);
            this.mrzScan1.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.mrzScan1.Name = "mrzScan1";
            this.mrzScan1.Size = new System.Drawing.Size(827, 533);
            this.mrzScan1.TabIndex = 46;
            // 
            // viewImages1
            // 
            this.viewImages1.BackColor = System.Drawing.Color.White;
            this.viewImages1.Location = new System.Drawing.Point(236, 188);
            this.viewImages1.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.viewImages1.Name = "viewImages1";
            this.viewImages1.Size = new System.Drawing.Size(832, 533);
            this.viewImages1.TabIndex = 48;
            // 
            // rfidScan1
            // 
            this.rfidScan1.BackColor = System.Drawing.Color.White;
            this.rfidScan1.Location = new System.Drawing.Point(236, 188);
            this.rfidScan1.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.rfidScan1.Name = "rfidScan1";
            this.rfidScan1.Size = new System.Drawing.Size(811, 533);
            this.rfidScan1.TabIndex = 47;
            // 
            // AddRecord
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1084, 720);
            this.Controls.Add(this.passenger_name);
            this.Controls.Add(this.hl_box);
            this.Controls.Add(this.cil_box);
            this.Controls.Add(this.doc_type);
            this.Controls.Add(this.class_combo);
            this.Controls.Add(this.cancel_btn);
            this.Controls.Add(this.done_scan);
            this.Controls.Add(this.save_scan);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.last_event_tview);
            this.Controls.Add(this.state_tview);
            this.Controls.Add(this.not_connected_tview);
            this.Controls.Add(this.label28);
            this.Controls.Add(this.label29);
            this.Controls.Add(this.connected_tview);
            this.Controls.Add(this.label27);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.final_dest);
            this.Controls.Add(this.flight_to);
            this.Controls.Add(this.flight_from);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label26);
            this.Controls.Add(this.label25);
            this.Controls.Add(this.label24);
            this.Controls.Add(this.mrzScan1);
            this.Controls.Add(this.viewImages1);
            this.Controls.Add(this.rfidScan1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AddRecord";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Add Record";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.AddRecord_FormClosing);
            this.Load += new System.EventHandler(this.AddRecord_Load);
            this.Shown += new System.EventHandler(this.AddRecord_Shown);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.AddRecord_KeyDown);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bunifuImageButton2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cil_box)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.hl_box)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label24;
        private System.Windows.Forms.TextBox flight_from;
        private System.Windows.Forms.Label label25;
        private System.Windows.Forms.TextBox flight_to;
        private System.Windows.Forms.Label label26;
        private System.Windows.Forms.TextBox final_dest;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label label27;
        private System.Windows.Forms.Label connected_tview;
        private System.Windows.Forms.Label label29;
        private System.Windows.Forms.Label state_tview;
        private System.Windows.Forms.Label not_connected_tview;
        private System.Windows.Forms.Label label28;
        private System.Windows.Forms.Label last_event_tview;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Panel panel1;
        private Bunifu.Framework.UI.BunifuFlatButton view_images;
        private Bunifu.Framework.UI.BunifuFlatButton mrz_scan;
        private Bunifu.Framework.UI.BunifuFlatButton save_scan;
        private Bunifu.Framework.UI.BunifuFlatButton adjust_settings;
        private Bunifu.Framework.UI.BunifuFlatButton rfid_scan;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel2;
        private Bunifu.Framework.UI.BunifuImageButton bunifuImageButton2;
        private System.Windows.Forms.Label label3;
        private MRZScan mrzScan1;
        private RFIDScan rfidScan1;
        private ViewImages viewImages1;
        private System.Windows.Forms.Timer timer2;
        private System.Windows.Forms.Timer timer3;
        private System.Windows.Forms.Button done_scan;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        public System.Windows.Forms.ComboBox class_combo;
        private System.Windows.Forms.TextBox doc_type;
        private System.Windows.Forms.NumericUpDown cil_box;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.NumericUpDown hl_box;
        private System.Windows.Forms.Label passenger_name;
        private System.Windows.Forms.Button cancel_btn;
    }
}