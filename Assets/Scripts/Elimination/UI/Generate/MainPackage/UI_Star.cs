/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace MainPackage
{
    public partial class UI_Star : GComponent
    {
        public Transition _t0;
        public const string URL = "ui://2ax0adbwja371q";

        public static UI_Star CreateInstance()
        {
            return (UI_Star)UIPackage.CreateObject("MainPackage", "Star");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            _t0 = GetTransitionAt(0);
        }
    }
}