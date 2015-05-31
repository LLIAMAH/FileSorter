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
    public partial class FContextNew : FBase, IFormSimple
    {
        public FContextNew()
        {
            InitializeComponent();
        }

        private void bnOK_Click(object sender, EventArgs e)
        {
            var fileName = tbContextName.Text;
            if (string.IsNullOrEmpty(fileName))
            {
                MessageBox.Show("Wrong context name");
                return;
            }

            var nameWithExtension = string.Format("{0}.xml", fileName);
            OptionsManager.OpenDocument(nameWithExtension);


            DialogResult = DialogResult.OK;
        }
    }
}
