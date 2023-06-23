#nullable enable

using Elimination.Core;
using KFramework;
using UnityEngine;

namespace Happy_Elimination.Data
{
	public class DataModule : IModule
	{
		public readonly BrickData brickData;
		public DataModule() => brickData = Resources.Load<BrickData>("Data/BrickData");
	}
}