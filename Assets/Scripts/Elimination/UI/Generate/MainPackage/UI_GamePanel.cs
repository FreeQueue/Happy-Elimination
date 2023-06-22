/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace MainPackage
{
    public partial class UI_GamePanel : GComponent
    {
        public UI_TimeLabel _timeLabel;
        public UI_ScoreLabel _scoreLabel;
        public GButton _restartButton;
        public const string URL = "ui://2ax0adbwja371t";

        public static UI_GamePanel CreateInstance()
        {
            return (UI_GamePanel)UIPackage.CreateObject("MainPackage", "GamePanel");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            _timeLabel = (UI_TimeLabel)GetChildAt(18);
            _scoreLabel = (UI_ScoreLabel)GetChildAt(19);
            _restartButton = (GButton)GetChildAt(20);
        }
    }
}