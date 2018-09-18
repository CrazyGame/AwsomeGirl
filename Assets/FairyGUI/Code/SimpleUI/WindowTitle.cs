/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace SimpleUI
{
	public partial class WindowTitle : GLabel,UIMdeiaDispose
	{
		public GImage m_BackGround;
		public GTextField m_Title;

		public const string URL = "ui://wmafp3a9iicjq";
		

		
		public static WindowTitle CreateInstance()
		{
			return (WindowTitle)UIPackage.CreateObject("SimpleUI","WindowTitle");
		}

		public WindowTitle()
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
			m_Title = (GTextField)this.GetChildAt(1);
		}
	}
		

	public class WindowTitleBundle: AssetBundleResName
    {
		public string ResName { get { return "WindowTitle"; } }
		
    }
	
	public partial class AssetBundleResNameFactory
    {
        public static AssetBundleResName CreateWindowTitleResName()
        {
            return new WindowTitleBundle();
        }
    }
	

     public class WindowTitleUIMedia:UIMedia
    {
	    WindowTitle instace;
        public GComponent Inject()
        {
			if(instace != null) return instace;
            instace = WindowTitle.CreateInstance();
			instace.Disposable = false;
            new WindowTitleMedia().Init(instace);
			return instace;
        }		
    }
		
	public class WindowTitleWindowName : WindowName
    {
        public string Key
        {
            get
            {
                return "WindowTitle";
            }
        }
    }
	
	public partial class WindowNameFactory
    {
        public static WindowName GetWindowTitleName()
        {
            return new WindowTitleWindowName();
        }
    }


    public partial class WindowTitleMedia
    {
        public void Init(WindowTitle instace)
        {
			InitInstance(instace);
        }
		
	
		
        partial void InitInstance(WindowTitle instace);		
    }

	public partial class CreateInstanceMapping
    {
        public void WindowTitleMapping()
        {
            WindowManage.GetInstance.AllWindows.Add(new WindowTitleWindowName().Key, new WindowTitleUIMedia());
        }
    }	
}