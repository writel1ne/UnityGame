using System.Collections;
using UnityEngine;

public class ShooterToTargetObject : MonoBehaviour
{
    [SerializeField] private float _startBulletVelocity = 15f;
    [SerializeField] private float _shootingCooldown = 1f;
    [SerializeField] private Transform _targetToShoot;
    [SerializeField] private Rigidbody2D _bulletPrefab;
    
    private WaitForSeconds _cooldown;
    private Vector3 _direction;

    private bool _shootingCoroutineIsRunning;

    private void Start()
    {
        _cooldown = new WaitForSeconds(_shootingCooldown);
        StartCoroutine(ShootingToTarget());
    }

    public void SetTarget(Transform newTarget)
    {
        _targetToShoot = newTarget;
    }

    private IEnumerator ShootingToTarget()
    {
        _shootingCoroutineIsRunning = true;

        while (_targetToShoot.gameObject.activeSelf && _shootingCoroutineIsRunning)
        {
            _direction = (_targetToShoot.position - transform.position).normalized;
            var newBullet = Instantiate(_bulletPrefab, transform.position + _direction, Quaternion.identity);
            Shoot(newBullet);

            yield return _cooldown;
        }

        yield return _cooldown;
    }

    private void Shoot(Rigidbody2D bullet)
    {
        bullet.transform.up = _direction;
        bullet.velocity = _direction * _startBulletVelocity;
        bullet.TryGetComponent<BulletLogic>(out var logic);
        logic.SetData(_targetToShoot, _startBulletVelocity);
    }
}