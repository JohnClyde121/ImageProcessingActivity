using System;
using System.Drawing;
using System.Windows.Forms;
using Emgu.CV;
using Emgu.CV.CvEnum;
using Emgu.CV.Structure;

namespace ImageProcessingActivity
{
    public partial class Form1 : Form
    {
        private Mat inputImage;

        public Form1()
        {
            InitializeComponent();

           //combo box
            choices.Items.AddRange(new object[]
            {
                "Basic Copy",
                "Grey Scale",
                "Color Inversion",
                "Histogram",
                "Sepia",
                "Smooth",
                "Gaussian Blur",
                "Sharpen",
                "Mean Removal",
                "Emboss"
            });
        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Title = "Select an image";
            ofd.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp";

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                inputImage = CvInvoke.Imread(ofd.FileName, ImreadModes.Color);
                pbOrig.Image = inputImage.ToBitmap();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (choices.SelectedItem == null || inputImage == null) return;
            string selected = choices.SelectedItem.ToString();

            Mat output = new Mat();

            switch (selected)
            {
                case "Basic Copy":
                    output = inputImage.Clone();
                    break;

                case "Grey Scale":
                    CvInvoke.CvtColor(inputImage, output, ColorConversion.Bgr2Gray);
                    CvInvoke.CvtColor(output, output, ColorConversion.Gray2Bgr); // keep 3 channels for display
                    break;

                case "Color Inversion":
                    CvInvoke.BitwiseNot(inputImage, output);
                    break;

                case "Histogram":
                    output = CreateHistogram(inputImage);
                    break;

                case "Sepia":
                    output = ApplySepia(inputImage);
                    break;

                case "Smooth":
                    CvInvoke.Blur(inputImage, output, new System.Drawing.Size(3, 3), new System.Drawing.Point(-1, -1));
                    break;

                case "Gaussian Blur":
                    CvInvoke.GaussianBlur(inputImage, output, new System.Drawing.Size(5, 5), 1.5);
                    break;

                case "Sharpen":
                    float[,] sharpenKernel = {
                        { 0, -1, 0 },
                        { -1, 5, -1 },
                        { 0, -1, 0 }
                    };
                    Convolution(inputImage, output, sharpenKernel);
                    break;

                case "Mean Removal":
                    float[,] meanKernel = {
                        { -1, -1, -1 },
                        { -1, 9, -1 },
                        { -1, -1, -1 }
                    };
                    Convolution(inputImage, output, meanKernel);
                    break;

                case "Emboss":
                    float[,] embossKernel = {
                        { -2, -1, 0 },
                        { -1, 1, 1 },
                        { 0, 1, 2 }
                    };
                    Convolution(inputImage, output, embossKernel, offset: 128);
                    break;

                default:
                    output = inputImage.Clone();
                    break;
            }

            pbCopy.Image = output.ToBitmap();
        }

        private void Convolution(Mat input, Mat output, float[,] kernel, float offset = 0)
        {
            var convKernel = new Emgu.CV.Matrix<float>(kernel);
            CvInvoke.Filter2D(input, output, convKernel, new System.Drawing.Point(-1, -1), offset, BorderType.Default);
        }

        private Mat ApplySepia(Mat input)
        {
            Image<Bgr, byte> img = input.ToImage<Bgr, byte>();

            for (int y = 0; y < img.Rows; y++)
            {
                for (int x = 0; x < img.Cols; x++)
                {
                    Bgr c = img[y, x];
                    double tr = 0.393 * c.Red + 0.769 * c.Green + 0.189 * c.Blue;
                    double tg = 0.349 * c.Red + 0.686 * c.Green + 0.168 * c.Blue;
                    double tb = 0.272 * c.Red + 0.534 * c.Green + 0.131 * c.Blue;

                    img[y, x] = new Bgr(
                        Math.Min(255, tb),
                        Math.Min(255, tg),
                        Math.Min(255, tr)
                    );
                }
            }
            return img.Mat;
        }

        private Mat CreateHistogram(Mat input)
        {
            Mat gray = new Mat();
            CvInvoke.CvtColor(input, gray, ColorConversion.Bgr2Gray);

            
            DenseHistogram hist = new DenseHistogram(256, new RangeF(0, 256));
            hist.Calculate(new Mat[] { gray }, false, null);

            float[] histData = new float[256];
            hist.MatND.ManagedArray.CopyTo(histData, 0);

            int histWidth = 512, histHeight = 400;
            Mat histImage = new Mat(new System.Drawing.Size(histWidth, histHeight), DepthType.Cv8U, 3);
            histImage.SetTo(new MCvScalar(255, 255, 255));

            CvInvoke.Normalize(hist, hist, 0, histImage.Rows, NormType.MinMax);

            for (int i = 1; i < 256; i++)
            {
                CvInvoke.Line(
                    histImage,
                    new System.Drawing.Point((i - 1) * 2, histHeight - (int)Math.Round(histData[i - 1])),
                    new System.Drawing.Point(i * 2, histHeight - (int)Math.Round(histData[i])),
                    new MCvScalar(0, 0, 0),
                    2);
            }

            return histImage;
        }
    }
}
