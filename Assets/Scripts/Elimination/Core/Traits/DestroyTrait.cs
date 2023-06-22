#nullable enable

using System;
using DG.Tweening;
using KFramework.Extensions;

namespace Elimination.Core.Traits
{
	public class DestroyTrait : BrickTrait
	{
		public event Action? OnDestroy;
		public void Destroy() {
			var brickView = GetTrait<ViewTrait>();
			foreach (Brick? neighbor in BrickMap.GetCross(Coord, 1)) {
				neighbor?.GetTrait<ListenNeighborTrait>()?.OnNeighborDestroy?.Invoke(Brick);
			}
			BrickMap.Remove(Coord);
			brickView?.PlayFade(0, Game.Data.fadeDuration, Game.Data.fadeEase)
				.OnComplete(() => {
					OnDestroy?.Invoke();
					Destroy(gameObject);
				});
		}
	}
}
