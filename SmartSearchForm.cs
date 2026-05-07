using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Windows.Forms;

namespace TravelPass
{
    public partial class SmartSearchForm : Form
    {
        private readonly string _flightsRoot;

        public SmartSearchForm(string flightsRoot)
        {
            InitializeComponent();
            _flightsRoot = flightsRoot;
        }

        private void SmartSearchForm_Load(object sender, EventArgs e)
        {
            // Try loading an existing index; if none exists prompt to build.
            if (RecordIndex.GetEntries() == null)
            {
                bool loaded = RecordIndex.Load(_flightsRoot);
                if (!loaded)
                {
                    DialogResult dr = MessageBox.Show(
                        "No search index found.\n\n" +
                        "Build the index now? This crawls all flight records and may take a moment.",
                        "Smart Passenger Search",
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Question,
                        MessageBoxDefaultButton.Button1,
                        MessageBoxOptions.RightAlign, false);
                    if (dr == DialogResult.Yes)
                        StartRebuild();
                    else
                        UpdateStatus("No index loaded. Click 'Rebuild Index' to build one.");
                }
                else
                {
                    UpdateStatus(null);
                }
            }
            else
            {
                UpdateStatus(null);
            }
        }

        // ------------------------------------------------------------------ //
        //  Image search                                                        //
        // ------------------------------------------------------------------ //

        private void btn_image_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog dlg = new OpenFileDialog())
            {
                dlg.Title  = "Select passport or document image";
                dlg.Filter = "Image files|*.jpg;*.jpeg;*.png;*.bmp|All files|*.*";

                if (dlg.ShowDialog() != DialogResult.OK) return;

                string imagePath = dlg.FileName;
                lbl_image_name.Text    = System.IO.Path.GetFileName(imagePath);
                lbl_image_name.Visible = true;

                if (RecordIndex.GetEntries() == null)
                {
                    MessageBox.Show(
                        "Please build the search index first (click 'Rebuild Index').",
                        "No Index", MessageBoxButtons.OK, MessageBoxIcon.Warning,
                        MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign, false);
                    return;
                }

                btn_image.Enabled  = false;
                btn_search.Enabled = false;
                UpdateStatus("Analysing image with Ollama llava...");

                BackgroundWorker worker = new BackgroundWorker();
                worker.DoWork += (s, args) =>
                {
                    SearchCriteria criteria = AISearchEngine.ParseImageQuery(imagePath);
                    args.Result = RecordIndex.Search(criteria);
                };
                worker.RunWorkerCompleted += (s, args) =>
                {
                    btn_image.Enabled  = true;
                    btn_search.Enabled = true;

                    if (args.Error != null)
                    {
                        string msg =
                            (args.Error.Message.Contains("Unable to connect") ||
                             args.Error.Message.Contains("actively refused") ||
                             args.Error.Message.Contains("Connection refused"))
                            ? "Ollama is not running.\n\nPlease start Ollama and try again."
                            : args.Error.Message.Contains("404") || args.Error.Message.Contains("llava")
                            ? "The llava model is not installed.\n\nRun:  ollama pull llava"
                            : "Image search error: " + args.Error.Message;
                        MessageBox.Show(msg, "Image Search Error", MessageBoxButtons.OK,
                            MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1,
                            MessageBoxOptions.RightAlign, false);
                        UpdateStatus("Image search failed.");
                        return;
                    }

                    List<IndexEntry> results = (List<IndexEntry>)args.Result;
                    UpdateStatus(results.Count + " result(s) found for image.");
                    BindResults(results);
                };
                worker.RunWorkerAsync();
            }
        }

        // ------------------------------------------------------------------ //
        //  Text search                                                         //
        // ------------------------------------------------------------------ //

        private void btn_search_Click(object sender, EventArgs e)
        {
            string query = txt_search.Text.Trim();
            if (string.IsNullOrEmpty(query)) return;

            if (RecordIndex.GetEntries() == null)
            {
                MessageBox.Show(
                    "Please build the search index first (click 'Rebuild Index').",
                    "No Index", MessageBoxButtons.OK, MessageBoxIcon.Warning,
                    MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign, false);
                return;
            }

            btn_search.Enabled = false;
            btn_search.Text    = "Searching...";
            UpdateStatus("Querying Ollama LLM...");

            BackgroundWorker worker = new BackgroundWorker();
            worker.DoWork += (s, args) =>
            {
                SearchCriteria criteria = AISearchEngine.ParseQuery(query);
                args.Result = RecordIndex.Search(criteria);
            };
            worker.RunWorkerCompleted += (s, args) =>
            {
                btn_search.Enabled = true;
                btn_search.Text    = "Search";

                if (args.Error != null)
                {
                    string msg = (args.Error.Message.Contains("Unable to connect") ||
                                  args.Error.Message.Contains("actively refused") ||
                                  args.Error.Message.Contains("Connection refused"))
                        ? "Ollama is not running.\n\nPlease start Ollama and try again."
                        : "Search error: " + args.Error.Message;
                    MessageBox.Show(msg, "Search Error", MessageBoxButtons.OK,
                        MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1,
                        MessageBoxOptions.RightAlign, false);
                    UpdateStatus("Search failed.");
                    return;
                }

                List<IndexEntry> results = (List<IndexEntry>)args.Result;
                UpdateStatus(results.Count + " result(s) found.");
                BindResults(results);
            };
            worker.RunWorkerAsync();
        }

        // ------------------------------------------------------------------ //
        //  Rebuild index                                                       //
        // ------------------------------------------------------------------ //

        private void btn_rebuild_Click(object sender, EventArgs e)
        {
            StartRebuild();
        }

        private void StartRebuild()
        {
            btn_rebuild.Enabled  = false;
            btn_rebuild.Text     = "Building...";
            progressBar.Visible  = true;
            progressBar.Value    = 0;
            UpdateStatus("Building index...");

            BackgroundWorker worker = new BackgroundWorker();
            worker.DoWork += (s, args) =>
            {
                RecordIndex.Build(_flightsRoot, (done, total) =>
                {
                    if (total > 0)
                    {
                        int pct = (int)(done * 100.0 / total);
                        progressBar.Invoke(new Action(() =>
                        {
                            if (progressBar.Value != pct)
                                progressBar.Value = pct;
                        }));
                    }
                });
            };
            worker.RunWorkerCompleted += (s, args) =>
            {
                btn_rebuild.Enabled = true;
                btn_rebuild.Text    = "Rebuild Index";
                progressBar.Visible = false;

                if (args.Error != null)
                {
                    UpdateStatus("Build failed: " + args.Error.Message);
                    return;
                }

                UpdateStatus(null);
            };
            worker.RunWorkerAsync();
        }

        // ------------------------------------------------------------------ //
        //  Sync                                                                //
        // ------------------------------------------------------------------ //

        private void btn_sync_Click(object sender, EventArgs e)
        {
            string syncUrl = RecordIndex.GetSyncUrl(_flightsRoot);
            if (string.IsNullOrEmpty(syncUrl))
            {
                string cfgPath = System.IO.Path.Combine(_flightsRoot, "search_sync_url.txt");
                MessageBox.Show(
                    "No sync URL is configured.\n\n" +
                    "To enable sync, create the file:\n" + cfgPath + "\n\n" +
                    "and paste the URL of your shared index server into it.\n\n" +
                    "The server should serve the search_index.json file at that URL.",
                    "Sync Not Configured",
                    MessageBoxButtons.OK, MessageBoxIcon.Information,
                    MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign, false);
                return;
            }

            btn_sync.Enabled = false;
            btn_sync.Text    = "Syncing...";
            UpdateStatus("Downloading index from server...");

            BackgroundWorker worker = new BackgroundWorker();
            worker.DoWork += (s, args) =>
            {
                System.Net.WebClient wc = new System.Net.WebClient();
                wc.Encoding = System.Text.Encoding.UTF8;
                string json = wc.DownloadString(syncUrl);
                System.IO.File.WriteAllText(
                    RecordIndex.GetIndexPath(_flightsRoot), json,
                    System.Text.Encoding.UTF8);
            };
            worker.RunWorkerCompleted += (s, args) =>
            {
                btn_sync.Enabled = true;
                btn_sync.Text    = "Sync";

                if (args.Error != null)
                {
                    UpdateStatus("Sync failed: " + args.Error.Message);
                    MessageBox.Show("Sync failed:\n" + args.Error.Message,
                        "Sync Error", MessageBoxButtons.OK, MessageBoxIcon.Warning,
                        MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign, false);
                    return;
                }

                RecordIndex.Load(_flightsRoot);
                UpdateStatus(null);
            };
            worker.RunWorkerAsync();
        }

        // ------------------------------------------------------------------ //
        //  Results binding                                                     //
        // ------------------------------------------------------------------ //

        private void BindResults(List<IndexEntry> entries)
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("Passport Name",   typeof(string));
            dt.Columns.Add("Passport Number", typeof(string));
            dt.Columns.Add("Nationality",     typeof(string));
            dt.Columns.Add("Doc Type",        typeof(string));
            dt.Columns.Add("Flight From",     typeof(string));
            dt.Columns.Add("Flight To",       typeof(string));
            dt.Columns.Add("Date Recorded",   typeof(string));
            dt.Columns.Add("Validation",      typeof(string));
            dt.Columns.Add("RFID",            typeof(string));
            dt.Columns.Add("Post Dated",      typeof(string));
            dt.Columns.Add("Flagged",         typeof(string));
            dt.Columns.Add("Record Path",     typeof(string));

            foreach (IndexEntry e in entries)
            {
                dt.Rows.Add(
                    e.PassportName     ?? "",
                    e.PassportNumber   ?? "",
                    e.Nationality      ?? "",
                    e.DocumentType     ?? "",
                    e.FlightFrom       ?? "",
                    e.FlightTo         ?? "",
                    e.DateTimeRecorded ?? "",
                    e.ValidationPassed ?? "",
                    e.RFIDStatus       ?? "",
                    e.IsPostDated      ?? "",
                    e.IsFlagged        ?? "",
                    e.RecordFolderPath ?? ""
                );
            }

            resultsGrid.DataSource = dt;
            resultsGrid.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);
        }

        // ------------------------------------------------------------------ //
        //  Helpers                                                             //
        // ------------------------------------------------------------------ //

        private void UpdateStatus(string overrideText)
        {
            if (overrideText != null)
            {
                lbl_status.Text = overrideText;
                return;
            }

            if (RecordIndex.GetEntries() == null)
            {
                lbl_status.Text = "No index loaded. Click 'Rebuild Index' to build.";
            }
            else
            {
                lbl_status.Text = string.Format("Index: {0} records  |  Built {1}",
                    RecordIndex.RecordCount, FormatAge(RecordIndex.LastBuilt));
            }
        }

        private static string FormatAge(DateTime built)
        {
            if (built == DateTime.MinValue) return "unknown";
            TimeSpan age = DateTime.Now - built;
            if (age.TotalMinutes < 2)  return "just now";
            if (age.TotalHours   < 1)  return ((int)age.TotalMinutes) + " min ago";
            if (age.TotalDays    < 1)  return ((int)age.TotalHours)   + " hr ago";
            return ((int)age.TotalDays) + " day(s) ago";
        }

        private void txt_search_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                btn_search.PerformClick();
        }

        private void SmartSearchForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
                Close();
        }
    }
}
