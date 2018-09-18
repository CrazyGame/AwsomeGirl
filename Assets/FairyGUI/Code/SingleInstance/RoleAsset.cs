using System.Collections;

namespace SimpleUI
{
    public class RoleAssetInstance : SingleInstance<RoleAsset>
    {

    }

    public interface RoleAssetAPI
    {
        IEnumerator CreateRoleIEnumerator( OnLoadBundleFinish onLoadBundleFinish);
    }


    public partial class SimpleFactory
    {
        public static RoleAssetAPI CreateRoleAssetAPI()
        {
            return RoleAssetInstance.GetInstance;
        }
    }


    public class AssetHelper
    {
        public static IEnumerator CreateRoleIEnumerator(string bundleName, OnLoadBundleFinish onLoadBundleFinish)
        {
            ResourceAPI resourceAPI = SimpleFactory.CreateResourceAPI();
            DownLoadEventAPI downLoadEventAPI = SimpleFactory.CreateDownLoadEventAPI();
            downLoadEventAPI.OnLoadBundleDelegate += onLoadBundleFinish;
            yield return resourceAPI.LoadAssetBundle(bundleName, downLoadEventAPI);
        }
    }

    public class RoleAsset : RoleAssetAPI
    {
        public IEnumerator CreateRoleIEnumerator(OnLoadBundleFinish onLoadBundleFinish)
        {
            string roleBundleName = "character.role";
            yield return AssetHelper.CreateRoleIEnumerator(roleBundleName, onLoadBundleFinish);           
        }
    }
}


