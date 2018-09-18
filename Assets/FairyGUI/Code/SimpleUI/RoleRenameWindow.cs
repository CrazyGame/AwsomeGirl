/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace SimpleUI
{
	public partial class RoleRenameWindow : GComponent,UIMdeiaDispose
	{
		public WindowFrame m_BaseWindow;
		public IconLoader m_IconLoader;
		public BasicInput m_BasicInput;
		public OrangeButton m_RandomName;
		public OrangeButton m_StartGameButton;

		public const string URL = "ui://wmafp3a9rxsv19";
		

		
		public static RoleRenameWindow CreateInstance()
		{
			return (RoleRenameWindow)UIPackage.CreateObject("SimpleUI","RoleRenameWindow");
		}

		public RoleRenameWindow()
		{
		}
		
		public bool Disposable
        {
            get;
            set;
        }

		public override void ConstructFromXML(XML xml)
		{
			base.ConstructFromXML(xml);

			m_BaseWindow = (WindowFrame)this.GetChildAt(0);
			m_IconLoader = (IconLoader)this.GetChildAt(1);
			m_BasicInput = (BasicInput)this.GetChildAt(2);
			m_RandomName = (OrangeButton)this.GetChildAt(3);
			m_StartGameButton = (OrangeButton)this.GetChildAt(4);
		}
	}
		

	public class RoleRenameWindowBundle: AssetBundleResName
    {
		public string ResName { get { return "RoleRenameWindow"; } }
		
    }
	
	public partial class AssetBundleResNameFactory
    {
        public static AssetBundleResName CreateRoleRenameWindowResName()
        {
            return new RoleRenameWindowBundle();
        }
    }
	

     public class RoleRenameWindowUIMedia:UIMedia
    {
	    RoleRenameWindow instace;
        public GComponent Inject()
        {
			if(instace != null) return instace;
            instace = RoleRenameWindow.CreateInstance();
			instace.Disposable = false;
            new RoleRenameWindowMedia().Init(instace);
			return instace;
        }		
    }
		
	public class RoleRenameWindowWindowName : WindowName
    {
        public string Key
        {
            get
            {
                return "RoleRenameWindow";
            }
        }
    }
	
	public partial class WindowNameFactory
    {
        public static WindowName GetRoleRenameWindowName()
        {
            return new RoleRenameWindowWindowName();
        }
    }


    public partial class RoleRenameWindowMedia
    {
        public void Init(RoleRenameWindow instace)
        {
			InitInstance(instace);
        }
		
	
		
        partial void InitInstance(RoleRenameWindow instace);		
    }

	public partial class CreateInstanceMapping
    {
        public void RoleRenameWindowMapping()
        {
            WindowManage.GetInstance.AllWindows.Add(new RoleRenameWindowWindowName().Key, new RoleRenameWindowUIMedia());
        }
    }	
}