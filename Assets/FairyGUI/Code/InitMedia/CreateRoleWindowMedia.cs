using UnityEngine;
using FairyGUI;
using FairyGUI.Utils;

namespace SimpleUI
{

    class MyGLoader : GLoader
    {
        override protected void LoadExternal()
        {
            /*
            ��ʼ�ⲿ���룬��ַ��url����
            ������ɺ����OnExternalLoadSuccess
            ����ʧ�ܵ���OnExternalLoadFailed
            ע�⣺������ⲿ���룬����������󣬵���OnExternalLoadSuccess��OnExternalLoadFailedǰ��
            �Ƚ��Ͻ����������ȼ��url�����Ƿ��Ѿ��������������ݲ������
            ������������ʾloader�Ѿ����޸��ˡ�
            ���������Ӧ�÷�������OnExternalLoadSuccess��OnExternalLoadFailed��
            */

            
        }


        public void LoadAsset(string url,Texture texture)
        {
            this.url = url;
            onExternalLoadSuccess(new NTexture(texture));
        }



        override protected void FreeExternal(NTexture texture)
        {
            //�ͷ��ⲿ�������Դ
        }
    }

    public partial class CreateRoleWindowMedia
    {
        Texture[] allRole;
        CreateRoleWindow instace;
        GObject[] allButtons;

        string[] detailInfo = { "Role0Info", "Role1Info", "Role2Info", "Role3Info" };

        int selectIndex = 0;

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



                MyGLoader loader = new MyGLoader();
                loader.position = instace.m_htmlText.position;
                loader.LoadAsset("icon", allRole[0]);
                string richText = string.Format(@"This is the Rich Text <img src='icon' width='20' height='20'/>");
                instace.m_htmlText.text = richText;
                HtmlElement  htmlElement = instace.m_htmlText.richTextField.GetHtmlElementAt(0);
                
                instace.AddChild(loader);
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
            selectIndex = index;
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
            SingleInstance<CurrentPlayIndex>.GetInstance.index = selectIndex;
            WindowManage.GetInstance.OpenWindow(WindowNameFactory.GetRoleRenameWindowName());
        }
    }
}