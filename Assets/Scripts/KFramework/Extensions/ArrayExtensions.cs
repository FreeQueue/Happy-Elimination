#nullable enable

using UnityEngine;

namespace KFramework.Extensions
{
	public static class ArrayExtensions
	{
		public static bool Contains<T>(this T[,] @this, Vector2Int coord) {
			return @this.Contains(coord.x, coord.y);
		}

		public static bool Contains<T>(this T[,] @this, int x, int y) {
			int lengthX = @this.GetLength(0);
			int lengthY = @this.GetLength(1);
			return x >= 0 && x < lengthX && y >= 0 && y < lengthY;
		}
	}
}