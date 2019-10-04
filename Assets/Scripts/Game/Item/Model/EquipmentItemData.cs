using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ROKConfig.ROKCsv;

namespace ROKGameBase.ROKItem
{
    public enum EEquipItemType
    {
        None,
        Weapon = 1,   //20100001~20109999
        Helmet = 2,   //20200001~20209999
        Belt = 3,     //20300001~20309999
        Armor = 4,    //20400001~20409999
        Shoe = 5,     //20500001~20509999
        Accessary = 6,//20600001~20609999
    }

    public class EquipmentItemData : ItemData
    {
        EEquipItemType m_EquipType;
        public EEquipItemType EquipType
        {
            get { return m_EquipType; }
            set { m_EquipType = value; }
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


        public EquipmentItemData() { }
        public EquipmentItemData(EquipmentItemCsvConfigData csv)
            : base(csv)
        {
            m_EquipType = (EEquipItemType)csv.EquipType;
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
