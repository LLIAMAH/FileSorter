using FileSorter.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace FileSorter.Forms
{
    public partial class FOptions : FBase
    {
        public FOptions()
        {
            InitializeComponent();
        }

        private void UpdateOptions(string filterText, string splitterText, DataGridViewRowCollection dataGridViewRowCollection)
        {
            var folders = new Dictionary<string, string>();
            var listExp = new List<Exception>();
            foreach (DataGridViewRow row in dgvFolders.Rows)
            {
                try
                {
                    var key = row.Cells[0].Value as string;
                    var value = row.Cells[1].Value as string;

                    folders.Add(key ?? throw new InvalidOperationException(), value);
                }
                catch (Exception ex)
                {
                    listExp.Add(ex);
                }
            }

            if (listExp.Any())
            {
                MessageBox.Show($"There is {listExp.Count()} exceptions. Last one: {listExp.Last()}");
                return;
            }

            OptionsManager.WriteData(filterText, splitterText, folders);
        }

        private void FOptions_Load(object sender, EventArgs e)
        {
            var filter = OptionsManager.ReadFilter();
            tbFilter.Text = filter.Key;
            tbSplitter.Text = string.Empty + filter.Value; // to avoid char to string conversion process

            var folders = OptionsManager.ReadFolders();
            if (folders != null && folders.Any())
            {
                var orderedFolders = folders.OrderBy(o => o.Key);
                foreach (var item in orderedFolders)
                    dgvFolders.Rows.Add(item.Key, item.Value);
            }
        }

        private void dgvFolders_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == colBrowse.Index)
                if (fbdBrowse.ShowDialog() == DialogResult.OK)
                    dgvFolders.Rows[e.RowIndex].Cells[colPath.Index].Value = fbdBrowse.SelectedPath;
        }

        private void bnOK_Click(object sender, EventArgs e)
        {
            UpdateOptions(this.tbFilter.Text, this.tbSplitter.Text, this.dgvFolders.Rows);
            DialogResult = DialogResult.OK;
        }
    }
}
