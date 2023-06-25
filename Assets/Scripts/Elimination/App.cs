#nullable enable
using Elimination.Audio;
using Elimination.Input;
using Elimination.UI;
using Happy_Elimination.Data;
using KFramework;
using KFramework.Extensions;
using UnityEditor;
using UnityEngine;

namespace Elimination
{
	public class App : MonoBehaviour
	{
		public static Framework framework = null!;
		public static InputModule Input => Get<InputModule>();
		public static UiModule UI => Get<UiModule>();
		public static MainModule Main => Get<MainModule>();
		public static DataModule Data => Get<DataModule>();
		public static AudioModule Audio => Get<AudioModule>();
		#region Event Functions
		private void Awake() {
			framework = new();
			framework.Init<DataModule>();
			framework.Init<AudioModule>();
			framework.Init<InputModule>();
			framework.Init<UiModule>();
			framework.Init<MainModule>();
		}
		private void Start() {
			Main.ToStartMenu();
		}

		private void Update() {
			framework.Update();
		}

		private void OnDestroy() {
			framework.Shutdown();
		}

		private void OnApplicationQuit() {
			framework.Shutdown();
		}
		#endregion

		public static void Quit() {
			framework.Shutdown();
#if UNITY_EDITOR
			EditorApplication.isPlaying = false;
#else
			Application.Quit();
#endif
		}

		private static T Get<T>() where T : IModule => framework.Get<T>().ThrowIfNull();
	}
}
