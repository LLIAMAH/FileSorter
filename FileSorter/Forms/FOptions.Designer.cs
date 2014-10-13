namespace FileSorter.Forms
{
    partial class FOptions
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
            this.tcOptionTabs = new System.Windows.Forms.TabControl();
            this.tpGeneral = new System.Windows.Forms.TabPage();
            this.lSplitter = new System.Windows.Forms.Label();
            this.tbSplitter = new System.Windows.Forms.TextBox();
            this.tbFilter = new System.Windows.Forms.TextBox();
            this.lFilter = new System.Windows.Forms.Label();
            this.tpFolders = new System.Windows.Forms.TabPage();
            this.dgvFolders = new System.Windows.Forms.DataGridView();
            this.colAlias = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPath = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colBrowse = new System.Windows.Forms.DataGridViewButtonColumn();
            this.fbdBrowse = new System.Windows.Forms.FolderBrowserDialog();
            this.bnOK = new System.Windows.Forms.Button();
            this.tcOptionTabs.SuspendLayout();
            this.tpGeneral.SuspendLayout();
            this.tpFolders.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvFolders)).BeginInit();
            this.SuspendLayout();
            // 
            // tcOptionTabs
            // 
            this.tcOptionTabs.Controls.Add(this.tpGeneral);
            this.tcOptionTabs.Controls.Add(this.tpFolders);
            this.tcOptionTabs.Dock = System.Windows.Forms.DockStyle.Top;
            this.tcOptionTabs.Location = new System.Drawing.Point(0, 0);
            this.tcOptionTabs.Name = "tcOptionTabs";
            this.tcOptionTabs.SelectedIndex = 0;
            this.tcOptionTabs.Size = new System.Drawing.Size(684, 321);
            this.tcOptionTabs.TabIndex = 0;
            // 
            // tpGeneral
            // 
            this.tpGeneral.Controls.Add(this.lSplitter);
            this.tpGeneral.Controls.Add(this.tbSplitter);
            this.tpGeneral.Controls.Add(this.tbFilter);
            this.tpGeneral.Controls.Add(this.lFilter);
            this.tpGeneral.Location = new System.Drawing.Point(4, 22);
            this.tpGeneral.Name = "tpGeneral";
            this.tpGeneral.Padding = new System.Windows.Forms.Padding(3);
            this.tpGeneral.Size = new System.Drawing.Size(676, 295);
            this.tpGeneral.TabIndex = 0;
            this.tpGeneral.Text = "General";
            this.tpGeneral.UseVisualStyleBackColor = true;
            // 
            // lSplitter
            // 
            this.lSplitter.AutoSize = true;
            this.lSplitter.Location = new System.Drawing.Point(8, 35);
            this.lSplitter.Name = "lSplitter";
            this.lSplitter.Size = new System.Drawing.Size(39, 13);
            this.lSplitter.TabIndex = 3;
            this.lSplitter.Text = "Splitter";
            // 
            // tbSplitter
            // 
            this.tbSplitter.Location = new System.Drawing.Point(288, 32);
            this.tbSplitter.Name = "tbSplitter";
            this.tbSplitter.Size = new System.Drawing.Size(81, 20);
            this.tbSplitter.TabIndex = 2;
            // 
            // tbFilter
            // 
            this.tbFilter.Location = new System.Drawing.Point(288, 6);
            this.tbFilter.Name = "tbFilter";
            this.tbFilter.Size = new System.Drawing.Size(162, 20);
            this.tbFilter.TabIndex = 1;
            // 
            // lFilter
            // 
            this.lFilter.AutoSize = true;
            this.lFilter.Location = new System.Drawing.Point(8, 9);
            this.lFilter.Name = "lFilter";
            this.lFilter.Size = new System.Drawing.Size(29, 13);
            this.lFilter.TabIndex = 0;
            this.lFilter.Text = "Filter";
            // 
            // tpFolders
            // 
            this.tpFolders.Controls.Add(this.dgvFolders);
            this.tpFolders.Location = new System.Drawing.Point(4, 22);
            this.tpFolders.Name = "tpFolders";
            this.tpFolders.Padding = new System.Windows.Forms.Padding(3);
            this.tpFolders.Size = new System.Drawing.Size(676, 295);
            this.tpFolders.TabIndex = 1;
            this.tpFolders.Text = "Folders";
            this.tpFolders.UseVisualStyleBackColor = true;
            // 
            // dgvFolders
            // 
            this.dgvFolders.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvFolders.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colAlias,
            this.colPath,
            this.colBrowse});
            this.dgvFolders.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvFolders.Location = new System.Drawing.Point(3, 3);
            this.dgvFolders.MultiSelect = false;
            this.dgvFolders.Name = "dgvFolders";
            this.dgvFolders.RowHeadersVisible = false;
            this.dgvFolders.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvFolders.ShowCellToolTips = false;
            this.dgvFolders.Size = new System.Drawing.Size(670, 289);
            this.dgvFolders.TabIndex = 0;
            this.dgvFolders.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvFolders_CellClick);
            // 
            // colAlias
            // 
            this.colAlias.HeaderText = "Alias";
            this.colAlias.Name = "colAlias";
            this.colAlias.Width = 180;
            // 
            // colPath
            // 
            this.colPath.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colPath.HeaderText = "Path";
            this.colPath.Name = "colPath";
            // 
            // colBrowse
            // 
            this.colBrowse.HeaderText = "...";
            this.colBrowse.Name = "colBrowse";
            this.colBrowse.Text = "...";
            this.colBrowse.Width = 40;
            // 
            // bnOK
            // 
            this.bnOK.Location = new System.Drawing.Point(597, 327);
            this.bnOK.Name = "bnOK";
            this.bnOK.Size = new System.Drawing.Size(75, 23);
            this.bnOK.TabIndex = 1;
            this.bnOK.Text = "OK";
            this.bnOK.UseVisualStyleBackColor = true;
            this.bnOK.Click += new System.EventHandler(this.bnOK_Click);
            // 
            // FOptions
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(684, 362);
            this.Controls.Add(this.bnOK);
            this.Controls.Add(this.tcOptionTabs);
            this.Name = "FOptions";
            this.Text = "Options";
            this.Load += new System.EventHandler(this.FOptions_Load);
            this.tcOptionTabs.ResumeLayout(false);
            this.tpGeneral.ResumeLayout(false);
            this.tpGeneral.PerformLayout();
            this.tpFolders.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvFolders)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tcOptionTabs;
        private System.Windows.Forms.TabPage tpGeneral;
        private System.Windows.Forms.TabPage tpFolders;
        private System.Windows.Forms.DataGridView dgvFolders;
        private System.Windows.Forms.TextBox tbFilter;
        private System.Windows.Forms.Label lFilter;
        private System.Windows.Forms.Label lSplitter;
        private System.Windows.Forms.TextBox tbSplitter;
        private System.Windows.Forms.FolderBrowserDialog fbdBrowse;
        private System.Windows.Forms.DataGridViewTextBoxColumn colAlias;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPath;
        private System.Windows.Forms.DataGridViewButtonColumn colBrowse;
        private System.Windows.Forms.Button bnOK;
    }
}