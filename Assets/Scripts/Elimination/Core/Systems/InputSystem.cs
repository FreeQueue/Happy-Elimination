#nullable enable

using Elimination.Core.Traits;
using Elimination.Input;
using UnityEngine;

namespace Elimination.Core.Systems
{

	public class InputSystem
	{
		public readonly MainGameActions actions;

		public InputSystem() {
			actions = new MainGameActions();
			actions.OnClick+=OnClick;
		}
		private void OnClick(Vector2 screenPos) {
			Vector2Int coord= Game.View.GetCoord(screenPos);
			Game.BrickMap[coord]?.GetTrait<ClickTrait>()?.OnClick?.Invoke();
		}

		public void SetActive(bool input) {
			if (input)
				App.Input.controls.MainGame.AddCallbacks(actions);
			else
				App.Input.controls.MainGame.RemoveCallbacks(actions);
		}
	}
}
