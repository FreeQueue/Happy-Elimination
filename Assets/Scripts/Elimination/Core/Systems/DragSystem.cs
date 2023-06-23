#nullable enable

using Elimination.Core.Traits;
using Elimination.Input;
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
			MainGameActions actions = Game.Input.actions;
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
				MutableState<Vector2Int> moveCoord = _holdBrick.Coord;
				Vector2Int swapCoord = moveCoord + direction.Value.GetVector();
				Game.BrickMap.Swap(moveCoord, swapCoord);
				Game.View.WaitAll().GetAwaiter().OnCompleted(() => Game.Eliminator.AfterDrag(moveCoord, swapCoord));

			} else _holdBrick.Coord.Value = _holdBrick.Coord;
			_holdBrick = null;
			Game.Input.SetActive(false);
		}
	}
}