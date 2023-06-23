#nullable enable

using KFramework;
using UnityEngine;

namespace Elimination.Core
{
	[RequireComponent(typeof(Brick))]
	public abstract class BrickTrait : MonoBehaviour
	{
		public Brick Brick { get; private set; } = null!;
		public MutableState<Vector2Int> Coord => Brick.Coord;
		public BrickMap BrickMap => Brick.BrickMap;

		#region Event Functions
		private void Awake() {
			Brick = GetComponent<Brick>();
		}
		#endregion

		public virtual void Init() {

		}
		public T? GetTrait<T>() where T : BrickTrait => Brick.GetTrait<T>();
	}
}
