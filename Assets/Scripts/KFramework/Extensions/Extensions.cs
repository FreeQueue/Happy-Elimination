#nullable enable

using System;
using System.Runtime.CompilerServices;
using Cysharp.Threading.Tasks;

namespace KFramework.Extensions
{
	public static class Extensions
	{
		public static T ThrowIfNull<T>(this T? @this) {
			if (@this is null) throw new NullReferenceException();
			return @this;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static T let<T>(this T @this, Action<T> action) {
			action(@this);
			return @this;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static T apply<T>(this T @this, Action<T>? action) {
			action?.Invoke(@this);
			return @this;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static TResult let<T, TResult>(this T @this, Func<T, TResult> action) => action(@this);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static TResult? apply<T, TResult>(this T @this, Func<T, TResult>? action) => action switch {
			not null => action(@this),
			_ => default
		};

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static async UniTask<T> let<T>(this T @this, Func<T, UniTask> action) {
			await action(@this);
			return @this;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static async UniTask<T> apply<T>(this T @this, Func<T, UniTask>? action) {
			if (action is not null) await action(@this);
			return @this;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static async UniTask<TResult> let<T, TResult>(this T @this, Func<T, UniTask<TResult>> action) =>
			await action(@this);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static async UniTask<TResult?> apply<T, TResult>(this T @this, Func<T, UniTask<TResult>>? action) {
			if (action is not null) return await action(@this);
			return default;
		}
	}
}
