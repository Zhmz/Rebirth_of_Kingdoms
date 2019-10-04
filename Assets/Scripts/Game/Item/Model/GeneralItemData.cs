using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ROKConfig.ROKCsv;

namespace ROKGameBase.ROKItem
{
    public enum EGeneralItemType
    {
        None,
        Consume, //30100001~30109999
        Debris,  //30200001~30209999
        Exchange,//30300001~30309999

        //其他模块的后续添加
    }

    public class GeneralItemData : ItemData
    {
        EGeneralItemType m_GeneralType;
        public EGeneralItemType GeneralType
        {
            get { return m_GeneralType; }
            set { m_GeneralType = value; }
        }


        public GeneralItemData() { }
        public GeneralItemData(GeneralItemCsvConfigData csv)
            : base(csv)
        {
            m_GeneralType = (EGeneralItemType)csv.GeneralType;
        }

    }
}
