/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace MainPackage
{
	public class UI_BreadMen : GComponent
	{
		public const string URL = "ui://2ax0adbwja371o";
		public Transition _t0;

		public static UI_BreadMen CreateInstance() => (UI_BreadMen)UIPackage.CreateObject("MainPackage", "BreadMen");

		public override void ConstructFromXML(XML xml) {
			base.ConstructFromXML(xml);

			_t0 = GetTransitionAt(0);
		}
	}
}