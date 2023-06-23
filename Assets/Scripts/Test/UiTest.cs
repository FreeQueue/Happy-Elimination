using FairyGUI;
using MainPackage;
using UnityEngine;

namespace Happy_Elimination
{
	public class UiTest : MonoBehaviour
	{
		private UI_GamePanel _gamePanel;

		private void Start() {
			UIPackage.AddPackage("FairyGUI/MatchSweet");

			MainPackageBinder.BindAll();
			_gamePanel = UI_GamePanel.CreateInstance();

			GRoot.inst.AddChild(_gamePanel);
		}
	}
}
