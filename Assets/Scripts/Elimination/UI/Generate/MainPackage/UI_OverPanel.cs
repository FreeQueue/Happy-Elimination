/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace MainPackage
{
	public partial class UI_OverPanel : GComponent
	{
		public const string URL = "ui://2ax0adbwf9v31y";
		public UI_OverMenu _overMenu;

		public static UI_OverPanel CreateInstance() => (UI_OverPanel)UIPackage.CreateObject("MainPackage", "OverPanel");

		public override void ConstructFromXML(XML xml) {
			base.ConstructFromXML(xml);

			_overMenu = (UI_OverMenu)GetChildAt(1);
		}
	}
}