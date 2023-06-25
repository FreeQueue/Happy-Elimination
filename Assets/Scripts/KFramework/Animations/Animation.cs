#nullable enable

using System;
using DG.Tweening;
using UnityEngine;

namespace KFramework.Animations
{
	[Serializable]
	public abstract class Animation
	{
		protected GameObject target = null!;
		public Tween Tween { get; protected set; } = null!;
		public void Init(GameObject target) {
			this.target = target;
			Tween = _Start();
		}
		protected abstract Tween _Start();
	}
}
