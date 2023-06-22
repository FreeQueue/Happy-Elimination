/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace MainPackage
{
    public partial class UI_PlayButton : GButton
    {
        public Transition _t0;
        public const string URL = "ui://2ax0adbwja371n";

        public static UI_PlayButton CreateInstance()
        {
            return (UI_PlayButton)UIPackage.CreateObject("MainPackage", "PlayButton");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            _t0 = GetTransitionAt(0);
        }
    }
}