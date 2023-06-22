#nullable enable

using Elimination.Core.Systems;
using KFramework;

namespace Elimination.Core
{
	public class Game : IModule
	{
		public static MutableState<int> Score { get; set; } = null!;
		public static BrickData Data => App.Data.brickData;
		public static BrickMap BrickMap { get; private set; } = null!;
		public static BrickFactory Factory { get; private set; } = null!;
		public static InputSystem Input { get; private set; } = null!;
		public static DragSystem Drag { get; private set; } = null!;
		public static ViewSystem View { get; private set; } = null!;
		public static BrickEliminator Eliminator { get; private set; } = null!;
		public Game() {
			BrickMap = new BrickMap(Data.mapSize);
			BrickMap.ValueChange += (coord, oldValue, newValue) => {
				if (newValue != null) newValue.Coord.Value = coord;
			};
			Factory = new BrickFactory();
			Input = new InputSystem();
			Drag = new DragSystem();
			View = new ViewSystem();
			Eliminator = new BrickEliminator();
			Score = 0;
		}
	}
}
