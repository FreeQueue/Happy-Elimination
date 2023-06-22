#nullable enable

using UnityEngine;
using UScreen=UnityEngine.Screen;

namespace KFramework.Utility
{
	partial class Util
	{
		public static class Screen
		{
			public static Vector3 GetWorldPos(Vector2 screenPos,Camera? camera=null) {
				camera ??= Camera.main;
				return camera!.ScreenToWorldPoint(screenPos);
			}
		}
	}
}