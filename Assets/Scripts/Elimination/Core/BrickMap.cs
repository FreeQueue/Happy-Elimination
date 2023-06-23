#nullable enable

using KFramework;
using KFramework.Extensions;
using UnityEngine;

namespace Elimination.Core
{
	public class BrickMap : Grid<Brick?>
	{
		public BrickMap(Vector2Int size) : base(size) => ValueChange += OnValueChange;

		public void Move( Brick brick, Vector2Int targetCoord) {
			var coord = brick.Coord;
			if (Contains(coord)&&this[coord] == brick) {
				this[coord] = null;
			}
			this.Add(targetCoord, brick);
		}

		private static void OnValueChange(Vector2Int coord, Brick? oldValue, Brick? newValue) {
			newValue?.let(brick => {
				brick.Coord.Value = coord;
			});
		}
	}
}
