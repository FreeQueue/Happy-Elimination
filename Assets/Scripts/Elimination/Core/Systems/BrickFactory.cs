#nullable enable

using System;
using Elimination.Core.Traits;
using KFramework.Extensions;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Elimination.Core.Systems
{
	public class BrickFactory
	{
		public event Action<Brick>? OnCreateBrick;

		public Brick CreateRandomSweet() {
			var id = Random.Range(0, Game.Data.sweetSprites.Count);
			return CreateSweet(id);
		}
		private Brick CreateBrick(int id, Func<Brick> create) {
			Brick brick = create();
			brick.Init(Game.BrickMap, id);
			OnCreateBrick?.Invoke(brick);
			return brick;
		}
		public Brick CreateSweet(int id) => CreateBrick(id, () => Game.Data.sweet.Instantiate());

		public Brick CreateSuperSweet(int count) => CreateBrick(1000, () => {
			int power = count;

			var brick= Game.Data.superSweet.Instantiate();
			brick.GetTrait<ExploreOnClickTrait>()!.power = power;
			return brick;
		});

		public Brick CreateSolidSweet() => CreateBrick(1001, () => Game.Data.solidSweet.Instantiate());
	}
}
