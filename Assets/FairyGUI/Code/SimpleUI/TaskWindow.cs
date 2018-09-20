/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace SimpleUI
{
	public partial class TaskWindow : GComponent,UIMdeiaDispose
	{
		public WindowFrame m_BaseWindow;

		public const string URL = "ui://wmafp3a9p9bq1w";
		

		
		public static TaskWindow CreateInstance()
		{
			return (TaskWindow)UIPackage.CreateObject("SimpleUI","TaskWindow");
		}

		public TaskWindow()
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
		

	public class TaskWindowBundle: AssetBundleResName
    {
		public string ResName { get { return "TaskWindow"; } }
		
    }
	
	public partial class AssetBundleResNameFactory
    {
        public static AssetBundleResName CreateTaskWindowResName()
        {
            return new TaskWindowBundle();
        }
    }
	

     public class TaskWindowUIMedia:UIMedia
    {
	    TaskWindow instace;
        public GComponent Inject()
        {
			if(instace != null) return instace;
            instace = TaskWindow.CreateInstance();
			instace.Disposable = false;
            new TaskWindowMedia().Init(instace);
			return instace;
        }		
    }
		
	public class TaskWindowWindowName : WindowName
    {
        public string Key
        {
            get
            {
                return "TaskWindow";
            }
        }
    }
	
	public partial class WindowNameFactory
    {
        public static WindowName GetTaskWindowName()
        {
            return new TaskWindowWindowName();
        }
    }


    public partial class TaskWindowMedia
    {
        public void Init(TaskWindow instace)
        {
			InitInstance(instace);
        }
		
	
		
        partial void InitInstance(TaskWindow instace);		
    }

	public partial class CreateInstanceMapping
    {
        public void TaskWindowMapping()
        {
            WindowManage.GetInstance.AllWindows.Add(new TaskWindowWindowName().Key, new TaskWindowUIMedia());
        }
    }	
}