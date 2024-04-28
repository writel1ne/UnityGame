using System.Collections.Generic;
using UnityEngine;

public class SawSpawner : MonoBehaviour
{
    [SerializeField] private int _sawCount;
    [SerializeField] private Transform _allPaths;
    [SerializeField] private GameObject _sawPrefab;

    private void Start()
    {
    }

    private List<Transform> GetAllPaths(Transform AllPaths)
    {
        var pathList = new List<Transform>();

        for (var i = 0; i < AllPaths.childCount; i++) pathList.Add(AllPaths.GetChild(i));

        return pathList;
    }
}