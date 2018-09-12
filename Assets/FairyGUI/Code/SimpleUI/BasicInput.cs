/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace SimpleUI
{
	public partial class BasicInput : GLabel,UIMdeiaDispose
	{
		public GImage m_BackGround;
		public GTextInput m_InputContent;
		public GTextField m_Title;

		public const string URL = "ui://wmafp3a9hv92u";
		

		
		public static BasicInput CreateInstance()
		{
			return (BasicInput)UIPackage.CreateObject("SimpleUI","BasicInput");
		}

		public BasicInput()
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
		

	public class BasicInputBundle: FairyGUIBundle
    {
		public string ResName { get { return "BasicInput"; } }
		
    }

     public class BasicInputUIMedia:UIMedia
    {
	    BasicInput instace;
        public GComponent Inject()
        {
			if(instace != null) return instace;
            instace = BasicInput.CreateInstance();
			instace.Disposable = false;
            new BasicInputMedia().Init(instace);
			return instace;
        }
		
		
    }
		
	 public class BasicInputWindowName : WindowName
    {
        public string Key
        {
            get
            {
                return "BasicInput";
            }
        }
    }
	
	 public partial class WindowNameFactory
    {
        public static WindowName GetBasicInputName()
        {
            return new BasicInputWindowName();
        }
    }


    public partial class BasicInputMedia
    {
        BasicInput window;
        public void Init(BasicInput instace)
        {
            window = instace;
			InitInstance(instace);
        }
		
	
		
        partial void InitInstance(BasicInput instace);		
    }

	public partial class CreateInstanceMapping
    {
        public void BasicInputMapping()
        {
            WindowManage.GetInstance.AllWindows.Add(new BasicInputWindowName().Key, new BasicInputUIMedia());
        }
    }
	
}