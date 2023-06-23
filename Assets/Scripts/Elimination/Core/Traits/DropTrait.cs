#nullable enable

using System.Linq;
using KFramework;
using KFramework.Extensions;
using UnityEngine;

namespace Elimination.Core.Traits
{
	[RequireComponent(typeof(ListenNeighborTrait))]
	public class DropTrait : BrickTrait
	{

		public void Drop() {
			Brick? down = BrickMap.GetInDir(Coord, Direction.Down).FirstOrDefault(brick => brick is not null);

			Vector2Int targetCoord
				= down is null ? Coord.Value.WithY(BrickMap.MaxY) : down.Coord.Value.To(Direction.Up);

			Drop(targetCoord);
		}

		private void Drop(Vector2Int targetCoord) {
			if (!BrickMap.Contains(targetCoord)) return;
			Brick up = GetOrAddUp();
			up.GetTrait<DropTrait>()?.Drop(targetCoord.To(Direction.Up));
			BrickMap.Move(Brick, targetCoord);
			TryFlow();
		}

		private bool TryFlow() {
			Brick? down = Brick.GetOneInDir(Direction.Down);
			if (down is null) return false;
			Vector2Int? flowCoord = null;
			if (!BrickMap.IsBoundaryInDir(down.Coord, Direction.Left) &&
				down.GetOneInDir(Direction.Left) is null)
				flowCoord = down.Coord.Value.To(Direction.Left);
			else if (!BrickMap.IsBoundaryInDir(down.Coord, Direction.Right) &&
					down.GetOneInDir(Direction.Right) is null)
				flowCoord = down.Coord.Value.To(Direction.Right);
			if (!flowCoord.HasValue) return false;
			Brick up = GetOrAddUp();
			var coord = Coord.Value;
			BrickMap.Move(Brick, flowCoord.Value);
			up.GetTrait<DropTrait>()?.Drop(coord);
			return true;
		}
		private Brick GetOrAddUp() => Brick.GetOneInDir(Direction.Up) ??
									Game.Factory.CreateRandomSweet().let(brick => {
										brick.Coord.Value = Coord.Value.To(Direction.Up);
									});
	}
}
