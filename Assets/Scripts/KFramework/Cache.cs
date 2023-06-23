#nullable enable

#region Copyright & License Information
/*
 * Copyright (c) The OpenRA Developers and Contributors
 * This file is part of OpenRA, which is free software. It is made
 * available to you under the terms of the GNU General Public License
 * as published by the Free Software Foundation, either version 3 of
 * the License, or (at your option) any later version. For more
 * information, see COPYING.
 */
#endregion

using System;
using System.Collections;
using System.Collections.Generic;

namespace KFramework
{
	public class Cache<TKey, TValue> : IReadOnlyDictionary<TKey, TValue>
	{
		private readonly Dictionary<TKey, TValue> _cache;
		private readonly Func<TKey, TValue> _loader;

		public Cache(Func<TKey, TValue> loader, IEqualityComparer<TKey> comparer) {
			_loader = loader ?? throw new ArgumentNullException(nameof(loader));
			_cache = new Dictionary<TKey, TValue>(comparer);
		}
		public Cache(Func<TKey, TValue> loader) : this(loader, EqualityComparer<TKey>.Default) {
		}

		public ICollection<TKey> Keys => _cache.Keys;
		public ICollection<TValue> Values => _cache.Values;
		public TValue this[TKey key] => _cache.TryGetValue(key, out TValue value) ? value : _cache[key] = _loader(key);
		public bool ContainsKey(TKey key) => _cache.ContainsKey(key);
		public bool TryGetValue(TKey key, out TValue value) => _cache.TryGetValue(key, out value);
		public int Count => _cache.Count;

		IEnumerable<TKey> IReadOnlyDictionary<TKey, TValue>.Keys => _cache.Keys;

		IEnumerable<TValue> IReadOnlyDictionary<TKey, TValue>.Values => _cache.Values;

		public IEnumerator<KeyValuePair<TKey, TValue>> GetEnumerator() => _cache.GetEnumerator();
		IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
		public void Clear() => _cache.Clear();
	}
}