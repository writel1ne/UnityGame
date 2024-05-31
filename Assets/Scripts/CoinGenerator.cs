using System.Collections.Generic;
using UnityEngine;
using Random = System.Random;

public class CoinGenerator : MonoBehaviour
{
	[SerializeField] private Transform _coinSpawnPositions;
	[SerializeField] private GameObject _coinPrefab;
	[SerializeField] private GameObject _parent;

	private void Start()
	{
		var spawnPositions = GetSpawnPositions(_coinSpawnPositions);

		GenerateCoins(spawnPositions);
	}

	private void GenerateCoins(List<Transform> spawnPositions)
	{
		var rand = new Random();
		float numberOfCoins = rand.Next(1, spawnPositions.Count);
		int randIndex;

		for (var i = 0; i < numberOfCoins; i++)
		{
			randIndex = rand.Next(spawnPositions.Count);

			while (_coinSpawnPositions.GetChild(randIndex).childCount != 0) randIndex = rand.Next(spawnPositions.Count);

			Instantiate(_coinPrefab, spawnPositions[randIndex], _parent);
		}
	}

	private List<Transform> GetSpawnPositions(Transform coinSpawnPositions)
	{
		var spawnPositions = new List<Transform>();

		for (var i = 0; i < coinSpawnPositions.childCount; i++) spawnPositions.Add(coinSpawnPositions.GetChild(i));

		return spawnPositions;
	}
}