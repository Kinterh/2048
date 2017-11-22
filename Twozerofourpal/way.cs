using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Twozerofourpal
{
    [Flags]
    public enum Way
    {
        left = 1, right = 2, up = 4, down = 8, check = 16, nothing = 32
    }
}