namespace TravelPass
{
    partial class AddAdditionalScan
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
            this.done_scanning = new System.Windows.Forms.Button();
            this.add_scan = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // done_scanning
            // 
            this.done_scanning.BackColor = System.Drawing.Color.White;
            this.done_scanning.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.done_scanning.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.done_scanning.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(140)))), ((int)(((byte)(0)))));
            this.done_scanning.Location = new System.Drawing.Point(239, 23);
            this.done_scanning.Name = "done_scanning";
            this.done_scanning.Size = new System.Drawing.Size(201, 33);
            this.done_scanning.TabIndex = 23;
            this.done_scanning.Text = "Done Scanning";
            this.done_scanning.UseVisualStyleBackColor = false;
            this.done_scanning.Click += new System.EventHandler(this.done_scanning_Click);
            // 
            // add_scan
            // 
            this.add_scan.BackColor = System.Drawing.Color.White;
            this.add_scan.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.add_scan.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.add_scan.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.add_scan.Location = new System.Drawing.Point(12, 23);
            this.add_scan.Name = "add_scan";
            this.add_scan.Size = new System.Drawing.Size(201, 33);
            this.add_scan.TabIndex = 24;
            this.add_scan.Text = "Add Another Scan";
            this.add_scan.UseVisualStyleBackColor = false;
            this.add_scan.Click += new System.EventHandler(this.add_scan_Click);
            // 
            // AddAdditionalScan
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(453, 79);
            this.Controls.Add(this.done_scanning);
            this.Controls.Add(this.add_scan);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AddAdditionalScan";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Add Additional Scan";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button done_scanning;
        private System.Windows.Forms.Button add_scan;
    }
}