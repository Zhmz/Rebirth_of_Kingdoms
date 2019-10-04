using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ROKConfig.ROKCsv
{
    public class MallCommodityCsvConfigData : BaseCsvConfigData
    {
        ulong m_CommodityId;

        public ulong CommodityId
        {
            get { return m_CommodityId; }
            set { m_CommodityId = value; }
        }
        string m_CommodityName;

        public string CommodityName
        {
            get { return m_CommodityName; }
            set { m_CommodityName = value; }
        }
        int m_MallType;

        public int MallType
        {
            get { return m_MallType; }
            set { m_MallType = value; }
        }
        ulong m_ItemId;

        public ulong ItemId
        {
            get { return m_ItemId; }
            set { m_ItemId = value; }
        }
        int m_ItemCount;

        public int ItemCount
        {
            get { return m_ItemCount; }
            set { m_ItemCount = value; }
        }
        int m_CurrencyType;

        public int CurrencyType
        {
            get { return m_CurrencyType; }
            set { m_CurrencyType = value; }
        }
        int m_Price;

        public int Price
        {
            get { return m_Price; }
            set { m_Price = value; }
        }
        int m_LimitBuyType;

        public int LimitBuyType
        {
            get { return m_LimitBuyType; }
            set { m_LimitBuyType = value; }
        }
        int m_LimitBuyTimes;

        public int LimitBuyTimes
        {
            get { return m_LimitBuyTimes; }
            set { m_LimitBuyTimes = value; }
        }
        int m_LimitMinLevel;

        public int LimitMinLevel
        {
            get { return m_LimitMinLevel; }
            set { m_LimitMinLevel = value; }
        }
        int m_LimitMaxLevel;

        public int LimitMaxLevel
        {
            get { return m_LimitMaxLevel; }
            set { m_LimitMaxLevel = value; }
        }
        int m_LimitVIP;

        public int LimitVIP
        {
            get { return m_LimitVIP; }
            set { m_LimitVIP = value; }
        }

        public override ECsvTag CsvTag
        {
            get { return ECsvTag.MallCommodity; }
        }

        const string FIELD_COMMODITYID = "CommodityId";
        const string FIELD_COMMODITYNAME = "CommodityName";
        const string FIELD_MALLTYPE = "MallType";
        const string FIELD_ITEMID = "ItemId";
        const string FIELD_ITEMCOUNT = "ItemCount";
        const string FIELD_CURRENCYTYPE = "CurrencyType";
        const string FIELD_PRICE = "Price";
        const string FIELD_LIMITBUYTYPE = "LimitBuyType";
        const string FIELD_LIMITBUYTIMES = "LimitBuyTimes";
        const string FIELD_LIMITMINLEVEL = "LimitMinLevel";
        const string FIELD_LIMITMAXLEVEL = "LimitMaxLevel";
        const string FIELD_LIMITVIP = "LimitVIP";

        public override void ParseConfigData(long rowIndex, int fieldCount, string[] headers, string[] values)
        {
            m_CommodityId = ReadUlong(FIELD_COMMODITYID ,headers, values, 0);
            m_CommodityName = ReadString(FIELD_COMMODITYNAME, headers, values);
            m_MallType = ReadInt32(FIELD_MALLTYPE, headers, values, 0);
            m_ItemId = ReadUlong(FIELD_ITEMID, headers, values, 0);
            m_ItemCount = ReadInt32(FIELD_ITEMCOUNT, headers, values, 0);
            m_CurrencyType = ReadInt32(FIELD_CURRENCYTYPE, headers, values, 0);
            m_Price = ReadInt32(FIELD_PRICE, headers, values, 0);
            m_LimitBuyType = ReadInt32(FIELD_LIMITBUYTYPE, headers, values, 0);
            m_LimitBuyTimes = ReadInt32(FIELD_LIMITBUYTIMES, headers, values, 0);
            m_LimitMinLevel = ReadInt32(FIELD_LIMITMINLEVEL, headers, values, 0);
            m_LimitMaxLevel = ReadInt32(FIELD_LIMITMAXLEVEL, headers, values, 0);
            m_LimitVIP = ReadInt32(FIELD_LIMITVIP, headers, values, 0);
        }

        public override string GetPrimaryKey()
        {
            return m_CommodityId.ToString();
        }
    }
}
