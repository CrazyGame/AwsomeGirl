/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace SimpleUI
{
	public partial class IconTitleLoader : GComponent,UIMdeiaDispose
	{
		public GLoader m_Icon;
		public GTextField m_Amount;

		public const string URL = "ui://wmafp3a9p9bq2c";
		

		
		public static IconTitleLoader CreateInstance()
		{
			return (IconTitleLoader)UIPackage.CreateObject("SimpleUI","IconTitleLoader");
		}

		public IconTitleLoader()
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
			m_Amount = (GTextField)this.GetChildAt(1);
		}
	}
		

	public class IconTitleLoaderBundle: AssetBundleResName
    {
		public string ResName { get { return "IconTitleLoader"; } }
		
    }
	
	public partial class AssetBundleResNameFactory
    {
        public static AssetBundleResName CreateIconTitleLoaderResName()
        {
            return new IconTitleLoaderBundle();
        }
    }
	

     public class IconTitleLoaderUIMedia:UIMedia
    {
	    IconTitleLoader instace;
        public GComponent Inject()
        {
			if(instace != null) return instace;
            instace = IconTitleLoader.CreateInstance();
			instace.Disposable = false;
            new IconTitleLoaderMedia().Init(instace);
			return instace;
        }		
    }
		
	public class IconTitleLoaderWindowName : WindowName
    {
        public string Key
        {
            get
            {
                return "IconTitleLoader";
            }
        }
    }
	
	public partial class WindowNameFactory
    {
        public static WindowName GetIconTitleLoaderName()
        {
            return new IconTitleLoaderWindowName();
        }
    }


    public partial class IconTitleLoaderMedia
    {
        public void Init(IconTitleLoader instace)
        {
			InitInstance(instace);
        }
		
	
		
        partial void InitInstance(IconTitleLoader instace);		
    }

	public partial class CreateInstanceMapping
    {
        public void IconTitleLoaderMapping()
        {
            WindowManage.GetInstance.AllWindows.Add(new IconTitleLoaderWindowName().Key, new IconTitleLoaderUIMedia());
        }
    }	
}