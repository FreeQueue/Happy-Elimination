#nullable enable

using Elimination;
using Elimination.Core;
using Elimination.UI;

namespace MainPackage
{
	partial class UI_GamePanel : IPanel<UI_GamePanel>
	{
		void IPanel.OnCreate() {
			_restartButton.onClick.Add(() => {
				App.Main.ToStartMenu();
			});
		}
		void IPanel.OnOpen() {
			Game.Score.OnChanged += OnScoreChanged;
			Game.Time.OnChanged += OnTimeChanged;
		}
		void IPanel.OnClose() {
			Game.Score.OnChanged -= OnScoreChanged;
			Game.Time.OnChanged -= OnTimeChanged;
		}
		private void OnTimeChanged(int time) {
			_timeLabel._time.SetVar("time", time.ToString());
		}
		private void OnScoreChanged(int score) {
			_scoreLabel._score.SetVar("score", score.ToString());
		}
	}
}