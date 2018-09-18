/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace SimpleUI
{
	public partial class GreenButton : GButton,UIMdeiaDispose
	{
		public Controller m_button;
		public GImage m_n0;
		public GImage m_n1;
		public GImage m_n2;
		public GImage m_n3;
		public GTextField m_title;

		public const string URL = "ui://wmafp3a9iicjg";
		

		
		public static GreenButton CreateInstance()
		{
			return (GreenButton)UIPackage.CreateObject("SimpleUI","GreenButton");
		}

		public GreenButton()
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
			m_n0 = (GImage)this.GetChildAt(0);
			m_n1 = (GImage)this.GetChildAt(1);
			m_n2 = (GImage)this.GetChildAt(2);
			m_n3 = (GImage)this.GetChildAt(3);
			m_title = (GTextField)this.GetChildAt(4);
		}
	}
		

	public class GreenButtonBundle: AssetBundleResName
    {
		public string ResName { get { return "GreenButton"; } }
		
    }
	
	public partial class AssetBundleResNameFactory
    {
        public static AssetBundleResName CreateGreenButtonResName()
        {
            return new GreenButtonBundle();
        }
    }
	

     public class GreenButtonUIMedia:UIMedia
    {
	    GreenButton instace;
        public GComponent Inject()
        {
			if(instace != null) return instace;
            instace = GreenButton.CreateInstance();
			instace.Disposable = false;
            new GreenButtonMedia().Init(instace);
			return instace;
        }		
    }
		
	public class GreenButtonWindowName : WindowName
    {
        public string Key
        {
            get
            {
                return "GreenButton";
            }
        }
    }
	
	public partial class WindowNameFactory
    {
        public static WindowName GetGreenButtonName()
        {
            return new GreenButtonWindowName();
        }
    }


    public partial class GreenButtonMedia
    {
        public void Init(GreenButton instace)
        {
			InitInstance(instace);
        }
		
	
		
        partial void InitInstance(GreenButton instace);		
    }

	public partial class CreateInstanceMapping
    {
        public void GreenButtonMapping()
        {
            WindowManage.GetInstance.AllWindows.Add(new GreenButtonWindowName().Key, new GreenButtonUIMedia());
        }
    }	
}