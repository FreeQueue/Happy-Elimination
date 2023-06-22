#nullable enable

using Elimination;
using Elimination.UI;

namespace MainPackage
{
	partial class UI_StartPanel : IPanel<UI_StartPanel>
	{
		void IPanel.OnCreate() {
			_exitButton.onClick.Add(App.Quit);
			_playButton.onClick.Add(() => {
				App.Main.StartGame();
			});
		}
		void IPanel.OnOpen() {

		}
		void IPanel.OnUpdate() {
		}
		void IPanel.OnClose() {
		}
	}
}