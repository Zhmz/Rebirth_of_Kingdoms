using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ROKCore.ROKAsset
{
    //第一位第二位作为Asset类型区分，暂时
    //GUI:1*
    //CharacterModel:2*
    //...

    //第三第四位作为模块(ModuleDefine)的编号
    public enum EAssetIDs
    {
        #region GUI

        //Role
        ROK_GUI_RoleMainView = 10110001,


        //Item
        ROK_GUI_ItemBagView = 10120001,
        ROK_GUI_ItemBagItemView = 10120001,

        #endregion


    }
}
