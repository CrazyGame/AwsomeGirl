/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace SimpleUI
{
	public partial class TabController : GComponent
	{
		public Controller m_Tab;
		public Button1 m_n7;
		public Button1 m_n8;
		public Button1 m_n10;
		public TabContext1 m_n11;

		public const string URL = "ui://3616ktusgjwy6y";
		
		

		
		public static TabController CreateInstance()
		{
			return (TabController)UIPackage.CreateObject("SimpleUI","TabController");
		}

		public TabController()
		{
		}

		public override void ConstructFromXML(XML xml)
		{
			base.ConstructFromXML(xml);

			m_Tab = this.GetControllerAt(0);
			m_n7 = (Button1)this.GetChildAt(0);
			m_n8 = (Button1)this.GetChildAt(1);
			m_n10 = (Button1)this.GetChildAt(2);
			m_n11 = (TabContext1)this.GetChildAt(3);
		}
	}
	
	public class TabControllerBundle: FairyGUIBundle
    {
        public string BundleName { get { return "SimpleUI_fui.TabController".ToLower(); } }		
		public string ResName { get { return "TabController"; } }
    }
}