#nullable enable

using System;
using Elimination.Input;
using KFramework;
using Sirenix.OdinInspector;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Happy_Elimination
{
	public class InputTest : MonoBehaviour
	{
		private InputModule _inputModule;
		private readonly MainGameActions _actions1 = new();
		private readonly MainGameActions _actions2 = new();
		private bool _enable1, _enable2;
		private Vector2Int coord;
		private void Awake() {
			_inputModule = new();
			_actions1.OnClick += Debug("OnClick");
			// actions.OnPointDown += v => Debug.LogFormat("OnPointDown{0}", v);
			// actions.OnPointPerform += v => Debug.LogFormat("OnPointPerform{0}", v);
			// actions.OnPointUp += v => Debug.LogFormat("OnPointUp{0}", v);
			_actions1.OnPointHoldStart += Debug("OnPointHoldStart");
			//actions.OnPointHoldPerform += v => Debug.LogFormat("OnPointHoldPerform{0}", v);
			_actions1.OnPointHoldEnd += Debug("OnPointHoldEnd");

			_actions2.OnPointHoldPerform += OnPointHoldPerform;
			_actions2.OnPointHoldEnd += OnPointHoldEnd;

			_inputModule.controls.Enable();
		}
		private void OnPointHoldEnd(Vector2 v) {
			var direction=_inputModule.LastPointDown.GetDirection(v, 35);
			UnityEngine.Debug.Log(direction);
		}
		private void OnPointHoldPerform(Vector2 v) {
			var direction=_inputModule.LastPointDown.GetDirection(v, 35);
			UnityEngine.Debug.Log(direction);
		}
		[Button]
		private void Test1() {
			if (_enable1) {
				_inputModule.controls.MainGame.RemoveCallbacks(_actions1);
				_enable1 = false;
			} else {
				_inputModule.controls.MainGame.AddCallbacks(_actions1);
				_enable1 = true;
			}
		}
		[Button]
		private void Test2() {
			if (_enable2) {
				_inputModule.controls.MainGame.RemoveCallbacks(_actions2);
				_enable2 = false;
			} else {
				_inputModule.controls.MainGame.AddCallbacks(_actions2);
				_enable2 = true;
			}
		}
		private void Debug(InputAction.CallbackContext context) => UnityEngine.Debug.Log(context);
		private static Action<Vector2> Debug(string name) => v => UnityEngine.Debug.LogFormat("{0}:{1}", name, v);
	}
}
