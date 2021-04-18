﻿using FileSorter.Classes;
using System;
using System.Windows.Forms;

namespace FileSorter.Forms
{
    public partial class FRename : FBase
    {
        private FileItem _fileItem;

        public FRename()
        {
            InitializeComponent();
        }

        internal void SetData(FileItem fileItem)
        {
            _fileItem = fileItem;
            tbOldName.Text = _fileItem.FileName;
        }

        private void bnOK_Click(object sender, EventArgs e)
        {
            var nameOld = tbOldName.Text;
            var nameNew = tbNewName.Text;

            if (string.IsNullOrEmpty(nameNew))
                return;

            if (nameOld.Equals(nameNew))
                return;

            _fileItem.ChangesStatus.Add(new ChangesStatus() { Change = Change.Rename, Name = nameNew, Value = nameNew });
            DialogResult = DialogResult.OK;
        }
    }
}
