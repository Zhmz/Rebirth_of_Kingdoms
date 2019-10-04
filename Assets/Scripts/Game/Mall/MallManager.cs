using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ROKConfig.ROKCsv;
using ROKTool;
using ROKCore;

namespace ROKGameBase.ROKMall
{
    public class MallManager : BaseModule
    {
        public static MallManager Instance
        {
            get
            {
                return ModuleManager.Instance.GetModule(EModuleType.Mall) as MallManager;
            }
        }

        public override EModuleType ModuleType
        {
            get { return EModuleType.Mall; }
        }

        List<MallCommodityCsvConfigData> m_ConfigList = null;

        public override void Init()
        {
            base.Init();
            m_ConfigList = CsvConfigManager.Instance.GetCsvConfigList<MallCommodityCsvConfigData>();

            List<MallCommodityData> commoList = GetCommodityWithItem(30100001);
            for (int i = 0; i < commoList.Count; i++)
            {
                ROKLogger.PrintLog("commoList[{0}].CommodityName: {1}", i, commoList[i].CommodityName);
            }
        }

        public MallCommodityData GetMallCommodityData(ulong commodityId)
        {
            if (m_ConfigList != null)
            {
                MallCommodityCsvConfigData config = m_ConfigList.Find(x => x.CommodityId == commodityId);
                if (config != null)
                {
                    return new MallCommodityData(config);
                }
            }
            return null;
        }

        public List<MallCommodityData> GetCommodityWithItem(ulong itemId)
        {
            List<MallCommodityData> result = new List<MallCommodityData>();
            if (m_ConfigList != null)
            {
                List<MallCommodityCsvConfigData> config = m_ConfigList.FindAll(x => x.ItemId == itemId);
                for (int i = 0; i < config.Count; i++)
                {
                    result.Add(new MallCommodityData(config[i]));
                }
            }
            return result;
        }
    }
}
