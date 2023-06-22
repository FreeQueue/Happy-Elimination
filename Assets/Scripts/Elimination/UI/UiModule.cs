#nullable enable

using System.Linq;
using FairyGUI;
using KFramework;
using MainPackage;

namespace Elimination.UI
{
	public class UiModule : IModule
	{
		private readonly UiPool _uiPool;

		public UiModule() {
			UIPackage.AddPackage("FairyGUI/MatchSweet");
			MainPackageBinder.BindAll();
			_uiPool = new UiPool();
		}

		public void Close(IPanel ui) {
			int uiIndex = GRoot.inst.GetChildIndex(ui as GObject);
			if (uiIndex != -1) {
				ui.OnClose();
				GRoot.inst.RemoveChildAt(uiIndex);
				_uiPool.Release(ui);
			}
		}

		public void CloseAll() {
			foreach (GObject ui in GRoot.inst.GetChildren().Reverse()) {
				if (ui is IPanel panel) {
					panel.OnClose();
					_uiPool.Release(panel);
				}
			}
			GRoot.inst.RemoveChildren();
		}

		public T Open<T>() where T : class, IPanel {
			CloseAll();
			return OpenAbove<T>();
		}

		public T OpenAbove<T>() where T : class, IPanel {
			var ui = _uiPool.Get<T>();
			ui.OnOpen();
			GRoot.inst.AddChild(ui as GObject);
			return ui;
		}
	}
}