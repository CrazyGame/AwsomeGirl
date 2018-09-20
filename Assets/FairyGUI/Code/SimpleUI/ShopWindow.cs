/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace SimpleUI
{
	public partial class ShopWindow : GComponent,UIMdeiaDispose
	{
		public WindowFrame m_BaseWindow;

		public const string URL = "ui://wmafp3a9p9bq1u";
		

		
		public static ShopWindow CreateInstance()
		{
			return (ShopWindow)UIPackage.CreateObject("SimpleUI","ShopWindow");
		}

		public ShopWindow()
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
		

	public class ShopWindowBundle: AssetBundleResName
    {
		public string ResName { get { return "ShopWindow"; } }
		
    }
	
	public partial class AssetBundleResNameFactory
    {
        public static AssetBundleResName CreateShopWindowResName()
        {
            return new ShopWindowBundle();
        }
    }
	

     public class ShopWindowUIMedia:UIMedia
    {
	    ShopWindow instace;
        public GComponent Inject()
        {
			if(instace != null) return instace;
            instace = ShopWindow.CreateInstance();
			instace.Disposable = false;
            new ShopWindowMedia().Init(instace);
			return instace;
        }		
    }
		
	public class ShopWindowWindowName : WindowName
    {
        public string Key
        {
            get
            {
                return "ShopWindow";
            }
        }
    }
	
	public partial class WindowNameFactory
    {
        public static WindowName GetShopWindowName()
        {
            return new ShopWindowWindowName();
        }
    }


    public partial class ShopWindowMedia
    {
        public void Init(ShopWindow instace)
        {
			InitInstance(instace);
        }
		
	
		
        partial void InitInstance(ShopWindow instace);		
    }

	public partial class CreateInstanceMapping
    {
        public void ShopWindowMapping()
        {
            WindowManage.GetInstance.AllWindows.Add(new ShopWindowWindowName().Key, new ShopWindowUIMedia());
        }
    }	
}