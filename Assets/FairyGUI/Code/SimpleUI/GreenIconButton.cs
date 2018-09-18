/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace SimpleUI
{
	public partial class GreenIconButton : GButton,UIMdeiaDispose
	{
		public Controller m_button;
		public GImage m_n0;
		public GImage m_n1;
		public GImage m_n2;
		public GImage m_n3;
		public GLoader m_icon;

		public const string URL = "ui://wmafp3a9rxsvx";
		

		
		public static GreenIconButton CreateInstance()
		{
			return (GreenIconButton)UIPackage.CreateObject("SimpleUI","GreenIconButton");
		}

		public GreenIconButton()
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
			m_icon = (GLoader)this.GetChildAt(4);
		}
	}
		

	public class GreenIconButtonBundle: AssetBundleResName
    {
		public string ResName { get { return "GreenIconButton"; } }
		
    }
	
	public partial class AssetBundleResNameFactory
    {
        public static AssetBundleResName CreateGreenIconButtonResName()
        {
            return new GreenIconButtonBundle();
        }
    }
	

     public class GreenIconButtonUIMedia:UIMedia
    {
	    GreenIconButton instace;
        public GComponent Inject()
        {
			if(instace != null) return instace;
            instace = GreenIconButton.CreateInstance();
			instace.Disposable = false;
            new GreenIconButtonMedia().Init(instace);
			return instace;
        }		
    }
		
	public class GreenIconButtonWindowName : WindowName
    {
        public string Key
        {
            get
            {
                return "GreenIconButton";
            }
        }
    }
	
	public partial class WindowNameFactory
    {
        public static WindowName GetGreenIconButtonName()
        {
            return new GreenIconButtonWindowName();
        }
    }


    public partial class GreenIconButtonMedia
    {
        public void Init(GreenIconButton instace)
        {
			InitInstance(instace);
        }
		
	
		
        partial void InitInstance(GreenIconButton instace);		
    }

	public partial class CreateInstanceMapping
    {
        public void GreenIconButtonMapping()
        {
            WindowManage.GetInstance.AllWindows.Add(new GreenIconButtonWindowName().Key, new GreenIconButtonUIMedia());
        }
    }	
}