/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace SimpleUI
{
	public partial class RedButton : GButton,UIMdeiaDispose
	{
		public Controller m_button;
		public GImage m_n0;
		public GImage m_n1;
		public GImage m_n2;
		public GImage m_n3;
		public GTextField m_title;

		public const string URL = "ui://wmafp3a9iicjk";
		

		
		public static RedButton CreateInstance()
		{
			return (RedButton)UIPackage.CreateObject("SimpleUI","RedButton");
		}

		public RedButton()
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
		

	public class RedButtonBundle: AssetBundleResName
    {
		public string ResName { get { return "RedButton"; } }
		
    }
	
	public partial class AssetBundleResNameFactory
    {
        public static AssetBundleResName CreateRedButtonResName()
        {
            return new RedButtonBundle();
        }
    }
	

     public class RedButtonUIMedia:UIMedia
    {
	    RedButton instace;
        public GComponent Inject()
        {
			if(instace != null) return instace;
            instace = RedButton.CreateInstance();
			instace.Disposable = false;
            new RedButtonMedia().Init(instace);
			return instace;
        }		
    }
		
	public class RedButtonWindowName : WindowName
    {
        public string Key
        {
            get
            {
                return "RedButton";
            }
        }
    }
	
	public partial class WindowNameFactory
    {
        public static WindowName GetRedButtonName()
        {
            return new RedButtonWindowName();
        }
    }


    public partial class RedButtonMedia
    {
        public void Init(RedButton instace)
        {
			InitInstance(instace);
        }
		
	
		
        partial void InitInstance(RedButton instace);		
    }

	public partial class CreateInstanceMapping
    {
        public void RedButtonMapping()
        {
            WindowManage.GetInstance.AllWindows.Add(new RedButtonWindowName().Key, new RedButtonUIMedia());
        }
    }	
}