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
            pictureBoxOriginal = new PictureBox();
            pictureBoxProcessed = new PictureBox();
            btnLoad = new Button();
            btnApply = new Button();
            btnSave = new Button();
            cmbFilters = new ComboBox();
            ((System.ComponentModel.ISupportInitialize)pictureBoxOriginal).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBoxProcessed).BeginInit();
            SuspendLayout();
            // 
            // pictureBoxOriginal
            // 
            pictureBoxOriginal.Location = new Point(170, 58);
            pictureBoxOriginal.Name = "pictureBoxOriginal";
            pictureBoxOriginal.Size = new Size(237, 152);
            pictureBoxOriginal.TabIndex = 0;
            pictureBoxOriginal.TabStop = false;
            // 
            // pictureBoxProcessed
            // 
            pictureBoxProcessed.Location = new Point(592, 58);
            pictureBoxProcessed.Name = "pictureBoxProcessed";
            pictureBoxProcessed.Size = new Size(237, 152);
            pictureBoxProcessed.TabIndex = 1;
            pictureBoxProcessed.TabStop = false;
            // 
            // btnLoad
            // 
            btnLoad.Location = new Point(76, 327);
            btnLoad.Name = "btnLoad";
            btnLoad.Size = new Size(150, 46);
            btnLoad.TabIndex = 2;
            btnLoad.Text = "Load";
            btnLoad.UseVisualStyleBackColor = true;
            btnLoad.Click += btnLoad_Click;
            // 
            // btnApply
            // 
            btnApply.Location = new Point(574, 327);
            btnApply.Name = "btnApply";
            btnApply.Size = new Size(150, 46);
            btnApply.TabIndex = 3;
            btnApply.Text = "Apply";
            btnApply.UseVisualStyleBackColor = true;
            btnApply.Click += btnApply_Click;
            // 
            // btnSave
            // 
            btnSave.Location = new Point(784, 327);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(150, 46);
            btnSave.TabIndex = 4;
            btnSave.Text = "Save";
            btnSave.UseVisualStyleBackColor = true;
            btnSave.Click += btnSave_Click;
            // 
            // cmbFilters
            // 
            cmbFilters.FormattingEnabled = true;
            cmbFilters.Location = new Point(276, 331);
            cmbFilters.Name = "cmbFilters";
            cmbFilters.Size = new Size(242, 40);
            cmbFilters.TabIndex = 5;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(986, 520);
            Controls.Add(cmbFilters);
            Controls.Add(btnSave);
            Controls.Add(btnApply);
            Controls.Add(btnLoad);
            Controls.Add(pictureBoxProcessed);
            Controls.Add(pictureBoxOriginal);
            Name = "Form1";
            Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)pictureBoxOriginal).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBoxProcessed).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private PictureBox pictureBoxOriginal;
        private PictureBox pictureBoxProcessed;
        private Button btnLoad;
        private Button btnApply;
        private Button btnSave;
        private ComboBox cmbFilters;
    }
}
