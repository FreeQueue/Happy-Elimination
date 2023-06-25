#nullable enable

using Cysharp.Threading.Tasks;
using KFramework;

namespace Elimination.Core.Systems
{
	public class TimeSystem
	{
		public MutableState<int> Time { get;private set; } = null!;

		public async UniTaskVoid Start() {
			Time = Game.Data.gameTime;
			while (Time > 0) {
				await UniTask.Delay(1000); // 等待1秒
				Time.Value--;
			}
			App.Main.GameOver();
		}
	}
}
