using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ROKConfig.ROKCsv
{
    public class ComposeCsvConfigData : BaseCsvConfigData
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

        string m_CompItemId;
        public string CompItemId
        {
            get { return m_CompItemId; }
            set { m_CompItemId = value; }
        }

        string m_CompItemCount;
        public string CompItemCount
        {
            get { return m_CompItemCount; }
            set { m_CompItemCount = value; }
        }

        string m_CompConsumeCurrency;
        public string CompConsumeCurrency
        {
            get { return m_CompConsumeCurrency; }
            set { m_CompConsumeCurrency = value; }
        }

        string m_CompConsumeCurrencyCount;
        public string CompConsumeCurrencyCount
        {
            get { return m_CompConsumeCurrencyCount; }
            set { m_CompConsumeCurrencyCount = value; }
        }

        public override ECsvTag CsvTag
        {
            get { return ECsvTag.Compose; }
        }

        const string FIELD_ID = "Id";
        const string FIELD_NAME = "Name";
        const string FIELD_COMPITEMID = "CompItemId";
        const string FIELD_COMPITEMCOUNT = "CompItemCount";
        const string FIELD_COMPCONSUMECURRENCY = "CompConsumeCurrency";
        const string FIELD_COMPCONSUMECURRENCYCOUNT = "CompConsumeCurrencyCount";

        public override void ParseConfigData(long rowIndex, int fieldCount, string[] headers, string[] values)
        {
            m_ItemId = ReadUlong(FIELD_ID, headers, values, 0);
            m_ItemName = ReadString(FIELD_NAME, headers, values);
            m_CompItemId = ReadString(FIELD_COMPITEMID, headers, values);
            m_CompItemCount = ReadString(FIELD_COMPITEMCOUNT, headers, values);
            m_CompConsumeCurrency = ReadString(FIELD_COMPCONSUMECURRENCY, headers, values);
            m_CompConsumeCurrencyCount = ReadString(FIELD_COMPCONSUMECURRENCYCOUNT, headers, values);
        }

        public override string GetPrimaryKey()
        {
            return m_ItemId.ToString();
        }
    }
}
