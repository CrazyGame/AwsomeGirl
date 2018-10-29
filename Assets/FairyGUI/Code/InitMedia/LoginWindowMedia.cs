using UnityEngine;
using System.IO;
using System.Collections;
using FairyGUI;

namespace SimpleUI
{
    public partial class LoginWindowMedia
    {
       // LoginWindow instace;
        partial void InitInstance(LoginWindow instace)
        {
            //this.instace = instace;
            instace.m_BaseWindow.m_BackTitleButton.m_Title.text = "LoginWindow";
            instace.m_LoginButton.onClick.Add(HandleLoginClick);
            instace.Disposable = true;

            //string path = string.Format("file://{0}/FairyGUI_files/2.png", Application.streamingAssetsPath);
            //MonoInst.GetInstance.MonoReference.StartCoroutine(DownLoadImg(path));
        }


        //IEnumerator DownLoadImg(string filelocaition)
        //{
        //    GLoader gLoader = new GLoader();
        //    gLoader.url = "playericon";

        //    //string htmlCode =  string.Format("<img src={0} width='48' height='48'/>", gLoader.icon);
        //    //instace.m_HtmlText.text = htmlCode;
        //    yield return null;
        //}


        void HandleLoginClick()
        {
            WindowManage.GetInstance.OpenWindow(WindowNameFactory.GetCreateRoleWindowName());
        }
    }
}