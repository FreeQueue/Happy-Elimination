#nullable enable

using System.Threading;
using Cysharp.Threading.Tasks;
using DG.Tweening;
using KFramework;
using KFramework.Extensions;
using KFramework.Utility;
using UnityEngine;

namespace Elimination.Core.Traits
{
	public enum WaitAnim
	{
		Move,
		Fade,
	}

	[RequireComponent(typeof(SpriteRenderer))]
	public class ViewTrait : BrickTrait
	{
		private SpriteRenderer _spriteRenderer = null!;
		private TweenManager<WaitAnim> _tweenManager = null!;

		public Vector3 Position() => Game.View.GetWorldPos(Coord);
		public override void Init() {
			_spriteRenderer = GetComponent<SpriteRenderer>();
			_tweenManager = new();
			Brick.Coord.OnChanged+=OnCoordChanged;
			Util.Sprite.ResizeSpriteToPixels(_spriteRenderer, Game.View.GridSize);
		}

		public void OnCoordChanged(Vector2Int oldCoord,Vector2Int newCoord) {
			BrickData data = Game.Data;
			Vector3 target =  Game.View.GetWorldPos(newCoord);
			int dis = oldCoord.Step(newCoord);
			PlayMoveSync(target,data.moveDurationPerUnit*dis,data.moveEase,true);
		}
		public void Move(Vector2Int coord) {
			transform.position = Game.View.GetWorldPos(coord);
			Brick.Coord.SetNoFire(coord);
		}

		private Tween PlayMove(Vector3 position, float duration, Ease ease = Ease.Linear) =>
			transform.DOMove(position, duration).SetEase(ease).SetAutoKill();
		public Tween PlayMoveSync(Vector3 position, float duration, Ease ease = Ease.Linear, bool wait = false) {
			Tween tween = PlayMove(position, duration, ease);
			AddTween(WaitAnim.Move, tween, wait);
			return tween;
		}
		public async UniTask PlayMoveAsync(
			Vector3 position, float duration, Ease ease = Ease.Linear, CancellationToken token = default
		) {
			await Wait(WaitAnim.Move);
			await PlayMove(position, duration, ease).WithCancellation(token);
		}
		private Tween PlayFade(int alpha, float duration, Ease ease = Ease.Linear) =>
			_spriteRenderer.DOFade(alpha, duration).SetEase(ease).SetAutoKill();
		public Tween PlayFadeSync(int alpha, float duration, Ease ease = Ease.Linear, bool wait = false) {
			Tween tween = PlayFade(alpha,duration,ease);
			AddTween(WaitAnim.Fade, tween, wait);
			return tween;
		}
		public async UniTask PlayFadeAsync(
			int alpha, float duration, Ease ease = Ease.Linear, CancellationToken token = default
		) => await PlayFade(alpha, duration, ease).WithCancellation(token);
		public UniTask Wait(WaitAnim id) => _tweenManager.Wait(id);
		public UniTask WaitAll() => _tweenManager.WaitAll();
		private void AddTween(WaitAnim id, Tween tween, bool wait) {
			if (wait) _tweenManager.Add(id, tween);
			else _tweenManager.Kill(id);
		}
	}
}
