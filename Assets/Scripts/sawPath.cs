using UnityEngine;
using DG.Tweening;

public class sawPath : MonoBehaviour
{
    [SerializeField] private Vector3[] _waypoints;
    [SerializeField] private float _duration = 1;
    void Start()
    {
        Tween path = transform.DOPath(_waypoints, _duration, PathType.Linear).SetOptions(true);

        path.SetEase(Ease.Linear).SetLoops(-1);
    }
}