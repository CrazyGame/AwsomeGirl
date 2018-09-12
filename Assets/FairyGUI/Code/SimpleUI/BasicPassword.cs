/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace SimpleUI
{
	public partial class BasicPassword : GLabel,UIMdeiaDispose
	{
		public GImage m_BackGround;
		public GTextInput m_InputContent;
		public GTextField m_Title;

		public const string URL = "ui://wmafp3a9hv92v";
		

		
		public static BasicPassword CreateInstance()
		{
			return (BasicPassword)UIPackage.CreateObject("SimpleUI","BasicPassword");
		}

		public BasicPassword()
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

			m_BackGround = (GImage)this.GetChildAt(0);
			m_InputContent = (GTextInput)this.GetChildAt(1);
			m_Title = (GTextField)this.GetChildAt(2);
		}
	}
		

	public class BasicPasswordBundle: FairyGUIBundle
    {
		public string ResName { get { return "BasicPassword"; } }
		
    }

     public class BasicPasswordUIMedia:UIMedia
    {
	    BasicPassword instace;
        public GComponent Inject()
        {
			if(instace != null) return instace;
            instace = BasicPassword.CreateInstance();
			instace.Disposable = false;
            new BasicPasswordMedia().Init(instace);
			return instace;
        }
		
		
    }
		
	 public class BasicPasswordWindowName : WindowName
    {
        public string Key
        {
            get
            {
                return "BasicPassword";
            }
        }
    }
	
	 public partial class WindowNameFactory
    {
        public static WindowName GetBasicPasswordName()
        {
            return new BasicPasswordWindowName();
        }
    }


    public partial class BasicPasswordMedia
    {
        BasicPassword window;
        public void Init(BasicPassword instace)
        {
            window = instace;
			InitInstance(instace);
        }
		
	
		
        partial void InitInstance(BasicPassword instace);		
    }

	public partial class CreateInstanceMapping
    {
        public void BasicPasswordMapping()
        {
            WindowManage.GetInstance.AllWindows.Add(new BasicPasswordWindowName().Key, new BasicPasswordUIMedia());
        }
    }
	
}