using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ROKGameBase;
using UnityEngine;
using System.IO;
using ROKTool;
using System.Text.RegularExpressions;
using System.Reflection;
using ROKCore;

namespace ROKConfig.ROKCsv
{
    public class CsvConfigManager : BaseModule
    {
        #region SomeDefine
        public readonly string CSV_CONFIG_FILES_NAME = "CsvConfigFiles";

        public readonly string CSV_TO_RESOURCE_PATH_FORMAT = "Config/Csv/{0}";
        public readonly string CSV_TO_ABSOLUTE_PATH_FORMAT = Application.dataPath + "/Resources/Config/Csv/{0}";
        #endregion

        public static CsvConfigManager Instance
        {
            get
            {
                return ModuleManager.Instance.GetModule(EModuleType.Csv) as CsvConfigManager;
            }
        }

        public override EModuleType ModuleType
        {
            get
            {
                return EModuleType.Csv;
            }
        }
        #region Cache

        /// <summary>
        /// 存储所有Csv的FullName和Res下路径的映射
        /// </summary>
        Dictionary<string, string> m_ConfigFilesDic = new Dictionary<string, string>();

        /// <summary>
        /// 存储所有Csv的数据，用父类存储，但实际上可以as为子类型
        /// string：CsvConfigData的fullname
        /// </summary>
        Dictionary<string, List<BaseCsvConfigData>> m_CsvListDic = new Dictionary<string, List<BaseCsvConfigData>>();

        //读取configfiles.csv到configfiles字典
        void ReadConfigFiles()
        {
            List<ConfigFilesConfigData> configFiles = ReadCsvData<ConfigFilesConfigData>(CSV_CONFIG_FILES_NAME);

            if (configFiles != null)
            {
                for (int i = 0; i < configFiles.Count; i++)
                {
                    if (!m_ConfigFilesDic.ContainsKey(configFiles[i].ConfigDataName))
                    {
                        m_ConfigFilesDic.Add(configFiles[i].ConfigDataName, configFiles[i].FileName);
                        ROKLogger.PrintLog("configFiles[{0}].ConfigDataName: {1}", i, configFiles[i].ConfigDataName);
                    }
                    else
                    {
                        ROKLogger.PrintError("m_ConfigFilesDic key : {0} is repeated.", configFiles[i].ConfigDataName);
                    }
                }
            }
        }
        #endregion

        public override void Init()
        {
            base.Init();

            ReadConfigFiles();
            ReadAllCsvFiles();

            //List<TestCsvConfigData> testList = GetCsvConfigList<TestCsvConfigData>();
            //for (int i = 0; i < testList.Count; i++)
            //{
            //    ROKLogger.PrintLog("testList[i].Id = {0}, testList[i].Name = {1}, testList[i].Height = {2}", testList[i].Id, testList[i].Name, testList[i].Height);
            //}
        }

        #region 查找
        //获取某一个值
        public T GetCsvConfig<T>(string key) where T : BaseCsvConfigData, new()
        {
            List<T> list = GetCsvConfigList<T>();
            return list.Find(x => string.Compare(x.GetPrimaryKey(), key) == 0);
        }

        //获取一整个表
        public List<T> GetCsvConfigList<T>() where T : BaseCsvConfigData, new()
        {
            List<T> result = null;

            string key = GetCsvDicKey<T>();

            if (m_CsvListDic.ContainsKey(key))
            {
                List<BaseCsvConfigData> list = m_CsvListDic[key];
                if (list != null)
                {
                    result = new List<T>();
                    for (int i = 0; i < list.Count; i++)
                    {
                        result.Add(list[i] as T);
                    }
                }
            }
            return result;
        }

        //根据字典或路径查找
        public List<T> ReadCsvData<T>(string fileName) where T : BaseCsvConfigData, new()
        {
            List<T> result = null;

            if (!File.Exists(FormatResPathToAppPath(fileName, ".csv")))
            {
                ROKLogger.PrintError("Path:{0} doesn't exist.", FormatResPathToAppPath(fileName, ".csv"));
                return null;
            }

            string key = GetCsvDicKey<T>();
            if (!m_CsvListDic.ContainsKey(key))
            {
                ReadCsvFiles<T>(fileName);
            }

            List<BaseCsvConfigData> list = m_CsvListDic[key];
            if (list != null)
            {
                result = new List<T>();
                for (int i = 0; i < list.Count; i++)
                {
                    result.Add(list[i] as T);
                }
            }

            return result;
        }
        #endregion

        #region 加载
        //读取所有的表
        public void ReadAllCsvFiles()
        {
            foreach (string typeName in m_ConfigFilesDic.Keys)
            {
                string fileName = m_ConfigFilesDic[typeName];

                //反射获取类型
                Type baseConfigDataType = typeof(BaseCsvConfigData);
                Assembly dataAssembly = baseConfigDataType.Assembly;
                Type[] typeParams = { typeof(string) };
                MethodInfo methodMaker = typeof(CsvConfigManager).GetMethod("ReadCsvFiles", typeParams);
                Type type = dataAssembly.GetType(typeName);

                if (type.IsSubclassOf(baseConfigDataType))
                {
                    MethodInfo concreteMethod = methodMaker.MakeGenericMethod(type);
                    object[] param = { fileName };
                    concreteMethod.Invoke(this, param);
                }
            }
        }

        //根据路径读csv（路径完全遵循Resources.Load的参数原则，Resources目录下不带后缀名的路径）
        public void ReadCsvFiles<T>(string fileName) where T : BaseCsvConfigData, new()
        {
            List<T> result = new List<T>();

            TextAsset csvContent = Resources.Load(string.Format(CSV_TO_RESOURCE_PATH_FORMAT, fileName), typeof(TextAsset)) as TextAsset;
            string[] lines = Regex.Split(csvContent.text, "\r\n", RegexOptions.IgnoreCase);

            int fieldCount = 0;
            if (lines != null && lines.Length > 0)
            {
                string headersLine = lines[0];
                string[] headers = headersLine.Split(BaseCsvConfigData.SEPERATE_CHAR);
                fieldCount = headers.Length;
                if (fieldCount > 0)
                {
                    for (int i = 1; i < lines.Length; i++)
                    {
                        if (!string.IsNullOrEmpty(lines[i]))
                        {
                            string[] values = lines[i].Split(',');

                            //跳过表头注释行（一般是第二行）
                            if (StringUtils.IsChinese(values[0]))
                            {
                                continue;
                            }

                            T obj = (T)Activator.CreateInstance(typeof(T));
                            obj.ParseConfigData(i, fieldCount, headers, values);

                            result.Add(obj);
                        }
                    }
                }
            }

            //存入缓存
            if (!m_CsvListDic.ContainsKey(typeof(T).FullName))
            {
                List<BaseCsvConfigData> baseList = new List<BaseCsvConfigData>();
                for (int i = 0; i < result.Count; i++)
                {
                    baseList.Add(result[i]);
                }
                m_CsvListDic.Add(typeof(T).FullName, baseList);
            }
        }
        #endregion

        #region Tools
        //Resouses.Load是相对于Resources文件夹下的，但是不带拓展名
        string FormatResPathToAppPath(string resPath, string extensions)
        {
            return string.Format(CSV_TO_ABSOLUTE_PATH_FORMAT, resPath) + extensions;
        }

        //获取fullname
        string GetCsvDicKey<T>()
        {
            return typeof(T).FullName;
        }
        #endregion
    }
}
