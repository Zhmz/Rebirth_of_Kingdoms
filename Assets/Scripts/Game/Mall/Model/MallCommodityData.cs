using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ROKConfig.ROKCsv;

namespace ROKGameBase.ROKMall
{
    public enum EMallType
    {
        None,

        RegularMall,//银币，元宝
        MaterialMall, //材料，对应GeneralItem里的Exchange
    }

    public enum ECurrencyType
    {
        None,

        Coin,    //银币
        YuanBao, //元宝
    }

    public enum ELimitBuyType
    {
        None,

        UnLimited,

        TimesPerDay,//每日限购
        TimesPerWeek,//每周限购
        TimesPerAccount,//账号限购（账号生命周期内只能买#次）

    }

    public class MallCommodityData
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
        EMallType m_MallType;

        public EMallType MallType
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
        ECurrencyType m_CurrencyType;

        public ECurrencyType CurrencyType
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
        ELimitBuyType m_LimitBuyType;

        public ELimitBuyType LimitBuyType
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


        public MallCommodityData() { }
        public MallCommodityData(MallCommodityCsvConfigData csv)
        {
            m_CommodityId = csv.CommodityId;
            m_CommodityName = csv.CommodityName;
            m_MallType = (EMallType)csv.MallType;
            m_ItemId = csv.ItemId;
            m_ItemCount = csv.ItemCount;
            m_CurrencyType = (ECurrencyType)csv.CurrencyType;
            m_Price = csv.Price;
            m_LimitBuyType = (ELimitBuyType)csv.LimitBuyType;
            m_LimitBuyTimes = csv.LimitBuyTimes;
            m_LimitMinLevel = csv.LimitMinLevel;
            m_LimitMaxLevel = csv.LimitMaxLevel;
            m_LimitVIP = csv.LimitVIP;
        }
    }
}
