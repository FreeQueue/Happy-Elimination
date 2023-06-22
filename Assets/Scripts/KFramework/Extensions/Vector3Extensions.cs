#nullable enable
using UnityEngine;

namespace KFramework.Extensions
{
	public static class Vector3Extensions
	{
		public static Vector2 XY(this Vector3 v) => new Vector2(v.x, v.y);
		public static Vector2 XZ(this Vector3 v) => new Vector2(v.x, v.z);
		public static Vector2 YZ(this Vector3 v) => new Vector2(v.y, v.z);
		public static Vector2 YX(this Vector3 v) => new Vector2(v.y, v.x);
		public static Vector2 ZX(this Vector3 v) => new Vector2(v.z, v.x);
		public static Vector2 ZY(this Vector3 v) => new Vector2(v.z, v.y);
		public static Vector3 XYZ(this Vector3 v) => new Vector3(v.x, v.y, v.z);
		public static Vector3 XZY(this Vector3 v) => new Vector3(v.x, v.z, v.y);
		public static Vector3 YXZ(this Vector3 v) => new Vector3(v.y, v.x, v.z);
		public static Vector3 YZX(this Vector3 v) => new Vector3(v.y, v.z, v.x);
		public static Vector3 ZXY(this Vector3 v) => new Vector3(v.z, v.x, v.y);
		public static Vector3 ZYX(this Vector3 v) => new Vector3(v.z, v.y, v.x);
		public static Vector2Int XY(this Vector3Int v) => new Vector2Int(v.x, v.y);
		public static Vector2Int XZ(this Vector3Int v) => new Vector2Int(v.x, v.z);
		public static Vector2Int YZ(this Vector3Int v) => new Vector2Int(v.y, v.z);
		public static Vector2Int YX(this Vector3Int v) => new Vector2Int(v.y, v.x);
		public static Vector2Int ZX(this Vector3Int v) => new Vector2Int(v.z, v.x);
		public static Vector2Int ZY(this Vector3Int v) => new Vector2Int(v.z, v.y);
		public static Vector3Int XYZ(this Vector3Int v) => new Vector3Int(v.x, v.y, v.z);
		public static Vector3Int XZY(this Vector3Int v) => new Vector3Int(v.x, v.z, v.y);
		public static Vector3Int YXZ(this Vector3Int v) => new Vector3Int(v.y, v.x, v.z);
		public static Vector3Int YZX(this Vector3Int v) => new Vector3Int(v.y, v.z, v.x);
		public static Vector3Int ZXY(this Vector3Int v) => new Vector3Int(v.z, v.x, v.y);
		public static Vector3Int ZYX(this Vector3Int v) => new Vector3Int(v.z, v.y, v.x);
		public static Vector3Int WithX(this Vector3Int v, int x) => new Vector3Int(x, v.y, v.z);
		public static Vector3Int WithY(this Vector3Int v, int y) => new Vector3Int(v.x, y, v.z);
		public static Vector3Int WithZ(this Vector3Int v, int z) => new Vector3Int(v.x, v.y, z);
		public static Vector3Int WithXY(this Vector3Int v, int x, int y) => new Vector3Int(x, y, v.z);
		public static Vector3Int WithYZ(this Vector3Int v, int y, int z) => new Vector3Int(v.x, y, z);
		public static Vector3Int WithXZ(this Vector3Int v, int x, int z) => new Vector3Int(x, v.y, z);
		public static Vector3Int WithXY(this Vector3Int v, Vector2Int p) => new Vector3Int(p.x, p.y, v.z);
		public static Vector3Int WithYZ(this Vector3Int v, Vector2Int p) => new Vector3Int(v.x, p.x, p.y);
		public static Vector3Int WithXZ(this Vector3Int v, Vector2Int p) => new Vector3Int(p.x, v.y, p.y);
		public static Vector3 WithX(this Vector3 v, float x) => new Vector3(x, v.y, v.z);
		public static Vector3 WithY(this Vector3 v, float y) => new Vector3(v.x, y, v.z);
		public static Vector3 WithZ(this Vector3 v, int z) => new Vector3(v.x, v.y, z);
		public static Vector3 WithXY(this Vector3 v, int x, int y) => new Vector3(x, y, v.z);
		public static Vector3 WithYZ(this Vector3 v, int y, int z) => new Vector3(v.x, y, z);
		public static Vector3 WithXZ(this Vector3 v, int x, int z) => new Vector3(x, v.y, z);
		public static Vector3 WithXY(this Vector3 v, Vector2 p) => new Vector3(p.x, p.y, v.z);
		public static Vector3 WithYZ(this Vector3 v, Vector2 p) => new Vector3(v.x, p.x, p.y);
		public static Vector3 WithXZ(this Vector3 v, Vector2 p) => new Vector3(p.x, v.y, p.y);
		public static Vector3Int AddX(this Vector3Int v, int x) => new Vector3Int(v.x + x, v.y, v.z);
		public static Vector3Int AddY(this Vector3Int v, int y) => new Vector3Int(v.x, v.y + y, v.z);
		public static Vector3Int AddZ(this Vector3Int v, int z) => new Vector3Int(v.x, v.y, v.z + z);
		public static Vector3 AddX(this Vector3 v, float x) => new Vector3(v.x + x, v.y, v.z);
		public static Vector3 AddY(this Vector3 v, float y) => new Vector3(v.x, v.y + y, v.z);
		public static Vector3 AddZ(this Vector3 v, float z) => new Vector3(v.x, v.y, v.z + z);
		public static Vector3 AddXY(this Vector3 v, int x, int y) => new Vector3(x, y, v.z);
		public static Vector3 AddYZ(this Vector3 v, int y, int z) => new Vector3(v.x, y, z);
		public static Vector3 AddXZ(this Vector3 v, int x, int z) => new Vector3(x, v.y, z);
		public static Vector3 AddXY(this Vector3 v, Vector2 p) => new Vector3(p.x, p.y, v.z);
		public static Vector3 AddYZ(this Vector3 v, Vector2 p) => new Vector3(v.x, p.x, p.y);
		public static Vector3 AddXZ(this Vector3 v, Vector2 p) => new Vector3(p.x, v.y, p.y);
	}
}