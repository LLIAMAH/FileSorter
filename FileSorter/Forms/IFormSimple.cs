using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FileSorter.Forms
{
    public interface IFormSimple : IDisposable
    {
        DialogResult ShowDialog();
    }
}
