#nullable enable

using System;
using Cysharp.Threading.Tasks;

namespace Elimination.Core.Traits
{
	public class ListenNeighborTrait : BrickTrait
	{
		public Func<Brick,UniTask>? OnNeighborDestroy;
	}
}
