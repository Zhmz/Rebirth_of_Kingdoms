using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace ROKTool
{
    public enum ELogType
    {
        Log,
        Warning,
        Error,
    }

    public class ROKLogger
    {
        public static void PrintLog(string content, params object[] objs)
        {
#if UNITY_EDITOR
            string log = content;
            if (objs != null && objs.Length > 0)
            {
                log = string.Format(content, objs);
            }

            Debug.Log(log);
#endif
        }


        public static void PrintWarning(string content, params object[] objs)
        {
#if UNITY_EDITOR
            string warning = content;
            if (objs != null && objs.Length > 0)
            {
                warning = string.Format(content, objs);
            }

            Debug.LogWarning(warning);
#endif
        }


        public static void PrintError(string content, params object[] objs)
        {
#if UNITY_EDITOR
            string error = content;
            if (objs != null && objs.Length > 0)
            {
                error = string.Format(content, objs);
            }

            Debug.LogError(error);
#endif
        }
    }
}