/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace SimpleUI
{
	public partial class SimpleMainWindow : GComponent,UIMdeiaDispose
	{
		public GImage m_BackGround;
		public GreenButton m_FightButton;
		public GreenButton m_HomeButton;
		public GreenButton m_ModifyButton;
		public GreenButton m_BuildButton;
		public IconLoader m_RoleIcon;
		public GList m_ButtomButtons;
		public GList m_HideButtons;
		public GList m_TopValues;

		public const string URL = "ui://wmafp3a9qdiw1b";
		

		
		public static SimpleMainWindow CreateInstance()
		{
			return (SimpleMainWindow)UIPackage.CreateObject("SimpleUI","SimpleMainWindow");
		}

		public SimpleMainWindow()
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

			m_BackGround = (GImage)this.GetChildAt(0);
			m_FightButton = (GreenButton)this.GetChildAt(1);
			m_HomeButton = (GreenButton)this.GetChildAt(2);
			m_ModifyButton = (GreenButton)this.GetChildAt(3);
			m_BuildButton = (GreenButton)this.GetChildAt(4);
			m_RoleIcon = (IconLoader)this.GetChildAt(5);
			m_ButtomButtons = (GList)this.GetChildAt(6);
			m_HideButtons = (GList)this.GetChildAt(7);
			m_TopValues = (GList)this.GetChildAt(8);
		}
	}
		

	public class SimpleMainWindowBundle: AssetBundleResName
    {
		public string ResName { get { return "SimpleMainWindow"; } }
		
    }
	
	public partial class AssetBundleResNameFactory
    {
        public static AssetBundleResName CreateSimpleMainWindowResName()
        {
            return new SimpleMainWindowBundle();
        }
    }
	

     public class SimpleMainWindowUIMedia:UIMedia
    {
	    SimpleMainWindow instace;
        public GComponent Inject()
        {
			if(instace != null) return instace;
            instace = SimpleMainWindow.CreateInstance();
			instace.Disposable = false;
            new SimpleMainWindowMedia().Init(instace);
			return instace;
        }		
    }
		
	public class SimpleMainWindowWindowName : WindowName
    {
        public string Key
        {
            get
            {
                return "SimpleMainWindow";
            }
        }
    }
	
	public partial class WindowNameFactory
    {
        public static WindowName GetSimpleMainWindowName()
        {
            return new SimpleMainWindowWindowName();
        }
    }


    public partial class SimpleMainWindowMedia
    {
        public void Init(SimpleMainWindow instace)
        {
			InitInstance(instace);
        }
		
	
		
        partial void InitInstance(SimpleMainWindow instace);		
    }

	public partial class CreateInstanceMapping
    {
        public void SimpleMainWindowMapping()
        {
            WindowManage.GetInstance.AllWindows.Add(new SimpleMainWindowWindowName().Key, new SimpleMainWindowUIMedia());
        }
    }	
}