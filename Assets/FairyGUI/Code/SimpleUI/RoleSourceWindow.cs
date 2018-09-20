/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace SimpleUI
{
	public partial class RoleSourceWindow : GComponent,UIMdeiaDispose
	{
		public WindowFrame m_BaseWindow;

		public const string URL = "ui://wmafp3a9p9bq26";
		

		
		public static RoleSourceWindow CreateInstance()
		{
			return (RoleSourceWindow)UIPackage.CreateObject("SimpleUI","RoleSourceWindow");
		}

		public RoleSourceWindow()
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
		}
	}
		

	public class RoleSourceWindowBundle: AssetBundleResName
    {
		public string ResName { get { return "RoleSourceWindow"; } }
		
    }
	
	public partial class AssetBundleResNameFactory
    {
        public static AssetBundleResName CreateRoleSourceWindowResName()
        {
            return new RoleSourceWindowBundle();
        }
    }
	

     public class RoleSourceWindowUIMedia:UIMedia
    {
	    RoleSourceWindow instace;
        public GComponent Inject()
        {
			if(instace != null) return instace;
            instace = RoleSourceWindow.CreateInstance();
			instace.Disposable = false;
            new RoleSourceWindowMedia().Init(instace);
			return instace;
        }		
    }
		
	public class RoleSourceWindowWindowName : WindowName
    {
        public string Key
        {
            get
            {
                return "RoleSourceWindow";
            }
        }
    }
	
	public partial class WindowNameFactory
    {
        public static WindowName GetRoleSourceWindowName()
        {
            return new RoleSourceWindowWindowName();
        }
    }


    public partial class RoleSourceWindowMedia
    {
        public void Init(RoleSourceWindow instace)
        {
			InitInstance(instace);
        }
		
	
		
        partial void InitInstance(RoleSourceWindow instace);		
    }

	public partial class CreateInstanceMapping
    {
        public void RoleSourceWindowMapping()
        {
            WindowManage.GetInstance.AllWindows.Add(new RoleSourceWindowWindowName().Key, new RoleSourceWindowUIMedia());
        }
    }	
}