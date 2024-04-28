using UnityEngine;

public class EntitySpawner : MonoBehaviour
{
    [SerializeField] private GameObject _entityPrefab;
    [SerializeField] private Transform _baseTarget;
    [SerializeField] private Transform _entityType;

    public void SpawnNewEntity()
    {
        GameObject newEntity = Instantiate(_entityPrefab, transform.position, Quaternion.identity, _entityType);
        newEntity.GetComponent<ToTargetMover>()?.SetTarget(_baseTarget);
        newEntity.GetComponent<ShooterToTargetObject>()?.SetTarget(_baseTarget);
    }
}