using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace TravelPass
{
    public partial class ViewZoomedImage : Form
    {
        public ViewZoomedImage()
        {
            InitializeComponent();
            
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
        private Bitmap bitmap;
        public Bitmap SetImage {
            get { return bitmap; }
            set { this.bitmap = value; }
        }

        private void ViewZoomedImage_Load(object sender, EventArgs e)
        {
            pictureBox1.Image = bitmap;
        }
    }
}
