using System.Collections.Generic;
using UnityEngine;

public class CoinGenerator : MonoBehaviour
{
	[SerializeField] private Transform _coinSpawnPositions;
	[SerializeField] private GameObject _coinPrefab;

	private void Start()
	{
		List<Transform> spawnPositions = GetSpawnPositions(_coinSpawnPositions);

		GenerateCoins(spawnPositions);
	}

	private void GenerateCoins(List<Transform> spawnPositions)
	{
		var rand = new System.Random();
		float numberOfCoins = rand.Next(1, spawnPositions.Count);
		int randIndex;

		for (int i = 0; i < numberOfCoins; i++)
		{
			randIndex = rand.Next(spawnPositions.Count);

			while (_coinSpawnPositions.GetChild(randIndex).childCount != 0)
			{
				randIndex = rand.Next(spawnPositions.Count);
			}

			Instantiate(_coinPrefab, spawnPositions[randIndex]);
		}
	}

	private List<Transform> GetSpawnPositions(Transform coinSpawnPositions)
	{
		var spawnPositions = new List<Transform>();

		for (int i = 0; i < coinSpawnPositions.childCount; i++)
		{
			spawnPositions.Add(coinSpawnPositions.GetChild(i));
		}

		return spawnPositions;
	}
}