using DG.Tweening;
using UnityEngine;

public class SawPath : MonoBehaviour
{
	[SerializeField] private Vector3[] _waypoints;
	[SerializeField] private float _duration = 1;

	private void Start()
	{
		Tween path = transform.DOPath(_waypoints, _duration, PathType.Linear).SetOptions(true);

		path.SetEase(Ease.Linear).SetLoops(-1);
	}
}