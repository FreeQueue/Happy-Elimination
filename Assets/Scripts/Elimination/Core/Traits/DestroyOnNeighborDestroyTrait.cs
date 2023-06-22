#nullable enable

using UnityEngine;

namespace Elimination.Core.Traits
{
	[RequireComponent(typeof(DestroyTrait),typeof(ListenNeighborTrait))]
	public class DestroyOnNeighborDestroyTrait:BrickTrait
	{
		public override void Init() {
			GetTrait<ListenNeighborTrait>()!.OnNeighborDestroy += OnNeighborDestroy;
		}
		private void OnNeighborDestroy(Brick brick) {
			GetTrait<DestroyTrait>()!.Destroy();
		}
	}
}
