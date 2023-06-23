using DG.Tweening;
using UnityEngine;

public class Rotate : MonoBehaviour
{
	public Vector3 rotationAxis = Vector3.back; // 旋转轴
	public float rotateDuration = 1; // 旋转速度

	private void Start()
	{
		// 启动旋转动画
		transform.DORotate(rotationAxis * 360f, rotateDuration, RotateMode.FastBeyond360)
			.SetLoops(-1, LoopType.Restart)
			.SetEase(Ease.Linear);
	}
}
