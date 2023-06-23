/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace MainPackage
{
	public class UI_PlayButton : GButton
	{
		public const string URL = "ui://2ax0adbwja371n";
		public Transition _t0;

		public static UI_PlayButton CreateInstance() =>
			(UI_PlayButton)UIPackage.CreateObject("MainPackage", "PlayButton");

		public override void ConstructFromXML(XML xml) {
			base.ConstructFromXML(xml);

			_t0 = GetTransitionAt(0);
		}
	}
}