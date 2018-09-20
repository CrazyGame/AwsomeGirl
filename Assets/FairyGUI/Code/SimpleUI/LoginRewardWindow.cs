/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace SimpleUI
{
	public partial class LoginRewardWindow : GComponent,UIMdeiaDispose
	{
		public WindowFrame m_BaseWindow;

		public const string URL = "ui://wmafp3a9p9bq29";
		

		
		public static LoginRewardWindow CreateInstance()
		{
			return (LoginRewardWindow)UIPackage.CreateObject("SimpleUI","LoginRewardWindow");
		}

		public LoginRewardWindow()
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
		

	public class LoginRewardWindowBundle: AssetBundleResName
    {
		public string ResName { get { return "LoginRewardWindow"; } }
		
    }
	
	public partial class AssetBundleResNameFactory
    {
        public static AssetBundleResName CreateLoginRewardWindowResName()
        {
            return new LoginRewardWindowBundle();
        }
    }
	

     public class LoginRewardWindowUIMedia:UIMedia
    {
	    LoginRewardWindow instace;
        public GComponent Inject()
        {
			if(instace != null) return instace;
            instace = LoginRewardWindow.CreateInstance();
			instace.Disposable = false;
            new LoginRewardWindowMedia().Init(instace);
			return instace;
        }		
    }
		
	public class LoginRewardWindowWindowName : WindowName
    {
        public string Key
        {
            get
            {
                return "LoginRewardWindow";
            }
        }
    }
	
	public partial class WindowNameFactory
    {
        public static WindowName GetLoginRewardWindowName()
        {
            return new LoginRewardWindowWindowName();
        }
    }


    public partial class LoginRewardWindowMedia
    {
        public void Init(LoginRewardWindow instace)
        {
			InitInstance(instace);
        }
		
	
		
        partial void InitInstance(LoginRewardWindow instace);		
    }

	public partial class CreateInstanceMapping
    {
        public void LoginRewardWindowMapping()
        {
            WindowManage.GetInstance.AllWindows.Add(new LoginRewardWindowWindowName().Key, new LoginRewardWindowUIMedia());
        }
    }	
}