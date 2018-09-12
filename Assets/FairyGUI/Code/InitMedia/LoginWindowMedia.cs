namespace SimpleUI
{
    public partial class LoginWindowMedia
    {
        partial void InitInstance(LoginWindow instace)
        {
            //instace.m_BaseWindow.m_Title.m_Title.text = "LoginWindow";
            instace.m_LoginButton.onClick.Add(HandleLoginClick);
            instace.Disposable = true;
        }

        void HandleLoginClick()
        {
            WindowManage.GetInstance.OpenWindow(WindowNameFactory.GetCreateRoleWindowName());
        }
    }
}