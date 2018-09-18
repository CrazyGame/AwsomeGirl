/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace SimpleUI
{
	public partial class BasicText : GComponent,UIMdeiaDispose
	{
		public GImage m_BackGround;
		public GTextField m_TextContent;

		public const string URL = "ui://wmafp3a9rxsv18";
		

		
		public static BasicText CreateInstance()
		{
			return (BasicText)UIPackage.CreateObject("SimpleUI","BasicText");
		}

		public BasicText()
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
			m_TextContent = (GTextField)this.GetChildAt(1);
		}
	}
		

	public class BasicTextBundle: AssetBundleResName
    {
		public string ResName { get { return "BasicText"; } }
		
    }
	
	public partial class AssetBundleResNameFactory
    {
        public static AssetBundleResName CreateBasicTextResName()
        {
            return new BasicTextBundle();
        }
    }
	

     public class BasicTextUIMedia:UIMedia
    {
	    BasicText instace;
        public GComponent Inject()
        {
			if(instace != null) return instace;
            instace = BasicText.CreateInstance();
			instace.Disposable = false;
            new BasicTextMedia().Init(instace);
			return instace;
        }		
    }
		
	public class BasicTextWindowName : WindowName
    {
        public string Key
        {
            get
            {
                return "BasicText";
            }
        }
    }
	
	public partial class WindowNameFactory
    {
        public static WindowName GetBasicTextName()
        {
            return new BasicTextWindowName();
        }
    }


    public partial class BasicTextMedia
    {
        public void Init(BasicText instace)
        {
			InitInstance(instace);
        }
		
	
		
        partial void InitInstance(BasicText instace);		
    }

	public partial class CreateInstanceMapping
    {
        public void BasicTextMapping()
        {
            WindowManage.GetInstance.AllWindows.Add(new BasicTextWindowName().Key, new BasicTextUIMedia());
        }
    }	
}