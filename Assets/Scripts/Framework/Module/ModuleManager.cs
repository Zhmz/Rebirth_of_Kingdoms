using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ROKConfig.ROKCsv;
using System.Reflection;

namespace ROKCore
{
    public class ModuleManager
    {
        #region Config
        /// <summary>
        /// 需要被初始化的模块
        /// </summary>
        Dictionary<EModuleType, Type> NeedToCreateModuleDic = new Dictionary<EModuleType, Type>()
        {
            {EModuleType.Event, typeof(ROKCore.EventManager)},
            {EModuleType.Assets, typeof(ROKAsset.AssetManager)},

            {EModuleType.Csv, typeof(ROKConfig.ROKCsv.CsvConfigManager)}, //配置的初始化
           
            {EModuleType.Role, typeof(ROKGameBase.ROKRole.RoleManager)},
            {EModuleType.Item, typeof(ROKGameBase.ROKItem.ItemManager)},
            {EModuleType.Mall, typeof(ROKGameBase.ROKMall.MallManager)}
        };
        #endregion

        private static ModuleManager m_Instance;
        public static ModuleManager Instance
        {
            get
            {
                if (m_Instance == null)
                {
                    m_Instance = new ModuleManager();
                }
                return m_Instance;
            }
        }

        Dictionary<int, BaseModule> m_ModuleDic = new Dictionary<int, BaseModule>();

        public BaseModule GetModule(EModuleType type)
        {
            if (ContainsModule(type))
            {
                return m_ModuleDic[(int)type];
            }
            return null;
        }

        public bool ContainsModule(EModuleType type)
        {
            return m_ModuleDic.ContainsKey((int)type);
        }

        public bool AddModule(EModuleType type, BaseModule module)
        {
            if (!ContainsModule(type))
            {
                m_ModuleDic.Add((int)type, module);
                return true;
            }
            ROKTool.ROKLogger.PrintError("Module:{0} has already existed.");
            return false;
        }

        public bool RemoveModule(EModuleType type)
        {
            if (ContainsModule(type))
            {
                m_ModuleDic.Remove((int)type);
                return true;
            }
            ROKTool.ROKLogger.PrintError("Module:{0} doesn't exist.");
            return false;
        }

        /// <summary>
        /// 通过反射调用
        /// </summary>
        /// <typeparam name="T">模块的子类</typeparam>
        /// <param name="moduleType">模块枚举</param>
        public void CreateModules<T>(EModuleType moduleType) where T : BaseModule, new()
        {
            ModuleManager.Instance.AddModule(moduleType, new T());
        }

        //模块初始化
        public void Initialize()
        {
            Type baseModuleType = typeof(BaseModule);
            Assembly ModuleAssembly = baseModuleType.Assembly;
            MethodInfo methodMaker = typeof(ModuleManager).GetMethod("CreateModules");

            foreach (EModuleType moduleType in NeedToCreateModuleDic.Keys)
            {
                Type moduleClass = NeedToCreateModuleDic[moduleType];
                if (moduleClass.IsSubclassOf(baseModuleType))
                {
                    MethodInfo concreteMethod = methodMaker.MakeGenericMethod(moduleClass);
                    object[] param = { moduleType };
                    concreteMethod.Invoke(this, param);
                }
            }

            foreach (BaseModule m in m_ModuleDic.Values)
            {
                m.Init();
            }
        }
    }
}
