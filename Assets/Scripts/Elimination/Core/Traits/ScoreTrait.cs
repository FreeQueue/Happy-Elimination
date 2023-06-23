#nullable enable

using UnityEngine;

namespace Elimination.Core.Traits
{
	[RequireComponent(typeof(DestroyTrait))]
	public class ScoreTrait : BrickTrait
	{
		#region Serialized Fields
		public int score;
		#endregion

		private void Destroy() {
			Game.Score.Value += score;
		}

		public override void Init() {
			GetTrait<DestroyTrait>()!.OnDestroy += Destroy;
		}
	}
}
