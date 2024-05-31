using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]

public class ToTargetMover : MonoBehaviour
{
	[SerializeField] private float _speed = 6;
	[SerializeField] private float _jumpForce = 17;
	[SerializeField] private float _maxApproachDistance;
	[SerializeField] private Transform _target;

	private float _distanceToTarget;
	private Vector2 _targetPoint;

	private Rigidbody2D _entity;

	private void Start()
	{
		_entity = GetComponent<Rigidbody2D>();
		_maxApproachDistance = Random.Range(0, _maxApproachDistance);
	}

	private void FixedUpdate()
	{
		MoveToTarget();
	}

	public void SetTarget(Transform newTarget)
	{
		_target = newTarget;
	}

	public void SetTarget(Vector2 targetPoint)
	{
		_targetPoint = targetPoint;
	}

	private void MoveToTarget()
	{
		if (_target != null)
			_distanceToTarget = _target.position.x - _entity.position.x;
		else
			_distanceToTarget = _targetPoint.x - _entity.position.x;


		if (Mathf.Abs(_distanceToTarget) > _maxApproachDistance)
			_entity.velocity = new Vector2(_speed * Mathf.Clamp(_distanceToTarget, -1, 1), _entity.velocity.y);
	}
}