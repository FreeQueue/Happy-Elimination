#nullable enable

using System;
using Cysharp.Threading.Tasks;
using DG.Tweening;
using KFramework;
using UnityEngine;

namespace Elimination.Core.Traits
{
	public class ViewTrait : BrickTrait
	{
		public SpriteRenderer spriteRenderer = null!;
		private TweenManager<string> _tweenManager = null!;

		public Vector3 Position() => Game.View.GetWorldPos(Coord);
		public override void Init() {
			spriteRenderer.sprite = Game.Data.sweetSprites[Brick.ID];
			_tweenManager = new();
			Coord.OnChanged += OnCoordChanged;
		}
		public async UniTask Wait() {
			await _tweenManager.WaitAll();
		}
		private void OnCoordChanged(Vector2Int coord) {
			Vector3 pos = Game.View.GetWorldPos(coord);
			PlayMove(pos, Game.Data.moveDuration, Game.Data.moveEase,true);
		}

		public Tween PlayMove(Vector3 position, float duration, Ease ease = Ease.Linear, bool wait = false) {
			var tween = transform.DOMove(position, duration)
				.SetEase(ease).SetAutoKill();
			AddTween(nameof(PlayMove),tween, wait);
			return tween;
		}

		public void After(string id,Action action) {
			_tweenManager.After(id, action).Forget();
		}
		public void AfterAll(string id,Action action) {
			_tweenManager.AfterAll(id, action).Forget();
		}
		public Tween PlayFade(int alpha, float duration, Ease ease = Ease.Linear, bool wait = false) {
			var tween = spriteRenderer.DOFade(alpha, duration)
				.SetEase(ease).SetAutoKill();
			AddTween(nameof(PlayFade),tween, wait);
			return tween;
		}

		private void AddTween(string id,Tween tween, bool wait) {
			if (wait) {
				_tweenManager.Add(id, tween);
			}
			else {
				_tweenManager.Kill(id);
			}
		}
	}
}
