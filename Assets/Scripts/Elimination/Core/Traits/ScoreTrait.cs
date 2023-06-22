#nullable enable

using UnityEngine;

namespace Elimination.Core.Traits
{
	[RequireComponent(typeof(DestroyTrait))]
	public class ScoreTrait:BrickTrait
	{
		public int score;
		public override void Init() {
			GetTrait<DestroyTrait>()!.OnDestroy+=OnDestroy;
		}
		private void OnDestroy() {
			Game.Score.Value += score;
		}
	}
}
