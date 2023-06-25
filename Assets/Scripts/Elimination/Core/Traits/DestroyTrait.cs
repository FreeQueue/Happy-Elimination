#nullable enable

using System;
using Cysharp.Threading.Tasks;
using KFramework.Extensions;
using UnityEngine;
using UnityEngine.Pool;

namespace Elimination.Core.Traits
{
	public class DestroyTrait : BrickTrait
	{
		public event Action? OnDestroy;
		public async UniTask Destroy() {
			var brickView = GetTrait<ViewTrait>();
			var tasks=ListPool<UniTask>.Get();
			foreach (Brick? neighbor in BrickMap.GetCross(Coord, 1)) {
				var task=neighbor?.GetTrait<ListenNeighborTrait>()?.OnNeighborDestroy?.Invoke(Brick);
				task?.let(tasks.Add);
			}
			BrickMap.Remove(Coord);
			OnDestroy?.Invoke();
			if (brickView is not null) {
				await brickView.PlayFadeAsync(0, Game.Data.fadeDuration, Game.Data.fadeEase);
			}
			Destroy(gameObject);
			await UniTask.WhenAll(tasks);
			ListPool<UniTask>.Release(tasks);
		}
	}
}
