using DG.Tweening;
using UnityEngine;
using Animation = KFramework.Animations.Animation;

public class Rotate : Animation
{
	public Vector3 rotationAxis = Vector3.back; // 旋转轴
	public float rotateDuration = 1; // 旋转速度

	protected override Tween _Start() {
		// 启动旋转动画
		return target.transform.DORotate(rotationAxis * 360f, rotateDuration, RotateMode.FastBeyond360)
			.SetLoops(-1, LoopType.Restart)
			.SetEase(Ease.Linear);
	}
}
