using ROKGameBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ROKCore
{
    public enum EEventType
    {
        None,
        UIEvent,
        ActorEvent,
    }

    public class EventManager : BaseModule
    {
        public static EventManager Instance
        {
            get
            {
                return ModuleManager.Instance.GetModule(EModuleType.Event) as EventManager;
            }
        }

        public override EModuleType ModuleType
        {
            get { return EModuleType.Event; }
        }

        public override void Init()
        {
            base.Init();
        }

        ResponseHandler m_UIEventHandler = null;
        ResponseHandler m_ActorEventHandler = null;

        public void RegisterModule(EEventType type, ResponseHandler handler)
        {
            switch (type)
            {
                case EEventType.UIEvent:
                    m_UIEventHandler = handler;
                    break;
                case EEventType.ActorEvent:
                    m_ActorEventHandler = handler;
                    break;
            }
        }

        public void UnRegisterModule(EEventType type)
        {
            switch (type)
            {
                case EEventType.UIEvent:
                    m_UIEventHandler = null;
                    break;
                case EEventType.ActorEvent:
                    m_ActorEventHandler = null;
                    break;
            }
        }

        public void SendEvent(EEventType type, BaseEventMsg Msg)
        {
            switch (type)
            {
                case EEventType.UIEvent:
                    m_UIEventHandler(Msg);
                    break;
                case EEventType.ActorEvent:
                    m_ActorEventHandler(Msg);
                    break;
            }
        }


        public void SendEvent(EEventType type, uint commandId, params object[] inParams)
        {
            BaseEventMsg Msg = new BaseEventMsg(commandId, inParams);
        }

    }
}
