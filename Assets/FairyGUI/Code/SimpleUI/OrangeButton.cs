/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace SimpleUI
{
	public partial class OrangeButton : GButton,UIMdeiaDispose
	{
		public Controller m_button;
		public GImage m_n0;
		public GImage m_n1;
		public GImage m_n2;
		public GImage m_n3;
		public GTextField m_title;

		public const string URL = "ui://wmafp3a9iicji";
		

		
		public static OrangeButton CreateInstance()
		{
			return (OrangeButton)UIPackage.CreateObject("SimpleUI","OrangeButton");
		}

		public OrangeButton()
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
		

	public class OrangeButtonBundle: FairyGUIBundle
    {
		public string ResName { get { return "OrangeButton"; } }
		
    }

     public class OrangeButtonUIMedia:UIMedia
    {
	    OrangeButton instace;
        public GComponent Inject()
        {
			if(instace != null) return instace;
            instace = OrangeButton.CreateInstance();
			instace.Disposable = false;
            new OrangeButtonMedia().Init(instace);
			return instace;
        }
		
		
    }
		
	 public class OrangeButtonWindowName : WindowName
    {
        public string Key
        {
            get
            {
                return "OrangeButton";
            }
        }
    }
	
	 public partial class WindowNameFactory
    {
        public static WindowName GetOrangeButtonName()
        {
            return new OrangeButtonWindowName();
        }
    }


    public partial class OrangeButtonMedia
    {
        OrangeButton window;
        public void Init(OrangeButton instace)
        {
            window = instace;
			InitInstance(instace);
        }
		
	
		
        partial void InitInstance(OrangeButton instace);		
    }

	public partial class CreateInstanceMapping
    {
        public void OrangeButtonMapping()
        {
            WindowManage.GetInstance.AllWindows.Add(new OrangeButtonWindowName().Key, new OrangeButtonUIMedia());
        }
    }
	
}