#nullable enable

using System;

namespace KFramework
{
	public class State<T>
	{
		protected T value;
		public T Value => value;
		public State(T value) => this.value = value;
		public static implicit operator State<T>(T value) => new State<T>(value);
		public static implicit operator T(State<T> state) => state.Value;
	}

	public class MutableState<T> : State<T>
	{
		public event Action<T>? OnChanged;
		public new virtual T Value {
			get => value;
			set {
				this.value = value;
				Fire();
			}
		}
		public void Fire() {
			OnChanged?.Invoke(value);
		}

		public MutableState(T value) : base(value) {
		}
		public static implicit operator MutableState<T>(T value) => new MutableState<T>(value);
	}

	public class EquatableMutableState<T> : MutableState<T> where T : IEquatable<T>
	{
		public override T Value {
			set {
				if (this.value.Equals(value)) {
					return;
				}
				base.Value = value;
			}
		}

		public EquatableMutableState(T value) : base(value) {
		}
		public static implicit operator EquatableMutableState<T>(T value) => new EquatableMutableState<T>(value);
	}
}
