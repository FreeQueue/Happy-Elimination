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
			actions = new();
			actions.OnClick += OnClick;
		}
		private void OnClick(Vector2 screenPos) {
			Debug.LogFormat("click{0}",screenPos);
			Vector2Int coord = Game.View.GetCoord(screenPos);
			if (!Game.BrickMap.Contains(coord)) return;
			var task = Game.BrickMap[coord]?.GetTrait<ClickTrait>()?.Click();
			if (task is null) return;
			SetActive(false);
			task.Value.GetAwaiter().OnCompleted(() => SetActive(true));
		}

		public void SetActive(bool input) {
			Debug.Log($"input active:{input}");
			if (input)
				App.Input.controls.MainGame.AddCallbacks(actions);
			else
				App.Input.controls.MainGame.RemoveCallbacks(actions);
		}
	}
}
