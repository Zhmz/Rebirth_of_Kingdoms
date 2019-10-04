using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ROKCore
{
    public class BaseEventMsg
    {
        public uint CommandID;
        public object[] Params = null;

        public BaseEventMsg()
        {

        }

        public BaseEventMsg(uint inCommandID, params object[] InParams)
        {
            CommandID = inCommandID;
            Params = InParams;
        }
    }

    public delegate void ResponseHandler(BaseEventMsg Msg);
  public class EventChannel
    {

        Dictionary<uint, ResponseHandler> EventResponseHandlers = new Dictionary<uint, ResponseHandler>();

        public EventChannel()
        {

        }

        public virtual void Init()
        {

        }

        public virtual void ShutDown()
        {
            EventResponseHandlers.Clear();
        }

        //一个事件指定挂载一个响应（后续替换）
        public void RegisterHandler(uint commandId, ResponseHandler handler)
        {
            if(handler==null)
            {
                if(EventResponseHandlers.ContainsKey(commandId))
                {
                    EventResponseHandlers.Remove(commandId);
                }
            }
            else
            {
                if (!EventResponseHandlers.ContainsKey(commandId))
                {
                    EventResponseHandlers.Add(commandId,handler);
                }
                else
                {
                    EventResponseHandlers[commandId] = handler;
                }
            }
        }

        public void UnRegisterHandler(uint commandId)
        {
            if(EventResponseHandlers.ContainsKey(commandId))
            {
                EventResponseHandlers.Remove(commandId);
            }
        }


        public bool ProcessEvent(BaseEventMsg Msg)
        {
            ResponseHandler handler = null;
            if(EventResponseHandlers.TryGetValue(Msg.CommandID, out handler))
            {
                handler(Msg);
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
