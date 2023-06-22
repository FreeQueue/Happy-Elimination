#nullable enable

using UnityEngine;

namespace Elimination.Core.Traits
{
	[RequireComponent(typeof(DestroyTrait))]
	public class EliminateTrait:BrickTrait
	{
		public void Eliminate() {
			GetTrait<DestroyTrait>()!.Destroy();
		}
	}
}
