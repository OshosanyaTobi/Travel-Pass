namespace TravelPass
{
    partial class SignInTravelPass
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
            this.label1 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.logo__setup = new System.Windows.Forms.PictureBox();
            this.topPanelSetup = new System.Windows.Forms.Panel();
            this.cancel = new System.Windows.Forms.Button();
            this.continue_ = new System.Windows.Forms.Button();
            this.quitSetupLabel = new System.Windows.Forms.Label();
            this.minimizeSetupLabel = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.signin_email_textbox = new System.Windows.Forms.TextBox();
            this.signin_pwd_textbox = new System.Windows.Forms.TextBox();
            this.minimizeSetup = new System.Windows.Forms.PictureBox();
            this.quitSetup = new System.Windows.Forms.PictureBox();
            this.bunifuImageButton2 = new Bunifu.Framework.UI.BunifuImageButton();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.logo__setup)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.minimizeSetup)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.quitSetup)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bunifuImageButton2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(206, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(117, 25);
            this.label1.TabIndex = 0;
            this.label1.Text = "TravelPass";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(87)))), ((int)(((byte)(138)))), ((int)(((byte)(214)))));
            this.panel1.Controls.Add(this.logo__setup);
            this.panel1.Controls.Add(this.topPanelSetup);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(200, 408);
            this.panel1.TabIndex = 1;
            // 
            // logo__setup
            // 
            this.logo__setup.Image = global::TravelPass.Properties.Resources.TravelPass_Logo_Blue_Icon_Round_2_8_18;
            this.logo__setup.Location = new System.Drawing.Point(49, 149);
            this.logo__setup.Name = "logo__setup";
            this.logo__setup.Size = new System.Drawing.Size(100, 101);
            this.logo__setup.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.logo__setup.TabIndex = 9;
            this.logo__setup.TabStop = false;
            this.logo__setup.Click += new System.EventHandler(this.logo__setup_Click);
            this.logo__setup.DoubleClick += new System.EventHandler(this.logo__setup_DoubleClick);
            // 
            // topPanelSetup
            // 
            this.topPanelSetup.Location = new System.Drawing.Point(199, 0);
            this.topPanelSetup.Name = "topPanelSetup";
            this.topPanelSetup.Size = new System.Drawing.Size(294, 53);
            this.topPanelSetup.TabIndex = 7;
            // 
            // cancel
            // 
            this.cancel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.cancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cancel.ForeColor = System.Drawing.Color.White;
            this.cancel.Location = new System.Drawing.Point(234, 283);
            this.cancel.Name = "cancel";
            this.cancel.Size = new System.Drawing.Size(103, 28);
            this.cancel.TabIndex = 0;
            this.cancel.Text = "Cancel";
            this.cancel.UseVisualStyleBackColor = false;
            this.cancel.Click += new System.EventHandler(this.cancel_Click);
            // 
            // continue_
            // 
            this.continue_.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(87)))), ((int)(((byte)(138)))), ((int)(((byte)(214)))));
            this.continue_.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.continue_.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.continue_.Location = new System.Drawing.Point(365, 283);
            this.continue_.Name = "continue_";
            this.continue_.Size = new System.Drawing.Size(103, 28);
            this.continue_.TabIndex = 3;
            this.continue_.Text = "Continue";
            this.continue_.UseVisualStyleBackColor = false;
            this.continue_.Click += new System.EventHandler(this.continue__Click);
            // 
            // quitSetupLabel
            // 
            this.quitSetupLabel.AutoSize = true;
            this.quitSetupLabel.Location = new System.Drawing.Point(462, 30);
            this.quitSetupLabel.Name = "quitSetupLabel";
            this.quitSetupLabel.Size = new System.Drawing.Size(34, 17);
            this.quitSetupLabel.TabIndex = 6;
            this.quitSetupLabel.Text = "Quit";
            this.quitSetupLabel.Visible = false;
            // 
            // minimizeSetupLabel
            // 
            this.minimizeSetupLabel.AutoSize = true;
            this.minimizeSetupLabel.Location = new System.Drawing.Point(405, 30);
            this.minimizeSetupLabel.Name = "minimizeSetupLabel";
            this.minimizeSetupLabel.Size = new System.Drawing.Size(62, 17);
            this.minimizeSetupLabel.TabIndex = 6;
            this.minimizeSetupLabel.Text = "Minimize";
            this.minimizeSetupLabel.Visible = false;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(206, 30);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(51, 17);
            this.label7.TabIndex = 7;
            this.label7.Text = "Sign In";
            // 
            // signin_email_textbox
            // 
            this.signin_email_textbox.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.signin_email_textbox.ForeColor = System.Drawing.SystemColors.GrayText;
            this.signin_email_textbox.Location = new System.Drawing.Point(234, 183);
            this.signin_email_textbox.Name = "signin_email_textbox";
            this.signin_email_textbox.Size = new System.Drawing.Size(234, 22);
            this.signin_email_textbox.TabIndex = 1;
            this.signin_email_textbox.Text = "Email or User ID";
            this.signin_email_textbox.Enter += new System.EventHandler(this.signin_email_textbox_Enter);
            this.signin_email_textbox.Leave += new System.EventHandler(this.signin_email_textbox_Leave);
            // 
            // signin_pwd_textbox
            // 
            this.signin_pwd_textbox.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.signin_pwd_textbox.ForeColor = System.Drawing.SystemColors.GrayText;
            this.signin_pwd_textbox.Location = new System.Drawing.Point(234, 230);
            this.signin_pwd_textbox.Name = "signin_pwd_textbox";
            this.signin_pwd_textbox.PasswordChar = '*';
            this.signin_pwd_textbox.Size = new System.Drawing.Size(234, 22);
            this.signin_pwd_textbox.TabIndex = 2;
            this.signin_pwd_textbox.Text = "Password";
            this.signin_pwd_textbox.Enter += new System.EventHandler(this.signin_pwd_textbox_Enter);
            this.signin_pwd_textbox.Leave += new System.EventHandler(this.signin_pwd_textbox_Leave);
            // 
            // minimizeSetup
            // 
            this.minimizeSetup.Image = global::TravelPass.Properties.Resources.Minimize_Window_96px;
            this.minimizeSetup.Location = new System.Drawing.Point(431, 0);
            this.minimizeSetup.Name = "minimizeSetup";
            this.minimizeSetup.Size = new System.Drawing.Size(28, 27);
            this.minimizeSetup.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.minimizeSetup.TabIndex = 5;
            this.minimizeSetup.TabStop = false;
            this.minimizeSetup.Click += new System.EventHandler(this.minimizeSetup_Click);
            // 
            // quitSetup
            // 
            this.quitSetup.Image = global::TravelPass.Properties.Resources.Delete_96px;
            this.quitSetup.Location = new System.Drawing.Point(465, 0);
            this.quitSetup.Name = "quitSetup";
            this.quitSetup.Size = new System.Drawing.Size(28, 27);
            this.quitSetup.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.quitSetup.TabIndex = 5;
            this.quitSetup.TabStop = false;
            this.quitSetup.Click += new System.EventHandler(this.quitSetup_Click);
            // 
            // bunifuImageButton2
            // 
            this.bunifuImageButton2.BackColor = System.Drawing.Color.Transparent;
            this.bunifuImageButton2.Image = global::TravelPass.Properties.Resources.newpng;
            this.bunifuImageButton2.ImageActive = null;
            this.bunifuImageButton2.Location = new System.Drawing.Point(280, 59);
            this.bunifuImageButton2.Name = "bunifuImageButton2";
            this.bunifuImageButton2.Size = new System.Drawing.Size(128, 99);
            this.bunifuImageButton2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.bunifuImageButton2.TabIndex = 15;
            this.bunifuImageButton2.TabStop = false;
            this.bunifuImageButton2.Zoom = 10;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBox1.Image = global::TravelPass.Properties.Resources.TravelPass_Logo_Blue_Icon_Round_2_8_18;
            this.pictureBox1.Location = new System.Drawing.Point(456, 371);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(30, 30);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 16;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // SignInTravelPass
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.ClientSize = new System.Drawing.Size(494, 408);
            this.ControlBox = false;
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.bunifuImageButton2);
            this.Controls.Add(this.signin_pwd_textbox);
            this.Controls.Add(this.signin_email_textbox);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.minimizeSetupLabel);
            this.Controls.Add(this.quitSetupLabel);
            this.Controls.Add(this.minimizeSetup);
            this.Controls.Add(this.quitSetup);
            this.Controls.Add(this.continue_);
            this.Controls.Add(this.cancel);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SignInTravelPass";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "TravelPass";
            this.Load += new System.EventHandler(this.SignInTravelPass_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.SignInTravelPass_KeyDown);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.logo__setup)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.minimizeSetup)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.quitSetup)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bunifuImageButton2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button cancel;
        private System.Windows.Forms.Button continue_;
        private System.Windows.Forms.PictureBox quitSetup;
        private System.Windows.Forms.PictureBox minimizeSetup;
        private System.Windows.Forms.Label quitSetupLabel;
        private System.Windows.Forms.Label minimizeSetupLabel;
        private System.Windows.Forms.Panel topPanelSetup;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.PictureBox logo__setup;
        private System.Windows.Forms.TextBox signin_email_textbox;
        private System.Windows.Forms.TextBox signin_pwd_textbox;
        private Bunifu.Framework.UI.BunifuImageButton bunifuImageButton2;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}

