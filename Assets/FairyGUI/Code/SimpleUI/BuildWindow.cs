/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace SimpleUI
{
	public partial class BuildWindow : GComponent,UIMdeiaDispose
	{
		public WindowFrame m_BaseWindow;

		public const string URL = "ui://wmafp3a9p9bq1q";
		

		
		public static BuildWindow CreateInstance()
		{
			return (BuildWindow)UIPackage.CreateObject("SimpleUI","BuildWindow");
		}

		public BuildWindow()
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
		

	public class BuildWindowBundle: AssetBundleResName
    {
		public string ResName { get { return "BuildWindow"; } }
		
    }
	
	public partial class AssetBundleResNameFactory
    {
        public static AssetBundleResName CreateBuildWindowResName()
        {
            return new BuildWindowBundle();
        }
    }
	

     public class BuildWindowUIMedia:UIMedia
    {
	    BuildWindow instace;
        public GComponent Inject()
        {
			if(instace != null) return instace;
            instace = BuildWindow.CreateInstance();
			instace.Disposable = false;
            new BuildWindowMedia().Init(instace);
			return instace;
        }		
    }
		
	public class BuildWindowWindowName : WindowName
    {
        public string Key
        {
            get
            {
                return "BuildWindow";
            }
        }
    }
	
	public partial class WindowNameFactory
    {
        public static WindowName GetBuildWindowName()
        {
            return new BuildWindowWindowName();
        }
    }


    public partial class BuildWindowMedia
    {
        public void Init(BuildWindow instace)
        {
			InitInstance(instace);
        }
		
	
		
        partial void InitInstance(BuildWindow instace);		
    }

	public partial class CreateInstanceMapping
    {
        public void BuildWindowMapping()
        {
            WindowManage.GetInstance.AllWindows.Add(new BuildWindowWindowName().Key, new BuildWindowUIMedia());
        }
    }	
}