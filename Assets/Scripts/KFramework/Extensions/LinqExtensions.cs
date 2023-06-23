#nullable enable

using System;
using System.Collections.Generic;
using System.Linq;

namespace KFramework.Extensions
{
	public static class LinqExtensions
	{
		public static IEnumerable<T> WhereNotNull<T>(this IEnumerable<T?> source) where T : struct {
			return source.Where(x => x.HasValue).Select(x => x!.Value);
		}
		public static IEnumerable<T> WhereNotNull<T>(this IEnumerable<T?> source) {
			return source.Where(x => x is not null)!;
		}

		public static IEnumerable<T> ForEach<T>(this IEnumerable<T> source, Action<T> action) {
			foreach (T obj in source) {
				action(obj);
			}
			return source;
		}
	}
}