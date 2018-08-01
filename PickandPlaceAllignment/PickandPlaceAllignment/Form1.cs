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
using Microsoft.VisualBasic;

namespace PickandPlaceAllignment
{
    public partial class Form1 : Form
    {
        //Public Variables
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
            //Allowing scaleFactorNUD to display 3 decimal places
            scaleFactorNUD.DecimalPlaces = 3;
            
            deviceList = new FilterInfoCollection(FilterCategory.VideoInputDevice);
            //If no devices are present exception will be thrown
            if (deviceList.Count == 0)
            {
                throw new Exception();
            }
            //Removes revious data in videoSourceList 
            videoSourceList.Items.Clear();
            //Populates the videoSoureList combo box with all avalible video devices
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
            //Selecting the video device to play video from 
            captureDevice = new VideoCaptureDevice(deviceList[videoSourceList.SelectedIndex].MonikerString);
            videoSourcePlayer1.VideoSource = captureDevice;
            videoSourcePlayer1.Start();
        }

        private void captureImageBtn_Click(object sender, EventArgs e)
        {
            //Adjusts gama and contrast 
            processImage();
            //Displays adjusted image in capturedImagePanel scrollable image panel
            capturedImagePanel.Image = workingImage;
        }

        public void processImage()
        {
            //Snaps an image from videoSourcePlayer1 and adjusts gama and contrast based on slider bars(gamaSlider and contrastSlider)
            Bitmap capturedImage = videoSourcePlayer1.GetCurrentVideoFrame();
            workingImage = capturedImage;
            GammaCorrection gamaFilter = new GammaCorrection((gamaSlider.Value)/100.0);
            ContrastCorrection contrastFilter = new ContrastCorrection((contrastSlider.Value));
            workingImage = gamaFilter.Apply(workingImage);
            workingImage = contrastFilter.Apply(workingImage);
            
        }

        private void gamaSlider_Scroll(object sender, ScrollEventArgs e)
        {
            //Update workingImage when gamaSlider is adjusted
            Bitmap capturedImage = videoSourcePlayer1.GetCurrentVideoFrame();
            workingImage = capturedImage;
            processImage();
            capturedImagePanel.Image = workingImage;
        }

        private void contrastSlider_Scroll(object sender, ScrollEventArgs e)
        {
            //Update workingImage when constrastSlider is adjusted
            Bitmap capturedImage = videoSourcePlayer1.GetCurrentVideoFrame();
            workingImage = capturedImage;
            processImage();
            capturedImagePanel.Image = workingImage;
        }

        public void cannyImageConvert()
        {
            //Apply canny edge detection on workingImage
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
        //Finds the degree tilt of the part using Hough Line Detection
        //Reference Documentation for Method:http://www.aforgenet.com/framework/docs/html/6141703e-d685-efb5-2f7f-b430aa42210f.htm
        public double findDegreeTilt(Bitmap inImage)
        {
            //Creating HoughLineTranformation object
            AForge.Imaging.HoughLineTransformation lineTransform = new AForge.Imaging.HoughLineTransformation();
            //Adjusts the number of decimal places of the returned angle (Reference Documentation:http://www.aforgenet.com/framework/docs/html/24be38e1-20d8-214e-7adb-31a61854e839.htm)
            lineTransform.StepsPerDegree = 10;
            //Applys filter on image
            lineTransform.ProcessImage(inImage);
            //Creating a temporary bitmap to apply graphics to(Grpahics doesn't accept canny images)
            Bitmap tempBitmap = new Bitmap(inImage.Width, inImage.Height);
            Graphics g = Graphics.FromImage(tempBitmap);
            //Redrawing original image on temporary image
            g.DrawImage(inImage, 0, 0);
            Pen bluePen = new Pen(Color.Blue, 2.0f);

            //Stores all Hough lines found with the filter 
            //.8 repersents the intensity constant(higher the constant the less lines the filter picks up)
            AForge.Imaging.HoughLine[] lines = lineTransform.GetLinesByRelativeIntensity(.8);
            double averageAngle = 0;
            //Converts each Hough line found to cartesian coordinates and draw each one
            foreach (AForge.Imaging.HoughLine line in lines)
            {
                //Stores the radius and theta and polar line
                int lineRadius = line.Radius;
                double lineTheta = line.Theta;
                //Negative radii are made positive
                if (lineRadius < 0)
                {
                    lineTheta += 180;
                    lineRadius = -lineRadius;
                }
                //Converting line theta from degrees to radians
                lineTheta = (lineTheta / 180) * Math.PI;
                
                //Image center coordinates
                double centerX = inImage.Width / 2.0;
                double centerY = inImage.Height / 2.0;

                //Initialization of hough line coordinates
                double firstX = 0, lastX = 0, firstY = 0, lastY = 0;

                //Creating line coordinates
                if (line.Theta != 0)
                {
                    firstX = -centerX;
                    lastX = centerX;

                    firstY = (-Math.Cos(lineTheta) * firstX + lineRadius) / Math.Sin(lineTheta);
                    lastY = (-Math.Cos(lineTheta) * lastX + lineRadius) / Math.Sin(lineTheta);
                }
                else
                {
                    firstX = line.Radius;
                    lastX = line.Radius;

                    firstY = centerY;
                    lastY = -centerY;
                }

                //Adjusting lineTheta angle to be in a range from 0 to 90 degrees
                double partRotationAngle = 90.0 - (double)(lines[0].Theta);
                if (partRotationAngle < 0)
                    partRotationAngle += 90;
                //Treat the angle of 90 the same as 0
                if (partRotationAngle == 90)
                    partRotationAngle = 0;
                //Adding the returned angles to average result later on
                averageAngle += partRotationAngle;
                //Draws cartesian line repersenting polar hough line 
                g.DrawLine(bluePen, new System.Drawing.Point((int)(firstX + centerX), (int)(centerY - firstY)), new System.Drawing.Point((int)(lastX + centerX), (int)(centerY - lastY)));
                
            }
            //Calculate the average degree of tilt to improve consistancy
            averageAngle /= (double)lines.Length;
            //Set the label to display rotation angle
            offsetAngle.Text = averageAngle.ToString();
            //If wanted by the user, the hough lines will be displayed in they canny image panel
            if (houghLineCheckBox.Checked)
            cannyImagePanel.Image = tempBitmap;
            //Returns the avearge offset angle
            return averageAngle;
        }

        //Finds the center coordinate of the part
        //Utilizes Harris Corner Detection from the Accord.Net Library
        //Reference Material:http://accord-framework.net/docs/html/T_Accord_Imaging_HarrisCornersDetector.htm
        public Bitmap findCenter(Bitmap inImage)
        {
            //Creating Harris Corener Dection method
            HarrisCornersDetector cornerDetector = new HarrisCornersDetector(.04f, 100);
            //List of IntPoints containing the found corners
            List<Accord.IntPoint> cornerArray = cornerDetector.ProcessImage(inImage);
            //Creating a temporary bitmap to apply graphics to(Grpahics doesn't accept canny images)
            Bitmap tempBitmap = new Bitmap(inImage.Width, inImage.Height);
            Graphics g = Graphics.FromImage(tempBitmap);
            //Redrawing original image on temporary bitmap
            g.DrawImage(inImage, 0, 0);
            Pen aquaPen = new Pen(Color.Aqua, 2.0f);
            //Draws a circle at each found corner
            foreach (Accord.IntPoint p in cornerArray)
                g.DrawEllipse(aquaPen, p.X - 1, p.Y + 1, 2, 2);
            //Finds edges of the part by looking for the minimum and maximum x and y values from found corners
            //IMPORTANT: This does not exculde outlier corners sometimes found in images. These are ussaly eliminated by increasing gama or the light in the overall picture. An outlier remover may be necessary based on conditions
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
                //Storing the X and Y dimensions of the part 
                xDimensionPixels = Math.Abs(rightEdge - leftEdge);
                yDimensionPixels = Math.Abs(topEdge - bottomEdge);
                //Finding center of the part based on the avearge of the previously found edges
                centerPoint.X = ((int)((leftEdge + rightEdge) / 2.0));
                centerPoint.Y = (int)((topEdge + bottomEdge) / 2.0);
                //Draws a circle at the center point of the image
                g.DrawEllipse(aquaPen, centerPoint.X - 10f, centerPoint.Y - 10f, 20f, 20f);

            }
            //Draws the center and corners if desired by the users
            if(centerCheckbox.Checked)
            cannyImagePanel.Image = tempBitmap;
            
            return tempBitmap;

        }
        //Finds the offset of the center of the part and the center of the image
        public Bitmap centerPart(Bitmap inImage)
        {
            //Updates the center of the part
            findCenter(inImage);
            //Center of the frame
            int imageCenterX = inImage.Width / 2;
            int imageCenterY = inImage.Height / 2;
            //initialization of the X offset and Y offset for the center of the image and the part
            int xOffset = 0;
            int yOffset = 0;

            //Creating a temporary bitmap to apply graphics to(Grpahics doesn't accept canny images)
            Bitmap modifiedBitmap = new Bitmap(inImage.Width, inImage.Height);
            Graphics g = Graphics.FromImage(modifiedBitmap);
            
            //Finds the distance from part's center and the center of the frame
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
            //Redraws the orignal image
            g.DrawImage(inImage, 0, 0);
            //Shifts the image according to the X and Y offsets
            CanvasMove shiftImage = new CanvasMove(new AForge.IntPoint(xOffset, yOffset), Color.White);
            modifiedBitmap = shiftImage.Apply(modifiedBitmap);

            return modifiedBitmap;
        }

        private void rotateBtn_Click(object sender, EventArgs e)
        {
            //Rotates Image based on the findDegreeTilt method(the method returns the degree of tilt)
            //IMPORTANT: Always rotate and then center
            RotateNearestNeighbor rotateFilter = new RotateNearestNeighbor(findDegreeTilt(workingImage), false);
            rotateFilter.FillColor = (Color.Black);
            workingImage = rotateFilter.Apply(workingImage);
            correctedImagePanel.Image = workingImage;
        }

        private void centerBtn_Click(object sender, EventArgs e)
        {
            //Centers Image bbasedon center part method
            //IMPORTANT: Always rotate and then center
            workingImage = centerPart(workingImage);
            correctedImagePanel.Image = workingImage;
            //Updates values determining the size of the part
            scaleFactorUpdate();
        }
        
        private void timer1_Tick(object sender, EventArgs e)
        {
            //If autoProcessCheckBox is not checked the rest of the method will not run
            if (!autoProcessCheckBox.Checked) return;

            //Grabs new frame from videosource and modifies the gama and contrast based on sliders
            processImage();
            //Sets capturedImagePanel to the modified snapshot
            capturedImagePanel.Image = workingImage;
            //Apply canny edge detector
            cannyImageConvert();
            //Rotate the image based on the degree offset returned by findDegreeTilt
            RotateNearestNeighbor rotateFilter = new RotateNearestNeighbor(findDegreeTilt(workingImage), false);
            rotateFilter.FillColor = (Color.Black);
            workingImage = rotateFilter.Apply(workingImage);
            //Centers the part with the centerPart method
            workingImage = centerPart(workingImage);
            //Updates correctedImagePanel with rotated and centered image
            correctedImagePanel.Image = workingImage;
            //Updates the size of the part and the proper orientation
            scaleFactorUpdate();
        }

        private void scaleFactorNUD_ValueChanged(object sender, EventArgs e)
        {
            //Updates the size of the part and the proper orientation
            scaleFactorUpdate();
        }
        public void scaleFactorUpdate()
        {
            //If scaleFactorNUD is equal to its default value(1) then calibration is required
            if (scaleFactorNUD.Value == 1)
            {
                xDimensionLabel.Text = "Calibrate";
                yDimensionLabel.Text = "Calibrate";
                return;
            }
            //Updates scale factor with value in the scaleFactorNUD
            scaleFactor = (double)scaleFactorNUD.Value;
            //Updates xDimensionLabel and yDimensionLabel with scaled pixel values
            xDimensionLabel.Text = (xDimensionPixels * (float)scaleFactorNUD.Value).ToString() + " mm";
            yDimensionLabel.Text = (yDimensionPixels * (float)scaleFactorNUD.Value).ToString() + " mm";
          
            //If radio boxes are checked by the user, they can set a proper orientation for the part(x dimension has to be longer than the y dimension or vice versa)
            if (yDominantRadioBtn.Checked && yDimensionPixels < xDimensionPixels)
            {
                //Rotates image based on desired orientation
                workingImage.RotateFlip(RotateFlipType.Rotate270FlipNone);
                correctedImagePanel.Image = workingImage;
                //Flips x and y values based on rotate
                xDimensionLabel.Text = (yDimensionPixels * (float)scaleFactorNUD.Value).ToString() + " mm";
                yDimensionLabel.Text = (xDimensionPixels * (float)scaleFactorNUD.Value).ToString() + " mm";
            }
            else if (xDominantRadioBtn.Checked && xDimensionPixels < yDimensionPixels)
            {
                //Rotates image based on desired orientation
                workingImage.RotateFlip(RotateFlipType.Rotate90FlipNone);
                //Flips x and y values based on rotate
                correctedImagePanel.Image = workingImage;
                xDimensionLabel.Text = (yDimensionPixels * (float)scaleFactorNUD.Value).ToString() + " mm";
                yDimensionLabel.Text = (xDimensionPixels * (float)scaleFactorNUD.Value).ToString() + " mm";
            }


        }

        private void calibrateScaleFactorBtn_Click(object sender, EventArgs e)
        {
            //User enters in the y dimension of the part in mm and a scale factor is generated
            double partYDimension = Convert.ToDouble(Microsoft.VisualBasic.Interaction.InputBox("Enter Y dimension of the part in mm: ", "Scale Factor Calibration", " ", 0, 0));
            scaleFactorNUD.Value = (decimal)(partYDimension / yDimensionPixels);
            scaleFactorUpdate();
        }
    }
}
