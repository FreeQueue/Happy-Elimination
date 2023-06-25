#nullable enable

using Cysharp.Threading.Tasks;
using UnityEngine;

namespace Elimination.Core.Traits
{
	[RequireComponent(typeof(DestroyTrait), typeof(ListenNeighborTrait))]
	public class DestroyOnNeighborDestroyTrait : BrickTrait
	{
		public override void Init() {
			GetTrait<ListenNeighborTrait>()!.OnNeighborDestroy += OnNeighborDestroy;
		}
		private async UniTask OnNeighborDestroy(Brick brick) {
			await GetTrait<DestroyTrait>()!.Destroy();
		}
	}
}
