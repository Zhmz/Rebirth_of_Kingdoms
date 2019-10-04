using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ROKConfig.ROKCsv;
using ROKTool;
using ROKCore;

namespace ROKGameBase.ROKRole
{
    public class RoleManager : BaseModule
    {
        public static RoleManager Instance
        {
            get
            {
                return ModuleManager.Instance.GetModule(EModuleType.Role) as RoleManager;
            }
        }
        public override EModuleType ModuleType
        {
            get { return EModuleType.Role; }
        }

        public override void Init()
        {
            base.Init();

            RoleData role = GetRoleData(10106001);
            ROKLogger.PrintLog("Name: {0}, Quality: {1}, Camp: {2}", role.RoleName, role.Quality.ToString(), role.Camp.ToString());
        }


       public RoleData GetRoleData(ulong roleId)
        {
            List<RoleCsvConfigData> configList = CsvConfigManager.Instance.GetCsvConfigList<RoleCsvConfigData>();
            RoleCsvConfigData config = configList.Find(x => x.RoleId == roleId);
            if (config != null)
            {
                return new RoleData(config);
            }
            return null;
        }
    }
}
