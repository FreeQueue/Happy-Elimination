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
			Brick? down = BrickMap.GetInDir(Coord, Direction.Down).First(brick => brick is not null);

			Vector2Int targetCoord
				= down is null ? Coord.Value.WithY(BrickMap.MaxY) : down.Coord.Value.To(Direction.Up);

			Drop(targetCoord);
		}

		private void Drop(Vector2Int targetCoord) {
			if (!BrickMap.Contains(targetCoord)) return;
			Brick up = GetOrAddUp();
			up.GetTrait<DropTrait>()?.Drop(targetCoord.To(Direction.Up));
			BrickMap.Move(Coord, targetCoord);
			GetTrait<ViewTrait>()?.AfterAll(nameof(ViewTrait.PlayMove), () => {
				TryFlow();
			});
		}

		private bool TryFlow() {
			Brick? down = BrickMap.GetInDir(Coord, Direction.Down).First(brick => brick is not null);
			if (down is null) return false;
			Vector2Int? flowCoord = null;
			if (down.GetOneInDir(Direction.Left) is null) flowCoord = down.Coord.Value.To(Direction.Left);
			else if (down.GetOneInDir(Direction.Right) is null) flowCoord = down.Coord.Value.To(Direction.Right);
			if (!flowCoord.HasValue) return false;
			Brick up = GetOrAddUp();
			MutableState<Vector2Int> coord = Coord;
			BrickMap.Move(coord, flowCoord.Value);
			up.GetTrait<DropTrait>()?.Drop(coord);
			return true;
		}
		private Brick GetOrAddUp() => BrickMap.GetInDir(Coord, Direction.Up)
										.First(brick => brick is not null) ??
									BrickMap.Add(Coord.Value.To(Direction.Up), Game.Factory.CreateRandomSweet());
	}
}