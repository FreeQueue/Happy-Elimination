#nullable enable

using System.Linq;
using Cysharp.Threading.Tasks;
using Elimination.Core.Traits;
using KFramework.Extensions;
using KFramework.Utility;
using UnityEngine;

namespace Elimination.Core.Systems
{
	public class ViewSystem
	{
		private readonly GameObject _grids;
		private readonly Vector2 _viewStart;
		public Vector2 GridSize { get; }

		public ViewSystem() {
			BrickData data = App.Data.brickData;
			_grids = data.grids.Instantiate();
			//可视化数据
			GridSize = data.mapViewSize.Divide(data.mapSize);
			SetGridsSprite(data);
			Vector2Int offset = data.mapViewSize / 2;
			_viewStart = _grids.transform.ToScreenPoint().XY().ToViewSpace() - offset;
		}

		public void SetGridsSprite(BrickData data) {
			var spriteRenderer = _grids.GetComponent<SpriteRenderer>();
			Util.Sprite.TileSpriteRenderer(spriteRenderer, data.mapSize);
			Util.Sprite.ResizeSpriteToPixels(spriteRenderer, data.mapViewSize);
		}

		public Vector2Int GetCoord(Vector2 screenPos) {
			Vector2 gridPos = screenPos - _viewStart;
			// 计算相对于起始点的格子偏移量
			return gridPos.Divide(GridSize).FloorToInt();
		}

		public Vector3 GetWorldPos(Vector2Int coord) {
			// 计算格子中心的屏幕坐标
			Vector2 gridCenter = _viewStart + coord * GridSize + GridSize / 2;
			// 将格子中心的屏幕坐标转换为世界坐标
			return Util.Screen.GetWorldPos(gridCenter.ToScreenSpace());
		}

		public async UniTask WaitAll() {
			foreach (ViewTrait brick in Game.BrickMap.Select(brick => brick?.GetTrait<ViewTrait>()).WhereNotNull()) {
				await brick.Wait();
			}
		}
	}

	internal static class ViewSpaceExtensions
	{
		public static Vector2 ToViewSpace(this Vector2 screenPos) => screenPos.WithY(Screen.height - screenPos.y);
		public static Vector2 ToScreenSpace(this Vector2 viewPos) => viewPos.WithY(Screen.height - viewPos.y);
	}
}
