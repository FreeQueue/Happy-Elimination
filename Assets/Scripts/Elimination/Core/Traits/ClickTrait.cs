#nullable enable

using System;
using Cysharp.Threading.Tasks;
using KFramework.Extensions;

namespace Elimination.Core.Traits
{
	public class ClickTrait : BrickTrait
	{
		public event Func<UniTask>? OnClick;

		public async UniTask Click() {
			var task=OnClick?.Invoke();
			await task.WaitNotNull();
		}
	}
}
