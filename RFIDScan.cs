using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace TravelPass
{
    public partial class RFIDScan : UserControl
    {
        public RFIDScan()
        {
            InitializeComponent();
        }

        private void rfZoom_Click(object sender, EventArgs e)
        {
            Bitmap bmp = new Bitmap(rfImage.Image);
            ViewZoomedImage viewZoomedImage = new ViewZoomedImage();
            viewZoomedImage.SetImage = bmp;
            viewZoomedImage.ShowDialog();
        }

        private void rfidREF_Click(object sender, EventArgs e)
        {
            ePassportRFIDScanReference ePassportRFIDScanReference = new ePassportRFIDScanReference();
            ePassportRFIDScanReference.ShowDialog();
        }
    }
}
