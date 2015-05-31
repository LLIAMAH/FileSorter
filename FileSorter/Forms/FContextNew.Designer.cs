namespace FileSorter.Forms
{
    partial class FContextNew
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
            this.lContextName = new System.Windows.Forms.Label();
            this.tbContextName = new System.Windows.Forms.TextBox();
            this.bnOK = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lContextName
            // 
            this.lContextName.AutoSize = true;
            this.lContextName.Location = new System.Drawing.Point(12, 9);
            this.lContextName.Name = "lContextName";
            this.lContextName.Size = new System.Drawing.Size(75, 13);
            this.lContextName.TabIndex = 0;
            this.lContextName.Text = "Context name:";
            // 
            // tbContextName
            // 
            this.tbContextName.Location = new System.Drawing.Point(15, 25);
            this.tbContextName.Name = "tbContextName";
            this.tbContextName.Size = new System.Drawing.Size(499, 20);
            this.tbContextName.TabIndex = 1;
            this.tbContextName.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // bnOK
            // 
            this.bnOK.Location = new System.Drawing.Point(439, 51);
            this.bnOK.Name = "bnOK";
            this.bnOK.Size = new System.Drawing.Size(75, 23);
            this.bnOK.TabIndex = 2;
            this.bnOK.Text = "OK";
            this.bnOK.UseVisualStyleBackColor = true;
            // 
            // FContextNew
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(526, 83);
            this.Controls.Add(this.bnOK);
            this.Controls.Add(this.tbContextName);
            this.Controls.Add(this.lContextName);
            this.Name = "FContextNew";
            this.Text = "New Context";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lContextName;
        private System.Windows.Forms.TextBox tbContextName;
        private System.Windows.Forms.Button bnOK;
    }
}