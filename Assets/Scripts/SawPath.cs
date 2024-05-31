using DG.Tweening;
using UnityEngine;

public class SawPath : MonoBehaviour
{
	[SerializeField] private Transform _waypointsList;
	[SerializeField] private float _speed = 1;

	private float _duration;

	private Vector3[] _waypoints;

	private void Start()
	{
		_duration = SpeedToDuration(_speed);
		UnPacking();

		Tween path = transform.DOPath(_waypoints, _duration);
		path.SetEase(Ease.Linear).SetLoops(-1, LoopType.Yoyo);
	}

	private void UnPacking()
	{
		var array = new Vector3[_waypointsList.childCount];

		for (var i = 0; i < _waypointsList.childCount; i++) array[i] = _waypointsList.GetChild(i).position;

		_waypoints = array;
	}

	private float SpeedToDuration(float speed)
	{
		var duration = 1 / speed * _waypointsList.childCount * 2;
		return duration;
	}
}