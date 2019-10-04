using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ROKCore
{
    public class UIEventSensor
    {
        protected EventChannel m_UIEventChannel = new EventChannel();
    
        public void RegisterEventHandler(uint commandId, ResponseHandler handler)
        {
            m_UIEventChannel.RegisterHandler(commandId, handler);
        }

        public void UnRegisterEventHandler(uint commandId)
        {
            m_UIEventChannel.UnRegisterHandler(commandId);
        }

        public virtual bool OnUIEvent(BaseEventMsg Msg)
        {
            return m_UIEventChannel.ProcessEvent(Msg);
        }

        public void ShutDown()
        {
            m_UIEventChannel.ShutDown();
        }
    }
}