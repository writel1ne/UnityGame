using System.Collections.Generic;
using UnityEngine;

public class CoinGenerator : MonoBehaviour
{
    [SerializeField] private Transform _coinSpawnPositions;
    [SerializeField] private GameObject _coinPrefab;

	private void Start()
    {
        GenerateCoins();
    }

    private void GenerateCoins()
    {
		var rand = new System.Random();
	    float numberOfCoins = rand.Next(1, _coinSpawnPositions.childCount);
		int randIndex;

        for (int i = 0; i < numberOfCoins; i++)
        {
            randIndex = rand.Next(_coinSpawnPositions.childCount);

            while (_coinSpawnPositions.GetChild(randIndex).childCount != 0)
            {
				randIndex = rand.Next(_coinSpawnPositions.childCount);
			}

            Instantiate(_coinPrefab, _coinSpawnPositions.GetChild(randIndex));
		}
    }
}
