using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ROKConfig.ROKCsv
{
    public class EquipmentItemCsvConfigData : BaseCsvConfigData
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

        int m_Quality;
        public int Quality
        {
            get { return m_Quality; }
            set { m_Quality = value; }
        }

        int m_EquipType;
        public int EquipType
        {
            get { return m_EquipType; }
            set { m_EquipType = value; }
        }

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

        float m_PhyAtk;
        public float PhyAtk
        {
            get { return m_PhyAtk; }
            set { m_PhyAtk = value; }
        }

        float m_MagAtk;
        public float MagAtk
        {
            get { return m_MagAtk; }
            set { m_MagAtk = value; }
        }

        float m_PhyDef;
        public float PhyDef
        {
            get { return m_PhyDef; }
            set { m_PhyDef = value; }
        }

        float m_MagDef;
        public float MagDef
        {
            get { return m_MagDef; }
            set { m_MagDef = value; }
        }

        float m_Speed;
        public float Speed
        {
            get { return m_Speed; }
            set { m_Speed = value; }
        }

        float m_Agility;
        public float Agility
        {
            get { return m_Agility; }
            set { m_Agility = value; }
        }

        float m_LifeValue;
        public float LifeValue
        {
            get { return m_LifeValue; }
            set { m_LifeValue = value; }
        }

        public override ECsvTag CsvTag
        {
            get { return ECsvTag.EquipmentItem; }
        }

        const string FIELD_ID = "Id";
        const string FIELD_NAME = "Name";
        const string FIELD_MAINTYPE = "MainType";
        const string FIELD_QUALITY = "Quality";
        const string FIELD_EQUIPTYPE = "EquipType";
        const string FIELD_ISTRADABLE = "IsTradable";
        const string FIELD_SELLINMALLTYPE = "SellInMallType";
        const string FIELD_ISRECYCLABLE = "IsRecyclable";
        const string FIELD_RECYCCOIN = "RecycCoin";
        const string FIELD_RECYCYUANBAO = "RecycYuanBao";
        const string FIELD_ISDECOMPOSABLE = "IsDecomposable";
        const string FIELD_ISCOMPOSABLE = "IsComposable";
        const string FIELD_PHYATK = "PhyAtk";
        const string FIELD_MAGATK = "MagAtk";
        const string FIELD_PHYDEF = "PhyDef";
        const string FIELD_MAGDEF = "MagDef";
        const string FIELD_SPEED = "Speed";
        const string FIELD_AGILITY = "Agility";
        const string FIELD_LIFEVALUE = "LifeValue";

        public override void ParseConfigData(long rowIndex, int fieldCount, string[] headers, string[] values)
        {
            m_ItemId = ReadUlong(FIELD_ID, headers, values, 0);
            m_ItemName = ReadString(FIELD_NAME, headers, values);
            m_MainType = ReadInt32(FIELD_MAINTYPE, headers, values, 0);
            m_Quality = ReadInt32(FIELD_QUALITY, headers, values, 0);
            m_EquipType = ReadInt32(FIELD_EQUIPTYPE, headers, values, 0);
            m_IsTradable = ReadInt32(FIELD_ISTRADABLE, headers, values, 0) == 1;
            m_SellInMallType = ReadString(FIELD_SELLINMALLTYPE, headers, values);
            m_IsRecyclable = ReadInt32(FIELD_ISRECYCLABLE, headers, values, 0) == 1;
            m_RecycCoinCount = ReadInt32(FIELD_RECYCCOIN, headers, values, 0);
            m_RecycYuanBaoCount = ReadInt32(FIELD_RECYCYUANBAO, headers, values, 0);
            m_IsDecomposable = ReadInt32(FIELD_ISDECOMPOSABLE, headers, values, 0) == 1;
            m_IsComposable = ReadInt32(FIELD_ISCOMPOSABLE, headers, values, 0) == 1;
            m_PhyAtk = ReadFloat(FIELD_PHYATK, headers, values, 0f);
            m_MagAtk = ReadFloat(FIELD_MAGATK, headers, values, 0f);
            m_PhyDef = ReadFloat(FIELD_PHYDEF, headers, values, 0f);
            m_MagDef = ReadFloat(FIELD_MAGDEF, headers, values, 0f);
            m_Speed = ReadFloat(FIELD_SPEED, headers, values, 0f);
            m_Agility = ReadFloat(FIELD_AGILITY, headers, values, 0f);
            m_LifeValue = ReadFloat(FIELD_LIFEVALUE, headers, values, 0f);
        }

        public override string GetPrimaryKey()
        {
            throw new NotImplementedException();
        }
    }
}
