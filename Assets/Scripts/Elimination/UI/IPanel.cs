using KFramework;

namespace Elimination.UI
{
	public interface IPanel
	{
		public void Open();
		public void Close() {
			App.UI.Close(this);
		}

		public void OnCreate() {
			
		}
		public void OnOpen() {
		}
		public void OnUpdate() {
		}
		public void OnClose() {
		}
	}

	public interface IPanel<T> : IPanel where T : class, IPanel
	{
		void IPanel.Open() {
			App.UI.OpenAbove<T>();
		}
	}
}