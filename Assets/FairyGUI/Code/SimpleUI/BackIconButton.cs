/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace SimpleUI
{
	public partial class BackIconButton : GButton,UIMdeiaDispose
	{
		public Controller m_button;
		public GImage m_n0;
		public GImage m_n1;
		public GImage m_n2;
		public GImage m_n3;

		public const string URL = "ui://wmafp3a9lgbt1i";
		

		
		public static BackIconButton CreateInstance()
		{
			return (BackIconButton)UIPackage.CreateObject("SimpleUI","BackIconButton");
		}

		public BackIconButton()
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
		}
	}
		

	public class BackIconButtonBundle: AssetBundleResName
    {
		public string ResName { get { return "BackIconButton"; } }
		
    }
	
	public partial class AssetBundleResNameFactory
    {
        public static AssetBundleResName CreateBackIconButtonResName()
        {
            return new BackIconButtonBundle();
        }
    }
	

     public class BackIconButtonUIMedia:UIMedia
    {
	    BackIconButton instace;
        public GComponent Inject()
        {
			if(instace != null) return instace;
            instace = BackIconButton.CreateInstance();
			instace.Disposable = false;
            new BackIconButtonMedia().Init(instace);
			return instace;
        }		
    }
		
	public class BackIconButtonWindowName : WindowName
    {
        public string Key
        {
            get
            {
                return "BackIconButton";
            }
        }
    }
	
	public partial class WindowNameFactory
    {
        public static WindowName GetBackIconButtonName()
        {
            return new BackIconButtonWindowName();
        }
    }


    public partial class BackIconButtonMedia
    {
        public void Init(BackIconButton instace)
        {
			InitInstance(instace);
        }
		
	
		
        partial void InitInstance(BackIconButton instace);		
    }

	public partial class CreateInstanceMapping
    {
        public void BackIconButtonMapping()
        {
            WindowManage.GetInstance.AllWindows.Add(new BackIconButtonWindowName().Key, new BackIconButtonUIMedia());
        }
    }	
}