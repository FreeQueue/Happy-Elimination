#nullable enable

using Cysharp.Threading.Tasks;
using Elimination.Core;
using KFramework;
using MainPackage;

namespace Elimination
{
	public class MainModule : IModule
	{
		public MainModule() {
			Game.Init();
		}

		public void ToStartMenu() {
			EndGame();
			App.Audio.PlayMainAudio("loop_menu");
			App.UI.Open<UI_StartPanel>();
		}

		public async UniTask StartGame() {
			Game.TimeSystem.Start().Forget();
			Game.ScoreSystem.ReStart();
			App.Audio.PlayMainAudio("loop_game");
			App.UI.Open<UI_GamePanel>();
			Game.Input.SetActive(false);
			await Game.Generator.FillMap();
			Game.Input.SetActive(true);
		}

		public void ReStartGame() {
			EndGame();
			StartGame().Forget();
		}

		public void GameOver() {
			EndGame();
			App.UI.OpenAbove<UI_OverPanel>();
		}

		private void EndGame() {
			App.UI.CloseAll();
		}
	}
}
