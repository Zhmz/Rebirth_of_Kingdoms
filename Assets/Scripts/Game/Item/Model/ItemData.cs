using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ROKGameBase;
using ROKGameBase.ROKMall;
using ROKConfig.ROKCsv;

namespace ROKGameBase.ROKItem
{
    /// <summary>
    /// 表里配置多个参数在一个格子时，使用“#”分割
    /// </summary>

    public enum EMainItemType
    {
        None,
        EquipmentItem = 2,//20000001~20909999
        GeneralItem = 3,//30000001~30909999
    }

    //用来配置合成和分解的信息
    public class ComposeInfo
    {
        public List<ulong> ComposeItemIdList;
        public List<int> ComposeItemCountList;
        public List<int> ConsumeCurrencyType;
        public List<int> ConsumeCurrencyCount;
    }

    public class ItemData
    {
        ulong m_ItemId;
        public ulong ItemId
        {
            get { return m_ItemId; }
            set { m_ItemId = value; }
        }

        string m_ItemName;
        public string ItemName
        {
            get { return m_ItemName; }
            set { m_ItemName = value; }
        }

        EMainItemType m_MainType;
        public EMainItemType MainType
        {
            get { return m_MainType; }
            set { m_MainType = value; }
        }

        EQuality m_Quality;
        public EQuality Quality
        {
            get { return m_Quality; }
            set { m_Quality = value; }
        }

        #region 是否可买
        bool m_IsTradable;
        public bool IsTradable
        {
            get { return m_IsTradable; }
            set { m_IsTradable = value; }
        }

        List<EMallType> m_SellInMallType;
        public List<EMallType> SellInMallType
        {
            get { return m_SellInMallType; }
            set { m_SellInMallType = value; }
        }
        #endregion

        #region 是否可被系统回收
        bool m_IsRecyclable;
        public bool IsRecyclable
        {
            get { return m_IsRecyclable; }
            set { m_IsRecyclable = value; }
        }

        //回收补偿银币
        int m_RecycCoinCount;
        public int RecycCoinCount
        {
            get { return m_RecycCoinCount; }
            set { m_RecycCoinCount = value; }
        }

        //回收补偿元宝
        int m_RecycYuanBaoCount;
        public int RecycYuanBaoCount
        {
            get { return m_RecycYuanBaoCount; }
            set { m_RecycYuanBaoCount = value; }
        }
        #endregion

        #region 分解与合成（互逆）
        //是否可被分解
        bool m_IsDecomposable;
        public bool IsDecomposable
        {
            get { return m_IsDecomposable; }
            set { m_IsDecomposable = value; }
        }

        //是否可被合成
        bool m_IsComposable;
        public bool IsComposable
        {
            get { return m_IsComposable; }
            set { m_IsComposable = value; }
        }

        ComposeInfo m_CompInfo;
        public ComposeInfo CompInfo
        {
            get { return m_CompInfo; }
            set { m_CompInfo = value; }
        }
        #endregion


        ////是否可出售给其他玩家（后面在考虑，比较复杂）
        //bool m_IsSaleable;
        //public bool IsSaleable
        //{
        //    get { return m_IsSaleable; }
        //    set { m_IsSaleable = value; }
        //}

        public ItemData() { }
        public ItemData(GeneralItemCsvConfigData csv)
        {
            m_ItemId = csv.ItemId;
            m_ItemName = csv.ItemName;
            m_MainType = (EMainItemType)csv.MainType;
            m_Quality = (EQuality)csv.Quality;
            m_IsTradable = csv.IsTradable;

            m_SellInMallType = new List<EMallType>();
            if (!string.IsNullOrEmpty(csv.SellInMallType))
            {
                string[] mallTypeStr = csv.SellInMallType.Split('#');
                for (int i = 0; i < mallTypeStr.Length; i++)
                {
                    int mallType;
                    if (int.TryParse(mallTypeStr[i], out mallType))
                    {
                        m_SellInMallType.Add((EMallType)mallType);
                    }
                    else
                    {
                        ROKTool.ROKLogger.PrintError("Transfer String To Enum Failed.");
                    }
                }
            }

            m_IsRecyclable = csv.IsRecyclable;
            m_RecycCoinCount = csv.RecycCoinCount;
            m_RecycYuanBaoCount = csv.RecycYuanBaoCount;
            m_IsDecomposable = csv.IsDecomposable;
            m_IsComposable = csv.IsComposable;
        }

        public ItemData(EquipmentItemCsvConfigData csv)
        {
            m_ItemId = csv.ItemId;
            m_ItemName = csv.ItemName;
            m_MainType = (EMainItemType)csv.MainType;
            m_Quality = (EQuality)csv.Quality;
            m_IsTradable = csv.IsTradable;

            m_SellInMallType = new List<EMallType>();
            if (!string.IsNullOrEmpty(csv.SellInMallType))
            {
                string[] mallTypeStr = csv.SellInMallType.Split('#');
                for (int i = 0; i < mallTypeStr.Length; i++)
                {
                    int mallType;
                    if (int.TryParse(mallTypeStr[i], out mallType))
                    {
                        m_SellInMallType.Add((EMallType)mallType);
                    }
                    else
                    {
                        ROKTool.ROKLogger.PrintError("Transfer String To Enum Failed.");
                    }
                }
            }

            m_IsRecyclable = csv.IsRecyclable;
            m_RecycCoinCount = csv.RecycCoinCount;
            m_RecycYuanBaoCount = csv.RecycYuanBaoCount;
            m_IsDecomposable = csv.IsDecomposable;
            m_IsComposable = csv.IsComposable;
        }
    }
}
