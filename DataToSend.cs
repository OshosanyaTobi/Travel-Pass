using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace TravelPass
{  
	public partial class DataToSend : Form
	{
		private System.Windows.Forms.GroupBox OpticalDataBox;
		private System.Windows.Forms.GroupBox PluginsBox;
		private System.Windows.Forms.GroupBox OtherBox;
		private System.Windows.Forms.CheckBox UVImageOption;
		private System.Windows.Forms.CheckBox PhotoImageOption;
		private System.Windows.Forms.CheckBox VisibleImageOption;
		private System.Windows.Forms.CheckBox IRImageOption;
		private System.Windows.Forms.CheckBox SecurityCheckOption;
		private System.Windows.Forms.CheckBox ChecksumOption;
		private System.Windows.Forms.CheckBox CodelineOption;
		private System.Windows.Forms.CheckBox ColourOption;
		private System.Windows.Forms.CheckBox CroppedToCodelineOption;
		private System.Windows.Forms.CheckBox CheckUVOption;
		private System.Windows.Forms.Button MovePluginRightButton;
		private System.Windows.Forms.Button MovePluginLeftButton;
		private System.Windows.Forms.ListBox SelectedPluginList;
		private System.Windows.Forms.ListBox AvailablePluginList;
		private System.Windows.Forms.Label SelectedLabel;
		private System.Windows.Forms.Label AvailableLabel;
		private System.Windows.Forms.CheckBox SendBarcodeImageOption;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.ListBox RFIDAvailDataItems;
		public System.Windows.Forms.ListBox RFIDSelectDataItems;
		public System.Windows.Forms.CheckBox RFIDOption;
		private System.Windows.Forms.CheckBox ShowProgressOption;
		private System.Windows.Forms.Button CancelButton;
		private System.Windows.Forms.Button OKButton;
		private System.Windows.Forms.Button RFIDDeselectAllButton;
		private System.Windows.Forms.Button RFIDDeselectButton;
		private System.Windows.Forms.Button RFIDSelectAllButton;
		private System.Windows.Forms.Button RFIDSelectButton;
		private System.Windows.Forms.CheckBox UHFOption;
		private System.Windows.Forms.GroupBox UHFGroupBox;
		private Button UHFDeselectAllButton;
		private Button UHFDeselectButton;
		private Button UHFSelectAllButton;
		private Button UHFSelectButton;
		private Label label3;
		private Label label4;
		private ListBox UHFAvailDataItems;
		private ListBox UHFSelectDataItems;
		private Label label5;
        private Label label6;
        private ComboBox ImageFormatCombo;
        private Label label7;
        private CheckBox AAMVAOption;
        private CheckBox MSRDataOption;
        private Label ScaleFactorLabel;
        private TrackBar ScaleFactorTrackBar;
        private int ReaderMaxDpi;
        private GroupBox groupBox1;
        private CheckBox IRSequentialOption;
        private CheckBox IRAntiGlareOption;
        private ComboBox IRAmbientRemovalOption;
        private GroupBox groupBox2;
        private CheckBox VisibleSequentialOption;
        private CheckBox VisibleAntiGlareOption;
        private ComboBox VisibleAmbientRemovalOption;
        private GroupBox groupBox3;
        private ComboBox UVAmbientRemovalOption;
        private CheckBox ActiveReaderOption;
        private CheckBox ActiveVideoOption;
        private CheckBox UseVisibleForBarcodeOption;
        private CheckBox checkBoxEDL;
        private CheckBox checkBoxEID;
        public CheckBox checkBoxEPASSPORT;
        private CheckBox checkBoxIDL;
        public Button ok_save;
        private Button _cancel;

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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DataToSend));
            this.OpticalDataBox = new System.Windows.Forms.GroupBox();
            this.ActiveReaderOption = new System.Windows.Forms.CheckBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.IRSequentialOption = new System.Windows.Forms.CheckBox();
            this.IRAntiGlareOption = new System.Windows.Forms.CheckBox();
            this.IRAmbientRemovalOption = new System.Windows.Forms.ComboBox();
            this.IRImageOption = new System.Windows.Forms.CheckBox();
            this.OKButton = new System.Windows.Forms.Button();
            this.CancelButton = new System.Windows.Forms.Button();
            this.ActiveVideoOption = new System.Windows.Forms.CheckBox();
            this.ScaleFactorLabel = new System.Windows.Forms.Label();
            this.ScaleFactorTrackBar = new System.Windows.Forms.TrackBar();
            this.AAMVAOption = new System.Windows.Forms.CheckBox();
            this.MSRDataOption = new System.Windows.Forms.CheckBox();
            this.ImageFormatCombo = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.ColourOption = new System.Windows.Forms.CheckBox();
            this.CroppedToCodelineOption = new System.Windows.Forms.CheckBox();
            this.CheckUVOption = new System.Windows.Forms.CheckBox();
            this.PhotoImageOption = new System.Windows.Forms.CheckBox();
            this.SecurityCheckOption = new System.Windows.Forms.CheckBox();
            this.ChecksumOption = new System.Windows.Forms.CheckBox();
            this.CodelineOption = new System.Windows.Forms.CheckBox();
            this.UVImageOption = new System.Windows.Forms.CheckBox();
            this.VisibleImageOption = new System.Windows.Forms.CheckBox();
            this.PluginsBox = new System.Windows.Forms.GroupBox();
            this.UseVisibleForBarcodeOption = new System.Windows.Forms.CheckBox();
            this.SendBarcodeImageOption = new System.Windows.Forms.CheckBox();
            this.SelectedLabel = new System.Windows.Forms.Label();
            this.AvailableLabel = new System.Windows.Forms.Label();
            this.MovePluginRightButton = new System.Windows.Forms.Button();
            this.MovePluginLeftButton = new System.Windows.Forms.Button();
            this.SelectedPluginList = new System.Windows.Forms.ListBox();
            this.AvailablePluginList = new System.Windows.Forms.ListBox();
            this.OtherBox = new System.Windows.Forms.GroupBox();
            this.checkBoxIDL = new System.Windows.Forms.CheckBox();
            this.checkBoxEDL = new System.Windows.Forms.CheckBox();
            this.checkBoxEID = new System.Windows.Forms.CheckBox();
            this.checkBoxEPASSPORT = new System.Windows.Forms.CheckBox();
            this.RFIDDeselectAllButton = new System.Windows.Forms.Button();
            this.RFIDDeselectButton = new System.Windows.Forms.Button();
            this.RFIDSelectAllButton = new System.Windows.Forms.Button();
            this.RFIDSelectButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.RFIDAvailDataItems = new System.Windows.Forms.ListBox();
            this.RFIDSelectDataItems = new System.Windows.Forms.ListBox();
            this.RFIDOption = new System.Windows.Forms.CheckBox();
            this.ShowProgressOption = new System.Windows.Forms.CheckBox();
            this.UHFOption = new System.Windows.Forms.CheckBox();
            this.UHFGroupBox = new System.Windows.Forms.GroupBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.UHFDeselectAllButton = new System.Windows.Forms.Button();
            this.UHFDeselectButton = new System.Windows.Forms.Button();
            this.UHFSelectAllButton = new System.Windows.Forms.Button();
            this.UHFSelectButton = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.UHFAvailDataItems = new System.Windows.Forms.ListBox();
            this.UHFSelectDataItems = new System.Windows.Forms.ListBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.VisibleSequentialOption = new System.Windows.Forms.CheckBox();
            this.VisibleAntiGlareOption = new System.Windows.Forms.CheckBox();
            this.VisibleAmbientRemovalOption = new System.Windows.Forms.ComboBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.UVAmbientRemovalOption = new System.Windows.Forms.ComboBox();
            this.ok_save = new System.Windows.Forms.Button();
            this._cancel = new System.Windows.Forms.Button();
            this.OpticalDataBox.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ScaleFactorTrackBar)).BeginInit();
            this.PluginsBox.SuspendLayout();
            this.OtherBox.SuspendLayout();
            this.UHFGroupBox.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // OpticalDataBox
            // 
            this.OpticalDataBox.Controls.Add(this.ActiveReaderOption);
            this.OpticalDataBox.Controls.Add(this.groupBox1);
            this.OpticalDataBox.Controls.Add(this.ActiveVideoOption);
            this.OpticalDataBox.Controls.Add(this.ScaleFactorLabel);
            this.OpticalDataBox.Controls.Add(this.ScaleFactorTrackBar);
            this.OpticalDataBox.Controls.Add(this.AAMVAOption);
            this.OpticalDataBox.Controls.Add(this.MSRDataOption);
            this.OpticalDataBox.Controls.Add(this.ImageFormatCombo);
            this.OpticalDataBox.Controls.Add(this.label7);
            this.OpticalDataBox.Controls.Add(this.ColourOption);
            this.OpticalDataBox.Controls.Add(this.CroppedToCodelineOption);
            this.OpticalDataBox.Controls.Add(this.CheckUVOption);
            this.OpticalDataBox.Controls.Add(this.PhotoImageOption);
            this.OpticalDataBox.Controls.Add(this.SecurityCheckOption);
            this.OpticalDataBox.Controls.Add(this.ChecksumOption);
            this.OpticalDataBox.Controls.Add(this.CodelineOption);
            this.OpticalDataBox.Location = new System.Drawing.Point(445, 237);
            this.OpticalDataBox.Name = "OpticalDataBox";
            this.OpticalDataBox.Size = new System.Drawing.Size(403, 176);
            this.OpticalDataBox.TabIndex = 0;
            this.OpticalDataBox.TabStop = false;
            this.OpticalDataBox.Visible = false;
            // 
            // ActiveReaderOption
            // 
            this.ActiveReaderOption.AutoSize = true;
            this.ActiveReaderOption.Location = new System.Drawing.Point(123, 61);
            this.ActiveReaderOption.Name = "ActiveReaderOption";
            this.ActiveReaderOption.Size = new System.Drawing.Size(94, 17);
            this.ActiveReaderOption.TabIndex = 17;
            this.ActiveReaderOption.Text = "Active Reader";
            this.ActiveReaderOption.UseVisualStyleBackColor = true;
            this.ActiveReaderOption.CheckedChanged += new System.EventHandler(this.ActiveReaderOption_Checked);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.IRSequentialOption);
            this.groupBox1.Controls.Add(this.IRAntiGlareOption);
            this.groupBox1.Controls.Add(this.IRAmbientRemovalOption);
            this.groupBox1.Controls.Add(this.IRImageOption);
            this.groupBox1.Controls.Add(this.OKButton);
            this.groupBox1.Controls.Add(this.CancelButton);
            this.groupBox1.Location = new System.Drawing.Point(0, 146);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(403, 70);
            this.groupBox1.TabIndex = 14;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Infra Red";
            this.groupBox1.Visible = false;
            // 
            // IRSequentialOption
            // 
            this.IRSequentialOption.AutoSize = true;
            this.IRSequentialOption.Location = new System.Drawing.Point(259, 44);
            this.IRSequentialOption.Name = "IRSequentialOption";
            this.IRSequentialOption.Size = new System.Drawing.Size(90, 17);
            this.IRSequentialOption.TabIndex = 12;
            this.IRSequentialOption.Text = "IR Sequential";
            this.IRSequentialOption.UseVisualStyleBackColor = true;
            // 
            // IRAntiGlareOption
            // 
            this.IRAntiGlareOption.AutoSize = true;
            this.IRAntiGlareOption.Location = new System.Drawing.Point(117, 43);
            this.IRAntiGlareOption.Name = "IRAntiGlareOption";
            this.IRAntiGlareOption.Size = new System.Drawing.Size(86, 17);
            this.IRAntiGlareOption.TabIndex = 11;
            this.IRAntiGlareOption.Text = "IR Anti-Glare";
            this.IRAntiGlareOption.UseVisualStyleBackColor = true;
            // 
            // IRAmbientRemovalOption
            // 
            this.IRAmbientRemovalOption.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.IRAmbientRemovalOption.FormattingEnabled = true;
            this.IRAmbientRemovalOption.Location = new System.Drawing.Point(117, 16);
            this.IRAmbientRemovalOption.Name = "IRAmbientRemovalOption";
            this.IRAmbientRemovalOption.Size = new System.Drawing.Size(276, 21);
            this.IRAmbientRemovalOption.TabIndex = 9;
            // 
            // IRImageOption
            // 
            this.IRImageOption.AutoSize = true;
            this.IRImageOption.Location = new System.Drawing.Point(6, 18);
            this.IRImageOption.Name = "IRImageOption";
            this.IRImageOption.Size = new System.Drawing.Size(69, 17);
            this.IRImageOption.TabIndex = 3;
            this.IRImageOption.Text = "IR Image";
            this.IRImageOption.UseVisualStyleBackColor = true;
            // 
            // OKButton
            // 
            this.OKButton.Location = new System.Drawing.Point(188, 273);
            this.OKButton.Name = "OKButton";
            this.OKButton.Size = new System.Drawing.Size(89, 25);
            this.OKButton.TabIndex = 11;
            this.OKButton.Text = "OK";
            this.OKButton.UseVisualStyleBackColor = true;
            this.OKButton.Click += new System.EventHandler(this.OKButton_Click);
            // 
            // CancelButton
            // 
            this.CancelButton.Location = new System.Drawing.Point(283, 273);
            this.CancelButton.Name = "CancelButton";
            this.CancelButton.Size = new System.Drawing.Size(90, 25);
            this.CancelButton.TabIndex = 10;
            this.CancelButton.Text = "Cancel";
            this.CancelButton.UseVisualStyleBackColor = true;
            this.CancelButton.Click += new System.EventHandler(this.CancelButton_Click);
            // 
            // ActiveVideoOption
            // 
            this.ActiveVideoOption.AutoSize = true;
            this.ActiveVideoOption.Location = new System.Drawing.Point(6, 61);
            this.ActiveVideoOption.Name = "ActiveVideoOption";
            this.ActiveVideoOption.Size = new System.Drawing.Size(86, 17);
            this.ActiveVideoOption.TabIndex = 15;
            this.ActiveVideoOption.Text = "Active Video";
            this.ActiveVideoOption.UseVisualStyleBackColor = true;
            this.ActiveVideoOption.CheckedChanged += new System.EventHandler(this.ActiveVideoOption_Checked);
            // 
            // ScaleFactorLabel
            // 
            this.ScaleFactorLabel.AutoSize = true;
            this.ScaleFactorLabel.BackColor = System.Drawing.SystemColors.Control;
            this.ScaleFactorLabel.Location = new System.Drawing.Point(129, 103);
            this.ScaleFactorLabel.Name = "ScaleFactorLabel";
            this.ScaleFactorLabel.Size = new System.Drawing.Size(70, 13);
            this.ScaleFactorLabel.TabIndex = 16;
            this.ScaleFactorLabel.Text = "Scale Factor:";
            // 
            // ScaleFactorTrackBar
            // 
            this.ScaleFactorTrackBar.Location = new System.Drawing.Point(123, 119);
            this.ScaleFactorTrackBar.Maximum = 100;
            this.ScaleFactorTrackBar.Minimum = 20;
            this.ScaleFactorTrackBar.Name = "ScaleFactorTrackBar";
            this.ScaleFactorTrackBar.Size = new System.Drawing.Size(174, 45);
            this.ScaleFactorTrackBar.TabIndex = 15;
            this.ScaleFactorTrackBar.TickFrequency = 10;
            this.ScaleFactorTrackBar.Value = 100;
            this.ScaleFactorTrackBar.ValueChanged += new System.EventHandler(this.ScaleFactorTrackBar_ValueChanged);
            // 
            // AAMVAOption
            // 
            this.AAMVAOption.AutoSize = true;
            this.AAMVAOption.Location = new System.Drawing.Point(6, 107);
            this.AAMVAOption.Name = "AAMVAOption";
            this.AAMVAOption.Size = new System.Drawing.Size(63, 17);
            this.AAMVAOption.TabIndex = 14;
            this.AAMVAOption.Text = "AAMVA";
            this.AAMVAOption.UseVisualStyleBackColor = true;
            // 
            // MSRDataOption
            // 
            this.MSRDataOption.AutoSize = true;
            this.MSRDataOption.Location = new System.Drawing.Point(6, 84);
            this.MSRDataOption.Name = "MSRDataOption";
            this.MSRDataOption.Size = new System.Drawing.Size(76, 17);
            this.MSRDataOption.TabIndex = 13;
            this.MSRDataOption.Text = "MSR Data";
            this.MSRDataOption.UseVisualStyleBackColor = true;
            // 
            // ImageFormatCombo
            // 
            this.ImageFormatCombo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ImageFormatCombo.FormattingEnabled = true;
            this.ImageFormatCombo.Location = new System.Drawing.Point(6, 143);
            this.ImageFormatCombo.Name = "ImageFormatCombo";
            this.ImageFormatCombo.Size = new System.Drawing.Size(86, 21);
            this.ImageFormatCombo.TabIndex = 11;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(3, 127);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(74, 13);
            this.label7.TabIndex = 10;
            this.label7.Text = "Image Format:";
            // 
            // ColourOption
            // 
            this.ColourOption.AutoSize = true;
            this.ColourOption.Location = new System.Drawing.Point(6, 38);
            this.ColourOption.Name = "ColourOption";
            this.ColourOption.Size = new System.Drawing.Size(56, 17);
            this.ColourOption.TabIndex = 9;
            this.ColourOption.Text = "Colour";
            this.ColourOption.UseVisualStyleBackColor = true;
            // 
            // CroppedToCodelineOption
            // 
            this.CroppedToCodelineOption.AutoSize = true;
            this.CroppedToCodelineOption.Location = new System.Drawing.Point(123, 38);
            this.CroppedToCodelineOption.Name = "CroppedToCodelineOption";
            this.CroppedToCodelineOption.Size = new System.Drawing.Size(121, 17);
            this.CroppedToCodelineOption.TabIndex = 8;
            this.CroppedToCodelineOption.Text = "Cropped to codeline";
            this.CroppedToCodelineOption.UseVisualStyleBackColor = true;
            // 
            // CheckUVOption
            // 
            this.CheckUVOption.AutoSize = true;
            this.CheckUVOption.Location = new System.Drawing.Point(265, 38);
            this.CheckUVOption.Name = "CheckUVOption";
            this.CheckUVOption.Size = new System.Drawing.Size(116, 17);
            this.CheckUVOption.TabIndex = 7;
            this.CheckUVOption.Text = "UV Security Check";
            this.CheckUVOption.UseVisualStyleBackColor = true;
            // 
            // PhotoImageOption
            // 
            this.PhotoImageOption.AutoSize = true;
            this.PhotoImageOption.Location = new System.Drawing.Point(265, 61);
            this.PhotoImageOption.Name = "PhotoImageOption";
            this.PhotoImageOption.Size = new System.Drawing.Size(86, 17);
            this.PhotoImageOption.TabIndex = 5;
            this.PhotoImageOption.Text = "Photo Image";
            this.PhotoImageOption.UseVisualStyleBackColor = true;
            // 
            // SecurityCheckOption
            // 
            this.SecurityCheckOption.AutoSize = true;
            this.SecurityCheckOption.Location = new System.Drawing.Point(265, 15);
            this.SecurityCheckOption.Name = "SecurityCheckOption";
            this.SecurityCheckOption.Size = new System.Drawing.Size(98, 17);
            this.SecurityCheckOption.TabIndex = 2;
            this.SecurityCheckOption.Text = "Security Check";
            this.SecurityCheckOption.UseVisualStyleBackColor = true;
            // 
            // ChecksumOption
            // 
            this.ChecksumOption.AutoSize = true;
            this.ChecksumOption.Location = new System.Drawing.Point(123, 15);
            this.ChecksumOption.Name = "ChecksumOption";
            this.ChecksumOption.Size = new System.Drawing.Size(120, 17);
            this.ChecksumOption.TabIndex = 1;
            this.ChecksumOption.Text = "Codeline Checksum";
            this.ChecksumOption.UseVisualStyleBackColor = true;
            // 
            // CodelineOption
            // 
            this.CodelineOption.AutoSize = true;
            this.CodelineOption.Location = new System.Drawing.Point(6, 15);
            this.CodelineOption.Name = "CodelineOption";
            this.CodelineOption.Size = new System.Drawing.Size(67, 17);
            this.CodelineOption.TabIndex = 0;
            this.CodelineOption.Text = "Codeline";
            this.CodelineOption.UseVisualStyleBackColor = true;
            // 
            // UVImageOption
            // 
            this.UVImageOption.AutoSize = true;
            this.UVImageOption.Location = new System.Drawing.Point(6, 17);
            this.UVImageOption.Name = "UVImageOption";
            this.UVImageOption.Size = new System.Drawing.Size(73, 17);
            this.UVImageOption.TabIndex = 6;
            this.UVImageOption.Text = "UV Image";
            this.UVImageOption.UseVisualStyleBackColor = true;
            // 
            // VisibleImageOption
            // 
            this.VisibleImageOption.AutoSize = true;
            this.VisibleImageOption.Location = new System.Drawing.Point(6, 19);
            this.VisibleImageOption.Name = "VisibleImageOption";
            this.VisibleImageOption.Size = new System.Drawing.Size(88, 17);
            this.VisibleImageOption.TabIndex = 4;
            this.VisibleImageOption.Text = "Visible Image";
            this.VisibleImageOption.UseVisualStyleBackColor = true;
            // 
            // PluginsBox
            // 
            this.PluginsBox.Controls.Add(this.UseVisibleForBarcodeOption);
            this.PluginsBox.Controls.Add(this.SendBarcodeImageOption);
            this.PluginsBox.Controls.Add(this.SelectedLabel);
            this.PluginsBox.Controls.Add(this.AvailableLabel);
            this.PluginsBox.Controls.Add(this.MovePluginRightButton);
            this.PluginsBox.Controls.Add(this.MovePluginLeftButton);
            this.PluginsBox.Controls.Add(this.SelectedPluginList);
            this.PluginsBox.Controls.Add(this.AvailablePluginList);
            this.PluginsBox.Location = new System.Drawing.Point(12, 383);
            this.PluginsBox.Name = "PluginsBox";
            this.PluginsBox.Size = new System.Drawing.Size(335, 138);
            this.PluginsBox.TabIndex = 1;
            this.PluginsBox.TabStop = false;
            this.PluginsBox.Text = "Plugins";
            this.PluginsBox.Visible = false;
            // 
            // UseVisibleForBarcodeOption
            // 
            this.UseVisibleForBarcodeOption.AutoSize = true;
            this.UseVisibleForBarcodeOption.Location = new System.Drawing.Point(185, 118);
            this.UseVisibleForBarcodeOption.Name = "UseVisibleForBarcodeOption";
            this.UseVisibleForBarcodeOption.Size = new System.Drawing.Size(139, 17);
            this.UseVisibleForBarcodeOption.TabIndex = 9;
            this.UseVisibleForBarcodeOption.Text = "Use Visible For Barcode";
            this.UseVisibleForBarcodeOption.UseVisualStyleBackColor = true;
            // 
            // SendBarcodeImageOption
            // 
            this.SendBarcodeImageOption.AutoSize = true;
            this.SendBarcodeImageOption.Location = new System.Drawing.Point(6, 118);
            this.SendBarcodeImageOption.Name = "SendBarcodeImageOption";
            this.SendBarcodeImageOption.Size = new System.Drawing.Size(126, 17);
            this.SendBarcodeImageOption.TabIndex = 8;
            this.SendBarcodeImageOption.Text = "Send Barcode Image";
            this.SendBarcodeImageOption.UseVisualStyleBackColor = true;
            // 
            // SelectedLabel
            // 
            this.SelectedLabel.AutoSize = true;
            this.SelectedLabel.BackColor = System.Drawing.Color.Transparent;
            this.SelectedLabel.Location = new System.Drawing.Point(228, 17);
            this.SelectedLabel.Name = "SelectedLabel";
            this.SelectedLabel.Size = new System.Drawing.Size(49, 13);
            this.SelectedLabel.TabIndex = 7;
            this.SelectedLabel.Text = "Selected";
            // 
            // AvailableLabel
            // 
            this.AvailableLabel.AutoSize = true;
            this.AvailableLabel.BackColor = System.Drawing.Color.Transparent;
            this.AvailableLabel.Location = new System.Drawing.Point(38, 17);
            this.AvailableLabel.Name = "AvailableLabel";
            this.AvailableLabel.Size = new System.Drawing.Size(50, 13);
            this.AvailableLabel.TabIndex = 6;
            this.AvailableLabel.Text = "Available";
            // 
            // MovePluginRightButton
            // 
            this.MovePluginRightButton.Location = new System.Drawing.Point(155, 73);
            this.MovePluginRightButton.Name = "MovePluginRightButton";
            this.MovePluginRightButton.Size = new System.Drawing.Size(24, 22);
            this.MovePluginRightButton.TabIndex = 3;
            this.MovePluginRightButton.Text = ">";
            this.MovePluginRightButton.UseVisualStyleBackColor = true;
            this.MovePluginRightButton.Click += new System.EventHandler(this.MovePluginRightButton_Click);
            // 
            // MovePluginLeftButton
            // 
            this.MovePluginLeftButton.Location = new System.Drawing.Point(155, 42);
            this.MovePluginLeftButton.Name = "MovePluginLeftButton";
            this.MovePluginLeftButton.Size = new System.Drawing.Size(24, 22);
            this.MovePluginLeftButton.TabIndex = 2;
            this.MovePluginLeftButton.Text = "<";
            this.MovePluginLeftButton.UseVisualStyleBackColor = true;
            this.MovePluginLeftButton.Click += new System.EventHandler(this.MovePluginLeftButton_Click);
            // 
            // SelectedPluginList
            // 
            this.SelectedPluginList.FormattingEnabled = true;
            this.SelectedPluginList.Location = new System.Drawing.Point(185, 33);
            this.SelectedPluginList.Name = "SelectedPluginList";
            this.SelectedPluginList.Size = new System.Drawing.Size(144, 82);
            this.SelectedPluginList.TabIndex = 1;
            // 
            // AvailablePluginList
            // 
            this.AvailablePluginList.Location = new System.Drawing.Point(6, 33);
            this.AvailablePluginList.Name = "AvailablePluginList";
            this.AvailablePluginList.Size = new System.Drawing.Size(143, 82);
            this.AvailablePluginList.TabIndex = 0;
            // 
            // OtherBox
            // 
            this.OtherBox.Controls.Add(this.checkBoxIDL);
            this.OtherBox.Controls.Add(this.checkBoxEDL);
            this.OtherBox.Controls.Add(this.checkBoxEID);
            this.OtherBox.Controls.Add(this.checkBoxEPASSPORT);
            this.OtherBox.Controls.Add(this.RFIDDeselectAllButton);
            this.OtherBox.Controls.Add(this.RFIDDeselectButton);
            this.OtherBox.Controls.Add(this.RFIDSelectAllButton);
            this.OtherBox.Controls.Add(this.RFIDSelectButton);
            this.OtherBox.Controls.Add(this.label1);
            this.OtherBox.Controls.Add(this.label2);
            this.OtherBox.Controls.Add(this.RFIDAvailDataItems);
            this.OtherBox.Controls.Add(this.RFIDSelectDataItems);
            this.OtherBox.Controls.Add(this.RFIDOption);
            this.OtherBox.Location = new System.Drawing.Point(10, 12);
            this.OtherBox.Name = "OtherBox";
            this.OtherBox.Size = new System.Drawing.Size(412, 280);
            this.OtherBox.TabIndex = 2;
            this.OtherBox.TabStop = false;
            this.OtherBox.Text = "RFID";
            // 
            // checkBoxIDL
            // 
            this.checkBoxIDL.AutoSize = true;
            this.checkBoxIDL.Location = new System.Drawing.Point(335, 16);
            this.checkBoxIDL.Name = "checkBoxIDL";
            this.checkBoxIDL.Size = new System.Drawing.Size(42, 17);
            this.checkBoxIDL.TabIndex = 19;
            this.checkBoxIDL.Text = "iDL";
            this.checkBoxIDL.UseVisualStyleBackColor = true;
            this.checkBoxIDL.CheckedChanged += new System.EventHandler(this.checkBoxIDL_CheckedChanged);
            // 
            // checkBoxEDL
            // 
            this.checkBoxEDL.AutoSize = true;
            this.checkBoxEDL.Location = new System.Drawing.Point(231, 16);
            this.checkBoxEDL.Name = "checkBoxEDL";
            this.checkBoxEDL.Size = new System.Drawing.Size(46, 17);
            this.checkBoxEDL.TabIndex = 18;
            this.checkBoxEDL.Text = "eDL";
            this.checkBoxEDL.UseVisualStyleBackColor = true;
            this.checkBoxEDL.CheckedChanged += new System.EventHandler(this.checkBoxEDL_CheckedChanged);
            // 
            // checkBoxEID
            // 
            this.checkBoxEID.AutoSize = true;
            this.checkBoxEID.Location = new System.Drawing.Point(286, 16);
            this.checkBoxEID.Name = "checkBoxEID";
            this.checkBoxEID.Size = new System.Drawing.Size(43, 17);
            this.checkBoxEID.TabIndex = 17;
            this.checkBoxEID.Text = "eID";
            this.checkBoxEID.UseVisualStyleBackColor = true;
            this.checkBoxEID.CheckedChanged += new System.EventHandler(this.checkBoxEID_CheckedChanged);
            // 
            // checkBoxEPASSPORT
            // 
            this.checkBoxEPASSPORT.AutoSize = true;
            this.checkBoxEPASSPORT.Location = new System.Drawing.Point(152, 16);
            this.checkBoxEPASSPORT.Name = "checkBoxEPASSPORT";
            this.checkBoxEPASSPORT.Size = new System.Drawing.Size(73, 17);
            this.checkBoxEPASSPORT.TabIndex = 16;
            this.checkBoxEPASSPORT.Text = "ePassport";
            this.checkBoxEPASSPORT.UseVisualStyleBackColor = true;
            this.checkBoxEPASSPORT.CheckedChanged += new System.EventHandler(this.checkBoxEPASSPORT_CheckedChanged);
            // 
            // RFIDDeselectAllButton
            // 
            this.RFIDDeselectAllButton.Location = new System.Drawing.Point(186, 169);
            this.RFIDDeselectAllButton.Name = "RFIDDeselectAllButton";
            this.RFIDDeselectAllButton.Size = new System.Drawing.Size(39, 29);
            this.RFIDDeselectAllButton.TabIndex = 15;
            this.RFIDDeselectAllButton.Text = "<<";
            this.RFIDDeselectAllButton.UseVisualStyleBackColor = true;
            this.RFIDDeselectAllButton.Click += new System.EventHandler(this.RFIDDeselectAllButton_Click);
            // 
            // RFIDDeselectButton
            // 
            this.RFIDDeselectButton.Location = new System.Drawing.Point(186, 134);
            this.RFIDDeselectButton.Name = "RFIDDeselectButton";
            this.RFIDDeselectButton.Size = new System.Drawing.Size(39, 29);
            this.RFIDDeselectButton.TabIndex = 14;
            this.RFIDDeselectButton.Text = "<";
            this.RFIDDeselectButton.UseVisualStyleBackColor = true;
            this.RFIDDeselectButton.Click += new System.EventHandler(this.RFIDDeselectButton_Click);
            // 
            // RFIDSelectAllButton
            // 
            this.RFIDSelectAllButton.Location = new System.Drawing.Point(186, 100);
            this.RFIDSelectAllButton.Name = "RFIDSelectAllButton";
            this.RFIDSelectAllButton.Size = new System.Drawing.Size(39, 29);
            this.RFIDSelectAllButton.TabIndex = 13;
            this.RFIDSelectAllButton.Text = ">>";
            this.RFIDSelectAllButton.UseVisualStyleBackColor = true;
            this.RFIDSelectAllButton.Click += new System.EventHandler(this.RFIDSelectAllButton_Click);
            // 
            // RFIDSelectButton
            // 
            this.RFIDSelectButton.Location = new System.Drawing.Point(186, 65);
            this.RFIDSelectButton.Name = "RFIDSelectButton";
            this.RFIDSelectButton.Size = new System.Drawing.Size(39, 29);
            this.RFIDSelectButton.TabIndex = 12;
            this.RFIDSelectButton.Text = ">";
            this.RFIDSelectButton.UseVisualStyleBackColor = true;
            this.RFIDSelectButton.Click += new System.EventHandler(this.RFIDSelectButton_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Location = new System.Drawing.Point(259, 39);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(100, 13);
            this.label1.TabIndex = 11;
            this.label1.Text = "Selected data items";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Location = new System.Drawing.Point(43, 39);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(101, 13);
            this.label2.TabIndex = 10;
            this.label2.Text = "Available data items";
            // 
            // RFIDAvailDataItems
            // 
            this.RFIDAvailDataItems.FormattingEnabled = true;
            this.RFIDAvailDataItems.Location = new System.Drawing.Point(15, 55);
            this.RFIDAvailDataItems.Name = "RFIDAvailDataItems";
            this.RFIDAvailDataItems.Size = new System.Drawing.Size(164, 199);
            this.RFIDAvailDataItems.TabIndex = 9;
            // 
            // RFIDSelectDataItems
            // 
            this.RFIDSelectDataItems.FormattingEnabled = true;
            this.RFIDSelectDataItems.Location = new System.Drawing.Point(231, 55);
            this.RFIDSelectDataItems.Name = "RFIDSelectDataItems";
            this.RFIDSelectDataItems.Size = new System.Drawing.Size(164, 199);
            this.RFIDSelectDataItems.TabIndex = 8;
            this.RFIDSelectDataItems.SelectedIndexChanged += new System.EventHandler(this.RFIDSelectDataItems_SelectedIndexChanged);
            // 
            // RFIDOption
            // 
            this.RFIDOption.AutoSize = true;
            this.RFIDOption.Location = new System.Drawing.Point(15, 19);
            this.RFIDOption.Name = "RFIDOption";
            this.RFIDOption.Size = new System.Drawing.Size(59, 17);
            this.RFIDOption.TabIndex = 2;
            this.RFIDOption.Text = "Enable";
            this.RFIDOption.UseVisualStyleBackColor = true;
            this.RFIDOption.CheckedChanged += new System.EventHandler(this.RFIDOption_Checked);
            // 
            // ShowProgressOption
            // 
            this.ShowProgressOption.AutoSize = true;
            this.ShowProgressOption.Location = new System.Drawing.Point(18, 527);
            this.ShowProgressOption.Name = "ShowProgressOption";
            this.ShowProgressOption.Size = new System.Drawing.Size(97, 17);
            this.ShowProgressOption.TabIndex = 9;
            this.ShowProgressOption.Text = "Show Progress";
            this.ShowProgressOption.UseVisualStyleBackColor = true;
            this.ShowProgressOption.Visible = false;
            this.ShowProgressOption.CheckedChanged += new System.EventHandler(this.ShowProgressOption_CheckedChanged);
            // 
            // UHFOption
            // 
            this.UHFOption.AutoSize = true;
            this.UHFOption.Location = new System.Drawing.Point(15, 19);
            this.UHFOption.Name = "UHFOption";
            this.UHFOption.Size = new System.Drawing.Size(59, 17);
            this.UHFOption.TabIndex = 12;
            this.UHFOption.Text = "Enable";
            this.UHFOption.UseVisualStyleBackColor = true;
            this.UHFOption.CheckedChanged += new System.EventHandler(this.UHFOption_Checked);
            // 
            // UHFGroupBox
            // 
            this.UHFGroupBox.Controls.Add(this.label5);
            this.UHFGroupBox.Controls.Add(this.label6);
            this.UHFGroupBox.Controls.Add(this.UHFDeselectAllButton);
            this.UHFGroupBox.Controls.Add(this.UHFDeselectButton);
            this.UHFGroupBox.Controls.Add(this.UHFSelectAllButton);
            this.UHFGroupBox.Controls.Add(this.UHFSelectButton);
            this.UHFGroupBox.Controls.Add(this.label3);
            this.UHFGroupBox.Controls.Add(this.label4);
            this.UHFGroupBox.Controls.Add(this.UHFAvailDataItems);
            this.UHFGroupBox.Controls.Add(this.UHFSelectDataItems);
            this.UHFGroupBox.Controls.Add(this.UHFOption);
            this.UHFGroupBox.Location = new System.Drawing.Point(436, 300);
            this.UHFGroupBox.Name = "UHFGroupBox";
            this.UHFGroupBox.Size = new System.Drawing.Size(412, 211);
            this.UHFGroupBox.TabIndex = 13;
            this.UHFGroupBox.TabStop = false;
            this.UHFGroupBox.Text = "UHF";
            this.UHFGroupBox.Visible = false;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Location = new System.Drawing.Point(259, 35);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(100, 13);
            this.label5.TabIndex = 25;
            this.label5.Text = "Selected data items";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.Location = new System.Drawing.Point(43, 35);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(101, 13);
            this.label6.TabIndex = 24;
            this.label6.Text = "Available data items";
            // 
            // UHFDeselectAllButton
            // 
            this.UHFDeselectAllButton.Location = new System.Drawing.Point(186, 166);
            this.UHFDeselectAllButton.Name = "UHFDeselectAllButton";
            this.UHFDeselectAllButton.Size = new System.Drawing.Size(39, 29);
            this.UHFDeselectAllButton.TabIndex = 23;
            this.UHFDeselectAllButton.Text = "<<";
            this.UHFDeselectAllButton.UseVisualStyleBackColor = true;
            this.UHFDeselectAllButton.Click += new System.EventHandler(this.UHFDeselectAllButton_Click);
            // 
            // UHFDeselectButton
            // 
            this.UHFDeselectButton.Location = new System.Drawing.Point(186, 131);
            this.UHFDeselectButton.Name = "UHFDeselectButton";
            this.UHFDeselectButton.Size = new System.Drawing.Size(39, 29);
            this.UHFDeselectButton.TabIndex = 22;
            this.UHFDeselectButton.Text = "<";
            this.UHFDeselectButton.UseVisualStyleBackColor = true;
            this.UHFDeselectButton.Click += new System.EventHandler(this.UHFDeselectButton_Click);
            // 
            // UHFSelectAllButton
            // 
            this.UHFSelectAllButton.Location = new System.Drawing.Point(186, 97);
            this.UHFSelectAllButton.Name = "UHFSelectAllButton";
            this.UHFSelectAllButton.Size = new System.Drawing.Size(39, 29);
            this.UHFSelectAllButton.TabIndex = 21;
            this.UHFSelectAllButton.Text = ">>";
            this.UHFSelectAllButton.UseVisualStyleBackColor = true;
            this.UHFSelectAllButton.Click += new System.EventHandler(this.UHFSelectAllButton_Click);
            // 
            // UHFSelectButton
            // 
            this.UHFSelectButton.Location = new System.Drawing.Point(186, 62);
            this.UHFSelectButton.Name = "UHFSelectButton";
            this.UHFSelectButton.Size = new System.Drawing.Size(39, 29);
            this.UHFSelectButton.TabIndex = 20;
            this.UHFSelectButton.Text = ">";
            this.UHFSelectButton.UseVisualStyleBackColor = true;
            this.UHFSelectButton.Click += new System.EventHandler(this.UHFSelectButton_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Location = new System.Drawing.Point(260, -34);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(100, 13);
            this.label3.TabIndex = 19;
            this.label3.Text = "Selected data items";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Location = new System.Drawing.Point(44, -34);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(101, 13);
            this.label4.TabIndex = 18;
            this.label4.Text = "Available data items";
            // 
            // UHFAvailDataItems
            // 
            this.UHFAvailDataItems.FormattingEnabled = true;
            this.UHFAvailDataItems.Location = new System.Drawing.Point(15, 51);
            this.UHFAvailDataItems.Name = "UHFAvailDataItems";
            this.UHFAvailDataItems.Size = new System.Drawing.Size(164, 147);
            this.UHFAvailDataItems.TabIndex = 17;
            // 
            // UHFSelectDataItems
            // 
            this.UHFSelectDataItems.FormattingEnabled = true;
            this.UHFSelectDataItems.Location = new System.Drawing.Point(231, 51);
            this.UHFSelectDataItems.Name = "UHFSelectDataItems";
            this.UHFSelectDataItems.Size = new System.Drawing.Size(164, 147);
            this.UHFSelectDataItems.TabIndex = 16;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.VisibleSequentialOption);
            this.groupBox2.Controls.Add(this.VisibleAntiGlareOption);
            this.groupBox2.Controls.Add(this.VisibleAmbientRemovalOption);
            this.groupBox2.Controls.Add(this.VisibleImageOption);
            this.groupBox2.Location = new System.Drawing.Point(436, 128);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(403, 61);
            this.groupBox2.TabIndex = 15;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Visible";
            this.groupBox2.Visible = false;
            // 
            // VisibleSequentialOption
            // 
            this.VisibleSequentialOption.AutoSize = true;
            this.VisibleSequentialOption.Location = new System.Drawing.Point(248, 42);
            this.VisibleSequentialOption.Name = "VisibleSequentialOption";
            this.VisibleSequentialOption.Size = new System.Drawing.Size(109, 17);
            this.VisibleSequentialOption.TabIndex = 14;
            this.VisibleSequentialOption.Text = "Visible Sequential";
            this.VisibleSequentialOption.UseVisualStyleBackColor = true;
            // 
            // VisibleAntiGlareOption
            // 
            this.VisibleAntiGlareOption.AutoSize = true;
            this.VisibleAntiGlareOption.Location = new System.Drawing.Point(117, 42);
            this.VisibleAntiGlareOption.Name = "VisibleAntiGlareOption";
            this.VisibleAntiGlareOption.Size = new System.Drawing.Size(105, 17);
            this.VisibleAntiGlareOption.TabIndex = 13;
            this.VisibleAntiGlareOption.Text = "Visible Anti-Glare";
            this.VisibleAntiGlareOption.UseVisualStyleBackColor = true;
            // 
            // VisibleAmbientRemovalOption
            // 
            this.VisibleAmbientRemovalOption.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.VisibleAmbientRemovalOption.FormattingEnabled = true;
            this.VisibleAmbientRemovalOption.Location = new System.Drawing.Point(117, 15);
            this.VisibleAmbientRemovalOption.Name = "VisibleAmbientRemovalOption";
            this.VisibleAmbientRemovalOption.Size = new System.Drawing.Size(276, 21);
            this.VisibleAmbientRemovalOption.TabIndex = 8;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.UVAmbientRemovalOption);
            this.groupBox3.Controls.Add(this.UVImageOption);
            this.groupBox3.Location = new System.Drawing.Point(451, 206);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(403, 40);
            this.groupBox3.TabIndex = 16;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Ultraviolet";
            this.groupBox3.Visible = false;
            // 
            // UVAmbientRemovalOption
            // 
            this.UVAmbientRemovalOption.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.UVAmbientRemovalOption.FormattingEnabled = true;
            this.UVAmbientRemovalOption.Location = new System.Drawing.Point(117, 13);
            this.UVAmbientRemovalOption.Name = "UVAmbientRemovalOption";
            this.UVAmbientRemovalOption.Size = new System.Drawing.Size(276, 21);
            this.UVAmbientRemovalOption.TabIndex = 7;
            // 
            // ok_save
            // 
            this.ok_save.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(140)))), ((int)(((byte)(0)))));
            this.ok_save.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.ok_save.ForeColor = System.Drawing.Color.White;
            this.ok_save.Location = new System.Drawing.Point(241, 298);
            this.ok_save.Name = "ok_save";
            this.ok_save.Size = new System.Drawing.Size(80, 33);
            this.ok_save.TabIndex = 20;
            this.ok_save.Text = "Save";
            this.ok_save.UseVisualStyleBackColor = false;
            this.ok_save.Click += new System.EventHandler(this.ok_save_Click);
            // 
            // _cancel
            // 
            this._cancel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this._cancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this._cancel.ForeColor = System.Drawing.Color.White;
            this._cancel.Location = new System.Drawing.Point(347, 298);
            this._cancel.Name = "_cancel";
            this._cancel.Size = new System.Drawing.Size(80, 33);
            this._cancel.TabIndex = 20;
            this._cancel.Text = "Cancel";
            this._cancel.UseVisualStyleBackColor = false;
            this._cancel.Click += new System.EventHandler(this._cancel_Click);
            // 
            // DataToSend
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(433, 334);
            this.Controls.Add(this._cancel);
            this.Controls.Add(this.ok_save);
            this.Controls.Add(this.OpticalDataBox);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.UHFGroupBox);
            this.Controls.Add(this.ShowProgressOption);
            this.Controls.Add(this.OtherBox);
            this.Controls.Add(this.PluginsBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "DataToSend";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Settings";
            this.Load += new System.EventHandler(this.DataToSend_Load);
            this.Shown += new System.EventHandler(this.DataToSend_Shown);
            this.OpticalDataBox.ResumeLayout(false);
            this.OpticalDataBox.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ScaleFactorTrackBar)).EndInit();
            this.PluginsBox.ResumeLayout(false);
            this.PluginsBox.PerformLayout();
            this.OtherBox.ResumeLayout(false);
            this.OtherBox.PerformLayout();
            this.UHFGroupBox.ResumeLayout(false);
            this.UHFGroupBox.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

		}

		#endregion


		public DataToSend()
		{
			InitializeComponent();
            ImageFormatCombo.Items.Add(MMM.Readers.FullPage.ImageFormats.RTE_BMP);
            ImageFormatCombo.Items.Add(MMM.Readers.FullPage.ImageFormats.RTE_PNG);
            ImageFormatCombo.Items.Add(MMM.Readers.FullPage.ImageFormats.RTE_JPEG);
            ImageFormatCombo.Items.Add(MMM.Readers.FullPage.ImageFormats.RTE_TIFF);

            for (int i=0; i<6; i++)
            {
                IRAmbientRemovalOption.Items.Add(StringConstant.AmbientString[i]);
                VisibleAmbientRemovalOption.Items.Add(StringConstant.AmbientString[i]);
                UVAmbientRemovalOption.Items.Add(StringConstant.AmbientString[i]);
            }        
        
        }

		private void DataToSend_Shown(Object aSender, EventArgs aEventArgs)
		{
			MMM.Readers.FullPage.ReaderSettings lSettings;
			MMM.Readers.ErrorCode lErrorCode =
				MMM.Readers.FullPage.Reader.GetSettings(out lSettings);

			if (lErrorCode == MMM.Readers.ErrorCode.NO_ERROR_OCCURRED)
			{
				// Optical data settings
				CodelineOption.Checked = (lSettings.puDataToSend.send &
					MMM.Readers.FullPage.DataSendSet.Flags.CODELINE) != 0;

				ChecksumOption.Checked = (lSettings.puDataToSend.send &
					MMM.Readers.FullPage.DataSendSet.Flags.CHECKSUM) != 0;

				IRImageOption.Checked = (lSettings.puDataToSend.send &
					MMM.Readers.FullPage.DataSendSet.Flags.IRIMAGE) != 0;

				VisibleImageOption.Checked = (lSettings.puDataToSend.send &
					MMM.Readers.FullPage.DataSendSet.Flags.VISIBLEIMAGE) != 0;

				UVImageOption.Checked = (lSettings.puDataToSend.send &
					MMM.Readers.FullPage.DataSendSet.Flags.UVIMAGE) != 0;

				SecurityCheckOption.Checked = (lSettings.puDataToSend.send &
					MMM.Readers.FullPage.DataSendSet.Flags.SECURITYCHECK) != 0;

				PhotoImageOption.Checked = (lSettings.puDataToSend.send &
					MMM.Readers.FullPage.DataSendSet.Flags.PHOTOIMAGE) != 0;

                MSRDataOption.Checked = (lSettings.puDataToSend.send &
                    MMM.Readers.FullPage.DataSendSet.Flags.SWIPE) != 0;

                AAMVAOption.Checked = (lSettings.puDataToSend.send &
                    MMM.Readers.FullPage.DataSendSet.Flags.AAMVA) != 0;

				// Data modifier settings
				CroppedToCodelineOption.Checked = (lSettings.puDataToSend.special &
					MMM.Readers.FullPage.DataSendSet.Flags.IRIMAGE) != 0;

				ColourOption.Checked = (lSettings.puDataToSend.special &
					MMM.Readers.FullPage.DataSendSet.Flags.VISIBLEIMAGE) != 0;

				CheckUVOption.Checked = (lSettings.puDataToSend.special &
					MMM.Readers.FullPage.DataSendSet.Flags.SECURITYCHECK) != 0;

                // TL - 23 Feb 2015 - no longer supporting/updating old UV background support option in application.ini - will be moved to uv.puAmbientRemoval
                //UVAmbientRemovalOption.Checked = (lSettings.puDataToSend.special &
                //    MMM.Readers.FullPage.DataSendSet.Flags.UVIMAGE) != 0;
                if ((lSettings.puDataToSend.special & MMM.Readers.FullPage.DataSendSet.Flags.UVIMAGE) != 0)
                    lSettings.puCameraSettings.uv.puAmbientRemoval = MMM.Readers.Modules.Camera.AmbientRemovalMethod.MRAS_BASIC_AMBIENT_REMOVAL;

                this.SendBarcodeImageOption.Checked = (lSettings.puDataToSend.send &
                    MMM.Readers.FullPage.DataSendSet.Flags.BARCODEIMAGE) != 0;

                IRAntiGlareOption.Checked = lSettings.puCameraSettings.ir.puUseAntiGlare;
                VisibleAntiGlareOption.Checked = lSettings.puCameraSettings.vis.puUseAntiGlare;

                IRSequentialOption.Checked = lSettings.puCameraSettings.ir.puUseSequentialImaging;
                VisibleSequentialOption.Checked = lSettings.puCameraSettings.vis.puUseSequentialImaging;

                if ((lSettings.puCameraSettings.flap & 0x20) != 0) ActiveReaderOption.Checked = true;
                else if ((lSettings.puCameraSettings.flap & 0x08) != 0) ActiveVideoOption.Checked = true;

                IRAmbientRemovalOption.SelectedIndex = (int) lSettings.puCameraSettings.ir.puAmbientRemoval;
                VisibleAmbientRemovalOption.SelectedIndex = (int)lSettings.puCameraSettings.vis.puAmbientRemoval;
                UVAmbientRemovalOption.SelectedIndex = (int)lSettings.puCameraSettings.uv.puAmbientRemoval;

                lSettings.puImageSettings.checkVisibleOcr = true;
                UseVisibleForBarcodeOption.Checked = (lSettings.puImageSettings.useVisibleForBarcode != 0);
                
                ImageFormatCombo.SelectedIndex = ImageFormatCombo.Items.IndexOf(lSettings.puDataToSend.imageFormat);

                int scaleFactor = lSettings.puCameraSettings.scaleFactor;

                if (scaleFactor == 0) scaleFactor = 100;
                if (scaleFactor < 20) scaleFactor = 20;

                ScaleFactorTrackBar.Value = scaleFactor;
                ReaderMaxDpi = (lSettings.puCameraSettings.xDPI + lSettings.puCameraSettings.yDPI) / 2 * 100 / scaleFactor;

                ScaleFactorLabel.Text = string.Format( "Scale Factor: {0}%-(~{1}% dpi)", scaleFactor,  ReaderMaxDpi * scaleFactor / 100);

				// Other settings
				SetRFIDEnabled
				(
					(lSettings.puDataToSend.send &
						MMM.Readers.FullPage.DataSendSet.Flags.SMARTCARD) != 0
				);

				SetUHFEnabled
				(
					(lSettings.puDataToSend.send &
					MMM.Readers.FullPage.DataSendSet.Flags.UHF) != 0
				);

				ShowProgressOption.Checked = lSettings.puDataToSend.progress != 0;

                this.checkBoxEPASSPORT.Checked = 
                    (lSettings.puRFIDSettings.puRFProcessSettings.puRFApplicationMode & (int)MMM.Readers.Modules.RF.RF_APPLICATION_MODE.EPASSPORT) != 0;
                this.checkBoxEID.Checked =
                    (lSettings.puRFIDSettings.puRFProcessSettings.puRFApplicationMode & (int)MMM.Readers.Modules.RF.RF_APPLICATION_MODE.EID) != 0;
                this.checkBoxEDL.Checked =
                    (lSettings.puRFIDSettings.puRFProcessSettings.puRFApplicationMode & (int)MMM.Readers.Modules.RF.RF_APPLICATION_MODE.EDL) != 0;
                this.checkBoxIDL.Checked =
                    (lSettings.puRFIDSettings.puRFProcessSettings.puRFApplicationMode & (int)MMM.Readers.Modules.RF.RF_APPLICATION_MODE.IDL) != 0;

                PopulateUHFLists(lSettings.puDataToSend.uhf);
				PopulateRFIDLists(lSettings.puDataToSend.rfid);
				PopulatePluginLists();
			}
		}

		private void SetRFIDEnabled(bool aEnabled)
		{
			RFIDOption.Checked = aEnabled;
			RFIDAvailDataItems.Enabled = aEnabled;
			RFIDSelectDataItems.Enabled = aEnabled;
            this.checkBoxEPASSPORT.Enabled = aEnabled;
            this.checkBoxEDL.Enabled = aEnabled;
            this.checkBoxEID.Enabled = aEnabled;
            this.checkBoxIDL.Enabled = aEnabled;
        }

        private void SetUHFEnabled(bool aEnabled)
		{
			UHFOption.Checked = aEnabled;
			UHFAvailDataItems.Enabled = aEnabled;
			UHFSelectDataItems.Enabled = aEnabled;
		}

		private void PopulateUHFLists(MMM.Readers.FullPage.UHFDataToSend aDataToSend)
		{
			ListBox lCurrentList = UHFAvailDataItems;
			for (int lOrder = 0; lOrder < 3; lOrder++)
			{
				if (lOrder > 0)
					lCurrentList = UHFSelectDataItems;

				if (aDataToSend.puEPC == lOrder)
					lCurrentList.Items.Add("EPC Tag");

				if (aDataToSend.puTagID == lOrder)
					lCurrentList.Items.Add("Tag ID");
			}
		}

		private void PopulateRFIDLists(MMM.Readers.FullPage.RFIDDataToSend aDataToSend)
		{
			ListBox lCurrentList = RFIDAvailDataItems;
			for (int lOrder = 0; lOrder < 50; lOrder++)
			{
				if (lOrder > 0)
					lCurrentList = RFIDSelectDataItems;

				if (aDataToSend.puEFComFile == lOrder)
					lCurrentList.Items.Add("EF.COM file");

				if (aDataToSend.puEFSodFile == lOrder)
					lCurrentList.Items.Add("EF.SOD file");

				if (aDataToSend.puAirBaudRate == lOrder)
					lCurrentList.Items.Add("Air Baud Rate");

				if (aDataToSend.puActiveAuthentication == lOrder)
					lCurrentList.Items.Add("Active Authentication");

				if (aDataToSend.puValidateDocSignerCert == lOrder)
					lCurrentList.Items.Add("Validate D/S Cert.");

				if (aDataToSend.puChipID == lOrder)
					lCurrentList.Items.Add("Chip ID");

				if (aDataToSend.puDG1MRZData == lOrder)
					lCurrentList.Items.Add("DG1 MRZ");

                if (aDataToSend.puDG1DataEDL == lOrder)
                    lCurrentList.Items.Add("DG1 Data eDL");

                if (aDataToSend.puDG2FaceJPEG == lOrder)
					lCurrentList.Items.Add("DG2 Photo");

				if (aDataToSend.puDG3Fingerprints == lOrder)
					lCurrentList.Items.Add("DG3 Fingerprints");

                if (aDataToSend.puDG6FaceJPEG == lOrder)
                    lCurrentList.Items.Add("DG6 eDL Photo");

                if (aDataToSend.puDG7Fingerprints == lOrder)
                    lCurrentList.Items.Add("DG7 eDL Fingerprints");

                if (aDataToSend.puCrosscheckEFComEFSod == lOrder)
					lCurrentList.Items.Add("Crosscheck EF.COM / EF.SOD");

				for (int lDataGroup = 0; lDataGroup < 16; lDataGroup++)
				{
					if (aDataToSend.puDGFile[lDataGroup + 1] == lOrder)
						lCurrentList.Items.Add(String.Format("DG{0} file", lDataGroup + 1));

					if (aDataToSend.puValidateDG[lDataGroup + 1] == lOrder)
						lCurrentList.Items.Add(String.Format("DG{0} validate", lDataGroup + 1));
				}

                for (int lDataGroup = 0; lDataGroup < 22; lDataGroup++)
                {
                    if (aDataToSend.puDGFileEID[lDataGroup + 1] == lOrder)
                        lCurrentList.Items.Add(String.Format("DG{0}_eID file", lDataGroup + 1));

                    if (aDataToSend.puValidateDGEID[lDataGroup + 1] == lOrder)
                        lCurrentList.Items.Add(String.Format("DG{0}_eID validate", lDataGroup + 1));
                }

                for (int lDataGroup = 0; lDataGroup < 14; lDataGroup++)
                {
                    if (aDataToSend.puDGFileEDL[lDataGroup + 1] == lOrder)
                        lCurrentList.Items.Add(String.Format("DG{0}_eDL file", lDataGroup + 1));

                    if (aDataToSend.puValidateDGEDL[lDataGroup + 1] == lOrder)
                        lCurrentList.Items.Add(String.Format("DG{0}_eDL validate", lDataGroup + 1));
                }

                if (aDataToSend.puValidateSignature == lOrder)
					lCurrentList.Items.Add("Validate Signature");

				if (aDataToSend.puValidateSignedAttrs == lOrder)
					lCurrentList.Items.Add("Validate Signed Attrs");

				if (aDataToSend.puGetBACStatus == lOrder)
					lCurrentList.Items.Add("BAC Status");

                if (aDataToSend.puGetSACStatus == lOrder)
                    lCurrentList.Items.Add("SAC Status");
            }
		}

		private void PopulatePluginLists()
		{
			int lPluginNameLength = 1;
			for (int i = 0; (lPluginNameLength > 0); i++)
			{
				String lPluginName = "";
				MMM.Readers.ErrorCode lErrorCode =
					MMM.Readers.FullPage.Reader.GetPluginName(ref lPluginName, i);

				lPluginNameLength = lPluginName.Length;

				if (lPluginNameLength > 0)
				{
					bool lEnabled = false;

					MMM.Readers.FullPage.Reader.IsPluginEnabled(lPluginName, ref lEnabled);
					if (lEnabled)
						SelectedPluginList.Items.Add(lPluginName);
					else
						AvailablePluginList.Items.Add(lPluginName);
				}
			}
		}

		private void OKButton_Click(Object aSender, EventArgs aEventArgs)
		{
			MMM.Readers.FullPage.ReaderSettings lSettings;
			if (MMM.Readers.FullPage.Reader.GetSettings(out lSettings) == MMM.Readers.ErrorCode.NO_ERROR_OCCURRED)
			{
				lSettings.puDataToSend.send |= MMM.Readers.FullPage.DataSendSet.Flags.DOCMARKERS;

                //if (CodelineOption.Checked)
                //    lSettings.puDataToSend.send |= MMM.Readers.FullPage.DataSendSet.Flags.CODELINE;
                //else
                //    lSettings.puDataToSend.send &= ~MMM.Readers.FullPage.DataSendSet.Flags.CODELINE;

                //if (ChecksumOption.Checked)
                //    lSettings.puDataToSend.send |= MMM.Readers.FullPage.DataSendSet.Flags.CHECKSUM;
                //else
                //    lSettings.puDataToSend.send &= ~MMM.Readers.FullPage.DataSendSet.Flags.CHECKSUM;

                //if (IRImageOption.Checked)
                //    lSettings.puDataToSend.send |= MMM.Readers.FullPage.DataSendSet.Flags.IRIMAGE;
                //else
                //    lSettings.puDataToSend.send &= ~MMM.Readers.FullPage.DataSendSet.Flags.IRIMAGE;

                //if (VisibleImageOption.Checked)
                //    lSettings.puDataToSend.send |= MMM.Readers.FullPage.DataSendSet.Flags.VISIBLEIMAGE;
                //else
                //    lSettings.puDataToSend.send &= ~MMM.Readers.FullPage.DataSendSet.Flags.VISIBLEIMAGE;

                //if (UVImageOption.Checked)
                //    lSettings.puDataToSend.send |= MMM.Readers.FullPage.DataSendSet.Flags.UVIMAGE;
                //else
                //    lSettings.puDataToSend.send &= ~MMM.Readers.FullPage.DataSendSet.Flags.UVIMAGE;

                //if (PhotoImageOption.Checked)
                //    lSettings.puDataToSend.send |= MMM.Readers.FullPage.DataSendSet.Flags.PHOTOIMAGE;
                //else
                //    lSettings.puDataToSend.send &= ~MMM.Readers.FullPage.DataSendSet.Flags.PHOTOIMAGE;

                //if (RFIDOption.Checked)
                //    lSettings.puDataToSend.send |= MMM.Readers.FullPage.DataSendSet.Flags.SMARTCARD;
                //else
                //    lSettings.puDataToSend.send &= ~MMM.Readers.FullPage.DataSendSet.Flags.SMARTCARD;

                //if (SecurityCheckOption.Checked)
                //    lSettings.puDataToSend.send |= MMM.Readers.FullPage.DataSendSet.Flags.SECURITYCHECK;
                //else
                //    lSettings.puDataToSend.send &= ~MMM.Readers.FullPage.DataSendSet.Flags.SECURITYCHECK;

                //if (MSRDataOption.Checked)
                //    lSettings.puDataToSend.send |= MMM.Readers.FullPage.DataSendSet.Flags.SWIPE;
                //else
                //    lSettings.puDataToSend.send &= ~MMM.Readers.FullPage.DataSendSet.Flags.SWIPE;

                //if (AAMVAOption.Checked)
                //    lSettings.puDataToSend.send |= MMM.Readers.FullPage.DataSendSet.Flags.AAMVA;
                //else
                //    lSettings.puDataToSend.send &= ~MMM.Readers.FullPage.DataSendSet.Flags.AAMVA;

                //if (CheckUVOption.Checked)
                //    lSettings.puDataToSend.special |= MMM.Readers.FullPage.DataSendSet.Flags.SECURITYCHECK;
                //else
                //    lSettings.puDataToSend.special &= ~MMM.Readers.FullPage.DataSendSet.Flags.SECURITYCHECK;

                //if (CroppedToCodelineOption.Checked)
                //    lSettings.puDataToSend.special |= MMM.Readers.FullPage.DataSendSet.Flags.IRIMAGE;
                //else
                //    lSettings.puDataToSend.special &= ~MMM.Readers.FullPage.DataSendSet.Flags.IRIMAGE;

                //if (ColourOption.Checked)
                //    lSettings.puDataToSend.special |= MMM.Readers.FullPage.DataSendSet.Flags.VISIBLEIMAGE;
                //else
                //    lSettings.puDataToSend.special &= ~MMM.Readers.FullPage.DataSendSet.Flags.VISIBLEIMAGE;

                //// TL - 23 Feb 2015 - no longer supporting/updating old UV background support option in application.ini - will be moved to uv.puAmbientRemoval
                ////if (UVAmbientRemovalOption.Checked)
                ////    lSettings.puDataToSend.special |= MMM.Readers.FullPage.DataSendSet.Flags.UVIMAGE;
                ////else
                ////   lSettings.puDataToSend.special &= ~MMM.Readers.FullPage.DataSendSet.Flags.UVIMAGE;

                //lSettings.puCameraSettings.ir.puUseAntiGlare = IRAntiGlareOption.Checked;
                //lSettings.puCameraSettings.vis.puUseAntiGlare = VisibleAntiGlareOption.Checked;

                //lSettings.puCameraSettings.ir.puUseSequentialImaging = IRSequentialOption.Checked;
                //lSettings.puCameraSettings.vis.puUseSequentialImaging = VisibleSequentialOption.Checked;

                //lSettings.puCameraSettings.flap = 0;
                //if (ActiveVideoOption.Checked == true) lSettings.puCameraSettings.flap |= 0x08;
                //if (ActiveReaderOption.Checked == true) lSettings.puCameraSettings.flap |= 0x20;

                //lSettings.puCameraSettings.ir.puAmbientRemoval = (MMM.Readers.Modules.Camera.AmbientRemovalMethod)IRAmbientRemovalOption.SelectedIndex;
                //lSettings.puCameraSettings.vis.puAmbientRemoval = (MMM.Readers.Modules.Camera.AmbientRemovalMethod)VisibleAmbientRemovalOption.SelectedIndex;
                //lSettings.puCameraSettings.uv.puAmbientRemoval = (MMM.Readers.Modules.Camera.AmbientRemovalMethod)UVAmbientRemovalOption.SelectedIndex;

                //lSettings.puImageSettings.useVisibleForBarcode = 0;
                //if (UseVisibleForBarcodeOption.Checked == true) lSettings.puImageSettings.useVisibleForBarcode = 1;

                //if (SendBarcodeImageOption.Checked)
                //    lSettings.puDataToSend.send |= MMM.Readers.FullPage.DataSendSet.Flags.BARCODEIMAGE;
                //else
                //    lSettings.puDataToSend.send &= ~MMM.Readers.FullPage.DataSendSet.Flags.BARCODEIMAGE;

                //if (UHFOption.Checked)
                //    lSettings.puDataToSend.send |= MMM.Readers.FullPage.DataSendSet.Flags.UHF;
                //else
                //    lSettings.puDataToSend.send &= ~MMM.Readers.FullPage.DataSendSet.Flags.UHF;

                //if (ShowProgressOption.Checked)
                //    lSettings.puDataToSend.progress = 1;
                //else
                //    lSettings.puDataToSend.progress = 0;

                //lSettings.puDataToSend.imageFormat =
                //    (MMM.Readers.FullPage.ImageFormats)ImageFormatCombo.Items[ImageFormatCombo.SelectedIndex];

                //lSettings.puCameraSettings.scaleFactor = 100;
                //if (ScaleFactorTrackBar.Value >= 20 && ScaleFactorTrackBar.Value <= 100)
                //    lSettings.puCameraSettings.scaleFactor = ScaleFactorTrackBar.Value;

                if (this.checkBoxEPASSPORT.Checked)
                    lSettings.puRFIDSettings.puRFProcessSettings.puRFApplicationMode |= (int)MMM.Readers.Modules.RF.RF_APPLICATION_MODE.EPASSPORT;
                else
                    lSettings.puRFIDSettings.puRFProcessSettings.puRFApplicationMode &= ~(int)MMM.Readers.Modules.RF.RF_APPLICATION_MODE.EPASSPORT;
                if (this.checkBoxEID.Checked)
                    lSettings.puRFIDSettings.puRFProcessSettings.puRFApplicationMode |= (int)MMM.Readers.Modules.RF.RF_APPLICATION_MODE.EID;
                else
                    lSettings.puRFIDSettings.puRFProcessSettings.puRFApplicationMode &= ~(int)MMM.Readers.Modules.RF.RF_APPLICATION_MODE.EID;
                if (this.checkBoxEDL.Checked)
                    lSettings.puRFIDSettings.puRFProcessSettings.puRFApplicationMode |= (int)MMM.Readers.Modules.RF.RF_APPLICATION_MODE.EDL;
                else
                    lSettings.puRFIDSettings.puRFProcessSettings.puRFApplicationMode &= ~(int)MMM.Readers.Modules.RF.RF_APPLICATION_MODE.EDL;
                if (this.checkBoxIDL.Checked)
                    lSettings.puRFIDSettings.puRFProcessSettings.puRFApplicationMode |= (int)MMM.Readers.Modules.RF.RF_APPLICATION_MODE.IDL;
                else
                    lSettings.puRFIDSettings.puRFProcessSettings.puRFApplicationMode &= ~(int)MMM.Readers.Modules.RF.RF_APPLICATION_MODE.IDL;

                //StoreUHFOrder(ref lSettings.puDataToSend.uhf);
				StoreRFIDOrder(ref lSettings.puDataToSend.rfid);
				//StorePlugins();

				MMM.Readers.FullPage.Reader.UpdateSettings(lSettings);
                MMM.Readers.FullPage.Reader.SaveSettings();
			}

			this.Close();
		}

		private void StoreUHFOrder(ref MMM.Readers.FullPage.UHFDataToSend aDataToSend)
		{
			for (int lListCtrlIndex = 0; lListCtrlIndex < 2; lListCtrlIndex++)
			{
				ListBox lListbox = (lListCtrlIndex == 0) ? UHFAvailDataItems : UHFSelectDataItems;

				for (int lIndex = 0; lIndex < lListbox.Items.Count; lIndex++)
				{
					if (!(lListbox.Items[lIndex] is String))
						continue;

					int lOrder = (lListCtrlIndex > 0) ? lIndex + 1 : 0;
					String lItem = lListbox.Items[lIndex] as String;

					if (lItem == "EPC Tag")
						aDataToSend.puEPC = lOrder;

					else if (lItem == "Tag ID")
						aDataToSend.puTagID = lOrder;
				}
			}
		}

		private void StoreRFIDOrder(ref MMM.Readers.FullPage.RFIDDataToSend aDataToSend)
		{
			// To avoid having this switch twice, we'll just go around this for both list controls with a loop.
			// For the available list control, we want to set the order number to 0 for all items in it. For the
			// selected list control, we want to set the order number to the index in the list, plus 1.
			for (int lListCtrlIndex = 0; lListCtrlIndex < 2; lListCtrlIndex++)
			{
				ListBox lListbox = (lListCtrlIndex == 0) ? RFIDAvailDataItems : RFIDSelectDataItems;

				for (int lIndex = 0; lIndex < lListbox.Items.Count; lIndex++)
				{
					if (!(lListbox.Items[lIndex] is String))
						continue;

					int lOrder = (lListCtrlIndex > 0) ? lIndex + 1 : 0;
					String lItem = lListbox.Items[lIndex] as String;

					if (lItem == "EF.COM file")
						aDataToSend.puEFComFile = lOrder;

					else if (lItem == "EF.SOD file")
						aDataToSend.puEFSodFile = lOrder;

					else if (lItem == "Air Baud Rate")
						aDataToSend.puAirBaudRate = lOrder;

					else if (lItem == "Active Authentication")
						aDataToSend.puActiveAuthentication = lOrder;

					else if (lItem == "Validate D/S Cert.")
						aDataToSend.puValidateDocSignerCert = lOrder;

					else if (lItem == "Chip ID")
						aDataToSend.puChipID = lOrder;

					else if (lItem == "DG1 MRZ")
						aDataToSend.puDG1MRZData = lOrder;

                    else if (lItem == "DG1 Data eDL")
                        aDataToSend.puDG1DataEDL = lOrder;

                    else if (lItem == "DG2 Photo")
						aDataToSend.puDG2FaceJPEG = lOrder;

					else if (lItem == "DG3 Fingerprints")
						aDataToSend.puDG3Fingerprints = lOrder;

                    else if (lItem == "DG6 eDL Photo")
                        aDataToSend.puDG6FaceJPEG = lOrder;

                    else if (lItem == "DG7 eDL Fingerprints")
                        aDataToSend.puDG7Fingerprints = lOrder;

                    else if (lItem == "Crosscheck EF.COM / EF.SOD")
						aDataToSend.puCrosscheckEFComEFSod = lOrder;

					else if (lItem == "Validate Signature")
						aDataToSend.puValidateSignature = lOrder;

					else if (lItem == "Validate Signed Attrs")
						aDataToSend.puValidateSignedAttrs = lOrder;

					else if (lItem == "BAC Status")
						aDataToSend.puGetBACStatus = lOrder;

                    else if (lItem == "SAC Status")
                        aDataToSend.puGetSACStatus = lOrder;

                    else if (lItem.Contains("DG") && !(lItem.Contains("_eID") || lItem.Contains("_eDL")))
					{
						String lDGString = "";
						foreach (Char lChar in lItem)
						{
							if (Char.IsNumber(lChar))
								lDGString += lChar;
						}
						int lDataGroup = Int32.Parse(lDGString);

						if (lItem.Contains("file") && lDataGroup <= aDataToSend.puDGFile.Length)
							aDataToSend.puDGFile[lDataGroup] = lOrder;
						else if (lItem.Contains("validate") && lDataGroup <= aDataToSend.puDGFile.Length)
							aDataToSend.puValidateDG[lDataGroup] = lOrder;
					}

                    else if (lItem.Contains("_eID"))
                    {
                        String lDGString = "";
                        foreach (Char lChar in lItem)
                        {
                            if (Char.IsNumber(lChar))
                                lDGString += lChar;
                        }
                        int lDataGroup = Int32.Parse(lDGString);

                        if (lItem.Contains("file") && lDataGroup <= aDataToSend.puDGFileEID.Length)
                            aDataToSend.puDGFileEID[lDataGroup] = lOrder;
                        else if (lItem.Contains("validate") && lDataGroup <= aDataToSend.puDGFileEID.Length)
                            aDataToSend.puValidateDGEID[lDataGroup] = lOrder;
                    }
                    else if (lItem.Contains("_eDL"))
                    {
                        String lDGString = "";
                        foreach (Char lChar in lItem)
                        {
                            if (Char.IsNumber(lChar))
                                lDGString += lChar;
                        }
                        int lDataGroup = Int32.Parse(lDGString);

                        if (lItem.Contains("file") && lDataGroup <= aDataToSend.puDGFileEDL.Length)
                            aDataToSend.puDGFileEDL[lDataGroup] = lOrder;
                        else if (lItem.Contains("validate") && lDataGroup <= aDataToSend.puDGFileEDL.Length)
                            aDataToSend.puValidateDGEDL[lDataGroup] = lOrder;
                    }
                }
            }
		}

		private void StorePlugins()
		{
			foreach (String lPluginName in AvailablePluginList.Items)
				MMM.Readers.FullPage.Reader.EnablePlugin(lPluginName, false);

			foreach (String lPluginName in SelectedPluginList.Items)
				MMM.Readers.FullPage.Reader.EnablePlugin(lPluginName, true);
		}

		private void CancelButton_Click(Object aSender, EventArgs aEventArgs)
		{
			this.Close();
		}

		private void UHFOption_Checked(Object aSender, EventArgs aEventArgs)
		{
			SetUHFEnabled(UHFOption.Checked);
		}

		private void RFIDOption_Checked(Object aSender, EventArgs aEventArgs)
		{
			SetRFIDEnabled(RFIDOption.Checked);
		}

		private void RFIDSelectButton_Click(Object aSender, EventArgs aEventArgs)
		{
			if (RFIDAvailDataItems.SelectedIndex != -1 && 
				RFIDAvailDataItems.Items[RFIDAvailDataItems.SelectedIndex] is String)
			{
				String lItem = RFIDAvailDataItems.Items[RFIDAvailDataItems.SelectedIndex] as String;
				RFIDAvailDataItems.Items.Remove(lItem);
				RFIDSelectDataItems.Items.Add(lItem);
			}
		}

		private void RFIDSelectAllButton_Click(Object aSender, EventArgs aEventArgs)
		{
			Object[] lRawItems = new Object[RFIDAvailDataItems.Items.Count];
			RFIDAvailDataItems.Items.CopyTo(lRawItems, 0);
			RFIDAvailDataItems.Items.Clear();

			foreach (Object lRawItem in lRawItems)
			{
				if (lRawItem is String)
					RFIDSelectDataItems.Items.Add(lRawItem);
			}
		}

		private void RFIDDeselectButton_Click(Object aSender, EventArgs aEventArgs)
		{
			if (RFIDSelectDataItems.SelectedIndex != -1 &&
				RFIDSelectDataItems.Items[RFIDSelectDataItems.SelectedIndex] is String)
			{
				String lItem = RFIDSelectDataItems.Items[RFIDSelectDataItems.SelectedIndex] as String;
				RFIDSelectDataItems.Items.Remove(lItem);
				RFIDAvailDataItems.Items.Add(lItem);
			}
		}

		private void RFIDDeselectAllButton_Click(Object aSender, EventArgs aEventArgs)
		{
			Object[] lRawItems = new Object[RFIDSelectDataItems.Items.Count];
			RFIDSelectDataItems.Items.CopyTo(lRawItems, 0);
			RFIDSelectDataItems.Items.Clear();

			foreach (Object lRawItem in lRawItems)
			{
				if (lRawItem is String)
					RFIDAvailDataItems.Items.Add(lRawItem);
			}
		}

		private void UHFSelectButton_Click(Object aSender, EventArgs aEventArgs)
		{
			if (UHFAvailDataItems.SelectedIndex != -1 &&
				UHFAvailDataItems.Items[UHFAvailDataItems.SelectedIndex] is String)
			{
				String lItem = UHFAvailDataItems.Items[UHFAvailDataItems.SelectedIndex] as String;
				UHFAvailDataItems.Items.Remove(lItem);
				UHFSelectDataItems.Items.Add(lItem);
			}
		}

		private void UHFSelectAllButton_Click(Object aSender, EventArgs aEventArgs)
		{
			Object[] lRawItems = new Object[UHFAvailDataItems.Items.Count];
			UHFAvailDataItems.Items.CopyTo(lRawItems, 0);
			UHFAvailDataItems.Items.Clear();

			foreach (Object lRawItem in lRawItems)
			{
				if (lRawItem is String)
					UHFSelectDataItems.Items.Add(lRawItem);
			}
		}

		private void UHFDeselectButton_Click(Object aSender, EventArgs aEventArgs)
		{
			if (UHFSelectDataItems.SelectedIndex != -1 &&
				UHFSelectDataItems.Items[UHFSelectDataItems.SelectedIndex] is String)
			{
				String lItem = UHFSelectDataItems.Items[UHFSelectDataItems.SelectedIndex] as String;
				UHFSelectDataItems.Items.Remove(lItem);
				UHFAvailDataItems.Items.Add(lItem);
			}
		}

		private void UHFDeselectAllButton_Click(Object aSender, EventArgs aEventArgs)
		{
			Object[] lRawItems = new Object[UHFSelectDataItems.Items.Count];
			UHFSelectDataItems.Items.CopyTo(lRawItems, 0);
			UHFSelectDataItems.Items.Clear();

			foreach (Object lRawItem in lRawItems)
			{
				if (lRawItem is String)
					UHFAvailDataItems.Items.Add(lRawItem);
			}
		}

		private void MovePluginRightButton_Click(Object aSender, EventArgs aEventArgs)
		{
			if (AvailablePluginList.SelectedIndex != -1 &&
				AvailablePluginList.Items[AvailablePluginList.SelectedIndex] is String)
			{
				String lItem = 
					AvailablePluginList.Items[AvailablePluginList.SelectedIndex] as String;

				AvailablePluginList.Items.RemoveAt(AvailablePluginList.SelectedIndex);
				SelectedPluginList.Items.Add(lItem);
			}
		}

		private void MovePluginLeftButton_Click(Object aSender, EventArgs aEventArgs)
		{
			if (SelectedPluginList.SelectedIndex != -1 &&
				SelectedPluginList.Items[SelectedPluginList.SelectedIndex] is String)
			{
				String lItem =
					SelectedPluginList.Items[SelectedPluginList.SelectedIndex] as String;

				SelectedPluginList.Items.RemoveAt(SelectedPluginList.SelectedIndex);
				AvailablePluginList.Items.Add(lItem);
			}
		}

        private void ScaleFactorTrackBar_ValueChanged(object sender, EventArgs e)
        {
            // get value and update ScaleFactorLabel
            int scaleFactor = ScaleFactorTrackBar.Value;
            ScaleFactorLabel.Text = string.Format("Scale Factor: {0}%-(~{1}% dpi)", scaleFactor, ReaderMaxDpi * scaleFactor / 100);
        }

        private void ActiveVideoOption_Checked(object sender, EventArgs e)
        {
           if (ActiveVideoOption.Checked == true) ActiveReaderOption.Checked = false;
        }

        private void ActiveReaderOption_Checked(object sender, EventArgs e)
        {
           if (ActiveReaderOption.Checked == true) ActiveVideoOption.Checked = false;

        }

        private void ShowProgressOption_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void checkBoxEPASSPORT_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void checkBoxEDL_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void checkBoxEID_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void checkBoxIDL_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void RFIDSelectDataItems_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void ok_save_Click(object sender, EventArgs e)
        {
            try
            {
                MMM.Readers.FullPage.ReaderSettings lSettings;
                if (MMM.Readers.FullPage.Reader.GetSettings(out lSettings) == MMM.Readers.ErrorCode.NO_ERROR_OCCURRED)
                {
                    lSettings.puDataToSend.send |= MMM.Readers.FullPage.DataSendSet.Flags.DOCMARKERS;

                    if (CodelineOption.Checked)
                        lSettings.puDataToSend.send |= MMM.Readers.FullPage.DataSendSet.Flags.CODELINE;
                    else
                        lSettings.puDataToSend.send &= ~MMM.Readers.FullPage.DataSendSet.Flags.CODELINE;

                    if (ChecksumOption.Checked)
                        lSettings.puDataToSend.send |= MMM.Readers.FullPage.DataSendSet.Flags.CHECKSUM;
                    else
                        lSettings.puDataToSend.send &= ~MMM.Readers.FullPage.DataSendSet.Flags.CHECKSUM;

                    if (IRImageOption.Checked)
                        lSettings.puDataToSend.send |= MMM.Readers.FullPage.DataSendSet.Flags.IRIMAGE;
                    else
                        lSettings.puDataToSend.send &= ~MMM.Readers.FullPage.DataSendSet.Flags.IRIMAGE;

                    if (VisibleImageOption.Checked)
                        lSettings.puDataToSend.send |= MMM.Readers.FullPage.DataSendSet.Flags.VISIBLEIMAGE;
                    else
                        lSettings.puDataToSend.send &= ~MMM.Readers.FullPage.DataSendSet.Flags.VISIBLEIMAGE;

                    if (UVImageOption.Checked)
                        lSettings.puDataToSend.send |= MMM.Readers.FullPage.DataSendSet.Flags.UVIMAGE;
                    else
                        lSettings.puDataToSend.send &= ~MMM.Readers.FullPage.DataSendSet.Flags.UVIMAGE;

                    if (PhotoImageOption.Checked)
                        lSettings.puDataToSend.send |= MMM.Readers.FullPage.DataSendSet.Flags.PHOTOIMAGE;
                    else
                        lSettings.puDataToSend.send &= ~MMM.Readers.FullPage.DataSendSet.Flags.PHOTOIMAGE;

                    if (RFIDOption.Checked)
                        lSettings.puDataToSend.send |= MMM.Readers.FullPage.DataSendSet.Flags.SMARTCARD;
                    else
                        lSettings.puDataToSend.send &= ~MMM.Readers.FullPage.DataSendSet.Flags.SMARTCARD;

                    //if (SecurityCheckOption.Checked)
                        lSettings.puDataToSend.send |= MMM.Readers.FullPage.DataSendSet.Flags.SECURITYCHECK;
                    //else
                        //lSettings.puDataToSend.send &= ~MMM.Readers.FullPage.DataSendSet.Flags.SECURITYCHECK;

                    if (MSRDataOption.Checked)
                        lSettings.puDataToSend.send |= MMM.Readers.FullPage.DataSendSet.Flags.SWIPE;
                    else
                        lSettings.puDataToSend.send &= ~MMM.Readers.FullPage.DataSendSet.Flags.SWIPE;

                    if (AAMVAOption.Checked)
                        lSettings.puDataToSend.send |= MMM.Readers.FullPage.DataSendSet.Flags.AAMVA;
                    else
                        lSettings.puDataToSend.send &= ~MMM.Readers.FullPage.DataSendSet.Flags.AAMVA;

                    //if (CheckUVOption.Checked)
                        lSettings.puDataToSend.special |= MMM.Readers.FullPage.DataSendSet.Flags.SECURITYCHECK;
                    //else
                        //lSettings.puDataToSend.special &= ~MMM.Readers.FullPage.DataSendSet.Flags.SECURITYCHECK;

                    if (CroppedToCodelineOption.Checked)
                        lSettings.puDataToSend.special |= MMM.Readers.FullPage.DataSendSet.Flags.IRIMAGE;
                    else
                        lSettings.puDataToSend.special &= ~MMM.Readers.FullPage.DataSendSet.Flags.IRIMAGE;

                    //if (ColourOption.Checked)
                        lSettings.puDataToSend.special |= MMM.Readers.FullPage.DataSendSet.Flags.VISIBLEIMAGE;
                    //else
                       // lSettings.puDataToSend.special &= ~MMM.Readers.FullPage.DataSendSet.Flags.VISIBLEIMAGE;

                    // TL - 23 Feb 2015 - no longer supporting/updating old UV background support option in application.ini - will be moved to uv.puAmbientRemoval
                    //if (UVAmbientRemovalOption.Checked)
                    //    lSettings.puDataToSend.special |= MMM.Readers.FullPage.DataSendSet.Flags.UVIMAGE;
                    //else
                    //   lSettings.puDataToSend.special &= ~MMM.Readers.FullPage.DataSendSet.Flags.UVIMAGE;

                    lSettings.puCameraSettings.ir.puUseAntiGlare = IRAntiGlareOption.Checked;
                    lSettings.puCameraSettings.vis.puUseAntiGlare = VisibleAntiGlareOption.Checked;

                    lSettings.puCameraSettings.ir.puUseSequentialImaging = IRSequentialOption.Checked;
                    lSettings.puCameraSettings.vis.puUseSequentialImaging = VisibleSequentialOption.Checked;

                    lSettings.puCameraSettings.flap = 0;
                    if (ActiveVideoOption.Checked == true) lSettings.puCameraSettings.flap |= 0x08;
                    if (ActiveReaderOption.Checked == true) lSettings.puCameraSettings.flap |= 0x20;

                    lSettings.puCameraSettings.ir.puAmbientRemoval = (MMM.Readers.Modules.Camera.AmbientRemovalMethod)IRAmbientRemovalOption.SelectedIndex;
                    lSettings.puCameraSettings.vis.puAmbientRemoval = (MMM.Readers.Modules.Camera.AmbientRemovalMethod)VisibleAmbientRemovalOption.SelectedIndex;
                    lSettings.puCameraSettings.uv.puAmbientRemoval = (MMM.Readers.Modules.Camera.AmbientRemovalMethod)UVAmbientRemovalOption.SelectedIndex;

                    lSettings.puImageSettings.checkVisibleOcr = true;
                    lSettings.puImageSettings.useVisibleForBarcode = 0;
                    if (UseVisibleForBarcodeOption.Checked == true) lSettings.puImageSettings.useVisibleForBarcode = 1;


                    if (SendBarcodeImageOption.Checked)
                        lSettings.puDataToSend.send |= MMM.Readers.FullPage.DataSendSet.Flags.BARCODEIMAGE;
                    else
                        lSettings.puDataToSend.send &= ~MMM.Readers.FullPage.DataSendSet.Flags.BARCODEIMAGE;

                    if (UHFOption.Checked)
                        lSettings.puDataToSend.send |= MMM.Readers.FullPage.DataSendSet.Flags.UHF;
                    else
                        lSettings.puDataToSend.send &= ~MMM.Readers.FullPage.DataSendSet.Flags.UHF;

                    if (ShowProgressOption.Checked)
                        lSettings.puDataToSend.progress = 1;
                    else
                        lSettings.puDataToSend.progress = 0;

                    lSettings.puDataToSend.imageFormat =
                        (MMM.Readers.FullPage.ImageFormats)ImageFormatCombo.Items[ImageFormatCombo.SelectedIndex];

                    lSettings.puCameraSettings.scaleFactor = 100;
                    if (ScaleFactorTrackBar.Value >= 20 && ScaleFactorTrackBar.Value <= 100)
                        lSettings.puCameraSettings.scaleFactor = ScaleFactorTrackBar.Value;

                    if (this.checkBoxEPASSPORT.Checked)
                        lSettings.puRFIDSettings.puRFProcessSettings.puRFApplicationMode |= (int)MMM.Readers.Modules.RF.RF_APPLICATION_MODE.EPASSPORT;
                    else
                        lSettings.puRFIDSettings.puRFProcessSettings.puRFApplicationMode &= ~(int)MMM.Readers.Modules.RF.RF_APPLICATION_MODE.EPASSPORT;
                    if (this.checkBoxEID.Checked)
                        lSettings.puRFIDSettings.puRFProcessSettings.puRFApplicationMode |= (int)MMM.Readers.Modules.RF.RF_APPLICATION_MODE.EID;
                    else
                        lSettings.puRFIDSettings.puRFProcessSettings.puRFApplicationMode &= ~(int)MMM.Readers.Modules.RF.RF_APPLICATION_MODE.EID;
                    if (this.checkBoxEDL.Checked)
                        lSettings.puRFIDSettings.puRFProcessSettings.puRFApplicationMode |= (int)MMM.Readers.Modules.RF.RF_APPLICATION_MODE.EDL;
                    else
                        lSettings.puRFIDSettings.puRFProcessSettings.puRFApplicationMode &= ~(int)MMM.Readers.Modules.RF.RF_APPLICATION_MODE.EDL;
                    if (this.checkBoxIDL.Checked)
                        lSettings.puRFIDSettings.puRFProcessSettings.puRFApplicationMode |= (int)MMM.Readers.Modules.RF.RF_APPLICATION_MODE.IDL;
                    else
                        lSettings.puRFIDSettings.puRFProcessSettings.puRFApplicationMode &= ~(int)MMM.Readers.Modules.RF.RF_APPLICATION_MODE.IDL;

                    //StoreUHFOrder(ref lSettings.puDataToSend.uhf);
                    StoreRFIDOrder(ref lSettings.puDataToSend.rfid);
                    //StorePlugins();

                    MMM.Readers.FullPage.Reader.UpdateSettings(lSettings);
                    //MMM.Readers.FullPage.Reader.SaveSettings();
                }

                this.Close();
            }
            catch (Exception ex) {
                Console.WriteLine(ex.ToString());
            }

        }

        private void _cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void DataToSend_Load(object sender, EventArgs e)
        {

        }

        public void doMagic() {
            MMM.Readers.FullPage.ReaderSettings lSettings;
            MMM.Readers.ErrorCode lErrorCode =
                MMM.Readers.FullPage.Reader.GetSettings(out lSettings);

            if (lErrorCode == MMM.Readers.ErrorCode.NO_ERROR_OCCURRED)
            {
                // Optical data settings
                CodelineOption.Checked = (lSettings.puDataToSend.send &
                    MMM.Readers.FullPage.DataSendSet.Flags.CODELINE) != 0;

                ChecksumOption.Checked = (lSettings.puDataToSend.send &
                    MMM.Readers.FullPage.DataSendSet.Flags.CHECKSUM) != 0;

                IRImageOption.Checked = (lSettings.puDataToSend.send &
                    MMM.Readers.FullPage.DataSendSet.Flags.IRIMAGE) != 0;

                VisibleImageOption.Checked = (lSettings.puDataToSend.send &
                    MMM.Readers.FullPage.DataSendSet.Flags.VISIBLEIMAGE) != 0;

                UVImageOption.Checked = (lSettings.puDataToSend.send &
                    MMM.Readers.FullPage.DataSendSet.Flags.UVIMAGE) != 0;

                SecurityCheckOption.Checked = (lSettings.puDataToSend.send &
                    MMM.Readers.FullPage.DataSendSet.Flags.SECURITYCHECK) != 0;

                PhotoImageOption.Checked = (lSettings.puDataToSend.send &
                    MMM.Readers.FullPage.DataSendSet.Flags.PHOTOIMAGE) != 0;

                MSRDataOption.Checked = (lSettings.puDataToSend.send &
                    MMM.Readers.FullPage.DataSendSet.Flags.SWIPE) != 0;

                AAMVAOption.Checked = (lSettings.puDataToSend.send &
                    MMM.Readers.FullPage.DataSendSet.Flags.AAMVA) != 0;

                // Data modifier settings
                CroppedToCodelineOption.Checked = (lSettings.puDataToSend.special &
                    MMM.Readers.FullPage.DataSendSet.Flags.IRIMAGE) != 0;

                ColourOption.Checked = (lSettings.puDataToSend.special &
                    MMM.Readers.FullPage.DataSendSet.Flags.VISIBLEIMAGE) != 0;

                CheckUVOption.Checked = (lSettings.puDataToSend.special &
                    MMM.Readers.FullPage.DataSendSet.Flags.SECURITYCHECK) != 0;

                // TL - 23 Feb 2015 - no longer supporting/updating old UV background support option in application.ini - will be moved to uv.puAmbientRemoval
                //UVAmbientRemovalOption.Checked = (lSettings.puDataToSend.special &
                //    MMM.Readers.FullPage.DataSendSet.Flags.UVIMAGE) != 0;
                if ((lSettings.puDataToSend.special & MMM.Readers.FullPage.DataSendSet.Flags.UVIMAGE) != 0)
                    lSettings.puCameraSettings.uv.puAmbientRemoval = MMM.Readers.Modules.Camera.AmbientRemovalMethod.MRAS_BASIC_AMBIENT_REMOVAL;

                this.SendBarcodeImageOption.Checked = (lSettings.puDataToSend.send &
                    MMM.Readers.FullPage.DataSendSet.Flags.BARCODEIMAGE) != 0;

                IRAntiGlareOption.Checked = lSettings.puCameraSettings.ir.puUseAntiGlare;
                VisibleAntiGlareOption.Checked = lSettings.puCameraSettings.vis.puUseAntiGlare;

                IRSequentialOption.Checked = lSettings.puCameraSettings.ir.puUseSequentialImaging;
                VisibleSequentialOption.Checked = lSettings.puCameraSettings.vis.puUseSequentialImaging;

                if ((lSettings.puCameraSettings.flap & 0x20) != 0) ActiveReaderOption.Checked = true;
                else if ((lSettings.puCameraSettings.flap & 0x08) != 0) ActiveVideoOption.Checked = true;

                IRAmbientRemovalOption.SelectedIndex = (int)lSettings.puCameraSettings.ir.puAmbientRemoval;
                VisibleAmbientRemovalOption.SelectedIndex = (int)lSettings.puCameraSettings.vis.puAmbientRemoval;
                UVAmbientRemovalOption.SelectedIndex = (int)lSettings.puCameraSettings.uv.puAmbientRemoval;

                lSettings.puImageSettings.checkVisibleOcr = true;
                UseVisibleForBarcodeOption.Checked = (lSettings.puImageSettings.useVisibleForBarcode != 0);

                ImageFormatCombo.SelectedIndex = ImageFormatCombo.Items.IndexOf(lSettings.puDataToSend.imageFormat);

                int scaleFactor = lSettings.puCameraSettings.scaleFactor;

                if (scaleFactor == 0) scaleFactor = 100;
                if (scaleFactor < 20) scaleFactor = 20;

                ScaleFactorTrackBar.Value = scaleFactor;
                ReaderMaxDpi = (lSettings.puCameraSettings.xDPI + lSettings.puCameraSettings.yDPI) / 2 * 100 / scaleFactor;

                ScaleFactorLabel.Text = string.Format("Scale Factor: {0}%-(~{1}% dpi)", scaleFactor, ReaderMaxDpi * scaleFactor / 100);

                // Other settings
                SetRFIDEnabled
                (
                    (lSettings.puDataToSend.send &
                        MMM.Readers.FullPage.DataSendSet.Flags.SMARTCARD) != 0
                );

                SetUHFEnabled
                (
                    (lSettings.puDataToSend.send &
                    MMM.Readers.FullPage.DataSendSet.Flags.UHF) != 0
                );

                ShowProgressOption.Checked = lSettings.puDataToSend.progress != 0;

                this.checkBoxEPASSPORT.Checked =
                    (lSettings.puRFIDSettings.puRFProcessSettings.puRFApplicationMode & (int)MMM.Readers.Modules.RF.RF_APPLICATION_MODE.EPASSPORT) != 0;
                this.checkBoxEID.Checked =
                    (lSettings.puRFIDSettings.puRFProcessSettings.puRFApplicationMode & (int)MMM.Readers.Modules.RF.RF_APPLICATION_MODE.EID) != 0;
                this.checkBoxEDL.Checked =
                    (lSettings.puRFIDSettings.puRFProcessSettings.puRFApplicationMode & (int)MMM.Readers.Modules.RF.RF_APPLICATION_MODE.EDL) != 0;
                this.checkBoxIDL.Checked =
                    (lSettings.puRFIDSettings.puRFProcessSettings.puRFApplicationMode & (int)MMM.Readers.Modules.RF.RF_APPLICATION_MODE.IDL) != 0;

                PopulateUHFLists(lSettings.puDataToSend.uhf);
                PopulateRFIDLists(lSettings.puDataToSend.rfid);
                PopulatePluginLists();
            }
            
        }

        public void doMagic2() {
            try
            {
                Console.WriteLine("I am here again mehn");
                MMM.Readers.FullPage.ReaderSettings lSettings;
                if (MMM.Readers.FullPage.Reader.GetSettings(out lSettings) == MMM.Readers.ErrorCode.NO_ERROR_OCCURRED)
                {
                    lSettings.puDataToSend.send |= MMM.Readers.FullPage.DataSendSet.Flags.DOCMARKERS;

                    if (CodelineOption.Checked)
                        lSettings.puDataToSend.send |= MMM.Readers.FullPage.DataSendSet.Flags.CODELINE;
                    else
                        lSettings.puDataToSend.send &= ~MMM.Readers.FullPage.DataSendSet.Flags.CODELINE;

                    if (ChecksumOption.Checked)
                        lSettings.puDataToSend.send |= MMM.Readers.FullPage.DataSendSet.Flags.CHECKSUM;
                    else
                        lSettings.puDataToSend.send &= ~MMM.Readers.FullPage.DataSendSet.Flags.CHECKSUM;

                    if (IRImageOption.Checked)
                        lSettings.puDataToSend.send |= MMM.Readers.FullPage.DataSendSet.Flags.IRIMAGE;
                    else
                        lSettings.puDataToSend.send &= ~MMM.Readers.FullPage.DataSendSet.Flags.IRIMAGE;

                    if (VisibleImageOption.Checked)
                        lSettings.puDataToSend.send |= MMM.Readers.FullPage.DataSendSet.Flags.VISIBLEIMAGE;
                    else
                        lSettings.puDataToSend.send &= ~MMM.Readers.FullPage.DataSendSet.Flags.VISIBLEIMAGE;

                    if (UVImageOption.Checked)
                        lSettings.puDataToSend.send |= MMM.Readers.FullPage.DataSendSet.Flags.UVIMAGE;
                    else
                        lSettings.puDataToSend.send &= ~MMM.Readers.FullPage.DataSendSet.Flags.UVIMAGE;

                    if (PhotoImageOption.Checked)
                        lSettings.puDataToSend.send |= MMM.Readers.FullPage.DataSendSet.Flags.PHOTOIMAGE;
                    else
                        lSettings.puDataToSend.send &= ~MMM.Readers.FullPage.DataSendSet.Flags.PHOTOIMAGE;

                    if (RFIDOption.Checked)
                        lSettings.puDataToSend.send |= MMM.Readers.FullPage.DataSendSet.Flags.SMARTCARD;
                    else
                        lSettings.puDataToSend.send &= ~MMM.Readers.FullPage.DataSendSet.Flags.SMARTCARD;

                    //if (SecurityCheckOption.Checked)
                    lSettings.puDataToSend.send |= MMM.Readers.FullPage.DataSendSet.Flags.SECURITYCHECK;
                    //else
                    //lSettings.puDataToSend.send &= ~MMM.Readers.FullPage.DataSendSet.Flags.SECURITYCHECK;

                    if (MSRDataOption.Checked)
                        lSettings.puDataToSend.send |= MMM.Readers.FullPage.DataSendSet.Flags.SWIPE;
                    else
                        lSettings.puDataToSend.send &= ~MMM.Readers.FullPage.DataSendSet.Flags.SWIPE;

                    if (AAMVAOption.Checked)
                        lSettings.puDataToSend.send |= MMM.Readers.FullPage.DataSendSet.Flags.AAMVA;
                    else
                        lSettings.puDataToSend.send &= ~MMM.Readers.FullPage.DataSendSet.Flags.AAMVA;

                    //if (CheckUVOption.Checked)
                    lSettings.puDataToSend.special |= MMM.Readers.FullPage.DataSendSet.Flags.SECURITYCHECK;
                    //else
                    //lSettings.puDataToSend.special &= ~MMM.Readers.FullPage.DataSendSet.Flags.SECURITYCHECK;

                    if (CroppedToCodelineOption.Checked)
                        lSettings.puDataToSend.special |= MMM.Readers.FullPage.DataSendSet.Flags.IRIMAGE;
                    else
                        lSettings.puDataToSend.special &= ~MMM.Readers.FullPage.DataSendSet.Flags.IRIMAGE;

                    //if (ColourOption.Checked)
                    lSettings.puDataToSend.special |= MMM.Readers.FullPage.DataSendSet.Flags.VISIBLEIMAGE;
                    //else
                    // lSettings.puDataToSend.special &= ~MMM.Readers.FullPage.DataSendSet.Flags.VISIBLEIMAGE;

                    // TL - 23 Feb 2015 - no longer supporting/updating old UV background support option in application.ini - will be moved to uv.puAmbientRemoval
                    //if (UVAmbientRemovalOption.Checked)
                    //    lSettings.puDataToSend.special |= MMM.Readers.FullPage.DataSendSet.Flags.UVIMAGE;
                    //else
                    //   lSettings.puDataToSend.special &= ~MMM.Readers.FullPage.DataSendSet.Flags.UVIMAGE;

                    lSettings.puCameraSettings.ir.puUseAntiGlare = IRAntiGlareOption.Checked;
                    lSettings.puCameraSettings.vis.puUseAntiGlare = VisibleAntiGlareOption.Checked;

                    lSettings.puCameraSettings.ir.puUseSequentialImaging = IRSequentialOption.Checked;
                    lSettings.puCameraSettings.vis.puUseSequentialImaging = VisibleSequentialOption.Checked;

                    lSettings.puCameraSettings.flap = 0;
                    if (ActiveVideoOption.Checked == true) lSettings.puCameraSettings.flap |= 0x08;
                    if (ActiveReaderOption.Checked == true) lSettings.puCameraSettings.flap |= 0x20;

                    lSettings.puCameraSettings.ir.puAmbientRemoval = (MMM.Readers.Modules.Camera.AmbientRemovalMethod)IRAmbientRemovalOption.SelectedIndex;
                    lSettings.puCameraSettings.vis.puAmbientRemoval = (MMM.Readers.Modules.Camera.AmbientRemovalMethod)VisibleAmbientRemovalOption.SelectedIndex;
                    lSettings.puCameraSettings.uv.puAmbientRemoval = (MMM.Readers.Modules.Camera.AmbientRemovalMethod)UVAmbientRemovalOption.SelectedIndex;

                    lSettings.puImageSettings.checkVisibleOcr = true;
                    lSettings.puImageSettings.useVisibleForBarcode = 0;
                    if (UseVisibleForBarcodeOption.Checked == true) lSettings.puImageSettings.useVisibleForBarcode = 1;

                    if (SendBarcodeImageOption.Checked)
                        lSettings.puDataToSend.send |= MMM.Readers.FullPage.DataSendSet.Flags.BARCODEIMAGE;
                    else
                        lSettings.puDataToSend.send &= ~MMM.Readers.FullPage.DataSendSet.Flags.BARCODEIMAGE;

                    if (UHFOption.Checked)
                        lSettings.puDataToSend.send |= MMM.Readers.FullPage.DataSendSet.Flags.UHF;
                    else
                        lSettings.puDataToSend.send &= ~MMM.Readers.FullPage.DataSendSet.Flags.UHF;

                    if (ShowProgressOption.Checked)
                        lSettings.puDataToSend.progress = 1;
                    else
                        lSettings.puDataToSend.progress = 0;

                    lSettings.puDataToSend.imageFormat =
                        (MMM.Readers.FullPage.ImageFormats)ImageFormatCombo.Items[ImageFormatCombo.SelectedIndex];

                    lSettings.puCameraSettings.scaleFactor = 100;
                    if (ScaleFactorTrackBar.Value >= 20 && ScaleFactorTrackBar.Value <= 100)
                        lSettings.puCameraSettings.scaleFactor = ScaleFactorTrackBar.Value;

                    if (this.checkBoxEPASSPORT.Checked)
                        lSettings.puRFIDSettings.puRFProcessSettings.puRFApplicationMode |= (int)MMM.Readers.Modules.RF.RF_APPLICATION_MODE.EPASSPORT;
                    else
                        lSettings.puRFIDSettings.puRFProcessSettings.puRFApplicationMode &= ~(int)MMM.Readers.Modules.RF.RF_APPLICATION_MODE.EPASSPORT;
                    if (this.checkBoxEID.Checked)
                        lSettings.puRFIDSettings.puRFProcessSettings.puRFApplicationMode |= (int)MMM.Readers.Modules.RF.RF_APPLICATION_MODE.EID;
                    else
                        lSettings.puRFIDSettings.puRFProcessSettings.puRFApplicationMode &= ~(int)MMM.Readers.Modules.RF.RF_APPLICATION_MODE.EID;
                    if (this.checkBoxEDL.Checked)
                        lSettings.puRFIDSettings.puRFProcessSettings.puRFApplicationMode |= (int)MMM.Readers.Modules.RF.RF_APPLICATION_MODE.EDL;
                    else
                        lSettings.puRFIDSettings.puRFProcessSettings.puRFApplicationMode &= ~(int)MMM.Readers.Modules.RF.RF_APPLICATION_MODE.EDL;
                    if (this.checkBoxIDL.Checked)
                        lSettings.puRFIDSettings.puRFProcessSettings.puRFApplicationMode |= (int)MMM.Readers.Modules.RF.RF_APPLICATION_MODE.IDL;
                    else
                        lSettings.puRFIDSettings.puRFProcessSettings.puRFApplicationMode &= ~(int)MMM.Readers.Modules.RF.RF_APPLICATION_MODE.IDL;

                    //StoreUHFOrder(ref lSettings.puDataToSend.uhf);
                    StoreRFIDOrder(ref lSettings.puDataToSend.rfid);
                    //StorePlugins();

                    MMM.Readers.FullPage.Reader.UpdateSettings(lSettings);
                    Console.WriteLine("ANd I am done mehn");
                    //MMM.Readers.FullPage.Reader.SaveSettings();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }
    }
    public static class StringConstant
    {
        public static string[] AmbientString = new string[] { 
	        "No Ambient Removal",
	        "Basic Ambient Removal",
	        "Post Gain Ambient Removal",
	        "Hardware Ambient Removal",
	        "Hardware Medium Ambient Removal",
	        "Hardware Extreme Ambient Removal"
        };
    }
}