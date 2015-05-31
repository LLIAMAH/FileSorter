using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileSorter.Forms
{
    interface IFormSetContext : IFormSimple
    {
        void SetContext(string contextFileName);
    }
}
