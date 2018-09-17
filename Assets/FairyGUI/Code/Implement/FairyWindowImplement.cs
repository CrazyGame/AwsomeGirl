using SimpleUI;
using UnityEngine;

public class FairyStartBundleImplement : BundleComplete
{
    public void OnComplete(AssetBundle bundle)
    { 
        WindowManage.GetInstance.OpenWindow(WindowNameFactory.GetLoginWindowName());
    }
}
