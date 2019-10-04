using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace ROKTool
{
   public static class StringUtils
    {
        public static int ConvertStringToInt(string str,int defaultValue)
        {
            int value = defaultValue;
            if (!string.IsNullOrEmpty(str))
            {
                if (!int.TryParse(str, out value))
                {
                    value = defaultValue;
                    ROKLogger.PrintError("Can't Convert {0} to Int.",str);
                }
            }
            return value;
        }

        public static float ConvertStringToFloat(string str, float defaultValue)
        {
            float value = defaultValue;
            if (!string.IsNullOrEmpty(str))
            {
                if (!float.TryParse(str, out value))
                {
                    value = defaultValue;
                    ROKLogger.PrintError("Can't Convert {0} to Float.", str);
                }
            }
            return value;
        }

        public static ulong ConvertStringToUlong(string str, ulong defaultValue)
        {
            ulong value = defaultValue;
            if (!string.IsNullOrEmpty(str))
            {
                if (!ulong.TryParse(str, out value))
                {
                    value = defaultValue;
                    ROKLogger.PrintError("Can't Convert {0} to Int64(ulong).", str);
                }
            }
            return value;
        }
        
        public static bool IsChinese(string str)
        {
            if (null == str) return false;
            return Regex.IsMatch(str, @"[\u4e00-\u9fa5]");
        }
    }
}
