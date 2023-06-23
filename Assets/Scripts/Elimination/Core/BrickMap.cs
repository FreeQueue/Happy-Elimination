#nullable enable

using KFramework;
using KFramework.Extensions;
using UnityEngine;

namespace Elimination.Core
{
	public class BrickMap : Grid<Brick?>
	{
		public BrickMap(Vector2Int size) : base(size) => ValueChange += OnValueChange;

		private static void OnValueChange(Vector2Int coord, Brick? oldValue, Brick? newValue) {
			newValue?.let(brick => {
				brick.Coord.Value = coord;
			});
		}
	}
}