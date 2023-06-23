#nullable enable
using System;
using System.Collections.Generic;
using System.Linq;

namespace KFramework
{
	public class Framework
	{
		private readonly Dictionary<Type, IModule> _modules = new Dictionary<Type, IModule>();
		private bool _isShutdown;

		public bool Contains<T>() where T : IModule => _modules.ContainsKey(typeof(T));

		public T Init<T>() where T : IModule, new() {
			Type type = typeof(T);
			if (Contains<T>()) return Get<T>()!;
			var module = new T();
			_modules.Add(type, module);
			return module;
		}

		public T? Get<T>() where T : IModule {
			_modules.TryGetValue(typeof(T), out IModule? module);
			return (T?)module;
		}

		public void Update() {
			foreach (IModule module in _modules.Values) {
				module.Update();
			}
		}

		public void Shutdown() {
			if (_isShutdown) return;
			_isShutdown = true;
			foreach (KeyValuePair<Type, IModule> module in _modules.Reverse()) {
				_modules.Remove(module.Key);
				module.Value.Shutdown();
			}
		}
	}
}
