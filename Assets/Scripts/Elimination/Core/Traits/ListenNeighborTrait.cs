#nullable enable

using System;

namespace Elimination.Core.Traits
{
	public class ListenNeighborTrait : BrickTrait
	{
		public Action<Brick>? OnNeighborDestroy;
	}
}