using System.Collections;
using UnityEngine;
using FairyGUI;
using SimpleUI;

public class FairyGUIBundleName
{
    public const string BundleName = "simpleui_fui.windowframe";
}


public class FairyLoadBundleImplement : FairyLoadBundle
{

    

   public IEnumerator DownLoadData<T>(BundleComplete fairyWindow) where T : FairyGUIBundle, new()
   {
        if(!this.LoadBundle())
        {
            T instance = new T();
            string path = string.Format("{1}/{0}", FairyGUIBundleName.BundleName, Application.streamingAssetsPath);
            WWW dataWWW = new WWW(path);
            yield return dataWWW;
            if (dataWWW.isDone)
            {
                AssetBundle assetBundle = AssetBundle.LoadFromMemory(dataWWW.bytes);
                Debug.Assert(assetBundle != null);
                UIPackage bundlePackage = UIPackage.GetByName(instance.ResName);
                if (null == bundlePackage)
                {
                    bundlePackage = UIPackage.AddPackage(assetBundle);
                    this.SetBundlePackageOfPoolInstance(bundlePackage);
                }

                fairyWindow.OnComplete();
            }
        }
    }
}
