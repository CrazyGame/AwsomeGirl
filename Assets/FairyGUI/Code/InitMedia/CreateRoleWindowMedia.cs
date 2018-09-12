namespace SimpleUI
{
    public partial class CreateRoleWindowMedia
    {
        partial void InitInstance(CreateRoleWindow instace)
        {
            //instace.m_BaseWindow.m_Title.m_Title.text = "RoleCreate";
            instace.m_Next.onClick.Add(HandleNextClick);
            instace.Disposable = true;
        }

        void HandleNextClick()
        {
            WindowManage.GetInstance.OpenWindow(WindowNameFactory.GetRoleRenameWindowName());
        }
    }
}