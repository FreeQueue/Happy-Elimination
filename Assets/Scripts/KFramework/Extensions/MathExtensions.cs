#nullable enable

using UnityEngine;

namespace KFramework.Extensions
{
	public static class MathExtensions
	{
		public static int Abs(this int num) => Mathf.Abs(num);
		public static float Abs(this float num) => Mathf.Abs(num);
		public static int Random(this int num) => UnityEngine.Random.Range(0,num);
		public static float Random(this float num) => UnityEngine.Random.Range(0,num);
	}
}
