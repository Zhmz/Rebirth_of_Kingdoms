using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ROKCore
{
    public abstract class BaseModule
    {
        public abstract EModuleType ModuleType { get; }

        protected BaseModule BaseInstance
        {
            get { return ModuleManager.Instance.GetModule(ModuleType); }
        }

        public virtual void Init()
        {
            ROKTool.ROKLogger.PrintLog("Module:{0} Inited.", ModuleType);
        }

        public virtual void ShutDown()
        {
            ROKTool.ROKLogger.PrintLog("Module:{0} Shut down.", ModuleType);
        }
    }
}
