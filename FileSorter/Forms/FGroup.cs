using FileSorter.Classes;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace FileSorter.Forms
{
    public partial class FGroup : FBase
    {
        List<IFileItem> _fileItems;

        public FGroup()
        {
            InitializeComponent();
        }

        internal void SetData(List<IFileItem> fileItems)
        {
            _fileItems = fileItems;
        }

        private void bnOK_Click(object sender, EventArgs e)
        {
            var groupName = tbGroupName.Text;
            if (string.IsNullOrEmpty(groupName))
                return;

            foreach (var item in _fileItems)
                item.ChangesStatus.Add(new ChangesStatus()
                {
                    Change = Change.Grouped,
                    Name = groupName,
                    Value = groupName,
                });

            DialogResult = DialogResult.OK;
        }
    }
}
