#nullable enable

using UnityEngine;

namespace KFramework.Extensions
{
	public static class TransformExtensions
	{
		public static Vector3 ToScreenPoint(this Transform transform) =>
			ToScreenPoint(transform, Camera.main.ThrowIfNull());
		public static Vector3 ToScreenPoint(this Transform transform, Camera camera) =>
			// 将世界坐标点转换为相机视口坐标系中的点
			camera.WorldToScreenPoint(transform.position);
	}
}