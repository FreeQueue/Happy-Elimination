#nullable enable

using System;
using System.Collections.Generic;
using System.Linq;
using KFramework;
using KFramework.Extensions;
using Sirenix.OdinInspector;
using UnityEditor;
using UnityEngine;

namespace Elimination.Core
{
	public class Brick : MonoBehaviour
	{
		private Dictionary<Type, BrickTrait> _traits = null!;
		public BrickMap BrickMap { get; private set; } = null!;
		[ShowInInspector] public State<int> ID { get; private set; } = null!;
		[ShowInInspector] public MutableState<Vector2Int> Coord { get;  } = Vector2Int.zero;
		public void Init(BrickMap brickMap, int id) {
			BrickMap = brickMap;
			ID = id;
			_traits = new();
			BrickTrait[]? traits = GetComponents<BrickTrait>();
			foreach (BrickTrait trait in traits) {
				_traits.Add(trait.GetType(), trait);
			}
			foreach (BrickTrait trait in traits) {
				trait.Init();
			}
		}

		public T? GetTrait<T>() where T : BrickTrait {
			_traits.TryGetValue(typeof(T), out BrickTrait? trait);
			return (T?)trait;
		}

		public Brick? GetNeighbor(Direction direction) =>
			BrickMap.GetInDir(Coord, direction, 1).FirstOrDefault(brick => brick is not null);

		private void OnDrawGizmos()
		{
			Handles.color = Color.black;
			Handles.Label(transform.position,Coord.ToString());
		}
	}
}
