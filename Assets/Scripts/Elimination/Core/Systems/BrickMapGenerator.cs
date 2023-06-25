#nullable enable

using Cysharp.Threading.Tasks;
using Elimination.Core.Traits;
using KFramework;
using KFramework.Extensions;
using UnityEngine;
using UnityEngine.Pool;

namespace Elimination.Core.Systems
{
	public class BrickMapGenerator
	{
		public async UniTask FillMap() {
			BrickData data = Game.Data;
			BrickMap brickMap = Game.BrickMap;
			BrickFactory factory = Game.Factory;
			foreach (Brick brick in brickMap.WhereNotNull()) {
				Object.Destroy(brick.gameObject);
			}
			for (int i = 0; i < data.solidSweetNum; i++) {
				Vector2Int coord = new(Random.Range(1,brickMap.X-1),brickMap.Y.Random());
				if (brickMap[coord] != null) {
					i--;
					continue;
				}
				Brick solidSweet = factory.CreateSolidSweet();
				solidSweet.GetTrait<ViewTrait>()?.Move(coord);
				brickMap.Add(coord, solidSweet);
			}
			var tasks = ListPool<UniTask>.Get();
			for (int x = 0; x < brickMap.X; x++) {
				Vector2Int targetCoord = new(x, -1);
				if (brickMap[targetCoord.To(Direction.Down)] is not null) continue;
				Brick brick = factory.CreateSweet(data.sweetSprites.Count.Random());
				brick.GetTrait<ViewTrait>()?.Move(targetCoord);
				var task = brick.GetTrait<DropTrait>()?.Drop();
				if (task.HasValue) {
					tasks.Add(task.Value);
				}
			}
			await UniTask.WhenAll(tasks);
			ListPool<UniTask>.Release(tasks);
			await Game.Eliminator.EliminateAll();
		}
	}
}
