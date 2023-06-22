#nullable enable

using KFramework;
using UnityEngine;

namespace Elimination.Core
{
	public abstract class BrickTrait : MonoBehaviour
	{
		public Brick Brick { get; private set; } = null!;
		public MutableState<Vector2Int> Coord => Brick.Coord;
		public BrickMap BrickMap => Brick.BrickMap;
		private void Awake() {
			Brick = GetComponent<Brick>();
		}
		public virtual void Init() {

		}
		public T? GetTrait<T>() where T : BrickTrait {
			return Brick.GetTrait<T>();
		}
	}
}
