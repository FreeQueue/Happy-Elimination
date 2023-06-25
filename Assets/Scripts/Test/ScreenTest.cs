#nullable enable

using KFramework.Utility;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Happy_Elimination
{
	public class ScreenTest : MonoBehaviour
	{
		//The current width of the screen window in pixels (Read Only).
		//This is the actual width of the player window (in full-screen it is also the current resolution).
		//Screen.width/height 是实际宽度 ，应该用Screen.currentResolution
		[Button]
		public void Test() {
			Vector3 source = new(Screen.width, Screen.height);
			var world = Util.Screen.GetWorldPos(source);
			var screen = Util.Screen.GetScreenPos(world);
			Debug.Log(source);
			Debug.Log(world);
			Debug.Log(screen);
			source = new(Screen.currentResolution.width, Screen.currentResolution.height);
			world = Util.Screen.GetWorldPos(source);
			screen = Util.Screen.GetScreenPos(world);
			Debug.Log(source);
			Debug.Log(world);
			Debug.Log(screen);
		}

		[Button]
		public void TestCenter() {
			var pos= Util.Screen.GetScreenPos(new(-4, -4));
			Debug.Log(pos);
			 pos= Util.Screen.GetScreenPos(new(0, 0));
			Debug.Log(pos);
			pos= Util.Screen.GetScreenPos(new(4, 4));
			Debug.Log(pos);
		}
	}
}
