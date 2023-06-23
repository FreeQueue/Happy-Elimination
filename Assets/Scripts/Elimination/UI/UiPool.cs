#nullable enable

using System;
using System.Collections.Generic;
using UnityEngine.Pool;

namespace Elimination.UI
{
	public class UiPool
	{
		private readonly Dictionary<Type, Func<IPanel>> _createUis = new Dictionary<Type, Func<IPanel>>();
		private readonly Dictionary<Type, ObjectPool<IPanel>> _uiPools = new Dictionary<Type, ObjectPool<IPanel>>();

		public T Create<T>() where T : IPanel {
			Type uiType = typeof(T);
			if (!_createUis.TryGetValue(uiType, out Func<IPanel>? createUi)) {
				createUi = (Func<IPanel>)Delegate.CreateDelegate(typeof(Func<IPanel>), uiType,
					"CreateInstance");
				_createUis.Add(uiType, createUi);
			}
			var ui = (T)createUi();
			ui.OnCreate();
			return ui;
		}

		public T Get<T>() where T : class, IPanel {
			Type uiType = typeof(T);
			if (!_uiPools.TryGetValue(uiType, out ObjectPool<IPanel>? uiPool)) uiPool = AddPool<T>();
			return (T)uiPool.Get();
		}

		public void Release(IPanel ui) {
			Type uiType = ui.GetType();
			if (!_uiPools.TryGetValue(uiType, out ObjectPool<IPanel>? uiPool))
				throw new ArgumentException($"Invalid ui({uiType.Name}) release before create pool");
			uiPool.Release(ui);
		}

		private ObjectPool<IPanel> AddPool<T>() where T : class, IPanel {
			ObjectPool<IPanel> uiPool = new ObjectPool<IPanel>(Create<T>);
			_uiPools.Add(typeof(T), uiPool);
			return uiPool;
		}
	}
}