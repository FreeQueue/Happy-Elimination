#nullable enable

using System.Collections.Generic;
using System.Linq;
using Cysharp.Threading.Tasks;
using KFramework;
using KFramework.Extensions;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Elimination.Core.Traits
{
	[RequireComponent(typeof(ListenNeighborTrait))]
	public class DropTrait : BrickTrait
	{
		[ShowInInspector]
		private List<(Brick brick,string info)> _record=new List<(Brick brick,string info)>();

		public override void Init() {
			GetTrait<ListenNeighborTrait>()!.OnNeighborDestroy += async brick => {
				if (brick.Coord == Coord.Value.To(Direction.Down)) {
					await Drop();
				}
			};
		}
		public async UniTask Drop() {
			Brick? down = BrickMap.GetInDir(Coord,Direction.Down).FirstOrDefault(brick => brick is not null);
			Vector2Int targetCoord
				= down is null ? Coord.Value.WithY(BrickMap.MaxY) : down.Coord.Value.To(Direction.Up);
			_record.Add((Brick,$"Drop {targetCoord} begin"));
			await Drop(Brick,targetCoord);
			await Flow(Brick);
		}

		private async UniTask Drop(Brick brick,Vector2Int targetCoord) {
			if (targetCoord==Coord) return;
			Vector2Int upCoord = targetCoord.To(Direction.Up);
			UniTask? upDropTask = null;
			if (BrickMap.Contains(upCoord)) {
				Brick up = GetOrAddUp();
				upDropTask = up.GetTrait<DropTrait>()?.Drop(Brick,upCoord);
			}
			_record.Add((brick,$"Drop {targetCoord}"));
			BrickMap.Move(Brick, targetCoord);
			var moveTask=GetTrait<ViewTrait>()?.Wait(WaitAnim.Move);
			await moveTask.WaitNotNull();
			await Flow(brick);
			await upDropTask.WaitNotNull();
		}

		private async UniTask Flow(Brick brick) {
			Brick? down = Brick.GetNeighbor(Direction.Down);
			if (down is null) return;
			Vector2Int? targetCoord = null;
			if (!BrickMap.IsBoundaryInDir(Coord, Direction.Left) &&
				down.GetNeighbor(Direction.Left) is null)
				targetCoord = down.Coord.Value.To(Direction.Left);
			else if (!BrickMap.IsBoundaryInDir(Coord, Direction.Right) &&
					down.GetNeighbor(Direction.Right) is null)
				targetCoord = down.Coord.Value.To(Direction.Right);
			if (!targetCoord.HasValue) return;
			Brick up = GetOrAddUp();
			Vector2Int coord = Coord.Value;
			_record.Add((brick,$"Flow {targetCoord}"));
			BrickMap.Move(Brick, targetCoord.Value);
			var upDropTask = up.GetTrait<DropTrait>()?.Drop(Brick,coord);
			var moveTask = GetTrait<ViewTrait>()?.Wait(WaitAnim.Move);
			await moveTask.WaitNotNull();
			await upDropTask.WaitNotNull();
			await Drop();
		}

		private Brick GetOrAddUp() {
			Brick? up = Brick.GetNeighbor(Direction.Up);
			if (up is null) {
				up = Game.Factory.CreateRandomSweet();
				up.GetTrait<ViewTrait>()?.Move(Coord.Value.To(Direction.Up));
			}
			return up;
		}
	}
}
