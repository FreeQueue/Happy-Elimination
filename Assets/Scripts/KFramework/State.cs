#nullable enable

using System;
using Sirenix.OdinInspector;

namespace KFramework
{
	[Serializable]
	public class State<T>
	{
		protected T value;
		public State(T value) => this.value = value;

		[ShowInInspector]
		public T Value => value;
		public static implicit operator State<T>(T value) => new State<T>(value);
		public static implicit operator T(State<T> state) => state.Value;
		public override string? ToString() => Value?.ToString();
	}

	public class MutableState<T> : State<T>
	{

		public MutableState(T value) : base(value) {
		}
		public new virtual T Value {
			get => value;
			set {
				this.value = value;
				Fire();
			}
		}
		public event Action<T>? OnChanged;
		public void Fire() {
			OnChanged?.Invoke(value);
		}
		public static implicit operator MutableState<T>(T value) => new MutableState<T>(value);
	}

	public class EquatableMutableState<T> : MutableState<T> where T : IEquatable<T>
	{

		public EquatableMutableState(T value) : base(value) {
		}
		public override T Value {
			set {
				if (this.value.Equals(value)) return;
				base.Value = value;
			}
		}
		public static implicit operator EquatableMutableState<T>(T value) => new EquatableMutableState<T>(value);
	}
}
