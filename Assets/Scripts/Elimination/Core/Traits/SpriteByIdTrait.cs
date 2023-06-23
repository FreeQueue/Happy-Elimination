#nullable enable

using Elimination.Core.Systems;
using KFramework.Utility;
using UnityEngine;

namespace Elimination.Core.Traits
{
	[RequireComponent(typeof(SpriteRenderer))]
	public class SpriteByIdTrait : BrickTrait
	{
		private SpriteRenderer _spriteRenderer = null!;
		public override void Init() {
			BrickData data = Game.Data;
			_spriteRenderer = GetComponent<SpriteRenderer>();
			_spriteRenderer.sprite = data.sweetSprites[Brick.ID];
		}
	}
}
