/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace MainPackage
{
	public class UI_HeartButton : GComponent
	{
		public const string URL = "ui://2ax0adbwja371r";
		public Transition _t0;
		public Transition _t1;

		public static UI_HeartButton CreateInstance() =>
			(UI_HeartButton)UIPackage.CreateObject("MainPackage", "HeartButton");

		public override void ConstructFromXML(XML xml) {
			base.ConstructFromXML(xml);

			_t0 = GetTransitionAt(0);
			_t1 = GetTransitionAt(1);
		}
	}
}