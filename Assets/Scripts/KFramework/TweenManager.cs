#nullable enable

using System;
using System.Collections.Generic;
using System.Threading;
using Cysharp.Threading.Tasks;
using DG.Tweening;
using KFramework.Extensions;

namespace KFramework
{
	public class TweenManager<TId>
	{
		private readonly Dictionary<TId, Tween> _tweenDic;
		private bool _disposed;
		public bool completeOnKill;
		public TweenManager(bool completeOnKill = true) {
			_tweenDic = new Dictionary<TId, Tween>();
			this.completeOnKill = completeOnKill;
		}
		public event Action<Tween>? OnAddTween;
		public T Add<T>(TId id, T tween) where T : Tween {
			Kill(id);
			tween.OnKill(() => {
				_tweenDic.Remove(id);
			}).apply(OnAddTween);
			_tweenDic.Add(id, tween);
			return tween;
		}

		public async UniTask After(TId id, Action action) {
			await Wait(id);
			action();
		}


		public async UniTask AfterAll(TId id, Action action) {
			await WaitAll();
			action();
		}

		public Tween? Take(TId id) {
			_tweenDic.Remove(id, out Tween? tween);
			return tween;
		}

		public Tween? Peek(TId id) {
			_tweenDic.TryGetValue(id, out Tween? tween);
			return tween;
		}

		public void Kill(TId id) {
			Kill(id, completeOnKill);
		}

		public void Kill(TId id, bool complete) {
			Tween? tween = Take(id);
			tween.Kill(complete);
		}
		public void KillAll() {
			KillAll(completeOnKill);
		}
		public void KillAll(bool complete) {
			foreach (KeyValuePair<TId, Tween> pair in _tweenDic) {
				pair.Value.Kill(complete);
			}
			_tweenDic.Clear();
		}

		public async UniTask Wait(TId id, CancellationToken token = default) {
			Tween? tween = Peek(id);
			if (tween is not null) await tween.ToUniTask(cancellationToken: token);
		}

		public async UniTask WaitAll(CancellationToken token = default) {
			await UniTask.WaitUntil(() => _tweenDic.Count == 0, cancellationToken: token);
		}
		~TweenManager() {
			KillAll();
		}
	}
}