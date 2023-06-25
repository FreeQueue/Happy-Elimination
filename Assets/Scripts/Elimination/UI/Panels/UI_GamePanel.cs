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
			_timeLabel._time.text = Game.TimeSystem.Time.ToString();
			_scoreLabel._score.text = Game.ScoreSystem.Score.ToString();
			Game.ScoreSystem.Score.OnChanged += OnScoreChanged;
			Game.TimeSystem.Time.OnChanged += OnTimeChanged;
		}
		void IPanel.OnClose() {
			Game.ScoreSystem.Score.OnChanged -= OnScoreChanged;
			Game.TimeSystem.Time.OnChanged -= OnTimeChanged;
		}
		private void OnTimeChanged(int _, int time) {
			_timeLabel._time.text = time.ToString();
		}
		private void OnScoreChanged(int _, int score) {
			_scoreLabel._score.text = score.ToString();
		}
	}
}
