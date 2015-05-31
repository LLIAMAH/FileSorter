using FileSorter.Classes;
using FileSorter.Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
            LoadOptions();
        }

        private void LoadOptions()
        {
            ReloadOptions();
        }

        private void moveTo_Click(object sender, EventArgs e)
        {
            ToolStripMenuItem clickedItem = (ToolStripMenuItem)sender;
            if (clickedItem == null)
                return;

            var path = clickedItem.Tag as String;
            if (String.IsNullOrEmpty(path))
                return;

            var selected = dgvFiles.SelectedRows[0].DataBoundItem as FileItem;
            if (selected != null)
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
            if (CheckContextLost())
                return;

            using (IFormSetContext form = new Forms.FOptions())
            {
                form.SetContext(cbContext.SelectedItem as String);
                if (form.ShowDialog() == DialogResult.OK)
                {
                    ClearMenuItems();
                    ReloadOptions();
                    RefreshDataGridView();
                }
            }
        }

        private void RefreshDataGridView()
        {
            dgvFiles.DataSource = Classes.FilesContext.RefreshFiles(_filter, tbRootFolder.Text);
        }

        private void ClearMenuItems()
        {
            tsmiMoveTo.DropDownItems.Clear();
        }

        private void ReloadOptions()
        {
            OptionsManager.LoadConfigs();

            if (OptionsManager.ConfigFiles.Count == 0)
                return;

            foreach (var item in OptionsManager.ConfigFiles.OrderBy(o => o.Name))
                cbContext.Items.Add(item.Name);

            cbContext.SelectedIndex = 0;
            var contextFileName = cbContext.SelectedItem as String;

            var filter = OptionsManager.ReadFilter(contextFileName);
            _filter = filter.Key.Equals(OptionsManager.Constant, StringComparison.OrdinalIgnoreCase) ? "" : filter.Key;
            _splitter = filter.Value;

            var folder = OptionsManager.ReadFolders(contextFileName);
            foreach (var item in folder.OrderBy(o => o.Key))
            {
                var menuItem = new ToolStripMenuItem(item.Key) { Tag = item.Value };
                menuItem.Click += moveTo_Click;
                tsmiMoveTo.DropDownItems.Add(menuItem);
            }
        }

        private void bnBrowseRootFolder_Click(object sender, EventArgs e)
        {
            if (CheckContextLost())
                return;

            if(fbdBroseRootFolder.ShowDialog() == DialogResult.OK)
            {
                tbRootFolder.Text = fbdBroseRootFolder.SelectedPath;

                RefreshDataGridView();
            }
        }

        private void dgvFiles_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left && e.Clicks == 2)
            {
                var dgv = sender as DataGridView;

                if (dgv == null)
                    return;

                if (e.RowIndex < 0 && e.RowIndex > dgv.RowCount - 1)
                    return;

                var row = dgv.SelectedRows[0].DataBoundItem as FileItem;
                if (row == null)
                    return;

                OpenFileInStandardApp(row.FullName);
            }
        }

        private void OpenFileInStandardApp(string fullFileName)
        {
            System.Diagnostics.Process process = new System.Diagnostics.Process();
            process.StartInfo.FileName = fullFileName;
            process.StartInfo.Verb = "Open";
            process.StartInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Normal;
            process.Start();
        }

        private void tsmiOpen_Click(object sender, EventArgs e)
        {
            var row = dgvFiles.SelectedRows[0].DataBoundItem as FileItem;
            if (row == null)
                return;

            OpenFileInStandardApp(row.FullName);
        }

        private void dgvFiles_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                System.Drawing.Point pt = dgvFiles.PointToClient(Cursor.Position);
                DataGridView.HitTestInfo test = dgvFiles.HitTest(pt.X, pt.Y);

                if (test.RowIndex < 0 || test.ColumnIndex < 0)
                    return;

                dgvFiles.Rows[test.RowIndex].Selected = true;

                cmsFileListMenu.Show(dgvFiles, dgvFiles.PointToClient(Cursor.Position));
            }
        }

        private void tsmiRename_Click(object sender, EventArgs e)
        {
            var selected = dgvFiles.SelectedRows[0].DataBoundItem as FileItem;
            if (selected == null)
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
            var selected = dgvFiles.SelectedRows[0].DataBoundItem as FileItem;
            if (selected == null)
                return;

            if(ofdAttachment.ShowDialog() == DialogResult.OK)
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
                if (fileData.Checked)
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

        private void CheckAll(DataGridView dgvFiles)
        {
            foreach (DataGridViewRow row in dgvFiles.Rows)
            {
                var fileData = row.DataBoundItem as IFileItem;
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
            List<IFileItem> files = new List<IFileItem>();
            foreach (DataGridViewRow row in dgvFiles.Rows)
            {
                var fileData = row.DataBoundItem as IFileItem;
                if (fileData != null)
                    files.Add(fileData);
            }

            FileManager.Process(files);

            RefreshDataGridView();
        }

        private void tsmiClearChanges_Click(object sender, EventArgs e)
        {
            var selected = dgvFiles.SelectedRows[0].DataBoundItem as FileItem;
            if (selected == null)
                return;

            selected.ChangesStatus.Clear();
            dgvFiles.Refresh();
        }

        private void bnRefreshFolder_Click(object sender, EventArgs e)
        {
            if (CheckContextLost())
                return;

            RefreshDataGridView();
        }

        private void dgvFiles_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            if (this.dgvFiles.CurrentCell.OwningColumn.Index == checkedDataGridViewCheckBoxColumn.Index)
            {
                this.dgvFiles.CommitEdit(DataGridViewDataErrorContexts.Commit);
            }
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var selected = dgvFiles.SelectedRows[0].DataBoundItem as IFileItem;
            if (selected == null)
                return;

            selected.ChangesStatus.Clear();
            selected.ChangesStatus.Add(new ChangesStatus()
            {
                Change = Change.Delete,
                Name = "OK"
            });

            dgvFiles.Refresh();
        }

        private void bnCreateNewContext_Click(object sender, EventArgs e)
        {
            using(IFormSimple form = new FContextNew())
            {
                if(form.ShowDialog() == DialogResult.OK)
                {
                    ReloadOptions();
                }
            }
        }

        private bool CheckContextLost()
        {
            if (cbContext.Items.Count == 0 || cbContext.SelectedIndex < 0)
                return true;

            return false;
        }
    }
}
