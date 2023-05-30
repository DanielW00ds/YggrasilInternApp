namespace WinFormsApp1
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
            this.titlelbl = new System.Windows.Forms.Label();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.titlesflp = new System.Windows.Forms.FlowLayoutPanel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.newAssetbtn = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // titlelbl
            // 
            this.titlelbl.AutoSize = true;
            this.titlelbl.Font = new System.Drawing.Font("Segoe UI", 26.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.titlelbl.Location = new System.Drawing.Point(28, -2);
            this.titlelbl.Name = "titlelbl";
            this.titlelbl.Size = new System.Drawing.Size(118, 47);
            this.titlelbl.TabIndex = 5;
            this.titlelbl.Text = "Assets";
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.AutoScroll = true;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(28, 109);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(1119, 502);
            this.flowLayoutPanel1.TabIndex = 7;
            // 
            // titlesflp
            // 
            this.titlesflp.Location = new System.Drawing.Point(28, 78);
            this.titlesflp.Name = "titlesflp";
            this.titlesflp.Size = new System.Drawing.Size(1120, 20);
            this.titlesflp.TabIndex = 8;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.pictureBox1.Location = new System.Drawing.Point(28, 102);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(1120, 2);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // newAssetbtn
            // 
            this.newAssetbtn.Location = new System.Drawing.Point(30, 48);
            this.newAssetbtn.Name = "newAssetbtn";
            this.newAssetbtn.Size = new System.Drawing.Size(72, 23);
            this.newAssetbtn.TabIndex = 9;
            this.newAssetbtn.Text = "+  Add asset";
            this.newAssetbtn.UseVisualStyleBackColor = true;
            this.newAssetbtn.Click += new System.EventHandler(this.NewAsset);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1179, 623);
            this.Controls.Add(this.newAssetbtn);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.titlesflp);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Controls.Add(this.titlelbl);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private Label titlelbl;
        private FlowLayoutPanel flowLayoutPanel1;
        private FlowLayoutPanel titlesflp;
        private PictureBox pictureBox1;
        private Button newAssetbtn;
    }
}