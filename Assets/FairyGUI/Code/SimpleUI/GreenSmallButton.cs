/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace SimpleUI
{
	public partial class GreenSmallButton : GButton,UIMdeiaDispose
	{
		public Controller m_button;
		public GImage m_n0;
		public GImage m_n1;
		public GImage m_n2;
		public GImage m_n3;
		public GTextField m_title;
		public GImage m_n6;

		public const string URL = "ui://wmafp3a9iicjm";
		

		
		public static GreenSmallButton CreateInstance()
		{
			return (GreenSmallButton)UIPackage.CreateObject("SimpleUI","GreenSmallButton");
		}

		public GreenSmallButton()
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
			m_n6 = (GImage)this.GetChildAt(5);
		}
	}
		

	public class GreenSmallButtonBundle: FairyGUIBundle
    {
		public string ResName { get { return "GreenSmallButton"; } }
		
    }

     public class GreenSmallButtonUIMedia:UIMedia
    {
	    GreenSmallButton instace;
        public GComponent Inject()
        {
			if(instace != null) return instace;
            instace = GreenSmallButton.CreateInstance();
			instace.Disposable = false;
            new GreenSmallButtonMedia().Init(instace);
			return instace;
        }
		
		
    }
		
	 public class GreenSmallButtonWindowName : WindowName
    {
        public string Key
        {
            get
            {
                return "GreenSmallButton";
            }
        }
    }
	
	 public partial class WindowNameFactory
    {
        public static WindowName GetGreenSmallButtonName()
        {
            return new GreenSmallButtonWindowName();
        }
    }


    public partial class GreenSmallButtonMedia
    {
        GreenSmallButton window;
        public void Init(GreenSmallButton instace)
        {
            window = instace;
			InitInstance(instace);
        }
		
	
		
        partial void InitInstance(GreenSmallButton instace);		
    }

	public partial class CreateInstanceMapping
    {
        public void GreenSmallButtonMapping()
        {
            WindowManage.GetInstance.AllWindows.Add(new GreenSmallButtonWindowName().Key, new GreenSmallButtonUIMedia());
        }
    }
	
}