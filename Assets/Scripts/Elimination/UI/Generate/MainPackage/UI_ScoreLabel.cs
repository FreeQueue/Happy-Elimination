/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace MainPackage
{
    public partial class UI_ScoreLabel : GLabel
    {
        public GTextField _score;
        public const string URL = "ui://2ax0adbwf9v31x";

        public static UI_ScoreLabel CreateInstance()
        {
            return (UI_ScoreLabel)UIPackage.CreateObject("MainPackage", "ScoreLabel");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            _score = (GTextField)GetChildAt(2);
        }
    }
}