namespace SimpleUI
{
    public partial class RoleRenameWindowMedia
    {
        partial void InitInstance(RoleRenameWindow instace)
        {
            //instace.m_BaseWindow.m_Title.m_Title.text = "RoleCreate";
            instace.Disposable = true;
            instace.m_StartGameButton.onClick.Add(HandleNextClick);
        }

        void HandleNextClick()
        {
            WindowManage.GetInstance.OpenWindow(WindowNameFactory.GetSimpleMainWindowName());
        }
    }
}