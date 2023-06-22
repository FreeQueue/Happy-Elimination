#nullable enable

using Elimination;
using Elimination.UI;

namespace MainPackage
{
	partial class UI_GamePanel:IPanel<UI_GamePanel>
	{
		void IPanel.OnCreate() {
			_restartButton.onClick.Add(() => {
				App.Main.ToStartMenu();
			});
		}
		void IPanel.OnOpen() {
			
		}
		void IPanel.OnUpdate() {
		}
		void IPanel.OnClose() {
		}
	}
}