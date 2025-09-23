namespace ImageProcessing
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            pictureBox1 = new PictureBox();
            pictureBox2 = new PictureBox();
            pictureBox3 = new PictureBox();
            button1 = new Button();
            button2 = new Button();
            button3 = new Button();
            button4 = new Button();
            button5 = new Button();
            button6 = new Button();
            button7 = new Button();
            button8 = new Button();
            button9 = new Button();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).BeginInit();
            SuspendLayout();
            // 
            // pictureBox1
            // 
            pictureBox1.Location = new Point(66, 49);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(200, 100);
            pictureBox1.TabIndex = 0;
            pictureBox1.TabStop = false;
            // 
            // pictureBox2
            // 
            pictureBox2.Location = new Point(307, 49);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(200, 100);
            pictureBox2.TabIndex = 1;
            pictureBox2.TabStop = false;
            // 
            // pictureBox3
            // 
            pictureBox3.Location = new Point(550, 49);
            pictureBox3.Name = "pictureBox3";
            pictureBox3.Size = new Size(200, 100);
            pictureBox3.TabIndex = 2;
            pictureBox3.TabStop = false;
            // 
            // button1
            // 
            button1.Location = new Point(97, 204);
            button1.Name = "button1";
            button1.Size = new Size(150, 46);
            button1.TabIndex = 3;
            button1.Text = "Load";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // button2
            // 
            button2.Location = new Point(339, 204);
            button2.Name = "button2";
            button2.Size = new Size(150, 46);
            button2.TabIndex = 4;
            button2.Text = "Load";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // button3
            // 
            button3.Location = new Point(575, 204);
            button3.Name = "button3";
            button3.Size = new Size(150, 46);
            button3.TabIndex = 5;
            button3.Text = "Copy";
            button3.UseVisualStyleBackColor = true;
            button3.Click += button3_Click;
            // 
            // button4
            // 
            button4.Location = new Point(97, 282);
            button4.Name = "button4";
            button4.Size = new Size(150, 46);
            button4.TabIndex = 6;
            button4.Text = "GrayScale";
            button4.UseVisualStyleBackColor = true;
            button4.Click += button4_Click;
            // 
            // button5
            // 
            button5.Location = new Point(339, 282);
            button5.Name = "button5";
            button5.Size = new Size(150, 46);
            button5.TabIndex = 7;
            button5.Text = "Invert";
            button5.UseVisualStyleBackColor = true;
            button5.Click += button5_Click;
            // 
            // button6
            // 
            button6.Location = new Point(575, 282);
            button6.Name = "button6";
            button6.Size = new Size(150, 46);
            button6.TabIndex = 8;
            button6.Text = "Sepia";
            button6.UseVisualStyleBackColor = true;
            button6.Click += button6_Click;
            // 
            // button7
            // 
            button7.Location = new Point(97, 359);
            button7.Name = "button7";
            button7.Size = new Size(150, 46);
            button7.TabIndex = 9;
            button7.Text = "Histogram";
            button7.UseVisualStyleBackColor = true;
            button7.Click += button7_Click;
            // 
            // button8
            // 
            button8.Location = new Point(339, 359);
            button8.Name = "button8";
            button8.Size = new Size(150, 46);
            button8.TabIndex = 10;
            button8.Text = "Subtract";
            button8.UseVisualStyleBackColor = true;
            button8.Click += button8_Click;
            // 
            // button9
            // 
            button9.Location = new Point(575, 359);
            button9.Name = "button9";
            button9.Size = new Size(150, 46);
            button9.TabIndex = 11;
            button9.Text = "SAVE";
            button9.UseVisualStyleBackColor = true;
            button9.Click += button9_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(button9);
            Controls.Add(button8);
            Controls.Add(button7);
            Controls.Add(button6);
            Controls.Add(button5);
            Controls.Add(button4);
            Controls.Add(button3);
            Controls.Add(button2);
            Controls.Add(button1);
            Controls.Add(pictureBox3);
            Controls.Add(pictureBox2);
            Controls.Add(pictureBox1);
            Name = "Form1";
            Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private PictureBox pictureBox1;
        private PictureBox pictureBox2;
        private PictureBox pictureBox3;
        private Button button1;
        private Button button2;
        private Button button3;
        private Button button4;
        private Button button5;
        private Button button6;
        private Button button7;
        private Button button8;
        private Button button9;
    }
}
