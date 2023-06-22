#nullable enable

using UnityEngine;

namespace KFramework.Extensions
{
	public static class ColorExtensions
	{
		public static void SetA(this ref Color color,int a) {
			color.a = a;
		}

		public static Color WithA(this Color color, int a) {
			color.a = a;
			return color;
		}
	}
}