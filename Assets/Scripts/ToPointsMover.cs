using System.Collections.Generic;
using UnityEngine;

public class ToPointsMover : MonoBehaviour
{
	[SerializeField] private float _maxDistanceDelta = 2f;
	[SerializeField] private Transform _allPoints;

	private List<Transform> _pointsArray;
	private int _targetPointIndex;

	private void Start()
	{
		_pointsArray = GetAllPointPositions(_allPoints);
	}

	private void Update()
	{
		var targetPoint = _pointsArray[_targetPointIndex];

		//transform.forward = targetPoint.transform.position - transform.position;
		transform.position =
			Vector3.MoveTowards(transform.position, targetPoint.position, _maxDistanceDelta * Time.deltaTime);

		if (transform.position == targetPoint.position) TargetNextPointIndex();
	}

	private void TargetNextPointIndex()
	{
		_targetPointIndex++;

		if (_targetPointIndex != _pointsArray.Count) return;
		_pointsArray.Reverse();
		_targetPointIndex = 0;
	}

	private static List<Transform> GetAllPointPositions(Transform points)
	{
		var array = new List<Transform>();

		if (points.childCount > 0)
			for (var i = 0; i < points.childCount; i++)
				array.Add(points.GetChild(i).GetComponent<Transform>());
		else
			array.Add(points);

		return array;
	}
}