#nullable enable
using Elimination.Input;
using Elimination.UI;
using Happy_Elimination.Data;
using KFramework;
using KFramework.Extensions;
using UnityEngine;

namespace Elimination
{
	public class App : MonoBehaviour
	{
		public static InputModule Input => Get<InputModule>();
		public static UiModule UI => Get<UiModule>();
		public static MainModule Main => Get<MainModule>();
		public static DataModule Data => Get<DataModule>();
		public static Framework framework=null!;
		public static void Quit() {
			framework.Shutdown();
			Application.Quit();
		}

		private void Awake() {
			framework = new Framework();
			framework.Init<InputModule>();
			framework.Init<UiModule>();
			framework.Init<MainModule>();
			framework.Init<DataModule>();
		}
		private void Start() {
			Main.ToStartMenu();
		}

		private void Update() {
			framework.Update();
		}

		private void OnApplicationQuit() {
			framework.Shutdown();
		}

		private void OnDestroy() {
			framework.Shutdown();
		}

		private static T Get<T>() where T : IModule {
			return framework.Get<T>().ThrowIfNull();
		}
	}
}