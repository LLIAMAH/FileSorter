namespace FileSorter.Forms
{
    partial class FRename
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
            this.tbOldName = new System.Windows.Forms.TextBox();
            this.lNameOld = new System.Windows.Forms.Label();
            this.lNameNew = new System.Windows.Forms.Label();
            this.tbNewName = new System.Windows.Forms.TextBox();
            this.bnOK = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // tbOldName
            // 
            this.tbOldName.Location = new System.Drawing.Point(15, 25);
            this.tbOldName.Name = "tbOldName";
            this.tbOldName.ReadOnly = true;
            this.tbOldName.Size = new System.Drawing.Size(548, 20);
            this.tbOldName.TabIndex = 0;
            this.tbOldName.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // lNameOld
            // 
            this.lNameOld.AutoSize = true;
            this.lNameOld.Location = new System.Drawing.Point(12, 9);
            this.lNameOld.Name = "lNameOld";
            this.lNameOld.Size = new System.Drawing.Size(55, 13);
            this.lNameOld.TabIndex = 1;
            this.lNameOld.Text = "Old name:";
            // 
            // lNameNew
            // 
            this.lNameNew.AutoSize = true;
            this.lNameNew.Location = new System.Drawing.Point(12, 65);
            this.lNameNew.Name = "lNameNew";
            this.lNameNew.Size = new System.Drawing.Size(61, 13);
            this.lNameNew.TabIndex = 3;
            this.lNameNew.Text = "New name:";
            // 
            // tbNewName
            // 
            this.tbNewName.Location = new System.Drawing.Point(15, 81);
            this.tbNewName.Name = "tbNewName";
            this.tbNewName.Size = new System.Drawing.Size(548, 20);
            this.tbNewName.TabIndex = 2;
            this.tbNewName.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // bnOK
            // 
            this.bnOK.Location = new System.Drawing.Point(488, 107);
            this.bnOK.Name = "bnOK";
            this.bnOK.Size = new System.Drawing.Size(75, 23);
            this.bnOK.TabIndex = 4;
            this.bnOK.Text = "OK";
            this.bnOK.UseVisualStyleBackColor = true;
            this.bnOK.Click += new System.EventHandler(this.bnOK_Click);
            // 
            // FRename
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(575, 144);
            this.Controls.Add(this.bnOK);
            this.Controls.Add(this.lNameNew);
            this.Controls.Add(this.tbNewName);
            this.Controls.Add(this.lNameOld);
            this.Controls.Add(this.tbOldName);
            this.Name = "FRename";
            this.Text = "Rename";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tbOldName;
        private System.Windows.Forms.Label lNameOld;
        private System.Windows.Forms.Label lNameNew;
        private System.Windows.Forms.TextBox tbNewName;
        private System.Windows.Forms.Button bnOK;
    }
}