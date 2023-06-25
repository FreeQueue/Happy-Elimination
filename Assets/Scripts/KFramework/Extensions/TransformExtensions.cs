#nullable enable

using KFramework.Utility;
using UnityEngine;

namespace KFramework.Extensions
{
	public static class TransformExtensions
	{
		public static Vector3 ToScreenPoint(this Transform transform, Camera? camera=null) =>
			Util.Screen.GetScreenPos(transform.position, camera);
	}

}
