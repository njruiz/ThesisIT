using System;
using System.Drawing;
using System.Windows.Forms;
using System.Windows.Forms.Integration;
using System.Xml;
using AForge.Imaging.Filters;
using System.IO;
using edu.stanford.nlp.ie.crf;
using edu.stanford.nlp.util;
using Tesseract;
using System.Text.RegularExpressions;
using System.Collections.Generic;
using System.Linq;
using ikvm.runtime;
using System.Diagnostics;

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
        OpenFileDialog file = new OpenFileDialog();
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
            Preprocesses.monochrome(image);
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
            
            file.ShowDialog();
            pictureBox1.ImageLocation = file.FileName;
            initializeSystem();            
            rich_status.Text = "File Opened: " + Convert.ToString(file.FileName) + "\n";
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
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
            Process myproc = new Process() ;
            myproc.StartInfo.UseShellExecute = false;
            myproc.StartInfo.FileName = "java";
            myproc.StartInfo.Arguments = "-jar " + path + @"\jTessBoxEditor\jTessBoxEditor.jar";
            myproc.Start();
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
            string regex2 = @"(January|February|March|April|May|June|July|August|September|October|November|December) *(\d|[0-3]\d) , *\d{4}";
            if (Regex.Match(data, regex).Value != "")
            {
                date = Regex.Match(data, regex).Value;
                MessageBox.Show("agi 1: " + Regex.Match(data, regex).Value);
            }
            else if (Regex.Match(data, regex2).Value != "")
            {
                date = Regex.Match(data, regex2).Value;
                MessageBox.Show("agi 2: " + Regex.Match(data, regex2).Value);
            }
            return date;
        }

        private string getCertificateType(string data)
        {
            string regex = @"(Certificate of|Certificate Of|CERTIFICATE OF|certificate of|CERTIFICATE of) \w+";
            certificateType = Regex.Match(data, regex).Value;
            return certificateType;
        }

        private void initializeSystem()
        {
            txt_award.Text = "";
            txt_confidence.Text = "";
            txt_date.Text = "";
            txt_presenter.Text = "";
            txt_recipient.Text = "";
            txt_type.Text = "";
            output = "";
        }       
    }
}
