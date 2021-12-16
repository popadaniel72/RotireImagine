using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RotireImagine
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
        public static Bitmap RotateImage(Image image, int x, int y, float angle)
        {
            if (image == null)
                throw new ArgumentNullException("image");

            //create a new empty bitmap to hold rotated image
            Bitmap rotatedBmp = new Bitmap(image.Width, image.Height);
            rotatedBmp.SetResolution(image.HorizontalResolution, image.VerticalResolution);

            //make a graphics object from the empty bitmap
            Graphics g = Graphics.FromImage(rotatedBmp);

            //Put the rotation point in the center of the image
            g.TranslateTransform(x, y);

            //rotate the image
            g.RotateTransform(angle);

            //move the image back
            g.TranslateTransform(-x, -y);

            //draw passed in image onto graphics object
            g.DrawImage(image, new PointF(0, 0));

            return rotatedBmp;
        }
        private void button1_Click(object sender, EventArgs e)
        {
           timer1.Enabled = ! timer1.Enabled;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            Image img = pictureBox1.Image;

            //Store our old image so we can delete it
            Image oldImage = img;
            //Pass in our original image and return a new image rotated 35 degrees right
            pictureBox1.Image = RotateImage(img, (int)img.Width / 2, (int)img.Height / 2, 6);
            if (oldImage != null)
            {
                oldImage.Dispose();
            }
        }
    }
}
