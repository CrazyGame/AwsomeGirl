/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace SimpleUI
{
	public partial class BoadWindow : GComponent,UIMdeiaDispose
	{
		public WindowFrame m_BaseWindow;

		public const string URL = "ui://wmafp3a9p9bq1t";
		

		
		public static BoadWindow CreateInstance()
		{
			return (BoadWindow)UIPackage.CreateObject("SimpleUI","BoadWindow");
		}

		public BoadWindow()
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
		

	public class BoadWindowBundle: AssetBundleResName
    {
		public string ResName { get { return "BoadWindow"; } }
		
    }
	
	public partial class AssetBundleResNameFactory
    {
        public static AssetBundleResName CreateBoadWindowResName()
        {
            return new BoadWindowBundle();
        }
    }
	

     public class BoadWindowUIMedia:UIMedia
    {
	    BoadWindow instace;
        public GComponent Inject()
        {
			if(instace != null) return instace;
            instace = BoadWindow.CreateInstance();
			instace.Disposable = false;
            new BoadWindowMedia().Init(instace);
			return instace;
        }		
    }
		
	public class BoadWindowWindowName : WindowName
    {
        public string Key
        {
            get
            {
                return "BoadWindow";
            }
        }
    }
	
	public partial class WindowNameFactory
    {
        public static WindowName GetBoadWindowName()
        {
            return new BoadWindowWindowName();
        }
    }


    public partial class BoadWindowMedia
    {
        public void Init(BoadWindow instace)
        {
			InitInstance(instace);
        }
		
	
		
        partial void InitInstance(BoadWindow instace);		
    }

	public partial class CreateInstanceMapping
    {
        public void BoadWindowMapping()
        {
            WindowManage.GetInstance.AllWindows.Add(new BoadWindowWindowName().Key, new BoadWindowUIMedia());
        }
    }	
}