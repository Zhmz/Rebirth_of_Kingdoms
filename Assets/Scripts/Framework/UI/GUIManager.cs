using ROKGameBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ROKCore;

namespace ROKGUI
{
    public class GUIManager : BaseModule
    {
        protected List<BaseUIController> m_UIControllerList = new List<BaseUIController>();

        public static GUIManager Instance
        {
            get
            {
                return ModuleManager.Instance.GetModule(EModuleType.UI) as GUIManager;
            }
        }

        public override EModuleType ModuleType
        {
            get { return EModuleType.UI; }
        }

        public override void Init()
        {
            base.Init();

            EventManager.Instance.RegisterModule(EEventType.UIEvent, this.ProcessEvent);
        }

        public override void ShutDown()
        {
            base.ShutDown();

            EventManager.Instance.UnRegisterModule(EEventType.UIEvent);
        }


        public void ProcessEvent(BaseEventMsg Msg)
        {
            for (int i = 0; i < m_UIControllerList.Count; i++)
            {
                BaseUIController ctrl = m_UIControllerList[i];
                ctrl.OnUIEvent(Msg);
            }
        }
    }
}
