using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ROKTool;

namespace ROKConfig.ROKCsv
{
    public abstract class BaseCsvConfigData
    {
        #region SomeDefine
        public const char SEPERATE_CHAR = ',';
        #endregion

        public BaseCsvConfigData()
        {
        }

        #region Abstract
        public abstract ECsvTag CsvTag { get; }

        public abstract void ParseConfigData(long rowIndex, int fieldCount, string[] headers, string[] values);

        public abstract string GetPrimaryKey();
        #endregion



        #region Tool Function

        public int ReadInt32(string fieldName, string[] headers, string[] values, int defaultValue = 0)
        {
           string value = GetFieldValueByHeader(fieldName, headers,values);
            if (!string.IsNullOrEmpty(value))
            {
                return StringUtils.ConvertStringToInt(value,defaultValue);
            }
            return defaultValue;
        }

        public string ReadString(string fieldName, string[] headers, string[] values, string defaultValue = "")
        {
            string value = GetFieldValueByHeader(fieldName, headers, values);
            if (!string.IsNullOrEmpty(value))
            {
                return value;
            }
            return defaultValue;
        }

        public float ReadFloat(string fieldName, string[] headers, string[] values, float defaultValue = 0f)
        {
            string value = GetFieldValueByHeader(fieldName, headers, values);
            if (!string.IsNullOrEmpty(value))
            {
                return StringUtils.ConvertStringToFloat(value, defaultValue);
            }
            return defaultValue;
        }

        public ulong ReadUlong(string fieldName, string[] headers, string[] values, ulong defaultValue = 0)
        {
            string value = GetFieldValueByHeader(fieldName, headers, values);
            if (!string.IsNullOrEmpty(value))
            {
                return StringUtils.ConvertStringToUlong(value, defaultValue);
            }
            return defaultValue;
        }

        public string GetFieldValueByHeader(string fieldName, string[] headers, string[] values)
        {
            string result = null;
            int index = -1;

            if (headers != null && headers.Length > 0 && !string.IsNullOrEmpty(fieldName))
            {
                for (int i = 0; i < headers.Length; i++)
                {
                    if (string.Compare(fieldName, headers[i]) == 0)
                    {
                        index = i;
                        break;
                    }
                }

                if (index >= 0)
                {
                    if (index < values.Length)
                    {
                        result = values[index];
                    }
                    else
                    {
                        ROKLogger.PrintError("FieldName:{0} Index is out of Range, Valus.Length", fieldName, values.Length);
                    }
                }
                else
                {
                    ROKLogger.PrintError("Can't Find FieldName:{0} in Headers:{1}", fieldName, headers.ToString());
                }
            }
            else
            {
                ROKLogger.PrintError("FieldName:{0} Headers:{1} is wrong.",fieldName,headers.ToString());
            }

            return result;
        }
        #endregion
    }
}
