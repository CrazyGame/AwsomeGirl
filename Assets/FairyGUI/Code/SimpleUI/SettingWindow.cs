/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace SimpleUI
{
	public partial class SettingWindow : GComponent,UIMdeiaDispose
	{
		public WindowFrame m_BaseWindow;

		public const string URL = "ui://wmafp3a9p9bq27";
		

		
		public static SettingWindow CreateInstance()
		{
			return (SettingWindow)UIPackage.CreateObject("SimpleUI","SettingWindow");
		}

		public SettingWindow()
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
		

	public class SettingWindowBundle: AssetBundleResName
    {
		public string ResName { get { return "SettingWindow"; } }
		
    }
	
	public partial class AssetBundleResNameFactory
    {
        public static AssetBundleResName CreateSettingWindowResName()
        {
            return new SettingWindowBundle();
        }
    }
	

     public class SettingWindowUIMedia:UIMedia
    {
	    SettingWindow instace;
        public GComponent Inject()
        {
			if(instace != null) return instace;
            instace = SettingWindow.CreateInstance();
			instace.Disposable = false;
            new SettingWindowMedia().Init(instace);
			return instace;
        }		
    }
		
	public class SettingWindowWindowName : WindowName
    {
        public string Key
        {
            get
            {
                return "SettingWindow";
            }
        }
    }
	
	public partial class WindowNameFactory
    {
        public static WindowName GetSettingWindowName()
        {
            return new SettingWindowWindowName();
        }
    }


    public partial class SettingWindowMedia
    {
        public void Init(SettingWindow instace)
        {
			InitInstance(instace);
        }
		
	
		
        partial void InitInstance(SettingWindow instace);		
    }

	public partial class CreateInstanceMapping
    {
        public void SettingWindowMapping()
        {
            WindowManage.GetInstance.AllWindows.Add(new SettingWindowWindowName().Key, new SettingWindowUIMedia());
        }
    }	
}