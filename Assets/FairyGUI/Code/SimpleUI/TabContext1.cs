/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace SimpleUI
{
	public partial class TabContext1 : GComponent
	{
		public Button1 m_n1;
		public Button1 m_n2;

		public const string URL = "ui://3616ktusgjwy71";
		
		

		
		public static TabContext1 CreateInstance()
		{
			return (TabContext1)UIPackage.CreateObject("SimpleUI","TabContext1");
		}

		public TabContext1()
		{
		}

		public override void ConstructFromXML(XML xml)
		{
			base.ConstructFromXML(xml);

			m_n1 = (Button1)this.GetChildAt(0);
			m_n2 = (Button1)this.GetChildAt(1);
		}
	}
	
	public class TabContext1Bundle: FairyGUIBundle
    {
        public string BundleName { get { return "SimpleUI_fui.TabContext1".ToLower(); } }		
		public string ResName { get { return "TabContext1"; } }
    }
}