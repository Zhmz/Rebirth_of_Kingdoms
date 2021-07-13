using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ROKConfig.ROKCsv;
using ROKTool;
using ROKCore;
using ROKCore.ROKAsset;

namespace ROKGameBase.ROKLogin
{
   public class LoginManager : BaseModule
    {
        public static LoginManager Instance
        {
            get
            {
                return ModuleManager.Instance.GetModule(EModuleType.Login) as LoginManager;
            }
        }

        public override EModuleType ModuleType
        {
            get { return EModuleType.Login; }
        }

        public override void Init()
        {
            base.Init();

            AssetManager.Instance.InstantiateController<LoginController>();
        }
    }
}
