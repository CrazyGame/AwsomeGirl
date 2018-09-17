/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace SimpleUI
{
	public partial class CreateRoleWindow : GComponent,UIMdeiaDispose
	{
		public WindowFrame m_BaseWindow;
		public OrangeButton m_Next;
		public GList m_RoleList;
		public BasicText m_Detials;
		public BasicText m_HintText;
		public IconLoader m_IconLoader;

		public const string URL = "ui://wmafp3a9rxsvw";
		

		
		public static CreateRoleWindow CreateInstance()
		{
			return (CreateRoleWindow)UIPackage.CreateObject("SimpleUI","CreateRoleWindow");
		}

		public CreateRoleWindow()
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
			m_Next = (OrangeButton)this.GetChildAt(1);
			m_RoleList = (GList)this.GetChildAt(2);
			m_Detials = (BasicText)this.GetChildAt(3);
			m_HintText = (BasicText)this.GetChildAt(4);
			m_IconLoader = (IconLoader)this.GetChildAt(5);
		}
	}
		

	public class CreateRoleWindowBundle: AssetBundleResName
    {
		public string ResName { get { return "CreateRoleWindow"; } }
		
    }

     public class CreateRoleWindowUIMedia:UIMedia
    {
	    CreateRoleWindow instace;
        public GComponent Inject()
        {
			if(instace != null) return instace;
            instace = CreateRoleWindow.CreateInstance();
			instace.Disposable = false;
            new CreateRoleWindowMedia().Init(instace);
			return instace;
        }		
    }
		
	public class CreateRoleWindowWindowName : WindowName
    {
        public string Key
        {
            get
            {
                return "CreateRoleWindow";
            }
        }
    }
	
	public partial class WindowNameFactory
    {
        public static WindowName GetCreateRoleWindowName()
        {
            return new CreateRoleWindowWindowName();
        }
    }


    public partial class CreateRoleWindowMedia
    {
        public void Init(CreateRoleWindow instace)
        {
			InitInstance(instace);
        }
		
	
		
        partial void InitInstance(CreateRoleWindow instace);		
    }

	public partial class CreateInstanceMapping
    {
        public void CreateRoleWindowMapping()
        {
            WindowManage.GetInstance.AllWindows.Add(new CreateRoleWindowWindowName().Key, new CreateRoleWindowUIMedia());
        }
    }	
}