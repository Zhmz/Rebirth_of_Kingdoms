using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ROKGUI
{
    /// <summary>
    /// FrontEnd 10000000~19999999
    /// OtherOutsideGame 20000000~29999999
    /// </summary>

    public enum EAssetID
    {
        ROK_None = 0,

        #region Login
        ROK_LoginView = 20001000,
        ROK_LoginInputWindow = 20001001,

        #endregion
    }
}
