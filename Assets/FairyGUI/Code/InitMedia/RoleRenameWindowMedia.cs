namespace SimpleUI
{
    public partial class RoleRenameWindowMedia
    {
        partial void InitInstance(RoleRenameWindow instace)
        {
            instace.m_BaseWindow.m_BackTitleButton.m_Title.text = "RoleCreate";
            instace.Disposable = true;
            instace.m_StartGameButton.onClick.Add(HandleNextClick);
        }

        void HandleNextClick()
        {
            WindowManage.GetInstance.CloseWindow(WindowNameFactory.GetRoleRenameWindowName());            
            WindowManage.GetInstance.AddMainMenu(WindowNameFactory.GetSimpleMainWindowName());
        }
    }
}