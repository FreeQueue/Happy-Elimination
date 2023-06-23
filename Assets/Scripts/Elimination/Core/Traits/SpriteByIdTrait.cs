#nullable enable

using Elimination.Core.Systems;
using KFramework.Utility;
using UnityEngine;

namespace Elimination.Core.Traits
{
	[RequireComponent(typeof(SpriteRenderer))]
	public class SpriteByIdTrait : BrickTrait
	{
		public override void Init() {
			BrickData data = Game.Data;
			var spriteRenderer = GetComponent<SpriteRenderer>();
			spriteRenderer.sprite = data.sweetSprites[Brick.ID];
		}
	}
}
