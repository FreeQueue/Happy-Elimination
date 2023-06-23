#nullable enable

using System;
using Elimination.Core;
using KFramework.Extensions;
using KFramework.Utility;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Happy_Elimination
{
	public class SpriteSizeTest:MonoBehaviour
	{
		public SpriteRenderer spriteRenderer=null!;
		public BrickData data=null!;
		public Vector2Int tileSize;
		public Vector2 size;

		[Button]
		public void Resize() {
			Util.Sprite.ResizeSpriteToPixels(spriteRenderer,size);
		}

		[Button]
		public void Tile() {
			Util.Sprite.TileSpriteRenderer(spriteRenderer, tileSize);
		}

		[Button]
		public void Log() {
			Debug.Log($"rect: {spriteRenderer.sprite.rect}");
			Debug.Log($"rect.size: {spriteRenderer.sprite.rect.size}");
			Debug.Log($"bounds: {spriteRenderer.sprite.bounds}");
			Debug.Log($"bounds.size: {spriteRenderer.sprite.bounds.size}");
		}
	}
}
