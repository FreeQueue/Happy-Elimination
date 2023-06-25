#nullable enable
using KFramework;
using UnityEngine;

namespace Elimination.Input
{
	public class InputModule : IModule
	{
		private readonly MainGameActions _actions;
		public readonly Controls controls;

		public InputModule() {
			controls = new();
			_actions = new();
			_actions.OnPointDown += screenPos => {
				LastPointDown = screenPos;
			};
			_actions.OnPointUp += screenPos => {
				LastPointUp = screenPos;
			};
			controls.MainGame.AddCallbacks(_actions);
			controls.Enable();
		}
		public Vector2 LastPointDown { get; private set; }
		public Vector2 LastPointUp { get; private set; }
	}
}
