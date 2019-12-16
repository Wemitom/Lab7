using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab7
{
    interface IBlinkers
    {
        bool BlinkersLeft(int state);
        bool BlinkersRight(int state);
        bool BlinkersOff(int state);
    }
}
