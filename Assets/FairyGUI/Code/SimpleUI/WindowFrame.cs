/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace SimpleUI
{
	public partial class WindowFrame : GComponent,UIMdeiaDispose
	{
		public GImage m_BackGround;
		public GImage m_WindowArea;
		public WindowTitle m_BaseWindow;
		public BackButtonTitle m_BackTitleButton;

		public const string URL = "ui://wmafp3a9iicjh";
		

		
		public static WindowFrame CreateInstance()
		{
			return (WindowFrame)UIPackage.CreateObject("SimpleUI","WindowFrame");
		}

		public WindowFrame()
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
			m_WindowArea = (GImage)this.GetChildAt(1);
			m_BaseWindow = (WindowTitle)this.GetChildAt(2);
			m_BackTitleButton = (BackButtonTitle)this.GetChildAt(3);
		}
	}
		

	public class WindowFrameBundle: AssetBundleResName
    {
		public string ResName { get { return "WindowFrame"; } }
		
    }
	
	public partial class AssetBundleResNameFactory
    {
        public static AssetBundleResName CreateWindowFrameResName()
        {
            return new WindowFrameBundle();
        }
    }
	

     public class WindowFrameUIMedia:UIMedia
    {
	    WindowFrame instace;
        public GComponent Inject()
        {
			if(instace != null) return instace;
            instace = WindowFrame.CreateInstance();
			instace.Disposable = false;
            new WindowFrameMedia().Init(instace);
			return instace;
        }		
    }
		
	public class WindowFrameWindowName : WindowName
    {
        public string Key
        {
            get
            {
                return "WindowFrame";
            }
        }
    }
	
	public partial class WindowNameFactory
    {
        public static WindowName GetWindowFrameName()
        {
            return new WindowFrameWindowName();
        }
    }


    public partial class WindowFrameMedia
    {
        public void Init(WindowFrame instace)
        {
			InitInstance(instace);
        }
		
	
		
        partial void InitInstance(WindowFrame instace);		
    }

	public partial class CreateInstanceMapping
    {
        public void WindowFrameMapping()
        {
            WindowManage.GetInstance.AllWindows.Add(new WindowFrameWindowName().Key, new WindowFrameUIMedia());
        }
    }	
}