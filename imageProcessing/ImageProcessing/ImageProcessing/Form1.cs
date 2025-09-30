using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.Windows.Forms;

namespace ImageProcessing
{
    public partial class Form1 : Form
    {
        private Bitmap originalImage;    // For Part 1 filters
        private Bitmap processedImage;   // For output
        private Bitmap imageA;           // Original image (for subtraction)
        private Bitmap imageB;           // Green background image (for subtraction)

        public Form1()
        {
            InitializeComponent();

            // Fill ComboBox with options
            cmbFilters.Items.AddRange(new string[]
            {
                "Copy",
                "Greyscale",
                "Invert",
                "Histogram",
                "Sepia",
                "Smooth",
                "Gaussian Blur",
                "Sharpen",
                "Mean Removal",
                "Emboss",
                "Image Subtraction (Green Screen)"
            });
            cmbFilters.SelectedIndex = 0;
        }

        // === Load Image (for Part 1 filters) ===
        private void btnLoad_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                ofd.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp";
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    originalImage = new Bitmap(ofd.FileName);
                    pictureBoxOriginal.Image = originalImage;
                }
            }
        }

        // === Apply Selected Filter ===
        private void btnApply_Click(object sender, EventArgs e)
        {
            if (originalImage == null && cmbFilters.SelectedItem.ToString() != "Image Subtraction (Green Screen)")
            {
                MessageBox.Show("Please load an image first.");
                return;
            }

            string choice = cmbFilters.SelectedItem.ToString();
            processedImage = null;

            switch (choice)
            {
                case "Copy":
                    processedImage = (Bitmap)originalImage.Clone();
                    break;

                case "Greyscale":
                    processedImage = Grayscale(originalImage);
                    break;

                case "Invert":
                    processedImage = Invert(originalImage);
                    break;

                case "Sepia":
                    processedImage = Sepia(originalImage);
                    break;

                case "Histogram":
                    processedImage = (Bitmap)originalImage.Clone();
                    ShowHistogram(processedImage);
                    break;

                case "Smooth":
                    processedImage = (Bitmap)originalImage.Clone();
                    BitmapFilter.Smooth(processedImage);
                    break;

                case "Gaussian Blur":
                    processedImage = (Bitmap)originalImage.Clone();
                    BitmapFilter.GaussianBlur(processedImage);
                    break;

                case "Sharpen":
                    processedImage = (Bitmap)originalImage.Clone();
                    BitmapFilter.Sharpen(processedImage);
                    break;

                case "Mean Removal":
                    processedImage = (Bitmap)originalImage.Clone();
                    BitmapFilter.MeanRemoval(processedImage);
                    break;

                case "Emboss":
                    processedImage = (Bitmap)originalImage.Clone();
                    BitmapFilter.Emboss(processedImage);
                    break;

                case "Image Subtraction (Green Screen)":
                    RunImageSubtraction();
                    break;
            }

            pictureBoxProcessed.Image = null;
            pictureBoxProcessed.Image = processedImage;
            pictureBoxProcessed.Refresh();
        }


        // === Save Processed Image ===
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (processedImage == null)
            {
                MessageBox.Show("No processed image to save!");
                return;
            }

            using (SaveFileDialog sfd = new SaveFileDialog())
            {
                sfd.Filter = "PNG Image|*.png|JPEG Image|*.jpg";
                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    processedImage.Save(sfd.FileName);
                    MessageBox.Show("Image saved!");
                }
            }
        }

        // ================= FILTER FUNCTIONS =================

        private Bitmap Grayscale(Bitmap src)
        {
            Bitmap bmp = (Bitmap)src.Clone();
            for (int y = 0; y < bmp.Height; y++)
            {
                for (int x = 0; x < bmp.Width; x++)
                {
                    Color c = bmp.GetPixel(x, y);
                    int gray = (int)((c.R + c.G + c.B) / 3);
                    bmp.SetPixel(x, y, Color.FromArgb(gray, gray, gray));
                }
            }
            return bmp;
        }

        private Bitmap Invert(Bitmap src)
        {
            Bitmap bmp = (Bitmap)src.Clone();
            for (int y = 0; y < bmp.Height; y++)
            {
                for (int x = 0; x < bmp.Width; x++)
                {
                    Color c = bmp.GetPixel(x, y);
                    bmp.SetPixel(x, y, Color.FromArgb(255 - c.R, 255 - c.G, 255 - c.B));
                }
            }
            return bmp;
        }

        private Bitmap Sepia(Bitmap src)
        {
            Bitmap bmp = (Bitmap)src.Clone();
            for (int y = 0; y < bmp.Height; y++)
            {
                for (int x = 0; x < bmp.Width; x++)
                {
                    Color c = bmp.GetPixel(x, y);
                    int tr = (int)(0.393 * c.R + 0.769 * c.G + 0.189 * c.B);
                    int tg = (int)(0.349 * c.R + 0.686 * c.G + 0.168 * c.B);
                    int tb = (int)(0.272 * c.R + 0.534 * c.G + 0.131 * c.B);

                    bmp.SetPixel(x, y, Color.FromArgb(
                        Math.Min(255, tr),
                        Math.Min(255, tg),
                        Math.Min(255, tb)
                    ));
                }
            }
            return bmp;
        }

        // === Show Histogram in popup window ===
        private void ShowHistogram(Bitmap bmp)
        {
            int[] histogram = new int[256];
            for (int y = 0; y < bmp.Height; y++)
            {
                for (int x = 0; x < bmp.Width; x++)
                {
                    Color c = bmp.GetPixel(x, y);
                    int gray = (c.R + c.G + c.B) / 3;
                    histogram[gray]++;
                }
            }

            Form histForm = new Form { Width = 400, Height = 300, Text = "Histogram" };
            histForm.Paint += (s, e) =>
            {
                int max = 0;
                foreach (int h in histogram) if (h > max) max = h;

                for (int i = 0; i < 256; i++)
                {
                    int barHeight = (int)((histForm.ClientSize.Height - 20) * (histogram[i] / (float)max));
                    e.Graphics.DrawLine(Pens.Black, i, histForm.ClientSize.Height - 10, i, histForm.ClientSize.Height - 10 - barHeight);
                }
            };
            histForm.Show();
        }

        // ================= SUBTRACTION (STEP 2) =================
        private void RunImageSubtraction()
        {
            // Load ImageA and ImageB first
            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                ofd.Title = "Select Image A (Original)";
                if (ofd.ShowDialog() == DialogResult.OK)
                    imageA = new Bitmap(ofd.FileName);
            }

            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                ofd.Title = "Select Image B (Green Background)";
                if (ofd.ShowDialog() == DialogResult.OK)
                    imageB = new Bitmap(ofd.FileName);
            }

            if (imageA == null || imageB == null || imageA.Size != imageB.Size)
            {
                MessageBox.Show("Both images must be loaded and have the same size!");
                return;
            }

            Bitmap result = new Bitmap(imageA.Width, imageA.Height);

            for (int y = 0; y < imageA.Height; y++)
            {
                for (int x = 0; x < imageA.Width; x++)
                {
                    Color ca = imageA.GetPixel(x, y);
                    Color cb = imageB.GetPixel(x, y);

                    // Check if green
                    if (cb.G > 150 && cb.R < 100 && cb.B < 100)
                    {
                        result.SetPixel(x, y, ca); // Replace with image A pixel
                    }
                    else
                    {
                        result.SetPixel(x, y, cb); // Keep B pixel
                    }
                }
            }

            processedImage = result;
        }

     
    }
}
