#nullable enable
using UnityEngine;

namespace KFramework.Extensions
{
	public static class Vector2Extensions
	{
		public static Vector2Int Abs(this Vector2Int v) => new Vector2Int(v.x.Abs(), v.y.Abs());
		public static int Sum(this Vector2Int v) => v.x + v.y;
		public static int Distance(this Vector2Int v1, Vector2Int v2) => (v1 - v2).Abs().Sum();

		public static Vector2 Random(this Vector2 v) => new Vector2(v.x.Random(), v.y.Random());
		public static Vector2Int Random(this Vector2Int v) => new Vector2Int(v.x.Random(), v.y.Random());
		public static Vector2 YX(this Vector2 v) => new Vector2(v.y, v.x);
		public static Vector2Int YX(this Vector2Int v) => new Vector2Int(v.y, v.x);
		public static Vector2Int To(this Vector2Int v, Direction direction, int step = 1) =>
			v + direction.GetVector(step);
		public static Vector2 Divide(this Vector2 v1, Vector2 v2) => new Vector2(v1.x / v2.x, v1.y / v2.y);
		public static Vector2 Divide(this Vector2Int v1, Vector2 v2) => new Vector2(v1.x / v2.x, v1.y / v2.y);
		public static float DisX(this Vector2 v1, Vector2 v2) => v2.x - v1.x;
		public static int DisX(this Vector2Int v1, Vector2Int v2) => v2.x - v1.x;
		public static float DisY(this Vector2 v1, Vector2 v2) => v2.y - v1.y;
		public static int DisY(this Vector2Int v1, Vector2Int v2) => v2.y - v1.y;
		public static Vector2Int WithX(this Vector2Int @this, int x) => new Vector2Int(x, @this.y);
		public static Vector2Int WithY(this Vector2Int @this, int y) => new Vector2Int(@this.x, y);
		public static Vector2 WithX(this Vector2 @this, float x) => new Vector2(x, @this.y);
		public static Vector2 WithY(this Vector2 @this, float y) => new Vector2(@this.x, y);
		public static Vector2Int AddX(this Vector2Int @this, int x) => new Vector2Int(@this.x + x, @this.y);
		public static Vector2Int AddY(this Vector2Int @this, int y) => new Vector2Int(@this.x, @this.y + y);
		public static Vector2 AddX(this Vector2 @this, float x) => new Vector2(@this.x + x, @this.y);
		public static Vector2 AddY(this Vector2 @this, float y) => new Vector2(@this.x, @this.y + y);
		public static Vector2Int FloorToInt(this Vector2 vector) =>
			new Vector2Int(Mathf.FloorToInt(vector.x), Mathf.FloorToInt(vector.y));
	}
}