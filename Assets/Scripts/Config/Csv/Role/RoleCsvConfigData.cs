using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ROKConfig.ROKCsv
{
    public class RoleCsvConfigData : BaseCsvConfigData
    {
        ulong m_RoleId;
        public ulong RoleId
        {
            get { return m_RoleId; }
            set { m_RoleId = value; }
        }

        string m_RoleName;
        public string RoleName
        {
            get { return m_RoleName; }
            set { m_RoleName = value; }
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

        int m_Camp;
        public int Camp
        {
            get { return m_Camp; }
            set { m_Camp = value; }
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


        #region Read CSV
        public override ECsvTag CsvTag
        {
            get { return ECsvTag.Role; }
        }

        const string FIELD_ID = "Id";
        const string FIELD_NAME = "Name";
        const string FIELD_MAINTYPE = "MainType";
        const string FIELD_QUALITY = "Quality";
        const string FIELD_CAMP = "Camp";
        const string FIELD_PHYATK = "PhyAtk";
        const string FIELD_MAGATK = "MagAtk";
        const string FIELD_PHYDEF = "PhyDef";
        const string FIELD_MAGDEF = "MagDef";
        const string FIELD_SPEED = "Speed";
        const string FIELD_AGILITY = "Agility";
        const string FIELD_LIFEVALUE = "LifeValue";

        public override void ParseConfigData(long rowIndex, int fieldCount, string[] headers, string[] values)
        {
            m_RoleId = ReadUlong(FIELD_ID, headers, values, 0);
            m_RoleName = ReadString(FIELD_NAME, headers, values);
            m_MainType = ReadInt32(FIELD_MAINTYPE,headers,values,0);
            m_Quality = ReadInt32(FIELD_QUALITY, headers, values, 0);
            m_Camp = ReadInt32(FIELD_CAMP, headers, values, 0);
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
            return m_RoleId.ToString();
        }
        #endregion
    }
}
