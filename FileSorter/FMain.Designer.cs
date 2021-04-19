namespace FileSorter
{
    partial class FMain
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
            this.msMainMenu = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.optionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiOptions = new System.Windows.Forms.ToolStripMenuItem();
            this.cmsFileListMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.tsmiOpen = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiMoveTo = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiAddAttachment = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiCreateGroup = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiRename = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiClearChanges = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiSplit1 = new System.Windows.Forms.ToolStripSeparator();
            this.tsmiProcess = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiSplit2 = new System.Windows.Forms.ToolStripSeparator();
            this.tsmiCheckAll = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiUncheckAll = new System.Windows.Forms.ToolStripMenuItem();
            this.dgvFiles = new System.Windows.Forms.DataGridView();
            this.bnBrowseRootFolder = new System.Windows.Forms.Button();
            this.tbRootFolder = new System.Windows.Forms.TextBox();
            this.lRootFolder = new System.Windows.Forms.Label();
            this.fbdBroseRootFolder = new System.Windows.Forms.FolderBrowserDialog();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ofdAttachment = new System.Windows.Forms.OpenFileDialog();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bnRefreshFolder = new System.Windows.Forms.Button();
            this.fileItemBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.filesContextBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.checkedDataGridViewCheckBoxColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.fileNameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.extensionDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ParentDir = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Changes = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fullNameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.msMainMenu.SuspendLayout();
            this.cmsFileListMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvFiles)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fileItemBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.filesContextBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // msMainMenu
            // 
            this.msMainMenu.GripMargin = new System.Windows.Forms.Padding(2, 2, 0, 2);
            this.msMainMenu.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.msMainMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.optionsToolStripMenuItem});
            this.msMainMenu.Location = new System.Drawing.Point(0, 0);
            this.msMainMenu.Name = "msMainMenu";
            this.msMainMenu.Size = new System.Drawing.Size(1772, 36);
            this.msMainMenu.TabIndex = 0;
            this.msMainMenu.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(54, 30);
            this.fileToolStripMenuItem.Text = "&File";
            // 
            // optionsToolStripMenuItem
            // 
            this.optionsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiOptions});
            this.optionsToolStripMenuItem.Name = "optionsToolStripMenuItem";
            this.optionsToolStripMenuItem.Size = new System.Drawing.Size(92, 30);
            this.optionsToolStripMenuItem.Text = "Options";
            // 
            // tsmiOptions
            // 
            this.tsmiOptions.Name = "tsmiOptions";
            this.tsmiOptions.Size = new System.Drawing.Size(190, 34);
            this.tsmiOptions.Text = "&Options...";
            this.tsmiOptions.Click += new System.EventHandler(this.tsmiOptions_Click);
            // 
            // cmsFileListMenu
            // 
            this.cmsFileListMenu.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.cmsFileListMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiOpen,
            this.tsmiMoveTo,
            this.tsmiAddAttachment,
            this.tsmiCreateGroup,
            this.tsmiRename,
            this.tsmiClearChanges,
            this.deleteToolStripMenuItem,
            this.tsmiSplit1,
            this.tsmiProcess,
            this.tsmiSplit2,
            this.tsmiCheckAll,
            this.tsmiUncheckAll});
            this.cmsFileListMenu.Name = "cmsFileListMenu";
            this.cmsFileListMenu.Size = new System.Drawing.Size(225, 336);
            // 
            // tsmiOpen
            // 
            this.tsmiOpen.Name = "tsmiOpen";
            this.tsmiOpen.Size = new System.Drawing.Size(224, 32);
            this.tsmiOpen.Text = "Open";
            this.tsmiOpen.Click += new System.EventHandler(this.tsmiOpen_Click);
            // 
            // tsmiMoveTo
            // 
            this.tsmiMoveTo.Name = "tsmiMoveTo";
            this.tsmiMoveTo.Size = new System.Drawing.Size(224, 32);
            this.tsmiMoveTo.Text = "&Move to...";
            // 
            // tsmiAddAttachment
            // 
            this.tsmiAddAttachment.Name = "tsmiAddAttachment";
            this.tsmiAddAttachment.Size = new System.Drawing.Size(224, 32);
            this.tsmiAddAttachment.Text = "Add &attachment...";
            this.tsmiAddAttachment.Click += new System.EventHandler(this.tsmiAddAttachment_Click);
            // 
            // tsmiCreateGroup
            // 
            this.tsmiCreateGroup.Name = "tsmiCreateGroup";
            this.tsmiCreateGroup.Size = new System.Drawing.Size(224, 32);
            this.tsmiCreateGroup.Text = "Create &group...";
            this.tsmiCreateGroup.Click += new System.EventHandler(this.tsmiCreateGroup_Click);
            // 
            // tsmiRename
            // 
            this.tsmiRename.Name = "tsmiRename";
            this.tsmiRename.Size = new System.Drawing.Size(224, 32);
            this.tsmiRename.Text = "Rename...";
            this.tsmiRename.Click += new System.EventHandler(this.tsmiRename_Click);
            // 
            // tsmiClearChanges
            // 
            this.tsmiClearChanges.Name = "tsmiClearChanges";
            this.tsmiClearChanges.Size = new System.Drawing.Size(224, 32);
            this.tsmiClearChanges.Text = "Clear changes";
            this.tsmiClearChanges.Click += new System.EventHandler(this.tsmiClearChanges_Click);
            // 
            // deleteToolStripMenuItem
            // 
            this.deleteToolStripMenuItem.Name = "deleteToolStripMenuItem";
            this.deleteToolStripMenuItem.Size = new System.Drawing.Size(224, 32);
            this.deleteToolStripMenuItem.Text = "Delete";
            this.deleteToolStripMenuItem.Click += new System.EventHandler(this.deleteToolStripMenuItem_Click);
            // 
            // tsmiSplit1
            // 
            this.tsmiSplit1.Name = "tsmiSplit1";
            this.tsmiSplit1.Size = new System.Drawing.Size(221, 6);
            // 
            // tsmiProcess
            // 
            this.tsmiProcess.Name = "tsmiProcess";
            this.tsmiProcess.Size = new System.Drawing.Size(224, 32);
            this.tsmiProcess.Text = "Process";
            this.tsmiProcess.Click += new System.EventHandler(this.tsmiProcess_Click);
            // 
            // tsmiSplit2
            // 
            this.tsmiSplit2.Name = "tsmiSplit2";
            this.tsmiSplit2.Size = new System.Drawing.Size(221, 6);
            // 
            // tsmiCheckAll
            // 
            this.tsmiCheckAll.Name = "tsmiCheckAll";
            this.tsmiCheckAll.Size = new System.Drawing.Size(224, 32);
            this.tsmiCheckAll.Text = "Check All";
            this.tsmiCheckAll.Click += new System.EventHandler(this.tsmiCheckAll_Click);
            // 
            // tsmiUncheckAll
            // 
            this.tsmiUncheckAll.Name = "tsmiUncheckAll";
            this.tsmiUncheckAll.Size = new System.Drawing.Size(224, 32);
            this.tsmiUncheckAll.Text = "Uncheck All";
            this.tsmiUncheckAll.Click += new System.EventHandler(this.tsmiUncheckAll_Click);
            // 
            // dgvFiles
            // 
            this.dgvFiles.AllowUserToAddRows = false;
            this.dgvFiles.AllowUserToDeleteRows = false;
            this.dgvFiles.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvFiles.AutoGenerateColumns = false;
            this.dgvFiles.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvFiles.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.checkedDataGridViewCheckBoxColumn,
            this.fileNameDataGridViewTextBoxColumn,
            this.extensionDataGridViewTextBoxColumn,
            this.ParentDir,
            this.Changes,
            this.fullNameDataGridViewTextBoxColumn});
            this.dgvFiles.DataSource = this.fileItemBindingSource;
            this.dgvFiles.Location = new System.Drawing.Point(18, 86);
            this.dgvFiles.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.dgvFiles.MultiSelect = false;
            this.dgvFiles.Name = "dgvFiles";
            this.dgvFiles.RowHeadersVisible = false;
            this.dgvFiles.RowHeadersWidth = 62;
            this.dgvFiles.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvFiles.Size = new System.Drawing.Size(1736, 695);
            this.dgvFiles.TabIndex = 1;
            this.dgvFiles.CellMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgvFiles_CellMouseClick);
            this.dgvFiles.CellMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgvFiles_CellMouseDoubleClick);
            this.dgvFiles.CurrentCellDirtyStateChanged += new System.EventHandler(this.dgvFiles_CurrentCellDirtyStateChanged);
            // 
            // bnBrowseRootFolder
            // 
            this.bnBrowseRootFolder.Location = new System.Drawing.Point(1208, 42);
            this.bnBrowseRootFolder.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.bnBrowseRootFolder.Name = "bnBrowseRootFolder";
            this.bnBrowseRootFolder.Size = new System.Drawing.Size(112, 35);
            this.bnBrowseRootFolder.TabIndex = 2;
            this.bnBrowseRootFolder.Text = "Browse...";
            this.bnBrowseRootFolder.UseVisualStyleBackColor = true;
            this.bnBrowseRootFolder.Click += new System.EventHandler(this.bnBrowseRootFolder_Click);
            // 
            // tbRootFolder
            // 
            this.tbRootFolder.Location = new System.Drawing.Point(126, 45);
            this.tbRootFolder.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tbRootFolder.Name = "tbRootFolder";
            this.tbRootFolder.ReadOnly = true;
            this.tbRootFolder.Size = new System.Drawing.Size(1070, 26);
            this.tbRootFolder.TabIndex = 3;
            // 
            // lRootFolder
            // 
            this.lRootFolder.AutoSize = true;
            this.lRootFolder.Location = new System.Drawing.Point(18, 49);
            this.lRootFolder.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lRootFolder.Name = "lRootFolder";
            this.lRootFolder.Size = new System.Drawing.Size(100, 20);
            this.lRootFolder.TabIndex = 4;
            this.lRootFolder.Text = "Folder (root):";
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dataGridViewTextBoxColumn1.DataPropertyName = "ChangesStatus";
            this.dataGridViewTextBoxColumn1.HeaderText = "ChangesStatus";
            this.dataGridViewTextBoxColumn1.MinimumWidth = 8;
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dataGridViewTextBoxColumn2.DataPropertyName = "ChangesStatus";
            this.dataGridViewTextBoxColumn2.HeaderText = "Changes";
            this.dataGridViewTextBoxColumn2.MinimumWidth = 8;
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.ReadOnly = true;
            // 
            // ofdAttachment
            // 
            this.ofdAttachment.Filter = "All files|*.*";
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dataGridViewTextBoxColumn3.DataPropertyName = "ChangesStatus";
            this.dataGridViewTextBoxColumn3.HeaderText = "Changes";
            this.dataGridViewTextBoxColumn3.MinimumWidth = 8;
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.ReadOnly = true;
            // 
            // bnRefreshFolder
            // 
            this.bnRefreshFolder.Location = new System.Drawing.Point(1329, 42);
            this.bnRefreshFolder.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.bnRefreshFolder.Name = "bnRefreshFolder";
            this.bnRefreshFolder.Size = new System.Drawing.Size(112, 35);
            this.bnRefreshFolder.TabIndex = 5;
            this.bnRefreshFolder.Text = "Refresh";
            this.bnRefreshFolder.UseVisualStyleBackColor = true;
            this.bnRefreshFolder.Click += new System.EventHandler(this.bnRefreshFolder_Click);
            // 
            // fileItemBindingSource
            // 
            this.fileItemBindingSource.DataSource = typeof(FileSorter.Classes.FileItem);
            // 
            // filesContextBindingSource
            // 
            this.filesContextBindingSource.DataSource = typeof(FileSorter.Classes.FilesContext);
            // 
            // checkedDataGridViewCheckBoxColumn
            // 
            this.checkedDataGridViewCheckBoxColumn.DataPropertyName = "Checked";
            this.checkedDataGridViewCheckBoxColumn.HeaderText = "";
            this.checkedDataGridViewCheckBoxColumn.MinimumWidth = 8;
            this.checkedDataGridViewCheckBoxColumn.Name = "checkedDataGridViewCheckBoxColumn";
            this.checkedDataGridViewCheckBoxColumn.Width = 50;
            // 
            // fileNameDataGridViewTextBoxColumn
            // 
            this.fileNameDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.fileNameDataGridViewTextBoxColumn.DataPropertyName = "FileName";
            this.fileNameDataGridViewTextBoxColumn.HeaderText = "FileName";
            this.fileNameDataGridViewTextBoxColumn.MinimumWidth = 8;
            this.fileNameDataGridViewTextBoxColumn.Name = "fileNameDataGridViewTextBoxColumn";
            this.fileNameDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // extensionDataGridViewTextBoxColumn
            // 
            this.extensionDataGridViewTextBoxColumn.DataPropertyName = "Extension";
            this.extensionDataGridViewTextBoxColumn.HeaderText = "Extension";
            this.extensionDataGridViewTextBoxColumn.MinimumWidth = 8;
            this.extensionDataGridViewTextBoxColumn.Name = "extensionDataGridViewTextBoxColumn";
            this.extensionDataGridViewTextBoxColumn.ReadOnly = true;
            this.extensionDataGridViewTextBoxColumn.Width = 60;
            // 
            // ParentDir
            // 
            this.ParentDir.DataPropertyName = "ParentDir";
            this.ParentDir.HeaderText = "ParentDir";
            this.ParentDir.MinimumWidth = 8;
            this.ParentDir.Name = "ParentDir";
            this.ParentDir.ReadOnly = true;
            this.ParentDir.Width = 150;
            // 
            // Changes
            // 
            this.Changes.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Changes.DataPropertyName = "Changes";
            this.Changes.HeaderText = "Changes";
            this.Changes.MinimumWidth = 8;
            this.Changes.Name = "Changes";
            this.Changes.ReadOnly = true;
            // 
            // fullNameDataGridViewTextBoxColumn
            // 
            this.fullNameDataGridViewTextBoxColumn.DataPropertyName = "FullName";
            this.fullNameDataGridViewTextBoxColumn.HeaderText = "FullName";
            this.fullNameDataGridViewTextBoxColumn.MinimumWidth = 8;
            this.fullNameDataGridViewTextBoxColumn.Name = "fullNameDataGridViewTextBoxColumn";
            this.fullNameDataGridViewTextBoxColumn.Visible = false;
            this.fullNameDataGridViewTextBoxColumn.Width = 150;
            // 
            // FMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1772, 800);
            this.Controls.Add(this.bnRefreshFolder);
            this.Controls.Add(this.lRootFolder);
            this.Controls.Add(this.tbRootFolder);
            this.Controls.Add(this.bnBrowseRootFolder);
            this.Controls.Add(this.dgvFiles);
            this.Controls.Add(this.msMainMenu);
            this.MainMenuStrip = this.msMainMenu;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(1474, 828);
            this.Name = "FMain";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "File Sorter";
            this.msMainMenu.ResumeLayout(false);
            this.msMainMenu.PerformLayout();
            this.cmsFileListMenu.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvFiles)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fileItemBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.filesContextBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip msMainMenu;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem optionsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tsmiOptions;
        private System.Windows.Forms.ContextMenuStrip cmsFileListMenu;
        private System.Windows.Forms.ToolStripMenuItem tsmiAddAttachment;
        private System.Windows.Forms.ToolStripMenuItem tsmiMoveTo;
        private System.Windows.Forms.DataGridView dgvFiles;
        private System.Windows.Forms.BindingSource fileItemBindingSource;
        private System.Windows.Forms.BindingSource filesContextBindingSource;
        private System.Windows.Forms.Button bnBrowseRootFolder;
        private System.Windows.Forms.TextBox tbRootFolder;
        private System.Windows.Forms.Label lRootFolder;
        private System.Windows.Forms.FolderBrowserDialog fbdBroseRootFolder;
        private System.Windows.Forms.ToolStripMenuItem tsmiOpen;
        private System.Windows.Forms.ToolStripMenuItem tsmiRename;
        private System.Windows.Forms.ToolStripMenuItem tsmiCreateGroup;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.ToolStripSeparator tsmiSplit1;
        private System.Windows.Forms.ToolStripSeparator tsmiSplit2;
        private System.Windows.Forms.ToolStripMenuItem tsmiCheckAll;
        private System.Windows.Forms.ToolStripMenuItem tsmiUncheckAll;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.OpenFileDialog ofdAttachment;
        private System.Windows.Forms.ToolStripMenuItem tsmiProcess;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.ToolStripMenuItem tsmiClearChanges;
        private System.Windows.Forms.Button bnRefreshFolder;
        private System.Windows.Forms.ToolStripMenuItem deleteToolStripMenuItem;
        private System.Windows.Forms.DataGridViewCheckBoxColumn checkedDataGridViewCheckBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn fileNameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn extensionDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn ParentDir;
        private System.Windows.Forms.DataGridViewTextBoxColumn Changes;
        private System.Windows.Forms.DataGridViewTextBoxColumn fullNameDataGridViewTextBoxColumn;
    }
}

