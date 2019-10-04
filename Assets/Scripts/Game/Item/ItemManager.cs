using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ROKConfig.ROKCsv;
using ROKTool;
using ROKCore;

namespace ROKGameBase.ROKItem
{
    public class ItemManager : BaseModule
    {
        List<EquipmentItemCsvConfigData> m_EquipConfigList;
        List<GeneralItemCsvConfigData> m_GeneralConfigList;

        public static ItemManager Instance
        {
            get
            {
                return ModuleManager.Instance.GetModule(EModuleType.Item) as ItemManager;
            }
        }

        public override EModuleType ModuleType
        {
            get { return EModuleType.Item; }
        }

        public override void Init()
        {
            base.Init();

            m_EquipConfigList = CsvConfigManager.Instance.GetCsvConfigList<EquipmentItemCsvConfigData>();
            m_GeneralConfigList = CsvConfigManager.Instance.GetCsvConfigList<GeneralItemCsvConfigData>();

            ROKLogger.PrintLog(GetItemData(30100003).ItemName);
            ROKLogger.PrintLog(GetItemData(20100002).ItemName);
        }

        public ItemData GetItemData(ulong itemId)
        {
            ItemData result = null;

            EMainItemType type = GetItemMainType(itemId);
            if (type == EMainItemType.EquipmentItem)
            {
                EquipmentItemCsvConfigData csv = m_EquipConfigList.Find(x => x.ItemId == itemId);
                result = new EquipmentItemData(csv);
            }
            else if (type == EMainItemType.GeneralItem)
            {
                GeneralItemCsvConfigData csv = m_GeneralConfigList.Find(x => x.ItemId == itemId);
                result = new GeneralItemData(csv);
            }
            else
            {
                ROKLogger.PrintError("Item Main Type is {0}, Error.", (int)type);
            }
            return result;
        }

        public EMainItemType GetItemMainType(ulong itemId)
        {
            ulong type = itemId / 10000000;//2:Equip,3:General
            return (EMainItemType)type;
        }
    }
}
