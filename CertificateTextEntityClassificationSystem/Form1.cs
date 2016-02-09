using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AForge.Imaging.Filters;
using System.IO;
using edu.stanford.nlp.ie.crf;
using edu.stanford.nlp.util;

namespace CertificateTextEntityClassificationSystem
{
    public partial class Form1 : Form
    {
        private Bitmap image;
        private int count;
        private double totalConfidence;
        private string output;
        string wanted_path = Path.GetDirectoryName(Path.GetDirectoryName(System.IO.Directory.GetCurrentDirectory()));
        string path = System.IO.Directory.GetCurrentDirectory();
        public Form1()
        {
            InitializeComponent();
        }

        private void btn_start_Click(object sender, EventArgs e)
        {
            try
            {
                tessnet2.Tesseract ocr = new tessnet2.Tesseract();
                ocr.SetVariable("tessedit_char_whitelist", "0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz.,$-/#&=()\"'");
                ocr.Init(path + @"\tessdata", "eng", false);
                List<tessnet2.Word> result = ocr.DoOCR(image, Rectangle.Empty);
                foreach (tessnet2.Word word in result)
                {
                    count++;
                    totalConfidence += word.Confidence;
                    output = string.Join(" ", result.Select(x => x.Text).ToList());
                    rich_status.Text = output;
                    using (StreamWriter writetext = new StreamWriter(path + @"\Results.txt"))
                    {
                        writetext.WriteLine(output);
                    }
                }
                rich_status.Text += recognize(output);
                totalConfidence = (totalConfidence / count);
                txt_confidence.Text = totalConfidence.ToString();

            }
            catch (Exception ex)
            {

            }
        }

        private void btn_prep_Click(object sender, EventArgs e)
        {           
            rich_status.Text += "Removing Image Noise...\n";
            image = new Bitmap(pictureBox1.Image);
            preprocess(image);
            //ConservativeSmoothing filter = new ConservativeSmoothing();
            //GaussianSharpen filter = new GaussianSharpen(4, 11);
            //filter.ApplyInPlace(image);

            rich_status.Text += "Image Pre-processing Successful.\n";
            pictureBox1.Image = image;
        }

        private void btn_pause_Click(object sender, EventArgs e)
        {
            if (btn_pause.Text == "Pause")
            {
                btn_pause.Text = "Resume";
                rich_status.Text += "Process Paused\n";
            }
            else
            {
                btn_pause.Text = "Pause";
                rich_status.Text += "Process Resumed\n";
            }
        }

        private void btn_terminate_Click(object sender, EventArgs e)
        {
            rich_status.Text += "Application is shutting down...\n";

            DialogResult d = MessageBox.Show("Are you sure you want this?",
                                             "Application is shutting down.",
                                             MessageBoxButtons.YesNo,
                                             MessageBoxIcon.Question);
            if (d != DialogResult.No)
            {
                Close();
            }
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog file = new OpenFileDialog();
            file.ShowDialog();
            pictureBox1.ImageLocation = file.FileName;
            rich_status.Text = "File Opened: " + Convert.ToString(file.FileName) + "\n";
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void preprocess(Bitmap image)
        {
            using (Graphics g = Graphics.FromImage(image))
            {
                var gray_matrix = new float[][]
                {
                    new float[] { 0.299f, 0.299f, 0.299f, 0, 0 },
                    new float[] { 0.587f, 0.587f, 0.587f, 0, 0 },
                    new float[] { 0.114f, 0.114f, 0.114f, 0, 0 },
                    new float[] { 0,      0,      0,      1, 0 },
                    new float[] { 0,      0,      0,      0, 1 }
                };

                var imageAttrib = new System.Drawing.Imaging.ImageAttributes();
                imageAttrib.SetColorMatrix(new System.Drawing.Imaging.ColorMatrix(gray_matrix));
                imageAttrib.SetThreshold((float)0.7);
                var rec = new Rectangle(0, 0, image.Width, image.Height);
                g.DrawImage(image, rec, 0, 0, image.Width, image.Height, GraphicsUnit.Pixel, imageAttrib);
            }

        }

        private string recognize(String data)
        {            
            string result = "";
            CRFClassifier classifier = CRFClassifier.getClassifierNoExceptions(path + @"\classifiers\english.all.3class.distsim.crf.ser.gz");
            var classified = classifier.classifyToCharacterOffsets(data).toArray();
            for(int i = 0; i < classified.Length; i++)
            {
                Triple triple = (Triple)classified[i];
                int second = Convert.ToInt32(triple.second().ToString());
                int third = Convert.ToInt32(triple.third().ToString());
                result += '\n' + (triple.first().ToString() + '\t' + data.Substring(second, third - second));
            }
            return result;
        }

        private void btn_ShowDB_Click(object sender, EventArgs e)
        {
            //output = "Nelson F. Ruiz Jr. December 11, 1995";
            rich_status.Text = recognize(output);
        }
    }
}
