#nullable enable

using System.Linq;
using Cysharp.Threading.Tasks;
using Elimination.Core.Traits;
using KFramework;
using KFramework.Extensions;
using KFramework.Utility;
using UnityEngine;

namespace Elimination.Core.Systems
{
	public class ViewSystem
	{
		private readonly GameObject _grids;
		private readonly Vector2 _gridSize;
		private readonly Vector2 _viewStart;

		public ViewSystem() {
			var data = App.Data.brickData;
			_grids = new GameObject("grids");
			//可视化数据
			_gridSize = data.mapViewSize.Divide(data.mapSize);
			SetGridsSprite(data);
			_viewStart = _grids.transform.ToScreenPoint().XY() - data.mapViewSize / 2;
		}

		public void SetGridsSprite(BrickData data) {
			SpriteRenderer spriteRenderer = _grids.GetComponent<SpriteRenderer>();
			Util.Sprite.TileSpriteRenderer(spriteRenderer, data.mapSize);
			Util.Sprite.ResizeSpriteToPixels(spriteRenderer, data.mapViewSize);
		}

		public Vector2Int GetCoord(Vector2 screenPos) {
			Vector2 gridPos = screenPos - _viewStart;
			// 计算相对于起始点的格子偏移量
			return gridPos.Divide(_gridSize).FloorToInt();
		}

		public Vector3 GetWorldPos(Vector2Int coord) {
			// 计算格子中心的屏幕坐标
			Vector2 gridCenter = _viewStart + coord * _gridSize + _gridSize / 2;
			// 将格子中心的屏幕坐标转换为世界坐标
			return Util.Screen.GetWorldPos(gridCenter);
		}

		public async UniTask WaitAll() {
			foreach (ViewTrait brick in Game.BrickMap.Select(brick => brick.GetTrait<ViewTrait>()).WhereNotNull()) {
				await brick.Wait();
			}
		}
	}
}
