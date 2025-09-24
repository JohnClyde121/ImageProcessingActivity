namespace ImageProcessingActivity
{
    partial class Form2
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
            button4 = new Button();
            button3 = new Button();
            button2 = new Button();
            button1 = new Button();
            label5 = new Label();
            label4 = new Label();
            label3 = new Label();
            image_C = new PictureBox();
            image_B = new PictureBox();
            image_A = new PictureBox();
            button6 = new Button();
            ((System.ComponentModel.ISupportInitialize)image_C).BeginInit();
            ((System.ComponentModel.ISupportInitialize)image_B).BeginInit();
            ((System.ComponentModel.ISupportInitialize)image_A).BeginInit();
            SuspendLayout();
            // 
            // button4
            // 
            button4.Location = new Point(1463, 151);
            button4.Name = "button4";
            button4.Size = new Size(273, 77);
            button4.TabIndex = 27;
            button4.Text = "Part 1";
            button4.UseVisualStyleBackColor = true;
            button4.Click += button4_Click;
            // 
            // button3
            // 
            button3.Location = new Point(1253, 862);
            button3.Name = "button3";
            button3.Size = new Size(343, 72);
            button3.TabIndex = 26;
            button3.Text = "Subtract";
            button3.UseVisualStyleBackColor = true;
            button3.Click += button3_Click;
            // 
            // button2
            // 
            button2.Location = new Point(775, 862);
            button2.Name = "button2";
            button2.Size = new Size(343, 72);
            button2.TabIndex = 25;
            button2.Text = "Load Background";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // button1
            // 
            button1.Location = new Point(284, 862);
            button1.Name = "button1";
            button1.Size = new Size(343, 72);
            button1.TabIndex = 24;
            button1.Text = "Load Image";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(1377, 346);
            label5.Name = "label5";
            label5.Size = new Size(78, 32);
            label5.TabIndex = 23;
            label5.Text = "Result";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(877, 346);
            label4.Name = "label4";
            label4.Size = new Size(101, 32);
            label4.TabIndex = 22;
            label4.Text = "Image B";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(401, 346);
            label3.Name = "label3";
            label3.Size = new Size(102, 32);
            label3.TabIndex = 21;
            label3.Text = "Image A";
            // 
            // image_C
            // 
            image_C.Location = new Point(1206, 407);
            image_C.Name = "image_C";
            image_C.Size = new Size(441, 429);
            image_C.TabIndex = 19;
            image_C.TabStop = false;
            // 
            // image_B
            // 
            image_B.Location = new Point(722, 407);
            image_B.Name = "image_B";
            image_B.Size = new Size(441, 429);
            image_B.TabIndex = 18;
            image_B.TabStop = false;
            // 
            // image_A
            // 
            image_A.Location = new Point(235, 407);
            image_A.Name = "image_A";
            image_A.Size = new Size(441, 429);
            image_A.TabIndex = 17;
            image_A.TabStop = false;
            // 
            // button6
            // 
            button6.Location = new Point(775, 972);
            button6.Name = "button6";
            button6.Size = new Size(343, 72);
            button6.TabIndex = 28;
            button6.Text = "Save Image";
            button6.UseVisualStyleBackColor = true;
            button6.Click += button6_Click;
            // 
            // Form2
            // 
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1881, 1194);
            Controls.Add(button6);
            Controls.Add(button4);
            Controls.Add(button3);
            Controls.Add(button2);
            Controls.Add(button1);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(image_C);
            Controls.Add(image_B);
            Controls.Add(image_A);
            Name = "Form2";
            Text = "Form2";
            ((System.ComponentModel.ISupportInitialize)image_C).EndInit();
            ((System.ComponentModel.ISupportInitialize)image_B).EndInit();
            ((System.ComponentModel.ISupportInitialize)image_A).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button button4;
        private Button button3;
        private Button button2;
        private Button button1;
        private Label label5;
        private Label label4;
        private Label label3;
        private Label label2;
        private PictureBox image_C;
        private PictureBox image_B;
        private PictureBox image_A;
        private Label label1;
        private Button button5;
        private Button button6;
    }
}