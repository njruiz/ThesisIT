using System;
using System.Drawing;
using System.Windows.Forms;
using AForge.Imaging.Filters;
using System.IO;
using edu.stanford.nlp.ie.crf;
using edu.stanford.nlp.util;
using Tesseract;
using System.Text.RegularExpressions;
using System.Collections.Generic;
using System.Linq;

namespace CertificateTextEntityClassificationSystem
{
    public partial class Form1 : Form
    {
        private Bitmap image;
        private double totalConfidence;
        private string output;
        private string date;
        private string certificateType;
        private int count;
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
                /*
               var engine = new TesseractEngine(path, "eng", EngineMode.Default);
               var page = engine.Process(image);
               output = page.GetText();
               rich_status.Text += output;
               rich_status.Text += recognize(output);
               rich_status.Text += "\nagi here" + checkHasDate(output) + getDate(output);
               */

               tessnet2.Tesseract ocr = new tessnet2.Tesseract();
               ocr.SetVariable("tessedit_char_whitelist", "0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz.,$-/#&=()'");
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
               txt_date.Text = getDate(output);
               txt_type.Text = getCertificateType(output);
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
            GaussianSharpen filter = new GaussianSharpen(4, 11);
            filter.ApplyInPlace(image);

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
            txt_award.Text = "";
            txt_confidence.Text = "";
            txt_date.Text = "";
            txt_presenter.Text = "";
            txt_recipient.Text = "";
            txt_type.Text = "";
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
            string temp = "|..|2i|i 2|r y an Cebu Educational Development Foundation for Information Technology atseaietintnrmat1auIerhnotogg|Philippine Information Technology General Certification Examination (Phil-IT GCE) Ruiz Nelson jr. Cebu Institute of Technology - University Examinee Name School This is to certify that you have successfully PASSED the Phil-IT General Certification Examination held on l December 26, 2015 at the Cebu Institute of Technology -- University , N. Buculso Avenue, Cebu City 6000 Philippines. y I e--e | It lvii | y it 'I OI-IN MIC L K. LAR|O WILFREDO T.| QR. | ,.,3 ,1.1 CEDF-IT yl Administrator CEDF-IT Manag g irector |L| gf";
            //DateTime time = DateTime.Parse(temp);
            rich_status.Text = checkHasDate(temp);
            rich_status.Text += "agi here " + getDate(temp); // January 06, 2015
        }

        private String checkHasDate(string data)
        {
            string[] inputText = data.Split(' ');
            bool hasDate = false;
            DateTime dateTime = new DateTime();            
            foreach(string text in inputText)
            {                
                try
                {
                    dateTime = DateTime.Parse(data);
                    dateTime.ToString();
                    hasDate = true;
                    break;
                }
                catch (Exception ex) { }
            }
            return dateTime.ToString("MMMM");
        }

        private string getDate(string data)
        {
            string regex = @"(January|February|March|April|May|June|July|August|September|October|November|December) *(\d|[0-3]\d), *\d{4}";
            string regex2 = @"(January|February|March|April|May|June|July|August|September|October|November|December) *(\d|[0-3]\d) . *\d{4}";
            if(Regex.Match(data, regex) != null)
                date = Regex.Match(data, regex).Value;
            else if(Regex.Match(data, regex2) != null)
                date = Regex.Match(data, regex2).Value;
            return date;
        }

        private string getCertificateType(string data)
        {
            string regex = @"(Certificate of|Certificate Of|CERTIFICATE OF|certificate of|CERTIFICATE of) \w+";
            certificateType = Regex.Match(data, regex).Value;
            return certificateType;
        }
    }
}
