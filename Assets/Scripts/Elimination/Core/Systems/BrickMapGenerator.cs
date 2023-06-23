#nullable enable

using Elimination.Core.Traits;
using KFramework.Extensions;
using UnityEngine;

namespace Elimination.Core.Systems
{
	public class BrickMapGenerator
	{
		public void FillMap() {
			BrickData data = Game.Data;
			BrickMap brickMap = Game.BrickMap;
			BrickFactory factory = Game.Factory;
			foreach (Brick brick in brickMap.WhereNotNull()) {
				Object.Destroy(brick.gameObject);
			}
			for (int i = 0; i < data.solidSweetNum; i++) {
				brickMap.Add(brickMap.size.Random(), factory.CreateSolidSweet());
			}
			for (int x = 0; x < brickMap.X; x++) {
				Brick brick = factory.CreateSweet(data.sweetSprites.Count.Random());
				brick.Coord.Value = new Vector2Int(x, -1);
				brick.GetTrait<DropTrait>()?.Drop();
			}
		}
	}
}