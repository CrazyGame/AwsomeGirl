using SimpleUI;

public class FairyStartBundleImplement : BundleComplete
{
    public void OnComplete()
    {
        WindowManage.GetInstance.OpenWindow(WindowNameFactory.GetLoginWindowName());
    }
}
