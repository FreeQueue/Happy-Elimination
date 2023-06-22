/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace MainPackage
{
    public partial class UI_TimeLabel : GLabel
    {
        public GTextField _time;
        public Transition _rotate;
        public const string URL = "ui://2ax0adbwja371u";

        public static UI_TimeLabel CreateInstance()
        {
            return (UI_TimeLabel)UIPackage.CreateObject("MainPackage", "TimeLabel");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            _time = (GTextField)GetChildAt(2);
            _rotate = GetTransitionAt(0);
        }
    }
}