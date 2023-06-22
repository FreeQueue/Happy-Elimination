/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace MainPackage
{
    public partial class UI_BreadMen : GComponent
    {
        public Transition _t0;
        public const string URL = "ui://2ax0adbwja371o";

        public static UI_BreadMen CreateInstance()
        {
            return (UI_BreadMen)UIPackage.CreateObject("MainPackage", "BreadMen");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            _t0 = GetTransitionAt(0);
        }
    }
}