#nullable enable
using KFramework;
using UnityEngine;

namespace Elimination.Input
{
	public class InputModule : IModule
	{
		public readonly Controls controls;
		private readonly MainGameActions _actions;
		public Vector2 LastPointDown { get; private set; }
		public Vector2 LastPointUp { get; private set; }

		public InputModule() {
			controls = new Controls();
			_actions = new MainGameActions();
			_actions.OnPointDown+= screenPos => {
				LastPointDown = screenPos;
			};
			_actions.OnPointUp+= screenPos => {
				LastPointUp = screenPos;
			};
			controls.MainGame.AddCallbacks(_actions);
		}
	}
}