/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace MainPackage
{
    public partial class UI_OverMenu : GComponent
    {
        public GButton _closeButton;
        public GTextField _score;
        public GButton _restartButton;
        public const string URL = "ui://2ax0adbwf9v320";

        public static UI_OverMenu CreateInstance()
        {
            return (UI_OverMenu)UIPackage.CreateObject("MainPackage", "OverMenu");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            _closeButton = (GButton)GetChildAt(10);
            _score = (GTextField)GetChildAt(13);
            _restartButton = (GButton)GetChildAt(14);
        }
    }
}