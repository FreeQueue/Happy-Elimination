#nullable enable

using Elimination;
using Elimination.Core;
using Elimination.UI;

namespace MainPackage
{
	partial class UI_OverPanel : IPanel<UI_OverPanel>
	{

		void IPanel.OnCreate() {
			_overMenu._closeButton.onClick.Add(() => {
				App.Main.StartGame();
			});
			_overMenu._restartButton.onClick.Add(() => {
				App.Main.ReStartGame();
			});
		}
		void IPanel.OnOpen() {
			_overMenu._score.SetVar("score", Game.Score.ToString());
		}
	}
}
