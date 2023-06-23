/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace MainPackage
{
	public class UI_TimeLabel : GLabel
	{
		public const string URL = "ui://2ax0adbwja371u";
		public Transition _rotate;
		public GTextField _time;

		public static UI_TimeLabel CreateInstance() => (UI_TimeLabel)UIPackage.CreateObject("MainPackage", "TimeLabel");

		public override void ConstructFromXML(XML xml) {
			base.ConstructFromXML(xml);

			_time = (GTextField)GetChildAt(2);
			_rotate = GetTransitionAt(0);
		}
	}
}