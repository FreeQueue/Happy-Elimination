#nullable enable

using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

namespace Elimination.Core
{
	[CreateAssetMenu(fileName = "BrickData", menuName = "BrickData", order = 0)]
	public class BrickData : ScriptableObject
	{
		[Header("map")] public Vector2Int mapSize;
		public Vector2Int mapViewSize;
		public int solidSweetNum;

		[Header("Anim")] public float moveDuration;
		public Ease moveEase;
		public float dragDis;
		public Ease dragEase;
		public float dragDuration;
		public Ease fadeEase;
		public float fadeDuration;

		[Header("Sweets")] 
		public List<Sprite> sweetSprites = null!;
		public Brick sweet = null!;
		public Brick superSweet = null!;
		public Brick solidSweet = null!;
	}
}
