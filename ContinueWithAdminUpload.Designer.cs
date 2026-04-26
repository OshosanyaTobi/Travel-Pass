namespace TravelPass
{
    partial class ContinueWithAdminUpload
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
            this.cancel = new System.Windows.Forms.Button();
            this.continue_ = new System.Windows.Forms.Button();
            this.signin_pwd_textbox = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // cancel
            // 
            this.cancel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.cancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cancel.ForeColor = System.Drawing.Color.White;
            this.cancel.Location = new System.Drawing.Point(27, 81);
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
            this.continue_.Location = new System.Drawing.Point(158, 81);
            this.continue_.Name = "continue_";
            this.continue_.Size = new System.Drawing.Size(103, 28);
            this.continue_.TabIndex = 3;
            this.continue_.Text = "Continue";
            this.continue_.UseVisualStyleBackColor = false;
            this.continue_.Click += new System.EventHandler(this.continue__Click);
            // 
            // signin_pwd_textbox
            // 
            this.signin_pwd_textbox.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.signin_pwd_textbox.ForeColor = System.Drawing.SystemColors.GrayText;
            this.signin_pwd_textbox.Location = new System.Drawing.Point(27, 28);
            this.signin_pwd_textbox.Name = "signin_pwd_textbox";
            this.signin_pwd_textbox.PasswordChar = '*';
            this.signin_pwd_textbox.Size = new System.Drawing.Size(234, 22);
            this.signin_pwd_textbox.TabIndex = 2;
            this.signin_pwd_textbox.Text = "Password";
            this.signin_pwd_textbox.Enter += new System.EventHandler(this.signin_pwd_textbox_Enter);
            this.signin_pwd_textbox.Leave += new System.EventHandler(this.signin_pwd_textbox_Leave);
            // 
            // ContinueWithAdminUpload
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.ClientSize = new System.Drawing.Size(309, 124);
            this.ControlBox = false;
            this.Controls.Add(this.signin_pwd_textbox);
            this.Controls.Add(this.continue_);
            this.Controls.Add(this.cancel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ContinueWithAdminUpload";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Please enter a pass phrase";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.SignInTravelPass_KeyDown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button cancel;
        private System.Windows.Forms.Button continue_;
        private System.Windows.Forms.TextBox signin_pwd_textbox;
    }
}

