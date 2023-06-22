#nullable enable

using KFramework;
using MainPackage;

namespace Elimination
{
	enum GameStatus
	{
		OutGame,
		InGame,
		GameOver,
	}
	public class MainModule:IModule
	{
		public MainModule() {
		}

		public void ToStartMenu() {
			App.UI.Open<UI_StartPanel>();
		}

		public void StartGame() {
			App.UI.Open<UI_GamePanel>();
		}

		public void ReStartGame() {
			
		}

		public void GameOver() {
			App.UI.OpenAbove<UI_OverPanel>();
		}
	}
}