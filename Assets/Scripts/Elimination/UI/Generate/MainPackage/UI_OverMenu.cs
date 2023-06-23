/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace MainPackage
{
	public class UI_OverMenu : GComponent
	{
		public const string URL = "ui://2ax0adbwf9v320";
		public GButton _closeButton;
		public GButton _restartButton;
		public GTextField _score;

		public static UI_OverMenu CreateInstance() => (UI_OverMenu)UIPackage.CreateObject("MainPackage", "OverMenu");

		public override void ConstructFromXML(XML xml) {
			base.ConstructFromXML(xml);

			_closeButton = (GButton)GetChildAt(10);
			_score = (GTextField)GetChildAt(13);
			_restartButton = (GButton)GetChildAt(14);
		}
	}
}