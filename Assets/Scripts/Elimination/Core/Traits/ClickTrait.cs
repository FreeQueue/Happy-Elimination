#nullable enable

using System;
using UnityEngine;

namespace Elimination.Core.Traits
{
	public class ClickTrait:BrickTrait
	{
		public Action? OnClick;
	}
}
