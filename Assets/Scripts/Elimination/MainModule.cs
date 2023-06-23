#nullable enable

using Elimination.Core;
using KFramework;
using MainPackage;

namespace Elimination
{
	internal enum GameStatus
	{
		InGame,
		Pause,
		OutGame

	}

	public class MainModule : IModule
	{
		private GameStatus Status = GameStatus.OutGame;
		public MainModule() {
			Game.Init();
		}

		void IModule.Update() {

		}

		public void ToStartMenu() {
			EndGame();
			App.UI.Open<UI_StartPanel>();
		}

		public void StartGame() {
			Game.Time = Game.Data.gameTime;
			Game.Time.OnChanged += OnTimeChanged;
			Game.Score = 0;
			App.UI.Open<UI_GamePanel>();
			Game.Generator.FillMap();
		}

		public void ReStartGame() {
			EndGame();
			StartGame();
		}

		public void GameOver() {
			EndGame();
			App.UI.OpenAbove<UI_OverPanel>();
		}

		private void EndGame() {
			Game.Time.OnChanged -= OnTimeChanged;
		}
		private void OnTimeChanged(int time) {
			if (time <= 0) GameOver();
		}
	}
}
