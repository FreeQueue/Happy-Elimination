#nullable enable

using KFramework;

namespace Elimination.Core.Systems
{
	public class ScoreSystem
	{
		public MutableState<int> Score { get;private set; } = null!;

		public void ReStart() {
			Score = 0;
		}
	}
}
