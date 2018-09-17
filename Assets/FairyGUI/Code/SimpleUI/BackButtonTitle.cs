/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace SimpleUI
{
	public partial class BackButtonTitle : GComponent,UIMdeiaDispose
	{
		public BackIconButton m_BackButton;
		public GTextField m_Title;

		public const string URL = "ui://wmafp3a9lgbt1j";
		

		
		public static BackButtonTitle CreateInstance()
		{
			return (BackButtonTitle)UIPackage.CreateObject("SimpleUI","BackButtonTitle");
		}

		public BackButtonTitle()
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

			m_BackButton = (BackIconButton)this.GetChildAt(0);
			m_Title = (GTextField)this.GetChildAt(1);
		}
	}
		

	public class BackButtonTitleBundle: AssetBundleResName
    {
		public string ResName { get { return "BackButtonTitle"; } }
		
    }

     public class BackButtonTitleUIMedia:UIMedia
    {
	    BackButtonTitle instace;
        public GComponent Inject()
        {
			if(instace != null) return instace;
            instace = BackButtonTitle.CreateInstance();
			instace.Disposable = false;
            new BackButtonTitleMedia().Init(instace);
			return instace;
        }		
    }
		
	public class BackButtonTitleWindowName : WindowName
    {
        public string Key
        {
            get
            {
                return "BackButtonTitle";
            }
        }
    }
	
	public partial class WindowNameFactory
    {
        public static WindowName GetBackButtonTitleName()
        {
            return new BackButtonTitleWindowName();
        }
    }


    public partial class BackButtonTitleMedia
    {
        public void Init(BackButtonTitle instace)
        {
			InitInstance(instace);
        }
		
	
		
        partial void InitInstance(BackButtonTitle instace);		
    }

	public partial class CreateInstanceMapping
    {
        public void BackButtonTitleMapping()
        {
            WindowManage.GetInstance.AllWindows.Add(new BackButtonTitleWindowName().Key, new BackButtonTitleUIMedia());
        }
    }	
}