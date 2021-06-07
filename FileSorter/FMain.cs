using FileSorter.Classes;
using FileSorter.Forms;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace FileSorter
{
    public partial class FMain : Form
    {
        private string _filter = "";
        private char _splitter = ' ';

        public FMain()
        {
            InitializeComponent();
            ReloadOptions();
        }

        private void moveTo_Click(object sender, EventArgs e)
        {
            ToolStripMenuItem clickedItem = (ToolStripMenuItem) sender;
            if (clickedItem == null)
                return;

            var path = clickedItem.Tag as string;
            if (string.IsNullOrEmpty(path))
                return;

            if (dgvFiles.SelectedRows[0].DataBoundItem is FileItem selected)
            {
                selected.ChangesStatus.Add(new ChangesStatus()
                {
                    Change = Change.Move,
                    Name = clickedItem.Text,
                    Value = path,
                });

                dgvFiles.Refresh();
            }
        }

        private void tsmiOptions_Click(object sender, EventArgs e)
        {
            using (IFormSimple form = new FOptions())
            {
                if (form.ShowDialog() == DialogResult.OK)
                {
                    ClearMenuItems();
                    ReloadOptions();
                }
            }
        }

        private void ClearMenuItems()
        {
            tsmiMoveTo.DropDownItems.Clear();
        }

        private void ReloadOptions()
        {
            var filter = OptionsManager.ReadFilter();
            _filter = filter.Key.Equals(OptionsManager.Constant, StringComparison.OrdinalIgnoreCase) ? "" : filter.Key;
            _splitter = filter.Value;

            var folders = OptionsManager.ReadFolders();
            CreateContextMenu(folders);
        }

        private void CreateContextMenu(Dictionary<string, string> folders)
        {
            foreach (var item in folders.OrderBy(o => o.Key))
            {
                var dir = new DirectoryInfo(item.Value);
                var subDirs = dir.GetDirectories();
                var list = new List<ToolStripItem>();
                var menuItem = new ToolStripMenuItem(item.Key) { Tag = item.Value };
                if (subDirs.Any())
                {
                    list.Add(CreateMoveToItem("<root>", item.Value));
                    list.Add(new ToolStripSeparator());
                    list.AddRange(subDirs.Select(directoryInfo => CreateMoveToItem(directoryInfo.Name, directoryInfo.FullName)));
                    menuItem.DropDownItems.AddRange(list.ToArray());
                }
                else
                {
                    menuItem.Click += moveTo_Click;
                }

                tsmiMoveTo.DropDownItems.Add(menuItem);
            }
        }

        private ToolStripItem CreateMoveToItem(string text, string path)
        {
            var mi = new ToolStripMenuItem(text) {Tag = path};
            mi.Click += moveTo_Click;
            return mi;
        }

        private void bnBrowseRootFolder_Click(object sender, EventArgs e)
        {
            if(fbdBroseRootFolder.ShowDialog() == DialogResult.OK)
            {
                tbRootFolder.Text = fbdBroseRootFolder.SelectedPath;
                var files = FileMgr.GetFiles(tbRootFolder.Text);

                tvFiles.Nodes.AddRange(files.CreateNodes());
            }
        }

        private List<TreeNode> GetData(string filePath)
        {
            var result = new List<TreeNode>();
            var dir = new DirectoryInfo(filePath);
            foreach (var directoryInfo in dir.GetDirectories())
            {
                foreach (var VARIABLE in COLLECTION)
                {
                    
                }
            }

        }

        private void dgvFiles_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left && e.Clicks == 2)
            {
                if (!(sender is DataGridView dgv))
                    return;

                if (e.RowIndex < 0 && e.RowIndex > dgv.RowCount - 1)
                    return;

                if (!(dgv.SelectedRows[0].DataBoundItem is FileItem row))
                    return;

                OpenFileInStandardApp(row.FullName);
            }
        }

        private static void OpenFileInStandardApp(string fullFileName)
        {
            var process = new Process
            {
                StartInfo =
                {
                    FileName = fullFileName,
                    Verb = "Open",
                    WindowStyle = ProcessWindowStyle.Normal
                }
            };
            process.Start();
        }

        private void tsmiOpen_Click(object sender, EventArgs e)
        {
            if (!(dgvFiles.SelectedRows[0].DataBoundItem is FileItem row))
                return;

            OpenFileInStandardApp(row.FullName);
        }

        private void dgvFiles_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                var pt = dgvFiles.PointToClient(Cursor.Position);
                var test = dgvFiles.HitTest(pt.X, pt.Y);

                if (test.RowIndex < 0 || test.ColumnIndex < 0)
                    return;

                dgvFiles.Rows[test.RowIndex].Selected = true;
                cmsFileListMenu.Show(dgvFiles, dgvFiles.PointToClient(Cursor.Position));
            }
        }

        private void tsmiRename_Click(object sender, EventArgs e)
        {
            if (!(dgvFiles.SelectedRows[0].DataBoundItem is FileItem selected))
                return;

            using(var dlg = new FRename())
            {
                dlg.SetData(selected);
                if (dlg.ShowDialog() == DialogResult.OK)
                    dgvFiles.Refresh();
            }
        }

        private void tsmiAddAttachment_Click(object sender, EventArgs e)
        {
            if (!(dgvFiles.SelectedRows[0].DataBoundItem is FileItem selected))
                return;

            if (ofdAttachment.ShowDialog() == DialogResult.OK)
            {
                IFileAttachment value = new FileItem(ofdAttachment.FileName);
                selected.ChangesStatus.Add(new ChangesStatus()
                {
                    Change = Change.AttachmentAdded,
                    Name = value.FileName,
                    Value = value,
                });

                dgvFiles.Refresh();
            }
        }

        private void tsmiCreateGroup_Click(object sender, EventArgs e)
        {
            List<IFileItem> fileItems = new List<IFileItem>();

            foreach (DataGridViewRow row in dgvFiles.Rows)
            {
                var fileData = row.DataBoundItem as IFileItem;                
                if (fileData != null && fileData.Checked)
                    fileItems.Add(fileData);
            }

            var dlg = new FGroup();
            dlg.SetData(fileItems);
            if (dlg.ShowDialog() == DialogResult.OK)
                UncheckAll(dgvFiles);
        }

        private void tsmiCheckAll_Click(object sender, EventArgs e)
        {
            CheckAll(dgvFiles);
        }

        private static void CheckAll(DataGridView dgvFiles)
        {
            foreach (DataGridViewRow row in dgvFiles.Rows)
            {
                if (row.DataBoundItem is IFileItem fileData)
                    fileData.Checked = true;
            }

            dgvFiles.Refresh();
        }

        private void tsmiUncheckAll_Click(object sender, EventArgs e)
        {
            UncheckAll(dgvFiles);
        }

        private void UncheckAll(DataGridView dgvFiles)
        {
            foreach (DataGridViewRow row in dgvFiles.Rows)
                row.Cells[checkedDataGridViewCheckBoxColumn.Index].Value = false;
        }

        private void tsmiProcess_Click(object sender, EventArgs e)
        {
            var files = new List<IFileItem>();
            foreach (DataGridViewRow row in dgvFiles.Rows)
            {
                if (row.DataBoundItem is IFileItem fileData)
                    files.Add(fileData);
            }

            FileManager.Process(files);
        }

        private void tsmiClearChanges_Click(object sender, EventArgs e)
        {
            if (!(dgvFiles.SelectedRows[0].DataBoundItem is FileItem selected))
                return;

            selected.ChangesStatus.Clear();
            dgvFiles.Refresh();
        }

        private void bnRefreshFolder_Click(object sender, EventArgs e)
        {
        }

        private void dgvFiles_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            if (this.dgvFiles.CurrentCell.OwningColumn.Index == checkedDataGridViewCheckBoxColumn.Index)
                this.dgvFiles.CommitEdit(DataGridViewDataErrorContexts.Commit);
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!(dgvFiles.SelectedRows[0].DataBoundItem is IFileItem selected))
                return;

            selected.ChangesStatus.Clear();
            selected.ChangesStatus.Add(new ChangesStatus()
            {
                Change = Change.Delete,
                Name = "OK"
            });

            dgvFiles.Refresh();
        }

        private void tsmiOpenFolder_Click(object sender, EventArgs e)
        {
            if (!(dgvFiles.SelectedRows[0].DataBoundItem is FileItem row))
                return;
            
            Process.Start(new DirectoryInfo(row.FullName)?.Parent?.FullName);
        }
    }
}
