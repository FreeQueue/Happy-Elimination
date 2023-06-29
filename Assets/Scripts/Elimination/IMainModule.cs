using Cysharp.Threading.Tasks;
using KFramework;

namespace Elimination
{
	public interface IMainModule : IModule
	{
		public void ToStartMenu();

		public UniTask StartGame();

		public void ReStartGame();

		public void GameOver();
	}
}
