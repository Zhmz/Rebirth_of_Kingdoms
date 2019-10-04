using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ROKConfig.ROKCsv
{
    public class GeneralItemCsvConfigData : BaseCsvConfigData
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

        int m_MainType;
        public int MainType
        {
            get { return m_MainType; }
            set { m_MainType = value; }
        }

        int m_GeneralType;
        public int GeneralType
        {
            get { return m_GeneralType; }
            set { m_GeneralType = value; }
        }


        int m_Quality;
        public int Quality
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

        string m_SellInMallType;
        public string SellInMallType
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
        #endregion

        public override ECsvTag CsvTag
        {
            get { return ECsvTag.GeneralItem; }
        }

        const string FIELD_ID = "Id";
        const string FIELD_NAME = "Name";
        const string FIELD_MAINTYPE = "MainType";
        const string FIELD_QUALITY = "Quality";
        const string FIELD_GENERALTYPE = "GeneralType";
        const string FIELD_ISTRADABLE = "IsTradable";
        const string FIELD_SELLINMALLTYPE = "SellInMallType";
        const string FIELD_ISRECYCLABLE = "IsRecyclable";
        const string FIELD_RECYCCOIN = "RecycCoin";
        const string FIELD_RECYCYUANBAO = "RecycYuanBao";
        const string FIELD_ISDECOMPOSABLE = "IsDecomposable";
        const string FIELD_ISCOMPOSABLE = "IsComposable";


        public override void ParseConfigData(long rowIndex, int fieldCount, string[] headers, string[] values)
        {
            m_ItemId = ReadUlong(FIELD_ID, headers, values, 0);
            m_ItemName = ReadString(FIELD_NAME, headers, values);
            m_MainType = ReadInt32(FIELD_MAINTYPE, headers, values, 0);
            m_Quality = ReadInt32(FIELD_QUALITY, headers, values, 0);
            m_GeneralType = ReadInt32(FIELD_GENERALTYPE, headers, values, 0);
            m_IsTradable = ReadInt32(FIELD_ISTRADABLE, headers, values, 0) == 1;
            m_SellInMallType = ReadString(FIELD_SELLINMALLTYPE, headers, values);
            m_IsRecyclable = ReadInt32(FIELD_ISRECYCLABLE, headers, values, 0) == 1;
            m_RecycCoinCount = ReadInt32(FIELD_RECYCCOIN, headers, values, 0);
            m_RecycYuanBaoCount = ReadInt32(FIELD_RECYCYUANBAO, headers, values, 0);
            m_IsDecomposable = ReadInt32(FIELD_ISDECOMPOSABLE, headers, values, 0) == 1;
            m_IsComposable = ReadInt32(FIELD_ISCOMPOSABLE, headers, values, 0) == 1;
        }

        public override string GetPrimaryKey()
        {
            throw new NotImplementedException();
        }
    }
}
