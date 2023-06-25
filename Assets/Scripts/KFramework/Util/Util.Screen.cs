#nullable enable

using UnityEngine;
using UScreen = UnityEngine.Screen;

namespace KFramework.Utility
{
	partial class Util
	{
		public static class Screen
		{
			public static Vector3 GetWorldPos(Vector3 screenPos, Camera? camera = null) {
				camera ??= Camera.main;
				return camera!.ScreenToWorldPoint(screenPos);
			}

			public static Vector3 GetScreenPos(Vector3 worldPos, Camera? camera = null) {
				camera ??= Camera.main;
				return camera!.WorldToScreenPoint(worldPos);
			}

			public static float PixelPerUnit() {
				float screenHeight = UnityEngine.Screen.currentResolution.height;
				float orthographicSize = Camera.main!.orthographicSize;
				return screenHeight / (2f * orthographicSize);
			}
		}
	}
}
