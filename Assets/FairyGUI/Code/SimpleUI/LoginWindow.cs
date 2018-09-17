/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace SimpleUI
{
	public partial class LoginWindow : GComponent,UIMdeiaDispose
	{
		public WindowFrame m_BaseWindow;
		public BasicInput m_Acount;
		public BasicPassword m_Password;
		public GreenButton m_LoginButton;

		public const string URL = "ui://wmafp3a9hv92r";
		

		
		public static LoginWindow CreateInstance()
		{
			return (LoginWindow)UIPackage.CreateObject("SimpleUI","LoginWindow");
		}

		public LoginWindow()
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
			m_Acount = (BasicInput)this.GetChildAt(1);
			m_Password = (BasicPassword)this.GetChildAt(2);
			m_LoginButton = (GreenButton)this.GetChildAt(3);
		}
	}
		

	public class LoginWindowBundle: AssetBundleResName
    {
		public string ResName { get { return "LoginWindow"; } }
		
    }

     public class LoginWindowUIMedia:UIMedia
    {
	    LoginWindow instace;
        public GComponent Inject()
        {
			if(instace != null) return instace;
            instace = LoginWindow.CreateInstance();
			instace.Disposable = false;
            new LoginWindowMedia().Init(instace);
			return instace;
        }		
    }
		
	public class LoginWindowWindowName : WindowName
    {
        public string Key
        {
            get
            {
                return "LoginWindow";
            }
        }
    }
	
	public partial class WindowNameFactory
    {
        public static WindowName GetLoginWindowName()
        {
            return new LoginWindowWindowName();
        }
    }


    public partial class LoginWindowMedia
    {
        public void Init(LoginWindow instace)
        {
			InitInstance(instace);
        }
		
	
		
        partial void InitInstance(LoginWindow instace);		
    }

	public partial class CreateInstanceMapping
    {
        public void LoginWindowMapping()
        {
            WindowManage.GetInstance.AllWindows.Add(new LoginWindowWindowName().Key, new LoginWindowUIMedia());
        }
    }	
}