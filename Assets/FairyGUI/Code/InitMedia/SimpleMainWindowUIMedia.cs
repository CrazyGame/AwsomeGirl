using UnityEngine;
namespace SimpleUI
{
    public partial class SimpleMainWindowMedia
    {
        partial void InitInstance(SimpleMainWindow instace)
        {
            AssetHelper.RunDownLoadBundle(BundleConst.PaymentIconBundleName, (AssetBundle bundle) =>
            {
                Texture[] allTexture = bundle.LoadAllAssets<Texture>();
                int count = instace.m_TopValues.GetChildren().Length;
                for (int i = 0; i < count; i++)
                {
                    IconTitleLoader titleLoader = instace.m_TopValues.GetChildAt(i) as IconTitleLoader;
                    if (titleLoader != null)
                    {
                        titleLoader.m_Amount.text = PaymentData.GetAmountValue(SingleInstance<PaymentData>.GetInstance, i).ToString();
                        titleLoader.m_Icon.texture = new FairyGUI.NTexture(allTexture[i]);
                    }
                }
            }
          );

            AssetHelper.RunDownLoadBundle(BundleConst.RoleBundleName, (AssetBundle bundle) =>
            {
                Texture[] allTexture = bundle.LoadAllAssets<Texture>();
                instace.m_RoleIcon.m_Icon.texture = new FairyGUI.NTexture(allTexture[SingleInstance<CurrentPlayIndex>.GetInstance.index]);
                Resources.UnloadUnusedAssets();
            }
         );
        }

        void HandleNextClick()
        {
            WindowManage.GetInstance.CloseWindow(WindowNameFactory.GetRoleRenameWindowName());
            WindowManage.GetInstance.AddMainMenu(WindowNameFactory.GetSimpleMainWindowName());
        }
    }
}
