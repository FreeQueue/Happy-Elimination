/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace MainPackage
{
    public partial class UI_StartPanel : GComponent
    {
        public GButton _exitButton;
        public UI_PlayButton _playButton;
        public const string URL = "ui://2ax0adbwga9h0";

        public static UI_StartPanel CreateInstance()
        {
            return (UI_StartPanel)UIPackage.CreateObject("MainPackage", "StartPanel");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            _exitButton = (GButton)GetChildAt(9);
            _playButton = (UI_PlayButton)GetChildAt(11);
        }
    }
}