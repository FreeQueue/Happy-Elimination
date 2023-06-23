#nullable enable

using KFramework;
using KFramework.Extensions;
using UnityEngine;

namespace Elimination.Core.Traits
{
	public class DragTrait : BrickTrait
	{
		public void OnDrag(Direction? direction) {
			var view = GetTrait<ViewTrait>();
			if (view is not null) {
				Vector3 target = view.Position();
				if (direction.HasValue) {
					Vector2 offset = (Vector2)direction.Value.GetVector() * Game.Data.dragDis;
					target = target.AddXY(offset);
				}
				view.PlayMove(target, Game.Data.dragDuration, Game.Data.dragEase);
			}
		}
	}
}