/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace SimpleUI
{
	public partial class UpgradeRewardWindow : GComponent,UIMdeiaDispose
	{
		public WindowFrame m_BaseWindow;

		public const string URL = "ui://wmafp3a9p9bq2a";
		

		
		public static UpgradeRewardWindow CreateInstance()
		{
			return (UpgradeRewardWindow)UIPackage.CreateObject("SimpleUI","UpgradeRewardWindow");
		}

		public UpgradeRewardWindow()
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
		

	public class UpgradeRewardWindowBundle: AssetBundleResName
    {
		public string ResName { get { return "UpgradeRewardWindow"; } }
		
    }
	
	public partial class AssetBundleResNameFactory
    {
        public static AssetBundleResName CreateUpgradeRewardWindowResName()
        {
            return new UpgradeRewardWindowBundle();
        }
    }
	

     public class UpgradeRewardWindowUIMedia:UIMedia
    {
	    UpgradeRewardWindow instace;
        public GComponent Inject()
        {
			if(instace != null) return instace;
            instace = UpgradeRewardWindow.CreateInstance();
			instace.Disposable = false;
            new UpgradeRewardWindowMedia().Init(instace);
			return instace;
        }		
    }
		
	public class UpgradeRewardWindowWindowName : WindowName
    {
        public string Key
        {
            get
            {
                return "UpgradeRewardWindow";
            }
        }
    }
	
	public partial class WindowNameFactory
    {
        public static WindowName GetUpgradeRewardWindowName()
        {
            return new UpgradeRewardWindowWindowName();
        }
    }


    public partial class UpgradeRewardWindowMedia
    {
        public void Init(UpgradeRewardWindow instace)
        {
			InitInstance(instace);
        }
		
	
		
        partial void InitInstance(UpgradeRewardWindow instace);		
    }

	public partial class CreateInstanceMapping
    {
        public void UpgradeRewardWindowMapping()
        {
            WindowManage.GetInstance.AllWindows.Add(new UpgradeRewardWindowWindowName().Key, new UpgradeRewardWindowUIMedia());
        }
    }	
}