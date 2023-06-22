#nullable enable

using UnityEngine;

namespace KFramework.Extensions
{
	public static class ObjectExtensions
	{
		public static T Instantiate<T>(this T @object) where T : Object {
			return Object.Instantiate(@object);
		}
	}
}