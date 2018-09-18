/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace SimpleUI
{
	public partial class SkySmallButton : GButton,UIMdeiaDispose
	{
		public Controller m_button;
		public GImage m_BackIcon;
		public GTextField m_Title;

		public const string URL = "ui://wmafp3a9iicjm";
		

		
		public static SkySmallButton CreateInstance()
		{
			return (SkySmallButton)UIPackage.CreateObject("SimpleUI","SkySmallButton");
		}

		public SkySmallButton()
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

			m_button = this.GetControllerAt(0);
			m_BackIcon = (GImage)this.GetChildAt(0);
			m_Title = (GTextField)this.GetChildAt(1);
		}
	}
		

	public class SkySmallButtonBundle: AssetBundleResName
    {
		public string ResName { get { return "SkySmallButton"; } }
		
    }
	
	public partial class AssetBundleResNameFactory
    {
        public static AssetBundleResName CreateSkySmallButtonResName()
        {
            return new SkySmallButtonBundle();
        }
    }
	

     public class SkySmallButtonUIMedia:UIMedia
    {
	    SkySmallButton instace;
        public GComponent Inject()
        {
			if(instace != null) return instace;
            instace = SkySmallButton.CreateInstance();
			instace.Disposable = false;
            new SkySmallButtonMedia().Init(instace);
			return instace;
        }		
    }
		
	public class SkySmallButtonWindowName : WindowName
    {
        public string Key
        {
            get
            {
                return "SkySmallButton";
            }
        }
    }
	
	public partial class WindowNameFactory
    {
        public static WindowName GetSkySmallButtonName()
        {
            return new SkySmallButtonWindowName();
        }
    }


    public partial class SkySmallButtonMedia
    {
        public void Init(SkySmallButton instace)
        {
			InitInstance(instace);
        }
		
	
		
        partial void InitInstance(SkySmallButton instace);		
    }

	public partial class CreateInstanceMapping
    {
        public void SkySmallButtonMapping()
        {
            WindowManage.GetInstance.AllWindows.Add(new SkySmallButtonWindowName().Key, new SkySmallButtonUIMedia());
        }
    }	
}