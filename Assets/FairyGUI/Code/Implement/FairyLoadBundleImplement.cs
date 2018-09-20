using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FairyGUI;
using SimpleUI;

public struct BundleReferenceStruct
{
    public static BundleReferenceStruct CreateBundleStruct()
    {
        BundleReferenceStruct referenceStruct = new BundleReferenceStruct() { loadedBundle = null, referenceCount = 0 };
        return referenceStruct;
    }

    public bool InitBundle(AssetBundle assetBundle)
    {
        if(loadedBundle == null)
        {
            loadedBundle = assetBundle;
            referenceCount = 0;
            return true;
        }
        return true;
    }

    public AssetBundle LoadBundle() 
    {
        if (HasBundle) { referenceCount++; return loadedBundle; }
        return null;
    }

    public bool UnloadBundle()
    {
        if(HasBundle)
        {
            referenceCount--;
            if(referenceCount <= 0)
            {
                referenceCount = 0;
                loadedBundle.Unload(true);
                Resources.UnloadUnusedAssets();
            }
            loadedBundle = null;
        }
        return true; 
    }

    AssetBundle loadedBundle { get; set; } 
    int referenceCount { get; set; } 
    public bool HasBundle { get { return loadedBundle == null; }}
}

public class BundleReference :SingleInstance<BundleReference>
{
    Dictionary<string, BundleReferenceStruct> bundleDic = new Dictionary<string, BundleReferenceStruct>();

    public AssetBundle LoadAssetBundle(string key)
    {
        if(bundleDic.ContainsKey(key))
        {
            return bundleDic[key].LoadBundle();
        }
        return null;
    }

    public bool UnLoadAssetbundle(string key)
    {
        bool containKey = bundleDic.ContainsKey(key);
        if(containKey)
        {
            bool hasReference = bundleDic[key].UnloadBundle();
            if(!hasReference)
            {
                bundleDic.Remove(key);
                containKey = false;
            }
        }
        return containKey;
    }


    public IEnumerator AssetFromBundle(string bundleAssetName)
    {
        bool containKey = bundleDic.ContainsKey(bundleAssetName);
        if(containKey)
        {
            yield break;
        }

        string path = string.Format("{1}/{0}", bundleAssetName, Application.streamingAssetsPath);

        WWW dataWWW = new WWW(path);
        yield return dataWWW;

        if(dataWWW.error != null)
        {
            yield break;
        }

        if (dataWWW.isDone)
        {
            AssetBundle assetBundle = AssetBundle.LoadFromMemory(dataWWW.bytes);
            BundleReferenceStruct referenceStruct = BundleReferenceStruct.CreateBundleStruct();
            referenceStruct.InitBundle(assetBundle);
            bundleDic.Add(bundleAssetName, referenceStruct);
        }
        yield return null;
    }
}


public class FairyLoadBundleImplement : FairyLoadBundle,BundleComplete
{
    public IEnumerator AssetFromBundle(string bundleAssetName, BundleComplete completeCallBack)
    {
        yield return BundleReference.GetInstance.AssetFromBundle(bundleAssetName);
        AssetBundle assetBundle = BundleReference.GetInstance.LoadAssetBundle(bundleAssetName);
        if(assetBundle != null)
        {
            completeCallBack.OnComplete(assetBundle);
        }
    }

   public IEnumerator DownLoadData<T>(BundleComplete completeCallBack) where T : AssetBundleResName, new()
   {
        if(!this.LoadBundle())
        {
            yield return AssetFromBundle(BundleConst.WindowframeBundleName ,this);

                T instance = new T();
                UIPackage bundlePackage = UIPackage.GetByName(instance.ResName);
                if (null == bundlePackage)
                {
                    //bundlePackage = UIPackage.AddPackage(assetBundle);
                    this.SetBundlePackageOfPoolInstance(bundlePackage);
                }
                //completeCallBack.OnComplete(assetBundle);
        }
    }

    public void OnComplete(AssetBundle bundle)
    {

    }
}

public class FairyLoadBundleImplementComplete : BundleComplete
{
    public void OnComplete(AssetBundle bundle)
    {

    }
}