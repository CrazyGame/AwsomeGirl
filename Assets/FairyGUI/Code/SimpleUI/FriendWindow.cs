/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace SimpleUI
{
	public partial class FriendWindow : GComponent,UIMdeiaDispose
	{
		public WindowFrame m_BaseWindow;

		public const string URL = "ui://wmafp3a9p9bq1x";
		

		
		public static FriendWindow CreateInstance()
		{
			return (FriendWindow)UIPackage.CreateObject("SimpleUI","FriendWindow");
		}

		public FriendWindow()
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
		

	public class FriendWindowBundle: AssetBundleResName
    {
		public string ResName { get { return "FriendWindow"; } }
		
    }
	
	public partial class AssetBundleResNameFactory
    {
        public static AssetBundleResName CreateFriendWindowResName()
        {
            return new FriendWindowBundle();
        }
    }
	

     public class FriendWindowUIMedia:UIMedia
    {
	    FriendWindow instace;
        public GComponent Inject()
        {
			if(instace != null) return instace;
            instace = FriendWindow.CreateInstance();
			instace.Disposable = false;
            new FriendWindowMedia().Init(instace);
			return instace;
        }		
    }
		
	public class FriendWindowWindowName : WindowName
    {
        public string Key
        {
            get
            {
                return "FriendWindow";
            }
        }
    }
	
	public partial class WindowNameFactory
    {
        public static WindowName GetFriendWindowName()
        {
            return new FriendWindowWindowName();
        }
    }


    public partial class FriendWindowMedia
    {
        public void Init(FriendWindow instace)
        {
			InitInstance(instace);
        }
		
	
		
        partial void InitInstance(FriendWindow instace);		
    }

	public partial class CreateInstanceMapping
    {
        public void FriendWindowMapping()
        {
            WindowManage.GetInstance.AllWindows.Add(new FriendWindowWindowName().Key, new FriendWindowUIMedia());
        }
    }	
}