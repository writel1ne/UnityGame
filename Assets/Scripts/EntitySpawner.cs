using UnityEngine;

public class EntitySpawner : MonoBehaviour
{
    [SerializeField] private GameObject _entityPrefab;
    [SerializeField] private Transform _target;
    [SerializeField] private Transform _entityType;

    private Vector2 _defaultLeft = new Vector2(-10000, 0);
    private Vector2 _defaultRight = new Vector2(10000, 0);
    private Vector2 _targetPoint;

	private void Start()
	{
		if (_target == null)
            GenerateDefaultDirection();
	}

	public void SpawnNewEntity()
    {
        GameObject newEntity = Instantiate(_entityPrefab, transform.position, Quaternion.identity, _entityType);
        newEntity.GetComponent<ShooterToTargetObject>()?.SetTarget(_target);

        if (_target != null)
            newEntity.GetComponent<ToTargetMover>()?.SetTarget(_target);
        else
            newEntity.GetComponent<ToTargetMover>()?.SetTarget(_targetPoint);
    }

    public void GenerateDefaultDirection()
    {
        _targetPoint = Random.Range(0, 2) == 0 ? _defaultLeft : _defaultRight;
    }
}