/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace SimpleUI
{
	public partial class SkyButton : GButton,UIMdeiaDispose
	{
		public Controller m_button;
		public GImage m_n0;
		public GImage m_n1;
		public GImage m_n2;
		public GImage m_n3;
		public GTextField m_title;

		public const string URL = "ui://wmafp3a9iicjl";
		

		
		public static SkyButton CreateInstance()
		{
			return (SkyButton)UIPackage.CreateObject("SimpleUI","SkyButton");
		}

		public SkyButton()
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
		

	public class SkyButtonBundle: AssetBundleResName
    {
		public string ResName { get { return "SkyButton"; } }
		
    }

     public class SkyButtonUIMedia:UIMedia
    {
	    SkyButton instace;
        public GComponent Inject()
        {
			if(instace != null) return instace;
            instace = SkyButton.CreateInstance();
			instace.Disposable = false;
            new SkyButtonMedia().Init(instace);
			return instace;
        }		
    }
		
	public class SkyButtonWindowName : WindowName
    {
        public string Key
        {
            get
            {
                return "SkyButton";
            }
        }
    }
	
	public partial class WindowNameFactory
    {
        public static WindowName GetSkyButtonName()
        {
            return new SkyButtonWindowName();
        }
    }


    public partial class SkyButtonMedia
    {
        public void Init(SkyButton instace)
        {
			InitInstance(instace);
        }
		
	
		
        partial void InitInstance(SkyButton instace);		
    }

	public partial class CreateInstanceMapping
    {
        public void SkyButtonMapping()
        {
            WindowManage.GetInstance.AllWindows.Add(new SkyButtonWindowName().Key, new SkyButtonUIMedia());
        }
    }	
}