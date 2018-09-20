/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace SimpleUI
{
	public partial class FightRewardWindow : GComponent,UIMdeiaDispose
	{
		public WindowFrame m_BaseWindow;

		public const string URL = "ui://wmafp3a9p9bq1v";
		

		
		public static FightRewardWindow CreateInstance()
		{
			return (FightRewardWindow)UIPackage.CreateObject("SimpleUI","FightRewardWindow");
		}

		public FightRewardWindow()
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
		

	public class FightRewardWindowBundle: AssetBundleResName
    {
		public string ResName { get { return "FightRewardWindow"; } }
		
    }
	
	public partial class AssetBundleResNameFactory
    {
        public static AssetBundleResName CreateFightRewardWindowResName()
        {
            return new FightRewardWindowBundle();
        }
    }
	

     public class FightRewardWindowUIMedia:UIMedia
    {
	    FightRewardWindow instace;
        public GComponent Inject()
        {
			if(instace != null) return instace;
            instace = FightRewardWindow.CreateInstance();
			instace.Disposable = false;
            new FightRewardWindowMedia().Init(instace);
			return instace;
        }		
    }
		
	public class FightRewardWindowWindowName : WindowName
    {
        public string Key
        {
            get
            {
                return "FightRewardWindow";
            }
        }
    }
	
	public partial class WindowNameFactory
    {
        public static WindowName GetFightRewardWindowName()
        {
            return new FightRewardWindowWindowName();
        }
    }


    public partial class FightRewardWindowMedia
    {
        public void Init(FightRewardWindow instace)
        {
			InitInstance(instace);
        }
		
	
		
        partial void InitInstance(FightRewardWindow instace);		
    }

	public partial class CreateInstanceMapping
    {
        public void FightRewardWindowMapping()
        {
            WindowManage.GetInstance.AllWindows.Add(new FightRewardWindowWindowName().Key, new FightRewardWindowUIMedia());
        }
    }	
}