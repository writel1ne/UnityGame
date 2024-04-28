using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class ToTargetMover : MonoBehaviour
{
    [SerializeField] private float _speed = 6;
    [SerializeField] private float _jumpForce = 17;
    [SerializeField] private float _maxApproachDistance;
    [SerializeField] private Transform _target;
    
    private float _distanceToTarget;

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


    private void MoveToTarget()
    {
        _distanceToTarget = _target.position.x - _entity.position.x;

        if (Mathf.Abs(_distanceToTarget) > _maxApproachDistance)
            _entity.velocity = new Vector2(_speed * Mathf.Clamp(_distanceToTarget, -1, 1), _entity.velocity.y);
    }
}