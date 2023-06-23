#nullable enable

using UnityEngine;
using USprite = UnityEngine.Sprite;

namespace KFramework.Utility
{
	public static partial class Util
	{
		public static class Sprite
		{
			public static Vector2 TileSpriteRenderer(SpriteRenderer spriteRenderer, float tilingFactor) =>
				TileSpriteRenderer(spriteRenderer, new Vector2(tilingFactor, tilingFactor));

			public static Vector2 TileSpriteRenderer(
				SpriteRenderer spriteRenderer, float tilingWidth, float tilingHeight
			) => TileSpriteRenderer(spriteRenderer, new Vector2(tilingWidth, tilingHeight));

			/// <summary>
			///     将指定的精灵渲染器进行平铺操作，返回平铺后的像素尺寸。
			/// </summary>
			/// <param name="spriteRenderer">需要进行平铺操作的精灵渲染器</param>
			/// <param name="tilingFactor">平铺系数</param>
			/// <returns>平铺后的像素尺寸</returns>
			public static Vector2 TileSpriteRenderer(
				SpriteRenderer spriteRenderer, Vector2 tilingFactor
			) {
				spriteRenderer.drawMode = SpriteDrawMode.Tiled;
				USprite sprite = spriteRenderer.sprite;
				// 获取Sprite的实际像素尺寸
				Vector2 spriteSize = sprite.rect.size;
				// 将实际尺寸乘以tilingFactor，得到平铺后的像素尺寸
				Vector2 tiledSize = spriteSize * tilingFactor;
				// 设置平铺的尺寸
				spriteRenderer.size = tiledSize / sprite.pixelsPerUnit;
				return tiledSize;
			}

			public static void ResizeSpriteToPixels(SpriteRenderer spriteRenderer, Vector2 desiredSize) {
				USprite sprite = spriteRenderer.sprite;
				Vector2 spriteSize = sprite.bounds.size;
				var scale = new Vector3(desiredSize.x / spriteSize.x, desiredSize.y / spriteSize.y, 1f);
				spriteRenderer.transform.localScale = scale;
			}
		}
	}
}