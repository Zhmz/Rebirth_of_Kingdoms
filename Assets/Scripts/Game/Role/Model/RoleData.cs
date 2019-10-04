using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ROKConfig.ROKCsv;
using ROKGameBase;

namespace ROKGameBase.ROKRole
{
    public enum EMainRoleType
    {
        None,
        Player, //必须有且只能有一个
        Optional, //可选上阵（主要部分）
        Plot, //剧情需要（神仙之类的）
    }
    public enum ERoleCamp
    {
        None,
        Wei,
        Shu,
        Wu,
        Qun,
    }

    public class RoleData
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

        EMainRoleType m_MainType;
        public EMainRoleType MainType
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

        ERoleCamp m_Camp;
        public ERoleCamp Camp
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

        public RoleData() { }
        public RoleData(RoleCsvConfigData csv)
        {
            m_RoleId = csv.RoleId;
            m_RoleName = csv.RoleName;
            m_MainType = (EMainRoleType)csv.MainType;
            m_Quality = (EQuality)csv.Quality;
            m_Camp = (ERoleCamp)csv.Camp;
            m_PhyAtk = csv.PhyAtk;
            m_MagAtk = csv.MagAtk;
            m_PhyDef = csv.PhyDef;
            m_MagDef = csv.MagDef;
            m_Speed = csv.Speed;
            m_Agility = csv.Agility;
            m_LifeValue = csv.LifeValue;
        }
    }
}
