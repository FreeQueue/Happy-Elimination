#nullable enable
using System;

namespace KFramework
{
	public interface IModule
	{
		public void Update() {
		}
		void Shutdown() {
		}
	}
}