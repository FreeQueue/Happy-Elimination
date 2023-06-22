#nullable enable

using System.Linq;
using KFramework;
using KFramework.Extensions;
using UnityEngine;

namespace Elimination.Core.Traits
{
	[RequireComponent(typeof(ClickTrait))]
	public class ExploreOnClickTrait : BrickTrait
	{
		public int power;
		public bool crossOrCircle;
		public override void Init() {
			var click = GetTrait<ClickTrait>();
			if (click is not null) {
				click.OnClick += OnClick;
			}
		}
		private void OnClick() {
			var bricks = crossOrCircle ? BrickMap.GetCross(Coord, power) : BrickMap.GetCircles(Coord, power);
			bricks.Select(brick => brick?.GetTrait<DestroyTrait>()).WhereNotNull()
				.ForEach(trait => trait.Destroy());
		}
	}
}
