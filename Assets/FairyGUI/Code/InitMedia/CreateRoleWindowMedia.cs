using UnityEngine;
using FairyGUI;

namespace SimpleUI
{
    public partial class CreateRoleWindowMedia
    {
        Texture[] allRole;
        CreateRoleWindow instace;
        GObject[] allButtons;

        string[] detailInfo = { "Role0Info", "Role1Info", "Role2Info", "Role3Info" };

        partial void InitInstance(CreateRoleWindow instace)
        {
            this.instace = instace;
            RoleAssetAPI roleAssetAPI = SimpleFactory.CreateRoleAssetAPI();
            MonoInst.RunConrotine(roleAssetAPI.CreateRoleIEnumerator((AssetBundle bundle) =>
            {
                allButtons = instace.m_RoleList.GetChildren();
                allRole = bundle.LoadAllAssets<Texture>();              
                SetTexture(0);
                SetDetailInfo(0);
            }
            ));

            instace.m_HintText.m_TextContent.text = "This is the HintInfo";           

            instace.m_BaseWindow.m_BackTitleButton.m_Title.text = "RoleCreate";
            instace.m_Next.onClick.Add(HandleNextClick);
            instace.Disposable = true;
            instace.m_RoleList.GetChildren();
            instace.m_RoleList.onClickItem.Add(EventCallback1);
        }

        void SetTexture(int index)
        {
            NTexture roleNTexture = new NTexture(allRole[index]);
            instace.m_IconLoader.m_Icon.texture = roleNTexture;
        }

        void SetDetailInfo(int index)
        {
            instace.m_Detials.m_TextContent.text = detailInfo[index];
        }

        void EventCallback1(EventContext context)
        {
            int index = FairTools.GetGListItemIndex(context.data,allButtons);           
            SetTexture(index);
            SetDetailInfo(index);
        }

        public int GetGListItemIndex(GObject current,GObject[] allObject)
        {
            int index = 0;
            for (int i = 0; i < allObject.Length; i++)
            {
                if(allObject[i] == current)
                {
                    index = 0;
                    break;
                }
            }
            return index;
        }


        void HandleNextClick()
        {
            WindowManage.GetInstance.OpenWindow(WindowNameFactory.GetRoleRenameWindowName());
        }
    }
}