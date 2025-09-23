using System;
using System.Drawing;
using System.Windows.Forms;
namespace ImageProcessing
{
    public partial class Form1 : Form
    {
        Bitmap imageA, imageB, colorGreen;
        public Form1()
        {
   
            InitializeComponent();
        }

        private void button7_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                imageA = new Bitmap(ofd.FileName);
                pictureBox2.Image = imageA;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                imageB = new Bitmap(ofd.FileName);
                pictureBox1.Image = imageB;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (imageA == null) return;

            colorGreen = new Bitmap(imageA);
            pictureBox3.Image = colorGreen;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (imageA == null) return;

            colorGreen = new Bitmap(imageA.Width, imageA.Height);
            for (int y = 0; y < imageA.Height; y++)
            {
                for (int x = 0; x < imageA.Width; x++)
                {
                    Color original = imageA.GetPixel(x, y);
                    int gray = (int)(0.3 * original.R + 0.59 * original.G + 0.11 * original.B);
                    Color grayColor = Color.FromArgb(gray, gray, gray);
                    colorGreen.SetPixel(x, y, grayColor);
                }
            }

            pictureBox3.Image = colorGreen;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (imageA == null) return;

            colorGreen = new Bitmap(imageA.Width, imageA.Height);
            for (int y = 0; y < imageA.Height; y++)
            {
                for (int x = 0; x < imageA.Width; x++)
                {
                    Color c = imageA.GetPixel(x, y);
                    Color inverted = Color.FromArgb(255 - c.R, 255 - c.G, 255 - c.B);
                    colorGreen.SetPixel(x, y, inverted);
                }
            }

            pictureBox3.Image = colorGreen;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (imageA == null) return;

            colorGreen = new Bitmap(imageA.Width, imageA.Height);
            for (int y = 0; y < imageA.Height; y++)
            {
                for (int x = 0; x < imageA.Width; x++)
                {
                    Color c = imageA.GetPixel(x, y);

                    int tr = (int)(0.393 * c.R + 0.769 * c.G + 0.189 * c.B);
                    int tg = (int)(0.349 * c.R + 0.686 * c.G + 0.168 * c.B);
                    int tb = (int)(0.272 * c.R + 0.534 * c.G + 0.131 * c.B);

                    tr = Math.Min(255, tr);
                    tg = Math.Min(255, tg);
                    tb = Math.Min(255, tb);

                    colorGreen.SetPixel(x, y, Color.FromArgb(tr, tg, tb));
                }
            }

            pictureBox3.Image = colorGreen;
        }

        private void button8_Click(object sender, EventArgs e)
        {
            if (imageA == null || imageB == null)
            {
                MessageBox.Show("Please load both Image A and Image B.");
                return;
            }

            if (imageA.Width != imageB.Width || imageA.Height != imageB.Height)
            {
                MessageBox.Show("Images must be the same size.");
                return;
            }

            colorGreen = new Bitmap(imageA.Width, imageA.Height);
            Color green = Color.FromArgb(0, 255, 0);
            int threshold = 30;

            for (int y = 0; y < imageA.Height; y++)
            {
                for (int x = 0; x < imageA.Width; x++)
                {
                    Color pixelA = imageA.GetPixel(x, y);
                    Color pixelB = imageB.GetPixel(x, y);

                    int grayA = (int)(0.3 * pixelA.R + 0.59 * pixelA.G + 0.11 * pixelA.B);
                    int grayB = (int)(0.3 * pixelB.R + 0.59 * pixelB.G + 0.11 * pixelB.B);

                    int diff = Math.Abs(grayA - grayB);

                    if (diff > threshold)
                    {
                        colorGreen.SetPixel(x, y, pixelA);
                    }
                    else
                    {
                        colorGreen.SetPixel(x, y, green);
                    }
                }
            }

            pictureBox3.Image = colorGreen;
        }

        private void button9_Click(object sender, EventArgs e)
        {
            if (colorGreen == null)
            {
                MessageBox.Show("No processed image to save.");
                return;
            }

            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "PNG Image|*.png|JPEG Image|*.jpg";

            if (sfd.ShowDialog() == DialogResult.OK)
            {
                colorGreen.Save(sfd.FileName);
                MessageBox.Show("Image saved!");
            }
        }
    }
}
