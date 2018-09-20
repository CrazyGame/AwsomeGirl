/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace SimpleUI
{
	public partial class UpgradeWindow : GComponent,UIMdeiaDispose
	{
		public WindowFrame m_BaseWindow;

		public const string URL = "ui://wmafp3a9p9bq1s";
		

		
		public static UpgradeWindow CreateInstance()
		{
			return (UpgradeWindow)UIPackage.CreateObject("SimpleUI","UpgradeWindow");
		}

		public UpgradeWindow()
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
		

	public class UpgradeWindowBundle: AssetBundleResName
    {
		public string ResName { get { return "UpgradeWindow"; } }
		
    }
	
	public partial class AssetBundleResNameFactory
    {
        public static AssetBundleResName CreateUpgradeWindowResName()
        {
            return new UpgradeWindowBundle();
        }
    }
	

     public class UpgradeWindowUIMedia:UIMedia
    {
	    UpgradeWindow instace;
        public GComponent Inject()
        {
			if(instace != null) return instace;
            instace = UpgradeWindow.CreateInstance();
			instace.Disposable = false;
            new UpgradeWindowMedia().Init(instace);
			return instace;
        }		
    }
		
	public class UpgradeWindowWindowName : WindowName
    {
        public string Key
        {
            get
            {
                return "UpgradeWindow";
            }
        }
    }
	
	public partial class WindowNameFactory
    {
        public static WindowName GetUpgradeWindowName()
        {
            return new UpgradeWindowWindowName();
        }
    }


    public partial class UpgradeWindowMedia
    {
        public void Init(UpgradeWindow instace)
        {
			InitInstance(instace);
        }
		
	
		
        partial void InitInstance(UpgradeWindow instace);		
    }

	public partial class CreateInstanceMapping
    {
        public void UpgradeWindowMapping()
        {
            WindowManage.GetInstance.AllWindows.Add(new UpgradeWindowWindowName().Key, new UpgradeWindowUIMedia());
        }
    }	
}