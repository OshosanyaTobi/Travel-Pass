namespace TravelPass
{
    partial class SmartSearchForm
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.pnl_top      = new System.Windows.Forms.Panel();
            this.lbl_hint     = new System.Windows.Forms.Label();
            this.txt_search   = new System.Windows.Forms.TextBox();
            this.btn_search   = new System.Windows.Forms.Button();
            this.resultsGrid  = new System.Windows.Forms.DataGridView();
            this.pnl_bottom   = new System.Windows.Forms.Panel();
            this.progressBar  = new System.Windows.Forms.ProgressBar();
            this.lbl_status   = new System.Windows.Forms.Label();
            this.btn_rebuild  = new System.Windows.Forms.Button();
            this.btn_sync     = new System.Windows.Forms.Button();
            this.pnl_top.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.resultsGrid)).BeginInit();
            this.pnl_bottom.SuspendLayout();
            this.SuspendLayout();

            // ── pnl_top ──────────────────────────────────────────────────── //
            this.pnl_top.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnl_top.Height = 72;
            this.pnl_top.Controls.Add(this.lbl_hint);
            this.pnl_top.Controls.Add(this.txt_search);
            this.pnl_top.Controls.Add(this.btn_search);

            // lbl_hint
            this.lbl_hint.AutoSize  = false;
            this.lbl_hint.Location  = new System.Drawing.Point(10, 8);
            this.lbl_hint.Size      = new System.Drawing.Size(840, 16);
            this.lbl_hint.Text      = "Type a query in plain English — e.g. \"Nigerian passports with RFID failure last week\" or \"all flagged visas\"";
            this.lbl_hint.Font      = new System.Drawing.Font("Microsoft Sans Serif", 7.5F,
                System.Drawing.FontStyle.Italic);
            this.lbl_hint.ForeColor = System.Drawing.Color.Gray;

            // txt_search
            this.txt_search.Location = new System.Drawing.Point(10, 30);
            this.txt_search.Size     = new System.Drawing.Size(740, 23);
            this.txt_search.Font     = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.txt_search.TabIndex = 0;
            this.txt_search.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txt_search_KeyDown);

            // btn_search
            this.btn_search.Text      = "Search";
            this.btn_search.Location  = new System.Drawing.Point(758, 28);
            this.btn_search.Size      = new System.Drawing.Size(100, 27);
            this.btn_search.TabIndex  = 1;
            this.btn_search.BackColor = System.Drawing.Color.FromArgb(0, 140, 0);
            this.btn_search.ForeColor = System.Drawing.Color.White;
            this.btn_search.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_search.Font      = new System.Drawing.Font("Microsoft Sans Serif", 9F,
                System.Drawing.FontStyle.Bold);
            this.btn_search.Click    += new System.EventHandler(this.btn_search_Click);

            // ── resultsGrid ───────────────────────────────────────────────── //
            this.resultsGrid.AllowUserToAddRows    = false;
            this.resultsGrid.AllowUserToDeleteRows = false;
            this.resultsGrid.ReadOnly              = true;
            this.resultsGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.resultsGrid.BackgroundColor =
                System.Drawing.SystemColors.GradientInactiveCaption;
            this.resultsGrid.BorderStyle =
                System.Windows.Forms.BorderStyle.None;
            this.resultsGrid.ColumnHeadersHeightSizeMode =
                System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.resultsGrid.RowHeadersWidth = 51;

            // ── pnl_bottom ────────────────────────────────────────────────── //
            this.pnl_bottom.Dock   = System.Windows.Forms.DockStyle.Bottom;
            this.pnl_bottom.Height = 42;
            this.pnl_bottom.Controls.Add(this.progressBar);
            this.pnl_bottom.Controls.Add(this.lbl_status);
            this.pnl_bottom.Controls.Add(this.btn_rebuild);
            this.pnl_bottom.Controls.Add(this.btn_sync);

            // progressBar
            this.progressBar.Location = new System.Drawing.Point(10, 12);
            this.progressBar.Size     = new System.Drawing.Size(320, 16);
            this.progressBar.Visible  = false;
            this.progressBar.TabStop  = false;

            // lbl_status
            this.lbl_status.AutoSize  = false;
            this.lbl_status.Location  = new System.Drawing.Point(10, 13);
            this.lbl_status.Size      = new System.Drawing.Size(480, 18);
            this.lbl_status.Text      = "Ready.";
            this.lbl_status.Font      = new System.Drawing.Font("Microsoft Sans Serif", 8F);

            // btn_rebuild
            this.btn_rebuild.Text      = "Rebuild Index";
            this.btn_rebuild.Location  = new System.Drawing.Point(500, 9);
            this.btn_rebuild.Size      = new System.Drawing.Size(120, 25);
            this.btn_rebuild.TabIndex  = 2;
            this.btn_rebuild.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_rebuild.Font      = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.btn_rebuild.Click    += new System.EventHandler(this.btn_rebuild_Click);

            // btn_sync
            this.btn_sync.Text      = "Sync";
            this.btn_sync.Location  = new System.Drawing.Point(628, 9);
            this.btn_sync.Size      = new System.Drawing.Size(75, 25);
            this.btn_sync.TabIndex  = 3;
            this.btn_sync.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_sync.Font      = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.btn_sync.Click    += new System.EventHandler(this.btn_sync_Click);

            // ── SmartSearchForm ───────────────────────────────────────────── //
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode       = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor           = System.Drawing.SystemColors.GradientInactiveCaption;
            this.ClientSize          = new System.Drawing.Size(880, 530);
            this.Controls.Add(this.resultsGrid);
            this.Controls.Add(this.pnl_top);
            this.Controls.Add(this.pnl_bottom);
            this.FormBorderStyle  = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.KeyPreview       = true;
            this.MinimizeBox      = false;
            this.Name             = "SmartSearchForm";
            this.StartPosition    = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text             = "Smart Passenger Search";
            this.Load            += new System.EventHandler(this.SmartSearchForm_Load);
            this.KeyDown         += new System.Windows.Forms.KeyEventHandler(this.SmartSearchForm_KeyDown);

            this.pnl_top.ResumeLayout(false);
            this.pnl_top.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.resultsGrid)).EndInit();
            this.pnl_bottom.ResumeLayout(false);
            this.ResumeLayout(false);
        }

        private System.Windows.Forms.Panel         pnl_top;
        private System.Windows.Forms.Label         lbl_hint;
        private System.Windows.Forms.TextBox       txt_search;
        private System.Windows.Forms.Button        btn_search;
        private System.Windows.Forms.DataGridView  resultsGrid;
        private System.Windows.Forms.Panel         pnl_bottom;
        private System.Windows.Forms.ProgressBar   progressBar;
        private System.Windows.Forms.Label         lbl_status;
        private System.Windows.Forms.Button        btn_rebuild;
        private System.Windows.Forms.Button        btn_sync;
    }
}
