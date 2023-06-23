#nullable enable

using Elimination.Core.Systems;
using KFramework;

namespace Elimination.Core
{
	public class Game : IModule
	{
		public static MutableState<int> Score { get; set; } = null!;
		public static MutableState<int> Time { get; set; } = null!;
		public static BrickData Data => App.Data.brickData;
		public static BrickMap BrickMap { get; private set; } = null!;
		public static BrickFactory Factory { get; private set; } = null!;
		public static InputSystem Input { get; private set; } = null!;
		public static DragSystem Drag { get; private set; } = null!;
		public static ViewSystem View { get; private set; } = null!;
		public static BrickEliminator Eliminator { get; private set; } = null!;
		public static BrickMapGenerator Generator { get; private set; } = null!;
		public static void Init() {
			BrickMap = new BrickMap(Data.mapSize);
			Factory = new BrickFactory();
			Input = new InputSystem();
			Drag = new DragSystem();
			View = new ViewSystem();
			Eliminator = new BrickEliminator();
			Generator = new BrickMapGenerator();
			Score = 0;
			Time = 0;
		}
	}
}