#nullable enable

using System;
using Elimination.Input;
using Sirenix.OdinInspector;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Happy_Elimination
{
	public class InputTest : MonoBehaviour
	{
		private InputModule _inputModule;
		MainGameActions actions = new MainGameActions();
		private bool enable1, enable2;

		private void Awake() {
			_inputModule = new();
			actions.OnClick += Debug("OnClick");
			// actions.OnPointDown += v => Debug.LogFormat("OnPointDown{0}", v);
			// actions.OnPointPerform += v => Debug.LogFormat("OnPointPerform{0}", v);
			// actions.OnPointUp += v => Debug.LogFormat("OnPointUp{0}", v);
			actions.OnPointHoldStart += Debug("OnPointHoldStart");
			//actions.OnPointHoldPerform += v => Debug.LogFormat("OnPointHoldPerform{0}", v);
			actions.OnPointHoldEnd += Debug("OnPointHoldEnd");
			_inputModule.controls.Enable();
		}
		[Button]
		private void Test1() {
			if (enable1) {
				_inputModule.controls.MainGame.RemoveCallbacks(actions);
				enable1 = false;
			} else {
				_inputModule.controls.MainGame.AddCallbacks(actions);
				enable1 = true;
			}
		}
		// [Button]
		// private void Test2() {
		// 	if (enable2) {
		// 		_inputModule.controls.MainGame.Point.started += Debug;
		// 		_inputModule.controls.MainGame.PointHold.started += Debug;
		// 		enable2 = false;
		// 	} else {
		// 		_inputModule.controls.MainGame.Point.started -= Debug;
		// 		_inputModule.controls.MainGame.PointHold.started -= Debug;
		// 		enable2 = true;
		// 	}
		// }
		private void Debug(InputAction.CallbackContext context) => UnityEngine.Debug.Log(context);
		private static Action<Vector2> Debug(string name) => v => UnityEngine.Debug.LogFormat("{0}:{1}", name, v);
	}
}
