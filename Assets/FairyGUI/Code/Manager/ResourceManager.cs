using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FairyGUI;
using UnityEngine.U2D;

namespace SimpleUI
{
    public delegate void OnLoadBundleFinish(AssetBundle bundle);

    public interface DownLoadEventAPI
    {
        OnLoadBundleFinish OnLoadBundleDelegate { get; set; }
        void OnLoadAssetBundle(AssetBundle bundle);
        AssetBundle GetBundle();
    }
    public interface ResourceAPI
    {
        bool ReleaseAsset(string key);
        IEnumerator LoadAssetBundle(string keyName, DownLoadEventAPI combineLoadHelp);
    }
    public interface DownLoadHelpAPI
    {
        void OnLoadAssetBundle(AssetBundle bundle);
        AssetBundle GetBundle();
    }

    public interface BundleNameAPI
    {
        string GetBundleName();
    }

    public interface BundleReferenceAPI
    {
        int ReferenceCount { get; set; }
        AssetBundle Bundle { get; set; }
        AssetBundle PlusCount();
        void InitBundle(AssetBundle assetBundle);
        bool MinusCount();
    }

    public interface PathHelperAPI
    {
        string AppContentPath();
    }

    public interface AppStartAPI
    {
        void StartApp(MonoBehaviour mono);
    }

    public partial class SimpleFactory
    {
        public static ResourceAPI CreateResourceAPI()
        {
            return ResourceInstance.GetInstance;
        }

        public static DownLoadEventAPI CreateDownLoadEventAPI()
        {
            return new DownLoadEventImplement();
        }

        public static DownLoadHelpAPI CreateDownLoadHelpAPI()
        {
            return new DownLoadHelp();
        }

        public static BundleReferenceAPI CreateBundleReferenceAPI()
        {
            return new BundleReference();
        }

        public static PathHelperAPI CreatePathHelperAPI()
        {
            return new PathHelper();
        }

        public static BundleNameAPI CreateFairyBundleNameAPI()
        {
            return new FairyBundleNameImplement();
        }

        public static AppStartAPI CreateAppStart()
        {
            return new SimpleFairyApp();
        }
    }


    public class FairyBundleNameImplement : BundleNameAPI
    {
        public string GetBundleName()
        {
            return "simpleui_fui.windowframe";
        }
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

    public class DownLoadHelp: DownLoadHelpAPI
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

    public class BundleReference : BundleReferenceAPI
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

    public class PathHelper: PathHelperAPI
    {
        public string AppContentPath()
        {
            string path = string.Empty;
            switch (Application.platform)
            {
                case RuntimePlatform.Android:
                    path =string.Format(@"jar:file://{0}!/assets/",Application.dataPath);
                    break;
                case RuntimePlatform.IPhonePlayer:
                    path = string.Format("file://{0}/Raw/", Application.dataPath);
                    break;
                default:
                    path = string.Format("file://{0}/StreamingAssets/", Application.dataPath);
                    break;
            }
            return path;
        }
    }


    public class ResourceManager :ResourceAPI
    {
        IEnumerator DownLoadAsset(string assetName, DownLoadHelpAPI downLoadHelper)
        {
            string loadpath = string.Format("{0}/{1}", SimpleFactory.CreatePathHelperAPI().AppContentPath(), assetName);
            WWW assetData = new WWW(loadpath);
            yield return assetData;

            Debug.Log(loadpath);

            if (assetData.error != null)
            {
                Debug.Log(assetData.error);
                yield break;
            }
            AssetBundle assetBundle;
            if (assetData.isDone)
            {
                assetBundle = AssetBundle.LoadFromMemory(assetData.bytes);
                BundleReferenceAPI bundleReference = SimpleFactory.CreateBundleReferenceAPI();
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

        Dictionary<string, BundleReferenceAPI> bundlelist = new Dictionary<string, BundleReferenceAPI>();
        public IEnumerator LoadAssetBundle(string keyName, DownLoadEventAPI combineLoadHelp)
        {
            AssetBundle assetBundle = null;
            bool hasBundle = bundlelist.ContainsKey(keyName) && bundlelist[keyName].Bundle != null;
            if (!hasBundle)
            {
                DownLoadHelpAPI downLoadHelp = SimpleFactory.CreateDownLoadHelpAPI();
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

    public class ResourceInstance :SingleInstance<ResourceManager>
    {

    }

    public class SimpleFairyApp : AppStartAPI
    {
        public void StartApp(MonoBehaviour mono)
        {
            SimpleUIBinder.BindAll();
            mono.StartCoroutine(CreateIEnumerator());

        }

        IEnumerator CreateIEnumerator()
        {
            BundleNameAPI bundleNameAPI = SimpleFactory.CreateFairyBundleNameAPI();
            ResourceAPI resourceAPI = SimpleFactory.CreateResourceAPI();
            DownLoadEventAPI downLoadEventAPI = SimpleFactory.CreateDownLoadEventAPI();
            downLoadEventAPI.OnLoadBundleDelegate += (AssetBundle bundle) =>
            {
                UIPackage.AddPackage(bundle);
                this.Inst<WindowManage>().OpenWindow(WindowNameFactory.GetLoginWindowName());
            };
            yield return resourceAPI.LoadAssetBundle(bundleNameAPI.GetBundleName(), downLoadEventAPI);
        }
    }
}