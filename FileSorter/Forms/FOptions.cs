using FileSorter.Classes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FileSorter.Forms
{
    public partial class FOptions : FBase, IFormSimple
    {
        private string _contextFileName = "";

        public FOptions()
        {
            InitializeComponent();
        }

        private void UpdateOptions(string filterText, string splitterText, DataGridViewRowCollection dataGridViewRowCollection)
        {
            Dictionary<string, string> folders = new Dictionary<string, string>();
            foreach (DataGridViewRow row in dgvFolders.Rows)
            {
                try
                {
                    var key = row.Cells[0].Value as string;
                    var value = row.Cells[1].Value as string;

                    folders.Add(key, value);
                }
                catch { }
            }

            OptionsManager.WriteData(this._contextFileName, filterText, splitterText, folders);
        }

        private void FOptions_Load(object sender, EventArgs e)
        {
            var filter = OptionsManager.ReadFilter(this._contextFileName);
            tbFilter.Text = filter.Key;
            tbSplitter.Text = string.Empty + filter.Value; // to avoid char to string convertation

            var folders = OptionsManager.ReadFolders(this._contextFileName);
            if (folders != null && folders.Count() > 0)
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

        public void SetContext(string fileName)
        {
            this._contextFileName = fileName;
            this.Text = string.Format("Options: {0}", this._contextFileName);
        }
    }
}
