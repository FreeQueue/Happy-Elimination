#nullable enable

using System.Linq;
using KFramework;
using KFramework.Extensions;
using UnityEngine;

namespace Elimination.Core
{
	public struct SameBrick
	{
		public int[] directions;
		public Vector2Int coord;
		public int Up => directions[(int)Direction.Up];
		public int Down => directions[(int)Direction.Down];
		public int Left => directions[(int)Direction.Left];
		public int Right => directions[(int)Direction.Right];
		public int NumX() => directions[(int)Direction.Left] + directions[(int)Direction.Right] + 1;
		public int NumY() => directions[(int)Direction.Up] + directions[(int)Direction.Down] + 1;
		public Vector2Int UpCoord() => coord.AddY(-directions[(int)Direction.Up]);
		public Vector2Int DownCoord() => coord.AddY(directions[(int)Direction.Down]);
		public Vector2Int LeftCoord() => coord.AddX(-directions[(int)Direction.Left]);
		public Vector2Int RightCoord() => coord.AddX(directions[(int)Direction.Right]);
	}
}