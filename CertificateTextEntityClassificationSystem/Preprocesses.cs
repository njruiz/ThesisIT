using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using Encoder = System.Drawing.Imaging.Encoder;
using System.Threading.Tasks;

namespace CertificateTextEntityClassificationSystem
{
    class Preprocesses
    {
        public static string[] ConvertJpegToTiff(string[] fileNames, bool isMultipage)
        {
            EncoderParameters encoderParams = new EncoderParameters(1);            
            ImageCodecInfo tiffCodecInfo = ImageCodecInfo.GetImageEncoders()
                .First(ie => ie.MimeType == "image/tiff");

            string[] tiffPaths = null;
            if (isMultipage)
            {
                tiffPaths = new string[1];
                Image tiffImg = null;
                try
                {
                    for (int i = 0; i < fileNames.Length; i++)
                    {
                        if (i == 0)
                        {
                            tiffPaths[i] = String.Format("{0}\\{1}.tif",
                                Path.GetDirectoryName(fileNames[i]),
                                Path.GetFileNameWithoutExtension(fileNames[i]));

                            // Initialize the first frame of multipage tiff. 
                            tiffImg = Image.FromFile(fileNames[i]);
                            encoderParams.Param[0] = new EncoderParameter(Encoder.SaveFlag, (long)EncoderValue.MultiFrame);                            
                            tiffImg.Save(tiffPaths[i], tiffCodecInfo, encoderParams);
                        }
                        else
                        {
                            // Add additional frames. 
                            encoderParams.Param[0] = new EncoderParameter(Encoder.SaveFlag, (long)EncoderValue.FrameDimensionPage);
                            using (Image frame = Image.FromFile(fileNames[i]))
                            {
                                tiffImg.SaveAdd(frame, encoderParams);
                            }
                        }

                        if (i == fileNames.Length - 1)
                        {
                            // When it is the last frame, flush the resources and closing. 
                            encoderParams.Param[0] = new EncoderParameter(Encoder.SaveFlag, (long)EncoderValue.Flush);
                            tiffImg.SaveAdd(encoderParams);
                        }
                    }
                }
                finally
                {
                    if (tiffImg != null)
                    {
                        tiffImg.Dispose();
                        tiffImg = null;
                    }
                }
            }
            else
            {
                tiffPaths = new string[fileNames.Length];

                for (int i = 0; i < fileNames.Length; i++)
                {
                    tiffPaths[i] = String.Format("{0}\\{1}.tif",
                        Path.GetDirectoryName(fileNames[i]),
                        Path.GetFileNameWithoutExtension(fileNames[i]));

                    // Save as individual tiff files. 
                    using (Image tiffImg = Image.FromFile(fileNames[i]))
                    {
                        tiffImg.Save(tiffPaths[i], ImageFormat.Tiff);
                    }
                }
            }

            return tiffPaths;
        }

        public static void monochrome(Bitmap image)
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
    }
}
