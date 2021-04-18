using System;
using System.Windows.Forms;

namespace FileSorter.Forms
{
    public interface IFormSimple : IDisposable
    {
        DialogResult ShowDialog();
    }
}
