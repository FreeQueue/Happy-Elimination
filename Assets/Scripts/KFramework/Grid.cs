#nullable enable

using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using KFramework.Extensions;
using UnityEngine;
using Debug = UnityEngine.Debug;

namespace KFramework
{
	public delegate void ValueChangedDelegate<in T>(Vector2Int coord, T oldValue, T newValue);

	public class Grid<T> : IEnumerable<T>
	{
		private readonly T[,] _grid;
		public readonly Vector2Int size;

		public Grid(Vector2Int size) {
			this.size = size;
			_grid = new T[size.x, size.y];
		}
		public int X => size.x;
		public int Y => size.y;
		public int MaxX => X - 1;
		public int MaxY => Y - 1;

		public T this[int x, int y] { get => this[new(x, y)]; set => this[new(x, y)] = value; }
		public T this[Vector2Int coord] {
			get {
				CheckContains(coord);
				return _grid[coord.x, coord.y];
			}
			set {
				CheckContains(coord);
				ValueChange?.Invoke(coord, _grid[coord.x, coord.y], value);
				_grid[coord.x, coord.y] = value;
			}
		}
		public IEnumerator<T> GetEnumerator() => _grid.Cast<T>().GetEnumerator();
		IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
		public event ValueChangedDelegate<T>? ValueChange;
		public Grid<TOther> Create<TOther>() => new Grid<TOther>(size);
		public bool Contains(Vector2Int coord) => _grid.Contains(coord);
		public bool Contains(int x, int y) => _grid.Contains(x, y);
		[Conditional("UNITY_EDITOR")]
		private void CheckContains(Vector2Int coord) {
			if (!Contains(coord)) {
				Debug.LogException(new IndexOutOfRangeException($"index ({coord.x},{coord.y}) out of range"));
			}
		}
	}
}
