#nullable enable

using Elimination.Core.Traits;
using KFramework;
using KFramework.Extensions;
using UnityEngine;

namespace Elimination.Core.Systems
{
	public class DragSystem
	{
		private DragTrait? _holdBrick;
		private Direction? _lastDirection;

		public DragSystem() {
			var actions = Game.Input.actions;
			actions.OnPointHoldStart += OnPointHoldStart;
			actions.OnPointHoldPerform += OnPointHoldPerform;
			actions.OnPointHoldEnd += OnPointHoldEnd;
		}

		private void OnPointHoldStart(Vector2 screenPos) {
			Vector2Int coord = Game.View.GetCoord(screenPos);
			_holdBrick = Game.BrickMap[coord]?.GetTrait<DragTrait>();
		}
		private void OnPointHoldPerform(Vector2 screenPos) {
			if (_holdBrick == null) return;
			Direction? direction = App.Input.LastPointDown.GetDirection(screenPos, 35);
			if (direction == _lastDirection) return;
			_lastDirection = direction;
			_holdBrick.OnDrag(direction);
		}
		private void OnPointHoldEnd(Vector2 screenPos) {
			if (_holdBrick == null) return;
			Direction? direction = App.Input.LastPointDown.GetDirection(screenPos, 35);
			if (direction.HasValue) {
				Game.BrickMap.Swap(_holdBrick.Coord, _holdBrick.Coord + direction.Value.GetVector());
			} else {
				_holdBrick.Coord.Value = _holdBrick.Coord;
			}
			_holdBrick = null;
			Game.Input.SetActive(false);
		}
	}
}
