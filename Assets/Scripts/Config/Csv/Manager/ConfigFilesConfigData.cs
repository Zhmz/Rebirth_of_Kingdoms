using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ROKConfig.ROKCsv
{
    public class ConfigFilesConfigData : BaseCsvConfigData
    {
        string m_ConfigDataName;
        public string ConfigDataName
        {
            get
            {
                return m_ConfigDataName;
            }

           private set
            {
                m_ConfigDataName = value;
            }
        }


        string m_FileName;
        public string FileName
        {
            get
            {
                return m_FileName;
            }

           private set
            {
                m_FileName = value;
            }
        }

        public override ECsvTag CsvTag
        {
            get
            {
                return ECsvTag.ConfigFiles;
            }
        }

        public override string GetPrimaryKey()
        {
            return ConfigDataName.ToString();
        }

        public override void ParseConfigData(long rowIndex, int fieldCount, string[] headers, string[] values)
        {
            ConfigDataName = ReadString("ConfigDataName", headers, values);
            FileName = ReadString("FileName", headers, values);
        }
    }
}
