using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SimpleUI
{
    public delegate void OnLoadBundleFinish(AssetBundle bundle);

    public interface DownLoadEventAPI
    {
        OnLoadBundleFinish OnLoadBundleDelegate { get; set; }
        void OnLoadAssetBundle(AssetBundle bundle);
        AssetBundle GetBundle();
    }

    public class DownLoadEventImplement :DownLoadEventAPI
    {
        public OnLoadBundleFinish OnLoadBundleDelegate { get; set; }
        AssetBundle assetBundle = null;
        public void OnLoadAssetBundle(AssetBundle bundle)
        {
            if (bundle == null)
            {
                return;
            }
            assetBundle = bundle;
            if (OnLoadBundleDelegate != null)
            {
                OnLoadBundleDelegate(bundle);
            }
        }

        public AssetBundle GetBundle()
        {
            return assetBundle;
        }
    }

    public class DownLoadHelp
    {
        AssetBundle assetBundle = null;
        public void OnLoadAssetBundle(AssetBundle bundle)
        {
            assetBundle = bundle;
        }

        public AssetBundle GetBundle()
        {
            return assetBundle;
        }
    }

    public class BundleReference
    {
        public int ReferenceCount { get; set; }
        public AssetBundle Bundle { get; set; }

        public AssetBundle PlusCount()
        {
            ReferenceCount++;
            return Bundle;
        }

        public void InitBundle(AssetBundle assetBundle)
        {
            Bundle = assetBundle;
            PlusCount();
        }

        public bool MinusCount()
        {
            ReferenceCount--;
            if (ReferenceCount <= 0)
            {
                if (Bundle != null)
                {
                    Bundle.Unload(true);
                    Bundle = null;
                    return true;
                }
            }
            return false;
        }
    }

    public class ResourceManager
    {
        IEnumerator DownLoadAsset(string assetName, DownLoadHelp downLoadHelper)
        {
            bool fromLocal = Application.isEditor;
            string loadpath = string.Format("file://{0}/{1}", Application.streamingAssetsPath, assetName);
            if (!fromLocal)
            {
                loadpath = string.Format("https://{0}/{1}", Application.streamingAssetsPath, assetName);
            }

            WWW assetData = new WWW(loadpath);
            yield return assetData;

            if (assetData.error != null)
            {
                Debug.Log(assetData.error);
                yield break;
            }
            AssetBundle assetBundle;
            if (assetData.isDone)
            {
                assetBundle = AssetBundle.LoadFromMemory(assetData.bytes);
                BundleReference bundleReference = new BundleReference();
                bundleReference.InitBundle(assetBundle);
                bundlelist.Add(assetName, bundleReference);
                downLoadHelper.OnLoadAssetBundle(assetBundle);
            }
            yield return null;
        }

        public bool ReleaseAsset(string key)
        {
            if (bundlelist.ContainsKey(key))
            {
                bool assetUnloaded = bundlelist[key].MinusCount();
                if (assetUnloaded)
                {
                    bundlelist.Remove(key);
                    return true;
                }
            }
            return false;
        }

        Dictionary<string, BundleReference> bundlelist = new Dictionary<string, BundleReference>();
        public IEnumerator LoadAssetBundle(string keyName, DownLoadEventAPI combineLoadHelp)
        {
            AssetBundle assetBundle = null;
            bool hasBundle = bundlelist.ContainsKey(keyName) && bundlelist[keyName].Bundle != null;
            if (!hasBundle)
            {
                DownLoadHelp downLoadHelp = new DownLoadHelp();
                yield return DownLoadAsset(keyName, downLoadHelp);
            }

            if (bundlelist.ContainsKey(keyName))
            {
                assetBundle = bundlelist[keyName].PlusCount();
            }
            if (assetBundle != null)
            {
                combineLoadHelp.OnLoadAssetBundle(assetBundle);
            }
            yield return null;
        }
    }
}