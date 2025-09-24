using System.Windows.Forms;
using static System.Windows.Forms.DataFormats;

namespace ImageProcessingActivity
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (pbCopy.Image != null)
            {
                SaveFileDialog sfd = new SaveFileDialog();
                sfd.Title = "Save image as";
                sfd.Filter = "JPEG Image|*.jpg|PNG Image|*.png|Bitmap Image|*.bmp";

                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    string extension = Path.GetExtension(sfd.FileName).ToLower();

                    switch (extension)
                    {
                        case ".jpg":
                        case ".jpeg":
                            pbCopy.Image.Save(sfd.FileName, System.Drawing.Imaging.ImageFormat.Jpeg);
                            break;

                        case ".png":
                            pbCopy.Image.Save(sfd.FileName, System.Drawing.Imaging.ImageFormat.Png);
                            break;

                        case ".bmp":
                            pbCopy.Image.Save(sfd.FileName, System.Drawing.Imaging.ImageFormat.Bmp);
                            break;

                        default:
                            MessageBox.Show("Unsupported format selected.");
                            break;
                    }
                }
            }
            else
            {
                MessageBox.Show("No image to save!");
            }
        }


        private void button3_Click(object sender, EventArgs e)
        {
            if (choices.SelectedItem == null) return;
            string selected = choices.SelectedItem.ToString();
            switch (selected)
            {
                case "Basic Copy":
                    basicCopyConversion();
                    break;
                case "Grey Scale":
                    greyScaleConversion();
                    break;
                case "Color Inversion":
                    colorInversion();
                    break;
                case "Histogram":
                    histogramConversion();
                    break;
                case "Sepia":
                    sepiaConversion();
                    break;
            }
        }
        private void basicCopyConversion()
        {
            if (pbOrig.Image != null)
            {
                pbCopy.Image = (Image)pbOrig.Image.Clone();
            }

        }
        private void greyScaleConversion()
        {
            if (pbOrig.Image == null) return;

            Bitmap bmp = new Bitmap(pbOrig.Image);

            for (int y = 0; y < bmp.Height; y++)
            {
                for (int x = 0; x < bmp.Width; x++)
                {
                    Color c = bmp.GetPixel(x, y);
                    int grey = (int)(0.3 * c.R + 0.59 * c.G + 0.11 * c.B);
                    bmp.SetPixel(x, y, Color.FromArgb(grey, grey, grey));
                }
            }

            pbCopy.Image = bmp;
        }

        private void colorInversion()
        {
            if (pbOrig.Image == null) return;

            Bitmap bmp = new Bitmap(pbOrig.Image);

            for (int y = 0; y < bmp.Height; y++)
            {
                for (int x = 0; x < bmp.Width; x++)
                {
                    Color c = bmp.GetPixel(x, y);
                    Color inverted = Color.FromArgb(255 - c.R, 255 - c.G, 255 - c.B);
                    bmp.SetPixel(x, y, inverted);
                }
            }

            pbCopy.Image = bmp;
        }

        private void histogramConversion()
        {
            if (pbOrig.Image == null) return;

            Bitmap bmp = new Bitmap(pbOrig.Image);
            int[] histogram = new int[256];

            for (int y = 0; y < bmp.Height; y++)
            {
                for (int x = 0; x < bmp.Width; x++)
                {
                    Color c = bmp.GetPixel(x, y);
                    int gray = (int)(0.3 * c.R + 0.59 * c.G + 0.11 * c.B);
                    histogram[gray]++;
                }
            }

            int max = 0;
            for (int i = 0; i < 256; i++)
            {
                if (histogram[i] > max)
                    max = histogram[i];
            }

            int width = 512;  
            int height = 400;
            Bitmap histImage = new Bitmap(width, height);

            using (Graphics g = Graphics.FromImage(histImage))
            {
                g.Clear(Color.White);
                Pen pen = new Pen(Color.Black);

                for (int i = 0; i < 256; i++)
                {
                    float normalized = (float)histogram[i] / max;
                    int barHeight = (int)(normalized * height);

                    g.DrawLine(pen,
                        new Point(i * 2, height - 1),
                        new Point(i * 2, height - 1 - barHeight));
                }
            }

            pbCopy.Image = histImage;
        }

        private void sepiaConversion()
        {
            if (pbOrig.Image == null) return;

            Bitmap bmp = new Bitmap(pbOrig.Image);

            for (int y = 0; y < bmp.Height; y++)
            {
                for (int x = 0; x < bmp.Width; x++)
                {
                    Color c = bmp.GetPixel(x, y);
                    int tr = (int)(0.393 * c.R + 0.769 * c.G + 0.189 * c.B);
                    int tg = (int)(0.349 * c.R + 0.686 * c.G + 0.168 * c.B);
                    int tb = (int)(0.272 * c.R + 0.534 * c.G + 0.131 * c.B);

                    tr = Math.Min(255, tr);
                    tg = Math.Min(255, tg);
                    tb = Math.Min(255, tb);

                    bmp.SetPixel(x, y, Color.FromArgb(tr, tg, tb));
                }
            }
            pbCopy.Image = bmp;

        }
        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }


        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Title = "Select an image";
            ofd.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp;*.gif";
            ofd.InitialDirectory = @"D:\School\3rd Yr 1st Sem\C#";

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                pbOrig.Image = new Bitmap(ofd.FileName);
            }
        }

        private void pbCopy_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form2 frm2 = new Form2();
            frm2.Show();
            this.Hide();
        }
    }
}
