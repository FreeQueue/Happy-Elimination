#nullable enable
using System;
using System.Collections.Generic;
using System.Linq;
using Elimination.Audio;
using Elimination.Input;
using Elimination.UI;
using Happy_Elimination.Data;
using KFramework;
using KFramework.Extensions;
using Sirenix.OdinInspector;
using UnityEditor;

namespace Elimination
{
	public class App : SerializedMonoBehaviour
	{
		public static Framework framework = null!;
		public static InputModule Input => Get<InputModule>();
		public static UiModule UI => Get<UiModule>();
		public static MainModule Main => Get<MainModule>();
		public static DataModule Data => Get<DataModule>();
		public static AudioModule Audio => Get<AudioModule>();

		[ShowInInspector] [TypeFilter(nameof(GetModuleTypes))]
		private Dictionary<Type, Type?> _modules = new();

		public IEnumerable<Type> GetModuleTypes() {
			var q = typeof(IModule).Assembly.GetTypes()
				.Where(x => typeof(IModule).IsAssignableFrom(x)); // Excludes classes not inheriting from BaseClass
			return q;
		}

		#region Event Functions
		private void Awake() {
			framework = new();
			// foreach (var pair in _modules) {
			// 	framework.Init(pair.Key, (IModule)Activator.CreateInstance(pair.Value));
			// }
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
