#nullable enable

using KFramework;
using KFramework.Extensions;
using UnityEngine;

namespace Elimination.Core.Traits
{
	[RequireComponent(typeof(ViewTrait))]
	public class DragTrait : BrickTrait
	{
		public void OnDrag(Direction? direction) {
			var data = Game.Data;
			var view = GetTrait<ViewTrait>()!;
			Vector3 target = view.Position();
			if (direction.HasValue) {
				Vector2 offset = (Vector2)direction.Value.GetVector() * data.dragDis;
				target = target.AddXY(offset);
			}
			view.PlayMoveSync(target, data.dragDuration, data.dragEase);
		}
	}
}
