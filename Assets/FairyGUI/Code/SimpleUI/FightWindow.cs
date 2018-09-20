/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace SimpleUI
{
	public partial class FightWindow : GComponent,UIMdeiaDispose
	{
		public WindowFrame m_BaseWindow;

		public const string URL = "ui://wmafp3a9p9bq1r";
		

		
		public static FightWindow CreateInstance()
		{
			return (FightWindow)UIPackage.CreateObject("SimpleUI","FightWindow");
		}

		public FightWindow()
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
		

	public class FightWindowBundle: AssetBundleResName
    {
		public string ResName { get { return "FightWindow"; } }
		
    }
	
	public partial class AssetBundleResNameFactory
    {
        public static AssetBundleResName CreateFightWindowResName()
        {
            return new FightWindowBundle();
        }
    }
	

     public class FightWindowUIMedia:UIMedia
    {
	    FightWindow instace;
        public GComponent Inject()
        {
			if(instace != null) return instace;
            instace = FightWindow.CreateInstance();
			instace.Disposable = false;
            new FightWindowMedia().Init(instace);
			return instace;
        }		
    }
		
	public class FightWindowWindowName : WindowName
    {
        public string Key
        {
            get
            {
                return "FightWindow";
            }
        }
    }
	
	public partial class WindowNameFactory
    {
        public static WindowName GetFightWindowName()
        {
            return new FightWindowWindowName();
        }
    }


    public partial class FightWindowMedia
    {
        public void Init(FightWindow instace)
        {
			InitInstance(instace);
        }
		
	
		
        partial void InitInstance(FightWindow instace);		
    }

	public partial class CreateInstanceMapping
    {
        public void FightWindowMapping()
        {
            WindowManage.GetInstance.AllWindows.Add(new FightWindowWindowName().Key, new FightWindowUIMedia());
        }
    }	
}