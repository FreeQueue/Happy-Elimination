#nullable enable

using Cysharp.Threading.Tasks;
using Elimination;

namespace Happy_Elimination
{
	public class TestModule:IMainModule
	{
		public TestModule() {

		}
		public void ToStartMenu() {
			throw new System.NotImplementedException();
		}
		public UniTask StartGame() => throw new System.NotImplementedException();
		public void ReStartGame() {
			throw new System.NotImplementedException();
		}
		public void GameOver() {
			throw new System.NotImplementedException();
		}
	}
}
