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
		public event Action<T,T>? OnChanged;
		[ShowInInspector]
		public T Value => value;
		public void Fire() => OnChanged?.Invoke(value,value);
		protected void Fire(T oldValue,T newValue) => OnChanged?.Invoke(oldValue, newValue);
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
				Fire(this.value,value);
				this.value = value;
			}
		}
		public void SetNoFire(T value) => this.value = value;
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
