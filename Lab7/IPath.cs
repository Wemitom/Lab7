using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab7
{
    interface IPath
    {
        void AddAStop(String stop);

        void RemoveAStop(String stop);
    }
}
