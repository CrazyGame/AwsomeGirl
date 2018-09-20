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

    public class RoleAsset : RoleAssetAPI
    {
        public IEnumerator CreateRoleIEnumerator(OnLoadBundleFinish onLoadBundleFinish)
        {
            yield return AssetHelper.DownLoadAssetBundle(BundleConst.RoleBundleName, onLoadBundleFinish);           
        }
    }
}


