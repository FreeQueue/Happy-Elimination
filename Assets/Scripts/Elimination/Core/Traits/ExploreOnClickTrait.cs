#nullable enable

using System.Collections.Generic;
using System.Linq;
using Cysharp.Threading.Tasks;
using KFramework.Extensions;
using UnityEngine;

namespace Elimination.Core.Traits
{
	[RequireComponent(typeof(ClickTrait))]
	public class ExploreOnClickTrait : BrickTrait
	{

		#region Serialized Fields
		public int power;
		public bool crossOrCircle;
		#endregion

		public override void Init() {
			var click = GetTrait<ClickTrait>();
			if (click is not null) click.OnClick += OnClick;
		}
		private async UniTask OnClick() {
			if (power > 8) {
				await Game.Eliminator.EliminateAll();
				return;
			}
			IEnumerable<Brick?> bricks
				= crossOrCircle ? BrickMap.GetCross(Coord, power) : BrickMap.GetCircles(Coord, power);
			var tasks = bricks.Select(brick => brick?.GetTrait<DestroyTrait>()?.Destroy());
			await UniTask.WhenAll(tasks.Select(task => task.WaitNotNull()));
		}
	}
}
