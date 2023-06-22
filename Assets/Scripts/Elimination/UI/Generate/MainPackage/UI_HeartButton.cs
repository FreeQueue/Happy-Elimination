/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace MainPackage
{
    public partial class UI_HeartButton : GComponent
    {
        public Transition _t0;
        public Transition _t1;
        public const string URL = "ui://2ax0adbwja371r";

        public static UI_HeartButton CreateInstance()
        {
            return (UI_HeartButton)UIPackage.CreateObject("MainPackage", "HeartButton");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            _t0 = GetTransitionAt(0);
            _t1 = GetTransitionAt(1);
        }
    }
}