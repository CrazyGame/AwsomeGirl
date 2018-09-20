/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace SimpleUI
{
	public partial class FirstPayRewardWindow : GComponent,UIMdeiaDispose
	{
		public WindowFrame m_BaseWindow;

		public const string URL = "ui://wmafp3a9p9bq2b";
		

		
		public static FirstPayRewardWindow CreateInstance()
		{
			return (FirstPayRewardWindow)UIPackage.CreateObject("SimpleUI","FirstPayRewardWindow");
		}

		public FirstPayRewardWindow()
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
		

	public class FirstPayRewardWindowBundle: AssetBundleResName
    {
		public string ResName { get { return "FirstPayRewardWindow"; } }
		
    }
	
	public partial class AssetBundleResNameFactory
    {
        public static AssetBundleResName CreateFirstPayRewardWindowResName()
        {
            return new FirstPayRewardWindowBundle();
        }
    }
	

     public class FirstPayRewardWindowUIMedia:UIMedia
    {
	    FirstPayRewardWindow instace;
        public GComponent Inject()
        {
			if(instace != null) return instace;
            instace = FirstPayRewardWindow.CreateInstance();
			instace.Disposable = false;
            new FirstPayRewardWindowMedia().Init(instace);
			return instace;
        }		
    }
		
	public class FirstPayRewardWindowWindowName : WindowName
    {
        public string Key
        {
            get
            {
                return "FirstPayRewardWindow";
            }
        }
    }
	
	public partial class WindowNameFactory
    {
        public static WindowName GetFirstPayRewardWindowName()
        {
            return new FirstPayRewardWindowWindowName();
        }
    }


    public partial class FirstPayRewardWindowMedia
    {
        public void Init(FirstPayRewardWindow instace)
        {
			InitInstance(instace);
        }
		
	
		
        partial void InitInstance(FirstPayRewardWindow instace);		
    }

	public partial class CreateInstanceMapping
    {
        public void FirstPayRewardWindowMapping()
        {
            WindowManage.GetInstance.AllWindows.Add(new FirstPayRewardWindowWindowName().Key, new FirstPayRewardWindowUIMedia());
        }
    }	
}