using FairyGUI;
using MainPackage;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Happy_Elimination
{
	public class Test : MonoBehaviour
	{
		private UI_GamePanel _gamePanel;
		private UI_OverPanel _overPanel;
		private UI_StartPanel _startPanel;

		#region Event Functions
		private void Start() {
			UIPackage.AddPackage("FairyGUI/MatchSweet");

			MainPackageBinder.BindAll();
			_startPanel = UI_StartPanel.CreateInstance();
			_gamePanel = UI_GamePanel.CreateInstance();
			_overPanel = UI_OverPanel.CreateInstance();
			GRoot.inst.AddChild(_startPanel);
			_startPanel._playButton.onClick.Add(() => {
				GRoot.inst.AddChild(_gamePanel);
			});
			_gamePanel._restartButton.onClick.Add(() => {
				GRoot.inst.AddChild(_overPanel);
			});
			_overPanel._overMenu._closeButton.onClick.Add(() => {
				GRoot.inst.RemoveChild(_overPanel);
			});
		}

		private void Update() {
			if (Input.GetMouseButtonDown(0)) Debug.Log(Mouse.current.position.ReadValue());
		}
		#endregion

	}
}