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
    public partial class MRZScan : UserControl
    {
        public MRZScan()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void doc_no_TextChanged(object sender, EventArgs e)
        {

        }

        private void label18_Click(object sender, EventArgs e)
        {

        }

        private Bitmap bitmap;
        public Bitmap Bitmap_ {
            get { return bitmap; }
            set { this.bitmap = value; }
        }

        private void mrzZoom_Click(object sender, EventArgs e)
        {
            Bitmap bmp = new Bitmap(mrzImage.Image);
            ViewZoomedImage viewZoomedImage = new ViewZoomedImage();
            viewZoomedImage.SetImage = bmp;
            viewZoomedImage.ShowDialog();
        }

        private void mrzImage_Click(object sender, EventArgs e)
        {
            mrzZoom.PerformClick();
        }
        
    }
}
