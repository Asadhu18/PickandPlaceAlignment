namespace PickandPlaceAllignment
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.videoSourcePlayer1 = new AForge.Controls.VideoSourcePlayer();
            this.cannyImagePanel = new CustomTools.ScrollableImagePanel();
            this.correctedImagePanel = new CustomTools.ScrollableImagePanel();
            this.capturedImagePanel = new CustomTools.ScrollableImagePanel();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.videoSourceList = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.recordBtn = new System.Windows.Forms.Button();
            this.captureImageBtn = new System.Windows.Forms.Button();
            this.cannyBtn = new System.Windows.Forms.Button();
            this.rotateBtn = new System.Windows.Forms.Button();
            this.gamaSlider = new System.Windows.Forms.HScrollBar();
            this.contrastSlider = new System.Windows.Forms.HScrollBar();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.centerBtn = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.offsetAngle = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.autoProcessCheckBox = new System.Windows.Forms.CheckBox();
            this.houghLineCheckBox = new System.Windows.Forms.CheckBox();
            this.centerCheckbox = new System.Windows.Forms.CheckBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.xyEqualRadioBtn = new System.Windows.Forms.RadioButton();
            this.xDominantRadioBtn = new System.Windows.Forms.RadioButton();
            this.yDominantRadioBtn = new System.Windows.Forms.RadioButton();
            this.scaleFactorNUD = new System.Windows.Forms.NumericUpDown();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.xDimensionLabel = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.yDimensionLabel = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.scaleFactorNUD)).BeginInit();
            this.SuspendLayout();
            // 
            // videoSourcePlayer1
            // 
            this.videoSourcePlayer1.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.videoSourcePlayer1.Location = new System.Drawing.Point(5, 54);
            this.videoSourcePlayer1.Name = "videoSourcePlayer1";
            this.videoSourcePlayer1.Size = new System.Drawing.Size(310, 302);
            this.videoSourcePlayer1.TabIndex = 0;
            this.videoSourcePlayer1.Text = "videoSourcePlayer1";
            this.videoSourcePlayer1.VideoSource = null;
            // 
            // cannyImagePanel
            // 
            this.cannyImagePanel.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.cannyImagePanel.CanvasSize = new System.Drawing.Size(60, 40);
            this.cannyImagePanel.Image = null;
            this.cannyImagePanel.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBilinear;
            this.cannyImagePanel.Location = new System.Drawing.Point(758, 51);
            this.cannyImagePanel.Name = "cannyImagePanel";
            this.cannyImagePanel.ROTATION = 0F;
            this.cannyImagePanel.Size = new System.Drawing.Size(417, 383);
            this.cannyImagePanel.TabIndex = 2;
            this.cannyImagePanel.Zoom = 1F;
            // 
            // correctedImagePanel
            // 
            this.correctedImagePanel.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.correctedImagePanel.CanvasSize = new System.Drawing.Size(60, 40);
            this.correctedImagePanel.Image = null;
            this.correctedImagePanel.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBilinear;
            this.correctedImagePanel.Location = new System.Drawing.Point(1192, 51);
            this.correctedImagePanel.Name = "correctedImagePanel";
            this.correctedImagePanel.ROTATION = 0F;
            this.correctedImagePanel.Size = new System.Drawing.Size(417, 383);
            this.correctedImagePanel.TabIndex = 3;
            this.correctedImagePanel.Zoom = 1F;
            // 
            // capturedImagePanel
            // 
            this.capturedImagePanel.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.capturedImagePanel.CanvasSize = new System.Drawing.Size(60, 40);
            this.capturedImagePanel.Image = null;
            this.capturedImagePanel.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBilinear;
            this.capturedImagePanel.Location = new System.Drawing.Point(325, 51);
            this.capturedImagePanel.Name = "capturedImagePanel";
            this.capturedImagePanel.ROTATION = 0F;
            this.capturedImagePanel.Size = new System.Drawing.Size(417, 383);
            this.capturedImagePanel.TabIndex = 4;
            this.capturedImagePanel.Zoom = 1F;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(77, 31);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(158, 20);
            this.label1.TabIndex = 5;
            this.label1.Text = "Live Video Preview";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(465, 28);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(138, 20);
            this.label2.TabIndex = 6;
            this.label2.Text = "Captured Image";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(904, 28);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(114, 20);
            this.label3.TabIndex = 7;
            this.label3.Text = "Canny Image";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(1351, 28);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(143, 20);
            this.label4.TabIndex = 8;
            this.label4.Text = "Corrected Image";
            // 
            // videoSourceList
            // 
            this.videoSourceList.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.videoSourceList.FormattingEnabled = true;
            this.videoSourceList.Location = new System.Drawing.Point(108, 405);
            this.videoSourceList.Name = "videoSourceList";
            this.videoSourceList.Size = new System.Drawing.Size(207, 24);
            this.videoSourceList.TabIndex = 9;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(12, 410);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(90, 16);
            this.label5.TabIndex = 10;
            this.label5.Text = "Video Source";
            // 
            // recordBtn
            // 
            this.recordBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.recordBtn.Location = new System.Drawing.Point(12, 362);
            this.recordBtn.Name = "recordBtn";
            this.recordBtn.Size = new System.Drawing.Size(142, 32);
            this.recordBtn.TabIndex = 11;
            this.recordBtn.Text = "Begin Recording";
            this.recordBtn.UseVisualStyleBackColor = true;
            this.recordBtn.Click += new System.EventHandler(this.recordBtn_Click);
            // 
            // captureImageBtn
            // 
            this.captureImageBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.captureImageBtn.Location = new System.Drawing.Point(469, 438);
            this.captureImageBtn.Name = "captureImageBtn";
            this.captureImageBtn.Size = new System.Drawing.Size(142, 32);
            this.captureImageBtn.TabIndex = 12;
            this.captureImageBtn.Text = "Capture Image";
            this.captureImageBtn.UseVisualStyleBackColor = true;
            this.captureImageBtn.Click += new System.EventHandler(this.captureImageBtn_Click);
            // 
            // cannyBtn
            // 
            this.cannyBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cannyBtn.Location = new System.Drawing.Point(893, 440);
            this.cannyBtn.Name = "cannyBtn";
            this.cannyBtn.Size = new System.Drawing.Size(205, 32);
            this.cannyBtn.TabIndex = 13;
            this.cannyBtn.Text = "Convert To Canny Image";
            this.cannyBtn.TextAlign = System.Drawing.ContentAlignment.TopLeft;
            this.cannyBtn.UseVisualStyleBackColor = true;
            this.cannyBtn.Click += new System.EventHandler(this.cannyBtn_Click);
            // 
            // rotateBtn
            // 
            this.rotateBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rotateBtn.Location = new System.Drawing.Point(1245, 442);
            this.rotateBtn.Name = "rotateBtn";
            this.rotateBtn.Size = new System.Drawing.Size(127, 32);
            this.rotateBtn.TabIndex = 14;
            this.rotateBtn.Text = "Rotate";
            this.rotateBtn.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.rotateBtn.UseVisualStyleBackColor = true;
            this.rotateBtn.Click += new System.EventHandler(this.rotateBtn_Click);
            // 
            // gamaSlider
            // 
            this.gamaSlider.Location = new System.Drawing.Point(382, 483);
            this.gamaSlider.Maximum = 150;
            this.gamaSlider.Name = "gamaSlider";
            this.gamaSlider.Size = new System.Drawing.Size(363, 23);
            this.gamaSlider.TabIndex = 15;
            this.gamaSlider.Value = 100;
            this.gamaSlider.Scroll += new System.Windows.Forms.ScrollEventHandler(this.gamaSlider_Scroll);
            // 
            // contrastSlider
            // 
            this.contrastSlider.Location = new System.Drawing.Point(382, 525);
            this.contrastSlider.Name = "contrastSlider";
            this.contrastSlider.Size = new System.Drawing.Size(363, 23);
            this.contrastSlider.TabIndex = 17;
            this.contrastSlider.Scroll += new System.Windows.Forms.ScrollEventHandler(this.contrastSlider_Scroll);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(322, 483);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(45, 16);
            this.label6.TabIndex = 18;
            this.label6.Text = "Gama";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(322, 525);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(57, 16);
            this.label7.TabIndex = 19;
            this.label7.Text = "Contrast";
            // 
            // centerBtn
            // 
            this.centerBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.centerBtn.Location = new System.Drawing.Point(1447, 440);
            this.centerBtn.Name = "centerBtn";
            this.centerBtn.Size = new System.Drawing.Size(127, 32);
            this.centerBtn.TabIndex = 20;
            this.centerBtn.Text = "Center";
            this.centerBtn.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.centerBtn.UseVisualStyleBackColor = true;
            this.centerBtn.Click += new System.EventHandler(this.centerBtn_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(1346, 486);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(98, 20);
            this.label8.TabIndex = 21;
            this.label8.Text = "Offset Angle";
            // 
            // offsetAngle
            // 
            this.offsetAngle.AutoSize = true;
            this.offsetAngle.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.offsetAngle.Location = new System.Drawing.Point(1450, 486);
            this.offsetAngle.Name = "offsetAngle";
            this.offsetAngle.Size = new System.Drawing.Size(31, 20);
            this.offsetAngle.TabIndex = 22;
            this.offsetAngle.Text = "0.0";
            // 
            // timer1
            // 
            this.timer1.Interval = 500;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // autoProcessCheckBox
            // 
            this.autoProcessCheckBox.AutoSize = true;
            this.autoProcessCheckBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.autoProcessCheckBox.Location = new System.Drawing.Point(192, 370);
            this.autoProcessCheckBox.Name = "autoProcessCheckBox";
            this.autoProcessCheckBox.Size = new System.Drawing.Size(107, 20);
            this.autoProcessCheckBox.TabIndex = 23;
            this.autoProcessCheckBox.Text = "Auto Process";
            this.autoProcessCheckBox.UseVisualStyleBackColor = true;
            // 
            // houghLineCheckBox
            // 
            this.houghLineCheckBox.AutoSize = true;
            this.houghLineCheckBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.houghLineCheckBox.Location = new System.Drawing.Point(925, 478);
            this.houghLineCheckBox.Name = "houghLineCheckBox";
            this.houghLineCheckBox.Size = new System.Drawing.Size(138, 20);
            this.houghLineCheckBox.TabIndex = 24;
            this.houghLineCheckBox.Text = "Show Hough Lines";
            this.houghLineCheckBox.UseVisualStyleBackColor = true;
            // 
            // centerCheckbox
            // 
            this.centerCheckbox.AutoSize = true;
            this.centerCheckbox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.centerCheckbox.Location = new System.Drawing.Point(936, 504);
            this.centerCheckbox.Name = "centerCheckbox";
            this.centerCheckbox.Size = new System.Drawing.Size(102, 20);
            this.centerCheckbox.TabIndex = 25;
            this.centerCheckbox.Text = "Show Center";
            this.centerCheckbox.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.xyEqualRadioBtn);
            this.groupBox1.Controls.Add(this.xDominantRadioBtn);
            this.groupBox1.Controls.Add(this.yDominantRadioBtn);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(1389, 509);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(234, 96);
            this.groupBox1.TabIndex = 27;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Allignment Options";
            // 
            // xyEqualRadioBtn
            // 
            this.xyEqualRadioBtn.AutoSize = true;
            this.xyEqualRadioBtn.Location = new System.Drawing.Point(14, 71);
            this.xyEqualRadioBtn.Name = "xyEqualRadioBtn";
            this.xyEqualRadioBtn.Size = new System.Drawing.Size(207, 20);
            this.xyEqualRadioBtn.TabIndex = 29;
            this.xyEqualRadioBtn.TabStop = true;
            this.xyEqualRadioBtn.Text = "X and Y Dimensions are Equal";
            this.xyEqualRadioBtn.UseVisualStyleBackColor = true;
            // 
            // xDominantRadioBtn
            // 
            this.xDominantRadioBtn.AutoSize = true;
            this.xDominantRadioBtn.Location = new System.Drawing.Point(13, 49);
            this.xDominantRadioBtn.Name = "xDominantRadioBtn";
            this.xDominantRadioBtn.Size = new System.Drawing.Size(177, 20);
            this.xDominantRadioBtn.TabIndex = 28;
            this.xDominantRadioBtn.TabStop = true;
            this.xDominantRadioBtn.Text = "X dimension larger than Y";
            this.xDominantRadioBtn.UseVisualStyleBackColor = true;
            // 
            // yDominantRadioBtn
            // 
            this.yDominantRadioBtn.AutoSize = true;
            this.yDominantRadioBtn.Location = new System.Drawing.Point(14, 23);
            this.yDominantRadioBtn.Name = "yDominantRadioBtn";
            this.yDominantRadioBtn.Size = new System.Drawing.Size(177, 20);
            this.yDominantRadioBtn.TabIndex = 27;
            this.yDominantRadioBtn.TabStop = true;
            this.yDominantRadioBtn.Text = "Y dimension larger than X";
            this.yDominantRadioBtn.UseVisualStyleBackColor = true;
            // 
            // scaleFactorNUD
            // 
            this.scaleFactorNUD.Increment = new decimal(new int[] {
            1,
            0,
            0,
            196608});
            this.scaleFactorNUD.Location = new System.Drawing.Point(1291, 509);
            this.scaleFactorNUD.Name = "scaleFactorNUD";
            this.scaleFactorNUD.Size = new System.Drawing.Size(92, 20);
            this.scaleFactorNUD.TabIndex = 28;
            this.scaleFactorNUD.Value = new decimal(new int[] {
            26,
            0,
            0,
            196608});
            this.scaleFactorNUD.ValueChanged += new System.EventHandler(this.scaleFactorNUD_ValueChanged);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(1201, 511);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(84, 16);
            this.label9.TabIndex = 29;
            this.label9.Text = "Scale Factor";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(1204, 538);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(81, 16);
            this.label10.TabIndex = 30;
            this.label10.Text = "X dimension";
            // 
            // xDimensionLabel
            // 
            this.xDimensionLabel.AutoSize = true;
            this.xDimensionLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xDimensionLabel.Location = new System.Drawing.Point(1290, 538);
            this.xDimensionLabel.Name = "xDimensionLabel";
            this.xDimensionLabel.Size = new System.Drawing.Size(25, 16);
            this.xDimensionLabel.TabIndex = 31;
            this.xDimensionLabel.Text = "0.0";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(1204, 558);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(82, 16);
            this.label12.TabIndex = 32;
            this.label12.Text = "Y dimension";
            // 
            // yDimensionLabel
            // 
            this.yDimensionLabel.AutoSize = true;
            this.yDimensionLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.yDimensionLabel.Location = new System.Drawing.Point(1290, 558);
            this.yDimensionLabel.Name = "yDimensionLabel";
            this.yDimensionLabel.Size = new System.Drawing.Size(25, 16);
            this.yDimensionLabel.TabIndex = 33;
            this.yDimensionLabel.Text = "0.0";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1619, 652);
            this.Controls.Add(this.yDimensionLabel);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.xDimensionLabel);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.scaleFactorNUD);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.centerCheckbox);
            this.Controls.Add(this.houghLineCheckBox);
            this.Controls.Add(this.autoProcessCheckBox);
            this.Controls.Add(this.offsetAngle);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.centerBtn);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.contrastSlider);
            this.Controls.Add(this.gamaSlider);
            this.Controls.Add(this.rotateBtn);
            this.Controls.Add(this.cannyBtn);
            this.Controls.Add(this.captureImageBtn);
            this.Controls.Add(this.recordBtn);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.videoSourceList);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.capturedImagePanel);
            this.Controls.Add(this.correctedImagePanel);
            this.Controls.Add(this.cannyImagePanel);
            this.Controls.Add(this.videoSourcePlayer1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.scaleFactorNUD)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private AForge.Controls.VideoSourcePlayer videoSourcePlayer1;
        private CustomTools.ScrollableImagePanel cannyImagePanel;
        private CustomTools.ScrollableImagePanel correctedImagePanel;
        private CustomTools.ScrollableImagePanel capturedImagePanel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox videoSourceList;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button recordBtn;
        private System.Windows.Forms.Button captureImageBtn;
        private System.Windows.Forms.Button cannyBtn;
        private System.Windows.Forms.Button rotateBtn;
        private System.Windows.Forms.HScrollBar gamaSlider;
        private System.Windows.Forms.HScrollBar contrastSlider;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button centerBtn;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label offsetAngle;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.CheckBox autoProcessCheckBox;
        private System.Windows.Forms.CheckBox houghLineCheckBox;
        private System.Windows.Forms.CheckBox centerCheckbox;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton xyEqualRadioBtn;
        private System.Windows.Forms.RadioButton xDominantRadioBtn;
        private System.Windows.Forms.RadioButton yDominantRadioBtn;
        private System.Windows.Forms.NumericUpDown scaleFactorNUD;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label xDimensionLabel;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label yDimensionLabel;
    }
}

