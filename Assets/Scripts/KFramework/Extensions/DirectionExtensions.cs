#nullable enable
using UnityEngine;

namespace KFramework
{
	static class DirectionExtensions
	{
		public static Direction[] directions = { Direction.Up, Direction.Down, Direction.Left, Direction.Right };
		public static Vector2Int GetVector(this Direction @this) {
			return @this switch {
				Direction.Up => Vector2Int.up,
				Direction.Down => Vector2Int.down,
				Direction.Right => Vector2Int.right,
				Direction.Left => Vector2Int.left,
				_ => Vector2Int.zero,
			};
		}
		public static Vector2Int GetVector(this Direction @this, int step) {
			return @this.GetVector() * step;
		}

		public static Direction? GetDirection(this Vector2 start, Vector2 end, float maxIncludedAngle = 45) {
			Vector2 dir = (end - start).normalized;
			foreach (Direction direction in directions) {
				if (Vector2.Angle(dir, direction.GetVector()) <= maxIncludedAngle) return direction;
			}
			return null;
		}
	}
}