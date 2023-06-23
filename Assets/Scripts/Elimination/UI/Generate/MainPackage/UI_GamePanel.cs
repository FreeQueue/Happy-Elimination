/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace MainPackage
{
	public partial class UI_GamePanel : GComponent
	{
		public const string URL = "ui://2ax0adbwja371t";
		public GButton _restartButton;
		public UI_ScoreLabel _scoreLabel;
		public UI_TimeLabel _timeLabel;

		public static UI_GamePanel CreateInstance() => (UI_GamePanel)UIPackage.CreateObject("MainPackage", "GamePanel");

		public override void ConstructFromXML(XML xml) {
			base.ConstructFromXML(xml);

			_timeLabel = (UI_TimeLabel)GetChildAt(18);
			_scoreLabel = (UI_ScoreLabel)GetChildAt(19);
			_restartButton = (GButton)GetChildAt(20);
		}
	}
}