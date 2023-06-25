#nullable enable

using Elimination.Core.Systems;
using KFramework;

namespace Elimination.Core
{
	public class Game : IModule
	{
		public static BrickData Data => App.Data.brickData;
		public static BrickMap BrickMap { get; private set; } = null!;
		public static BrickFactory Factory { get; private set; } = null!;
		public static InputSystem Input { get; private set; } = null!;
		public static DragSystem Drag { get; private set; } = null!;
		public static ViewSystem View { get; private set; } = null!;
		public static ScoreSystem ScoreSystem { get; private set; } = null!;
		public static TimeSystem TimeSystem { get; private set; } = null!;
		public static BrickEliminator Eliminator { get; private set; } = null!;
		public static BrickMapGenerator Generator { get; private set; } = null!;
		public static void Init() {
			BrickMap = new(Data.mapSize);
			Factory = new();
			Input = new();
			Drag = new();
			View = new();
			Eliminator = new();
			Generator = new();
			ScoreSystem = new();
			TimeSystem = new();
		}
	}
}
