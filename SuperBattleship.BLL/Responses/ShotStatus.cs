using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperBattleship.BLL.Responses
{
    public enum ShotStatus
    {
        Invalid,
        Duplicate,
        Miss,
        Hit,
        HitAndSunk,
        Victory
    }
}
