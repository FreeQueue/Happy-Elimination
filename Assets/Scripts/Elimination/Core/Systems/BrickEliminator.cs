#nullable enable

using System.Collections.Generic;
using System.Linq;
using Elimination.Core.Traits;
using KFramework;
using KFramework.Extensions;
using UnityEngine;

namespace Elimination.Core.Systems
{
	public class BrickEliminator
	{
		public void EliminateAll() {
			BrickMap brickMap = Game.BrickMap;
			Grid<int> brickIdMap = brickMap.Transform(brick => {
				int id = brick?.GetTrait<EliminateTrait>()?.Brick.ID ?? -1;
				return id;
			});
			Grid<int> flagMap = brickIdMap.Create<int>();
			MarkFlag(brickIdMap, flagMap, true);
			MarkFlag(brickIdMap, flagMap, false);

			Game.View.WaitAll().GetAwaiter().OnCompleted(() => {
				EliminateFlagBrick(brickIdMap, flagMap);
			});
		}

		private void EliminateFlagBrick(Grid<int> brickIdMap, Grid<int> flagMap) {
			bool eliminateAny = false;
			foreach (Vector2Int coord in brickIdMap.GetCoords()) {
				if (brickIdMap[coord] == -1) continue;
				int max = 0;
				int count = 0;
				Vector2Int maxCoord = coord;
				foreach (Vector2Int current in brickIdMap.Dfs(coord,
							(grid, current, next) => grid[current] == grid[next])) {
					brickIdMap[current] = -1;
					count++;
					if (flagMap[current] > max) {
						max = flagMap[current];
						maxCoord = current;
					}
					Eliminate(current);
				}
				switch (count) {
					case 0: continue;
					case > 4:
						Game.BrickMap.Add(maxCoord, Game.Factory.CreateSuperSweet(count));
						break;
				}
				eliminateAny = true;
			}
			if (eliminateAny) Game.View.WaitAll().GetAwaiter().OnCompleted(EliminateAll);
			else Game.Input.SetActive(true);
		}

		private void Eliminate(Vector2Int coord) {
			Game.BrickMap[coord]?.GetTrait<EliminateTrait>()?.Eliminate();
		}
		private void MarkFlag(Grid<int> brickIdMap, Grid<int> flagMap, bool isX) {
			for (int x = 0; x < brickIdMap.X; x++) {
				int id = -1, start = 0;
				bool paint = false;
				for (int y = 0; y < brickIdMap.Y; y++) {
					Vector2Int coord = GetCoord(x, y);
					if (brickIdMap[coord] != id) {
						id = brickIdMap[coord];
						start = y;
						paint = false;
						continue;
					}
					if (paint) {
						PaintLast3(x, y);
						continue;
					}
					int num = y - start;
					if (id != -1 && num >= 2) paint = true;
				}
			}

			void PaintLast3(int x, int y) {
				for (int i = 0; i < 3; i++) {
					Vector2Int coord = GetCoord(x, y - i);
					flagMap[coord] += 1;
				}
			}

			Vector2Int GetCoord(int x, int y) => isX ? new Vector2Int(x, y) : new Vector2Int(y, x);
		}

		public void AfterDrag(Vector2Int moveCoord, Vector2Int swapCoord) {
			moveCoord.let(CheckSameBrick)?.let(Eliminate);
			swapCoord.let(CheckSameBrick)?.let(Eliminate);
			Game.View.WaitAll().GetAwaiter().OnCompleted(EliminateAll);
		}

		private SameBrick? CheckSameBrick(Vector2Int coord) {
			Brick? brick = Game.BrickMap[coord];
			if (brick is null) return null;
			SameBrick sameBrick;
			sameBrick.coord = coord;
			sameBrick.directions = DirectionExtensions.directions
				.Select(direction => GetSameBrickNumInDir(coord, brick.ID, direction)).ToArray();
			return sameBrick;
		}

		private int GetSameBrickNumInDir(Vector2Int coord, int id, Direction direction) {
			Vector2Int nextCoord = coord + direction.GetVector();
			Brick? nextBrick = Game.BrickMap[nextCoord];
			if (nextBrick != null && nextBrick.ID == id) return GetSameBrickNumInDir(nextCoord, id, direction) + 1;
			return 0;
		}

		public void Eliminate(SameBrick sameBrick) {
			BrickMap brickMap = Game.BrickMap;
			int numX = sameBrick.NumX(), numY = sameBrick.NumY();
			List<Brick> eliminatedBricks = new List<Brick>();
			if (numX >= 3) {
				IEnumerable<Brick> xBricks = brickMap.GetInDir(sameBrick.coord, Direction.Left)
					.Concat(brickMap.GetInDir(sameBrick.coord, Direction.Right)).WhereNotNull();
				eliminatedBricks.AddRange(xBricks);
			}
			if (numY >= 3) {
				IEnumerable<Brick> yBricks = brickMap.GetInDir(sameBrick.coord, Direction.Up)
					.Concat(brickMap.GetInDir(sameBrick.coord, Direction.Down)).WhereNotNull();
				eliminatedBricks.AddRange(yBricks);
			}
			eliminatedBricks.ForEach(brick => brick.GetTrait<DestroyTrait>()?.Destroy());
			int sum = numX + numY - 1;
			if (sum >= 4) brickMap.Add(sameBrick.coord, Game.Factory.CreateSuperSweet(sum));
		}
	}
}