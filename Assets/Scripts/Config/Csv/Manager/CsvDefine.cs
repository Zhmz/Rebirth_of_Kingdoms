using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ROKConfig.ROKCsv
{
    /// <summary>
    /// Role: 10000001~10009999
    /// EquipmentItem: 20000001~20009999
    /// GeneralItem: 30000001~30009999
    /// MallCommodity: 40000001~40009999
    /// 
    /// </summary>

    public enum ECsvTag
    {
        None,
        TestCsv,

        Role,
        
        EquipmentItem,
        GeneralItem,
        Compose,

        MallCommodity,

        ModuleMax = 9999,
        ConfigFiles,
    }
}
