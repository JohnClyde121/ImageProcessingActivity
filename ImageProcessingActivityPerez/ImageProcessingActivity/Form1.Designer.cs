namespace ImageProcessingActivity
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
            choices = new ComboBox();
            btnLoad = new Button();
            btnSave = new Button();
            btnConvert = new Button();
            pbOrig = new PictureBox();
            pbCopy = new PictureBox();
            label1 = new Label();
            openFileDialog1 = new OpenFileDialog();
            button1 = new Button();
            ((System.ComponentModel.ISupportInitialize)pbOrig).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pbCopy).BeginInit();
            SuspendLayout();
            // 
            // choices
            // 
            choices.FormattingEnabled = true;
            choices.Items.AddRange(new object[] { "Basic Copy", "Grey Scale", "Color Inversion", "Histogram", "Sepia" });
            choices.Location = new Point(790, 885);
            choices.Name = "choices";
            choices.Size = new Size(292, 40);
            choices.TabIndex = 0;
            choices.SelectedIndexChanged += comboBox1_SelectedIndexChanged;
            // 
            // btnLoad
            // 
            btnLoad.Location = new Point(145, 36);
            btnLoad.Name = "btnLoad";
            btnLoad.Size = new Size(325, 83);
            btnLoad.TabIndex = 1;
            btnLoad.Text = "Load Image";
            btnLoad.UseVisualStyleBackColor = true;
            btnLoad.Click += btnLoad_Click;
            // 
            // btnSave
            // 
            btnSave.Location = new Point(790, 1038);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(292, 72);
            btnSave.TabIndex = 2;
            btnSave.Text = "Save Image";
            btnSave.UseVisualStyleBackColor = true;
            btnSave.Click += button2_Click;
            // 
            // btnConvert
            // 
            btnConvert.Location = new Point(790, 948);
            btnConvert.Name = "btnConvert";
            btnConvert.Size = new Size(292, 67);
            btnConvert.TabIndex = 3;
            btnConvert.Text = "Convert";
            btnConvert.UseVisualStyleBackColor = true;
            btnConvert.Click += button3_Click;
            // 
            // pbOrig
            // 
            pbOrig.Location = new Point(145, 209);
            pbOrig.Name = "pbOrig";
            pbOrig.Size = new Size(726, 628);
            pbOrig.TabIndex = 4;
            pbOrig.TabStop = false;
            // 
            // pbCopy
            // 
            pbCopy.Location = new Point(953, 209);
            pbCopy.Name = "pbCopy";
            pbCopy.Size = new Size(726, 628);
            pbCopy.TabIndex = 5;
            pbCopy.TabStop = false;
            pbCopy.Click += pbCopy_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(463, 164);
            label1.Name = "label1";
            label1.Size = new Size(0, 32);
            label1.TabIndex = 6;
            label1.Click += label1_Click;
            // 
            // openFileDialog1
            // 
            openFileDialog1.FileName = "openFileDialog1";
            // 
            // button1
            // 
            button1.Location = new Point(1675, 54);
            button1.Name = "button1";
            button1.Size = new Size(150, 46);
            button1.TabIndex = 8;
            button1.Text = "Part 2";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1904, 1206);
            Controls.Add(button1);
            Controls.Add(label1);
            Controls.Add(pbCopy);
            Controls.Add(pbOrig);
            Controls.Add(btnConvert);
            Controls.Add(btnSave);
            Controls.Add(btnLoad);
            Controls.Add(choices);
            Name = "Form1";
            Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)pbOrig).EndInit();
            ((System.ComponentModel.ISupportInitialize)pbCopy).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ComboBox choices;
        private Button btnLoad;
        private Button btnSave;
        private Button btnConvert;
        private PictureBox pbOrig;
        private PictureBox pbCopy;
        private Label label1;
        private Label label2;
        private OpenFileDialog openFileDialog1;
        private Button button1;
    }
}
