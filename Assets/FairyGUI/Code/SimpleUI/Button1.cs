/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace SimpleUI
{
	public partial class Button1 : GButton
	{
		public Controller m_button;
		public GGraph m_n0;
		public GGraph m_n1;
		public GGraph m_n2;
		public GTextField m_title;

		public const string URL = "ui://3616ktusgjwy70";
		
		

		
		public static Button1 CreateInstance()
		{
			return (Button1)UIPackage.CreateObject("SimpleUI","Button1");
		}

		public Button1()
		{
		}

		public override void ConstructFromXML(XML xml)
		{
			base.ConstructFromXML(xml);

			m_button = this.GetControllerAt(0);
			m_n0 = (GGraph)this.GetChildAt(0);
			m_n1 = (GGraph)this.GetChildAt(1);
			m_n2 = (GGraph)this.GetChildAt(2);
			m_title = (GTextField)this.GetChildAt(3);
		}
	}
	
	public class Button1Bundle: FairyGUIBundle
    {
        public string BundleName { get { return "SimpleUI_fui.Button1".ToLower(); } }		
		public string ResName { get { return "Button1"; } }
    }
}