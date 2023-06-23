#nullable enable

using DG.Tweening;
using UnityEngine;

namespace KFramework.Animations
{
	public class YoYoScale : MonoBehaviour
	{
		public Vector3 scaleRange1 = new Vector3(0.9f, 0.9f, 0.9f); // 第一个缩放范围
		public Ease ease1=Ease.InOutSine;
		public Vector3 scaleRange2 = new Vector3(1.1f, 1.1f, 1.1f); // 第二个缩放范围
		public Ease ease2=Ease.InOutSine;
		public float scaleDuration = 1f; // 缩放动画持续时间

		private void Start()
		{
			// 启动缩放动画
			Sequence sequence = DOTween.Sequence();
			sequence.Append(transform.DOScale(scaleRange1, scaleDuration).SetEase(ease1))
				.Append(transform.DOScale(scaleRange2, scaleDuration).SetEase(ease2))
				.SetLoops(-1, LoopType.Yoyo);
		}
	}
}
