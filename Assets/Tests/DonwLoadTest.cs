using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.TestTools;
using NUnit.Framework;

namespace Test
{
    public class DonwLoadTest
    {

        [Test]
        public void DonwLoadTestSimplePasses()
        {

            // Use the Assert class to test conditions.
        }

        // A UnityTest behaves like a coroutine in PlayMode
        // and allows you to yield null to skip a frame in EditMode
        [UnityTest]
        public IEnumerator DonwLoadTestWithEnumeratorPasses()
        {

            string assetName = "simpleui_fui.windowframe";
            ResourceManager resourceManager = new ResourceManager();
            CombineDownLoadHelp combineDownLoad = new CombineDownLoadHelp();
            yield return resourceManager.LoadAssetBundle(assetName, combineDownLoad);
            AssetBundle assetBundle = combineDownLoad.GetBundle();
            Assert.AreNotEqual(assetBundle, null);
            bool release = resourceManager.ReleaseAsset(assetName);
            Assert.AreEqual(release, true);
            yield return assetBundle;
        }
    }



    public delegate void OnLoadBundleFinish(AssetBundle bundle);

    public class CombineDownLoadHelp
    {
        public OnLoadBundleFinish OnLoadBundleDelegate;
        AssetBundle assetBundle = null;
        public void OnLoadAssetBundle(AssetBundle bundle)
        {
            if (bundle == null)
            {
                return;
            }
            Debug.Log("Setup Bundle" + bundle);
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

    public struct BundleReference
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
            if (Bundle != null)
            {
                //.Unload(false);
            }
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
        public IEnumerator DownLoadAsset(string assetName, DownLoadHelp downLoadHelper)
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
                Assert.AreNotEqual(assetData, null);
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
        public IEnumerator LoadAssetBundle(string keyName, CombineDownLoadHelp combineLoadHelp)
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
