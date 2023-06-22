#nullable enable

using System;
using System.Collections.Generic;
using System.Linq;
using Cysharp.Threading.Tasks;
using Elimination.Core.Traits;
using KFramework;
using KFramework.Extensions;
using UnityEngine;

namespace Elimination.Core
{
	public class Brick : MonoBehaviour
	{
		private Dictionary<Type, BrickTrait?> _traits = null!;
		public BrickMap BrickMap { get; private set; } = null!;
		public State<int> ID { get; private set; } = null!;
		public MutableState<Vector2Int> Coord { get; } = new MutableState<Vector2Int>(Vector2Int.zero);
		public void Init(BrickMap brickMap, int id) {
			BrickMap = brickMap;
			ID = new MutableState<int>(id);
			_traits = new();
			var traits = GetComponents<BrickTrait>();
			foreach (BrickTrait trait in traits) {
				_traits.Add(trait.GetType(), trait);
			}
			foreach (BrickTrait trait in traits) {
				trait.Init();
			}
		}

		public T? GetTrait<T>() where T : BrickTrait {
			return (T?)_traits[typeof(T)];
		}

		public Brick? GetOneInDir(Direction direction) => BrickMap.GetInDir(Coord, direction, 1).First();
	}
}
