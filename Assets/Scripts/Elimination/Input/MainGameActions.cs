#nullable enable

using System;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Elimination.Input
{
	public class MainGameActions : Controls.IMainGameActions
	{
		private bool _isHold;
		void Controls.IMainGameActions.OnPoint(InputAction.CallbackContext context) {
			var screenPos = context.ReadValue<Vector2>();
			if (context.started) OnPointDown?.Invoke(screenPos);
			else if (context.performed) OnPointPerform?.Invoke(screenPos);
			else if (context.canceled) {
				OnPointUp?.Invoke(screenPos);
				if (!_isHold) OnClick?.Invoke(screenPos);
			}
		}

		void Controls.IMainGameActions.OnPointHold(InputAction.CallbackContext context) {
			var screenPos = context.ReadValue<Vector2>();
			if (context.started) {
				_isHold = true;
				OnPointHoldStart?.Invoke(screenPos);
			} else if (context.performed) OnPointHoldPerform?.Invoke(screenPos);
			else if (context.canceled) {
				OnPointHoldEnd?.Invoke(screenPos);
				_isHold = false;
			}
		}
		public event Action<Vector2>? OnPointHoldStart;
		public event Action<Vector2>? OnPointHoldPerform;
		public event Action<Vector2>? OnPointHoldEnd;
		public event Action<Vector2>? OnPointDown;
		public event Action<Vector2>? OnPointPerform;
		public event Action<Vector2>? OnPointUp;
		public event Action<Vector2>? OnClick;
	}
}