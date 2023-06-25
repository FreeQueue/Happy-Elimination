#nullable enable

using Cysharp.Threading.Tasks;
using UnityEngine;

namespace Elimination.Core.Traits
{
	[RequireComponent(typeof(DestroyTrait))]
	public class EliminateTrait : BrickTrait
	{
		public async UniTask Eliminate() {
			await GetTrait<DestroyTrait>()!.Destroy();
		}
	}
}
