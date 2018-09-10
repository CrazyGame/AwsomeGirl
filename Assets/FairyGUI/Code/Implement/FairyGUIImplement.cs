using System.Collections;
using UnityEngine;
using FairyGUI;

public class FairyLoadBundleImplement : FairyLoadBundle
{
   public IEnumerator DownLoadData<T>(FairyWindow fairyWindow) where T : FairyGUIBundle, new()
   {
        T instance = new T();
        string path = string.Format("{1}/{0}", instance.BundleName, Application.streamingAssetsPath);
        WWW dataWWW = new WWW(path);
        yield return dataWWW;
        if (dataWWW.isDone)
        {
            AssetBundle assetBundle = AssetBundle.LoadFromMemory(dataWWW.bytes);
            Debug.Assert(assetBundle != null);
            UIPackage tabControllerPackage = UIPackage.GetByName(instance.ResName);
            if (null == tabControllerPackage)
            {
                tabControllerPackage = UIPackage.AddPackage(assetBundle);
            }
            GObject controllerObj = tabControllerPackage.CreateObject(instance.ResName);

            assetBundle.Unload(true);
            tabControllerPackage.UnloadAssets();
            Resources.UnloadUnusedAssets();

            fairyWindow.CreateWindow(controllerObj);
           
        }
    }
}
