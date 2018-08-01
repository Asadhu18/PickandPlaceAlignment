using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AForge;
using AForge.Video.DirectShow;
using AForge.Video.FFMPEG;
using Accord.Imaging;
using AForge.Math.Geometry;
using AForge.Imaging;
using AForge.Imaging.Filters;

namespace PickandPlaceAllignment
{
    public partial class Form1 : Form
    {
        public VideoCaptureDevice captureDevice;
        public FilterInfoCollection deviceList;
        public Bitmap workingImage;
        public AForge.Point centerPoint;
        public float xDimensionPixels;
        public float yDimensionPixels;
        public double scaleFactor= .026;

        public Form1()
        {
            InitializeComponent();
        }

        public void Form1_Load(object sender, EventArgs e)
        {
            scaleFactorNUD.DecimalPlaces = 3;
            deviceList = new FilterInfoCollection(FilterCategory.VideoInputDevice);
            if (deviceList.Count == 0)
            {
                throw new Exception();
            }
            videoSourceList.Items.Clear();

            foreach (FilterInfo device in deviceList)
            {
                videoSourceList.Items.Add(device.Name);
            }
            videoSourceList.SelectedIndex = 0;
            captureDevice = new VideoCaptureDevice();
            timer1.Start();
        }

        private void recordBtn_Click(object sender, EventArgs e)
        {
            captureDevice = new VideoCaptureDevice(deviceList[videoSourceList.SelectedIndex].MonikerString);
            videoSourcePlayer1.VideoSource = captureDevice;
            videoSourcePlayer1.Start();
        }

        private void captureImageBtn_Click(object sender, EventArgs e)
        {
            processImage();
            capturedImagePanel.Image = workingImage;
        }

        public void processImage()
        {
            Bitmap capturedImage = videoSourcePlayer1.GetCurrentVideoFrame();
            workingImage = capturedImage;
            GammaCorrection gamaFilter = new GammaCorrection((gamaSlider.Value)/100.0);
            ContrastCorrection contrastFilter = new ContrastCorrection((contrastSlider.Value));
            workingImage = gamaFilter.Apply(workingImage);
            workingImage = contrastFilter.Apply(workingImage);
            
        }

        private void gamaSlider_Scroll(object sender, ScrollEventArgs e)
        {
            Bitmap capturedImage = videoSourcePlayer1.GetCurrentVideoFrame();
            workingImage = capturedImage;
            processImage();
            capturedImagePanel.Image = workingImage;
        }

        private void contrastSlider_Scroll(object sender, ScrollEventArgs e)
        {
            Bitmap capturedImage = videoSourcePlayer1.GetCurrentVideoFrame();
            workingImage = capturedImage;
            processImage();
            capturedImagePanel.Image = workingImage;
        }

        public void cannyImageConvert()
        {
            Grayscale grayscaleFilter = new Grayscale(.21, .07, .72);
            CannyEdgeDetector cannyFilter = new CannyEdgeDetector();
            workingImage = grayscaleFilter.Apply(workingImage);
            workingImage = cannyFilter.Apply(workingImage);
            cannyImagePanel.Image = workingImage;
        }

        private void cannyBtn_Click(object sender, EventArgs e)
        {
            cannyImageConvert();
        }
        
        public double findDegreeTilt(Bitmap inImage)
        {
            AForge.Imaging.HoughLineTransformation lineTransform = new AForge.Imaging.HoughLineTransformation();
            lineTransform.StepsPerDegree = 10;
            lineTransform.ProcessImage(inImage);

            Bitmap tempBitmap = new Bitmap(inImage.Width, inImage.Height);
            Graphics g = Graphics.FromImage(tempBitmap);
            g.DrawImage(inImage, 0, 0);
            Pen bluePen = new Pen(Color.Blue, 2.0f);
            Bitmap completedImage = lineTransform.ToBitmap();
            AForge.Imaging.HoughLine[] lines = lineTransform.GetLinesByRelativeIntensity(.8);
            AForge.Math.Geometry.Line[] cartesianLines = new AForge.Math.Geometry.Line[lines.Length];
            int counter = 0;
            double averageAngle = 0;

            foreach (AForge.Imaging.HoughLine line in lines)
            {
                int lineRadius = line.Radius;
                double lineTheta = line.Theta;

                if (lineRadius < 0)
                {
                    lineTheta += 180;
                    lineRadius = -lineRadius;
                }

                lineTheta = (lineTheta / 180) * Math.PI;
                double halfWidth = inImage.Width / 2.0;
                double halfHeight = inImage.Height / 2.0;

                double firstX = 0, lastX = 0, firstY = 0, lastY = 0;

                if (line.Theta != 0)
                {
                    firstX = -halfWidth;
                    lastX = halfWidth;

                    firstY = (-Math.Cos(lineTheta) * firstX + lineRadius) / Math.Sin(lineTheta);
                    lastY = (-Math.Cos(lineTheta) * lastX + lineRadius) / Math.Sin(lineTheta);
                }
                else
                {
                    firstX = line.Radius;
                    lastX = line.Radius;

                    firstY = halfHeight;
                    lastY = -halfHeight;
                }

                cartesianLines[counter] = Line.FromPoints(new AForge.Point((int)(firstX + halfWidth), (int)(halfHeight - firstY)), new AForge.Point((int)(lastX + halfWidth), (int)(halfHeight - lastY)));
                
                double partRotationAngle = 90.0 - (double)(lines[0].Theta);
                if (partRotationAngle < 0)
                    partRotationAngle += 90;

                if (partRotationAngle == 90)
                    partRotationAngle = 0;

                offsetAngle.Text = partRotationAngle.ToString();

                averageAngle += partRotationAngle;

                g.DrawLine(bluePen, new System.Drawing.Point((int)(firstX + halfWidth), (int)(halfHeight - firstY)), new System.Drawing.Point((int)(lastX + halfWidth), (int)(halfHeight - lastY)));
                counter++;
            }
            averageAngle /= (double)lines.Length;
            if(houghLineCheckBox.Checked)
            cannyImagePanel.Image = tempBitmap;
            return averageAngle;
        }

        public Bitmap findCenter(Bitmap inImage)
        {

            HarrisCornersDetector cornerDetector = new HarrisCornersDetector(.04f, 100);
            List<Accord.IntPoint> cornerArray = cornerDetector.ProcessImage(inImage);
            Bitmap tempBitmap = new Bitmap(inImage.Width, inImage.Height);
            Graphics g = Graphics.FromImage(tempBitmap);
            g.DrawImage(inImage, 0, 0);
            Pen aquaPen = new Pen(Color.Aqua, 2.0f);
            foreach (Accord.IntPoint p in cornerArray)
                g.DrawEllipse(aquaPen, p.X - 1, p.Y + 1, 2, 2);
            if (cornerArray.Count > 1)
            {
                int topEdge = cornerArray[0].Y;
                int bottomEdge = cornerArray[cornerArray.Count - 1].Y;
                int leftEdge = cornerArray[0].X;
                int rightEdge = cornerArray[cornerArray.Count - 1].X;


                for (int i = 0; i < cornerArray.Count - 1; i++)
                {
                    if (topEdge > cornerArray[i].Y)
                        topEdge = cornerArray[i].Y;
                    if (bottomEdge < cornerArray[i].Y)
                        bottomEdge = cornerArray[i].Y;
                    if (leftEdge > cornerArray[i].X)
                        leftEdge = cornerArray[i].X;
                    if (rightEdge < cornerArray[i].X)
                        rightEdge = cornerArray[i].X;

                }
                xDimensionPixels = Math.Abs(rightEdge - leftEdge);
                yDimensionPixels = Math.Abs(topEdge - bottomEdge);
                centerPoint.X = ((int)((leftEdge + rightEdge) / 2.0));
                centerPoint.Y = (int)((topEdge + bottomEdge) / 2.0);
                g.DrawEllipse(aquaPen, centerPoint.X - 10f, centerPoint.Y - 10f, 20f, 20f);

            }
            if(centerCheckbox.Checked)
            cannyImagePanel.Image = tempBitmap;
            return tempBitmap;

        }

        public Bitmap centerPart(Bitmap inImage)
        {
            findCenter(inImage);
            int imageCenterX = inImage.Width / 2;
            int imageCenterY = inImage.Height / 2;
            int xOffset = 0;
            int yOffset = 0;
            Bitmap modifiedBitmap = new Bitmap(inImage.Width, inImage.Height);
            Graphics g = Graphics.FromImage(modifiedBitmap);
            Pen orangePen = new Pen(Color.Orange, 2.0f);

            if (centerPoint.X < imageCenterX)
            {
                xOffset = (imageCenterX - (int)centerPoint.X);

            }
            else if (centerPoint.X > imageCenterX)
            {
                xOffset = -((int)centerPoint.X - imageCenterX);

            }

            if (centerPoint.Y < imageCenterY)
            {
                yOffset = (imageCenterY - (int)centerPoint.Y);

            }
            else if (centerPoint.Y > imageCenterY)
            {
                yOffset = -((int)centerPoint.Y - imageCenterY);

            }
            
            g.DrawImage(inImage, 0, 0);
            CanvasMove shiftImage = new CanvasMove(new AForge.IntPoint(xOffset, yOffset), Color.White);

            modifiedBitmap = shiftImage.Apply(modifiedBitmap);
            g.DrawLine(orangePen, imageCenterX, 0, imageCenterX, inImage.Height);
            g.DrawLine(orangePen, 0, imageCenterY, inImage.Width, imageCenterY);
            
            return modifiedBitmap;
        }

        private void rotateBtn_Click(object sender, EventArgs e)
        {
            RotateNearestNeighbor rotateFilter = new RotateNearestNeighbor(findDegreeTilt(workingImage), false);
            rotateFilter.FillColor = (Color.Black);
            workingImage = rotateFilter.Apply(workingImage);
            //if(yDominantRadioBtn.Checked)

            correctedImagePanel.Image = workingImage;
            
        }

        private void centerBtn_Click(object sender, EventArgs e)
        {
            workingImage = centerPart(workingImage);
            correctedImagePanel.Image = workingImage;
            scaleFactorUpdate();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (!autoProcessCheckBox.Checked) return;

            
            processImage();
            capturedImagePanel.Image = workingImage;
            cannyImageConvert();
            RotateNearestNeighbor rotateFilter = new RotateNearestNeighbor(findDegreeTilt(workingImage), false);
            rotateFilter.FillColor = (Color.Black);
            workingImage = rotateFilter.Apply(workingImage);
            workingImage = centerPart(workingImage);
            correctedImagePanel.Image = workingImage;
            scaleFactorUpdate();
        }

        private void scaleFactorNUD_ValueChanged(object sender, EventArgs e)
        {
            scaleFactorUpdate();
        }
        public void scaleFactorUpdate()
        {
            scaleFactor = (double)scaleFactorNUD.Value;
            xDimensionLabel.Text = (xDimensionPixels * (float)scaleFactorNUD.Value).ToString() + " mm";
            yDimensionLabel.Text = (yDimensionPixels * (float)scaleFactorNUD.Value).ToString() + " mm";
          
            if (yDominantRadioBtn.Checked && yDimensionPixels < xDimensionPixels)
            {
                workingImage.RotateFlip(RotateFlipType.Rotate270FlipNone);
                correctedImagePanel.Image = workingImage;
                xDimensionLabel.Text = (yDimensionPixels * (float)scaleFactorNUD.Value).ToString() + " mm";
                yDimensionLabel.Text = (xDimensionPixels * (float)scaleFactorNUD.Value).ToString() + " mm";
            }
            else if (xDominantRadioBtn.Checked && xDimensionPixels < yDimensionPixels)
            {
                workingImage.RotateFlip(RotateFlipType.Rotate90FlipNone);
                correctedImagePanel.Image = workingImage;
                xDimensionLabel.Text = (yDimensionPixels * (float)scaleFactorNUD.Value).ToString() + " mm";
                yDimensionLabel.Text = (xDimensionPixels * (float)scaleFactorNUD.Value).ToString() + " mm";
            }


        }
    }
}
