#nullable enable

using System.Collections;
using System.Collections.Generic;
using KFramework.Extensions;
using UnityEngine;

namespace KFramework
{
	public delegate void ValueChangedDelegate<in T>(Vector2Int coord, T oldValue, T newValue);

	public class Grid<T> : IEnumerable<T>
	{
		private readonly T[,] _grid;
		public readonly Vector2Int size;
		public event ValueChangedDelegate<T>? ValueChange;
		public int X => size.x;
		public int Y => size.y;
		public int MaxX => X - 1;
		public int MaxY => Y - 1;

		public T this[Vector2Int coord] { get => this[coord.x, coord.y]; set => this[coord.x, coord.y] = value; }
		public T this[int x, int y] {
			get => _grid[x, y];
			set {
				ValueChange?.Invoke(new Vector2Int(x, y), _grid[x, y], value);
				_grid[x, y] = value;
			}
		}

		public Grid(Vector2Int size) {
			this.size = size;
			_grid = new T[size.x, size.y];
		}

		public Grid<TOther> Create<TOther>() => new Grid<TOther>(size);
		public bool Contains(Vector2Int coord) {
			return _grid.Contains(coord);
		}

		public bool Contains(int x, int y) {
			return _grid.Contains(x, y);
		}
		public IEnumerator<T> GetEnumerator() {
			foreach (T item in _grid) {
				yield return item;
			}
		}
		IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
	}
}
