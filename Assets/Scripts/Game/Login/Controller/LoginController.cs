using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ROKGUI;
using System;
using ROKTool;

namespace ROKGameBase.ROKLogin
{
    public class LoginController :BaseUIController
    {
        LoginView m_View;

        public override EAssetID GetViewAssetId()
        {
            return EAssetID.ROK_LoginView;
        }

        public override void Init()
        {
            base.Init();
            m_View = UINode as LoginView;
        }

        public override void RegisterDelegates()
        {
            m_View.m_QQButton.onClick.AddListener(OnQQButtonClick);
            m_View.m_WechatButton.onClick.AddListener(OnWechatButtonClick);
        }

        public override void UnRegisterDelegates()
        {
            m_View.m_QQButton.onClick.RemoveListener(OnQQButtonClick);
            m_View.m_WechatButton.onClick.RemoveListener(OnWechatButtonClick);
        }

        void OnQQButtonClick()
        {
            ROKLogger.PrintLog("Click QQButton.");
        }

        void OnWechatButtonClick()
        {
            ROKLogger.PrintLog("Click WechatButton.");
        }
    }
}
