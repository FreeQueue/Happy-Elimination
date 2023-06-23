/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace MainPackage
{
	public class UI_Star : GComponent
	{
		public const string URL = "ui://2ax0adbwja371q";
		public Transition _t0;

		public static UI_Star CreateInstance() => (UI_Star)UIPackage.CreateObject("MainPackage", "Star");

		public override void ConstructFromXML(XML xml) {
			base.ConstructFromXML(xml);

			_t0 = GetTransitionAt(0);
		}
	}
}