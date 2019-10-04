using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ROKCore;

namespace ROKGUI
{
    public abstract class BaseUIController
    {
        BaseUIView m_UINode = null;
        public BaseUIView UINode
        {
            get { return m_UINode; }
        }

        List<BaseUIController> m_ChildControllers = new List<BaseUIController>();
        public List<BaseUIController> ChildControllers
        {
            get { return m_ChildControllers; }
        }

        protected bool m_IsActive = false;
        public bool IsActive
        {
            get { return m_IsActive; }
        }

        UIEventSensor m_EventSensor = new UIEventSensor();

        public abstract EAssetID GetViewAssetId();

        public virtual void Init()
        {

        }

        public virtual void ShutDown()
        {
            m_EventSensor.ShutDown();
        }


        #region Event
        public virtual void RegisterDelegates()
        {

        }
        public virtual void UnRegisterDelegates()
        {

        }

        public void RegisterEventHandler(uint commandId, ResponseHandler handler)
        {
            m_EventSensor.RegisterEventHandler(commandId, handler);
        }
        public void UnRegisterEventHandler(uint commandId)
        {
            m_EventSensor.UnRegisterEventHandler(commandId);
        }

        public virtual void OnShow()
        {

        }

        public virtual void OnClose()
        {

        }

        public virtual bool OnUIEvent(BaseEventMsg Msg)
        {
            if (!m_EventSensor.OnUIEvent(Msg))
            {
                for (int i = 0; i < m_ChildControllers.Count; i++)
                {
                    BaseUIController ctrl = m_ChildControllers[i];
                    if (ctrl != null && ctrl.OnUIEvent(Msg))
                    {
                        return true;
                    }
                }
                return false;
            }
            return true;
        }

        #endregion



        #region Functional
        public virtual void SetActive(bool isActive, bool recursively = false)
        {
            if (m_UINode != null && m_UINode.gameObject.activeSelf != isActive)
            {
                m_UINode.SetActive(isActive);
            }

            if (recursively && m_ChildControllers != null)
            {
                for (int i = 0; i < m_ChildControllers.Count; i++)
                {
                    if (m_ChildControllers[i] != null)
                    {
                        m_ChildControllers[i].SetActive(isActive, recursively);
                    }
                }
            }

            m_IsActive = isActive;

            if (m_IsActive)
            {
                RegisterDelegates();
                OnShow();
            }
            else
            {
                UnRegisterDelegates();
                OnClose();
            }
        }

        protected virtual void CloseSelf()
        {

        }

        #endregion

        #region Child

        public T CreateChildController<T>() where T : BaseUIController, new()
        {
            return null;
        }

        public T ShowChildController<T>() where T:BaseUIController,new()
        {
            return null;
        }


        #endregion
    }
}
