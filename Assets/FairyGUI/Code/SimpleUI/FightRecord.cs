/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace SimpleUI
{
	public partial class FightRecord : GComponent,UIMdeiaDispose
	{
		public WindowFrame m_BaseWindow;

		public const string URL = "ui://wmafp3a9p9bq1z";
		

		
		public static FightRecord CreateInstance()
		{
			return (FightRecord)UIPackage.CreateObject("SimpleUI","FightRecord");
		}

		public FightRecord()
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
		

	public class FightRecordBundle: AssetBundleResName
    {
		public string ResName { get { return "FightRecord"; } }
		
    }
	
	public partial class AssetBundleResNameFactory
    {
        public static AssetBundleResName CreateFightRecordResName()
        {
            return new FightRecordBundle();
        }
    }
	

     public class FightRecordUIMedia:UIMedia
    {
	    FightRecord instace;
        public GComponent Inject()
        {
			if(instace != null) return instace;
            instace = FightRecord.CreateInstance();
			instace.Disposable = false;
            new FightRecordMedia().Init(instace);
			return instace;
        }		
    }
		
	public class FightRecordWindowName : WindowName
    {
        public string Key
        {
            get
            {
                return "FightRecord";
            }
        }
    }
	
	public partial class WindowNameFactory
    {
        public static WindowName GetFightRecordName()
        {
            return new FightRecordWindowName();
        }
    }


    public partial class FightRecordMedia
    {
        public void Init(FightRecord instace)
        {
			InitInstance(instace);
        }
		
	
		
        partial void InitInstance(FightRecord instace);		
    }

	public partial class CreateInstanceMapping
    {
        public void FightRecordMapping()
        {
            WindowManage.GetInstance.AllWindows.Add(new FightRecordWindowName().Key, new FightRecordUIMedia());
        }
    }	
}