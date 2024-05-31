
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerLoop : MonoBehaviour
{
	[SerializeField] private List<GameObject> _spawners;

	private WaitForSeconds _spawnDelay = new WaitForSeconds(2);

	private void Start()
	{
		StartCoroutine(SpawnLoop());
	}

	private IEnumerator SpawnLoop()
	{
		while (true)
		{
			EntitySpawner spawner = null;
			yield return _spawnDelay;

			SelectRandomSpawner().TryGetComponent(out spawner);
			spawner?.GenerateDefaultDirection();
			spawner?.SpawnNewEntity();
		}
	}

	private GameObject SelectRandomSpawner()
	{
		GameObject spawner = _spawners[Random.Range(0, _spawners.Count)];
		return spawner;
	}
}