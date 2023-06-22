#nullable enable

using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using UnityEngine;

namespace KFramework.Extensions
{
	public static class GridExtensions
	{
		public static IEnumerable<Vector2Int> GetCoords<T>(this Grid<T> grid) {
			for (int x = 0; x < grid.X; x++) {
				for (int y = 0; y < grid.Y; y++) {
					yield return new Vector2Int(x, y);
				}
			}
		}
		public static T Add<T>(this Grid<T> grid, Vector2Int coord, T item) {
			return grid[coord] = item;
		}

		public static T? Remove<T>(this Grid<T> grid, Vector2Int coord) {
			T? removeBrick = grid[coord];
			grid[coord] = default;
			return removeBrick;
		}

		public static T? Move<T>(this Grid<T> grid, Vector2Int coord, Vector2Int targetCoord) {
			T? moveItem = grid[coord];
			if (moveItem is not null && coord != targetCoord) {
				grid[coord] = default;
				grid[targetCoord] = moveItem;
			}
			return moveItem;
		}

		public static (T? coord1Item, T? coord2Item) Swap<T>(this Grid<T> grid, Vector2Int coord1, Vector2Int coord2) {
			return (grid[coord1], grid[coord2]) = (grid[coord2], grid[coord1]);
		}
		public static bool IsNull<T>(this Grid<T> grid, Vector2Int coord) {
			return grid[coord] is null;
		}
		public static bool IsNull<T>(this Grid<T> grid, int x, int y) {
			return grid[x, y] is null;
		}

		public static bool IsBoundary<T>(this Grid<T> grid, Vector2Int coord) {
			int x = coord.x;
			int y = coord.y;
			return x == 0 || x == grid.X - 1 || y == 0 || y == grid.Y - 1;
		}

		public static bool IsBoundaryInDir<T>(this Grid<T> grid, Vector2Int coord, Direction direction) {
			int x = coord.x;
			int y = coord.y;
			return direction switch {
				Direction.Up => y == 0,
				Direction.Down => y == grid.Y - 1,
				Direction.Left => x == 0,
				Direction.Right => y == grid.Y - 1,
				_ => throw new ArgumentException("Invalid direction")
			};
		}

		public static IEnumerable<T?> GetInDir<T>(
			this Grid<T> grid, Vector2Int coord, Direction direction, int num = int.MaxValue
		) {
			var max = grid.GetDistance(coord, direction);
			for (int i = 0; i < num && i < max; i++) {
				coord += direction.GetVector();
				yield return grid[coord];
			}
		}

		public static IEnumerable<T?> GetCross<T>(
			this Grid<T> grid, Vector2Int coord, int distance = int.MaxValue
		) => DirectionExtensions.directions.SelectMany(direction => grid.GetInDir(coord, direction, distance));

		public static IEnumerable<T?> GetCircles<T>(
			this Grid<T> grid, Vector2Int coord, int distance = int.MaxValue
		) {
			return grid.Bfs(coord, (_, current, next) => current.Distance(next) < distance);
		}

		public static int GetDistance<T>(this Grid<T> grid, Vector2Int coord, Direction direction) {
			return direction switch {
				Direction.Up => coord.y,
				Direction.Down => grid.Y - coord.y - 1,
				Direction.Left => coord.x,
				Direction.Right => grid.X - coord.x - 1,
				_ => throw new ArgumentException("Invalid direction")
			};
		}

		public static Grid<TResult> Transform<T, TResult>(this Grid<T> grid, Func<T?, TResult> action) {
			var resultGrid = grid.Create<TResult>();
			for (int i = 0; i < resultGrid.X; i++) {
				for (int j = 0; j < resultGrid.Y; j++) {
					resultGrid[i, j] = action(grid[i, j]);
				}
			}
			return resultGrid;
		}

		public static IEnumerable<T> Bfs<T>(
			this Grid<T> grid, Vector2Int coord, Func<Grid<T>, Vector2Int, Vector2Int, bool> predicate
		) {
			var visited = grid.Create<bool>();
			var queue = new Queue<Vector2Int>();
			queue.Enqueue(coord); // 存储已访问节点
			while (queue.Count > 0) {
				Vector2Int current = queue.Dequeue();
				yield return grid[current];
				foreach (Direction direction in DirectionExtensions.directions) {
					Vector2Int next = current.To(direction);
					if (!grid.Contains(next) || visited[next]) continue;
					if (predicate(grid, current, next)) {
						visited[current] = true;
						queue.Enqueue(next); // 加入到队列中
					}
				}
			}
		}

		// 查找坐标附近所有符合条件的块
		public static IEnumerable<Vector2Int> Dfs<T>(
			this Grid<T> grid, Vector2Int coord, Func<Grid<T>, Vector2Int, Vector2Int, bool> predicate
		) {
			Grid<bool> visited = grid.Create<bool>();
			var stack = new Stack<Vector2Int>();
			stack.Push(coord);
			while (stack.Count > 0) {
				Vector2Int current = stack.Pop();
				foreach (Direction direction in DirectionExtensions.directions) {
					Vector2Int next = current.To(direction);
					if (!grid.Contains(next) || visited[next]) continue;
					if (!predicate(grid, current, next)) continue;
					visited[next] = true;
					stack.Push(next); // 加入到栈中
					yield return next;
				}
			}
		}
	}

}
