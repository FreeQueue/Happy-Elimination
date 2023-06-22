#nullable enable

using KFramework.Extensions;
using UnityEngine;

namespace Elimination.Core.Systems
{
	public class BrickMapGenerator
	{
		public void FillMap() {
			var brickMap = Game.BrickMap;
			var factory = Game.Factory;
			foreach (Brick brick in brickMap) {
				Object.Destroy(brick.gameObject);
			}
			for (int i = 0; i < Game.Data.solidSweetNum; i++) {
				brickMap.Add(brickMap.size.Random(),factory.CreateSolidSweet());
			}
		}
	}
}
