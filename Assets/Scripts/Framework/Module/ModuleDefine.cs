using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ROKCore
{
    public enum EModuleType
    {
        None,

        Csv,
        Assets,
        Scene,
        Event,
        UI,

        Role = 11,
        Item,
        Mall,

        Max = 9999,
    }
}
