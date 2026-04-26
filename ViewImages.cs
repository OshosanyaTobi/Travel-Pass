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
    public partial class ViewImages : UserControl
    {
        public ViewImages()
        {
            InitializeComponent();
        }

        private void visZoom_Click(object sender, EventArgs e)
        {
            Bitmap bmp = new Bitmap(visImage.Image);
            ViewZoomedImage viewZoomedImage = new ViewZoomedImage();
            viewZoomedImage.SetImage = bmp;
            viewZoomedImage.ShowDialog();
        }

        private void irZoom_Click(object sender, EventArgs e)
        {
            Bitmap bmp = new Bitmap(irImage.Image);
            ViewZoomedImage viewZoomedImage = new ViewZoomedImage();
            viewZoomedImage.SetImage = bmp;
            viewZoomedImage.ShowDialog();
        }

        private void uvImage_Click(object sender, EventArgs e)
        {
            Bitmap bmp = new Bitmap(uvImage.Image);
            ViewZoomedImage viewZoomedImage = new ViewZoomedImage();
            viewZoomedImage.SetImage = bmp;
            viewZoomedImage.ShowDialog();
        }

        private void uvZoom_Click(object sender, EventArgs e)
        {
            Bitmap bmp = new Bitmap(uvImage.Image);
            ViewZoomedImage viewZoomedImage = new ViewZoomedImage();
            viewZoomedImage.SetImage = bmp;
            viewZoomedImage.ShowDialog();
        }

        private void irImage_Click(object sender, EventArgs e)
        {
            Bitmap bmp = new Bitmap(irImage.Image);
            ViewZoomedImage viewZoomedImage = new ViewZoomedImage();
            viewZoomedImage.SetImage = bmp;
            viewZoomedImage.ShowDialog();
        }

        private void visImage_Click(object sender, EventArgs e)
        {
            Bitmap bmp = new Bitmap(visImage.Image);
            ViewZoomedImage viewZoomedImage = new ViewZoomedImage();
            viewZoomedImage.SetImage = bmp;
            viewZoomedImage.ShowDialog();
        }
    }
}
