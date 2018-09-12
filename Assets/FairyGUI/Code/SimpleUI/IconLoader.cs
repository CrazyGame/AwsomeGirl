/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace SimpleUI
{
	public partial class IconLoader : GComponent,UIMdeiaDispose
	{
		public GLoader m_Icon;

		public const string URL = "ui://wmafp3a9rxsv1a";
		

		
		public static IconLoader CreateInstance()
		{
			return (IconLoader)UIPackage.CreateObject("SimpleUI","IconLoader");
		}

		public IconLoader()
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

			m_Icon = (GLoader)this.GetChildAt(0);
		}
	}
		

	public class IconLoaderBundle: FairyGUIBundle
    {
		public string ResName { get { return "IconLoader"; } }
		
    }

     public class IconLoaderUIMedia:UIMedia
    {
	    IconLoader instace;
        public GComponent Inject()
        {
			if(instace != null) return instace;
            instace = IconLoader.CreateInstance();
			instace.Disposable = false;
            new IconLoaderMedia().Init(instace);
			return instace;
        }
		
		
    }
		
	 public class IconLoaderWindowName : WindowName
    {
        public string Key
        {
            get
            {
                return "IconLoader";
            }
        }
    }
	
	 public partial class WindowNameFactory
    {
        public static WindowName GetIconLoaderName()
        {
            return new IconLoaderWindowName();
        }
    }


    public partial class IconLoaderMedia
    {
        IconLoader window;
        public void Init(IconLoader instace)
        {
            window = instace;
			InitInstance(instace);
        }
		
	
		
        partial void InitInstance(IconLoader instace);		
    }

	public partial class CreateInstanceMapping
    {
        public void IconLoaderMapping()
        {
            WindowManage.GetInstance.AllWindows.Add(new IconLoaderWindowName().Key, new IconLoaderUIMedia());
        }
    }
	
}