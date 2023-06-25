#nullable enable

using System;
using System.Collections.Generic;
using KFramework.Animations;
using Sirenix.OdinInspector;
using Sirenix.Serialization;

namespace Elimination.Core.Traits
{
	public class AnimationTrait : BrickTrait
	{
		[Button]
		private void PlayTest() {
			Init();
		}
		[OdinSerialize] [NonSerialized] [ShowInInspector]
		public List<Animation> _animations = new List<Animation>();
		public override void Init() {
			_animations.ForEach(animation => animation.Init(gameObject));
		}

	}
}
