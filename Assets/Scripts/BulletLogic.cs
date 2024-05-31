using System.Collections;
using UnityEngine;
using Random = UnityEngine.Random;

public class BulletLogic : MonoBehaviour
{
	[SerializeField] private float _maxLifetime = 4f;
	[SerializeField] private float _damage = 10;
	[SerializeField] private float _torqueAfterHit = 100;
	[SerializeField] private float _minRicochetValue = 2;

	private BoxCollider2D _bulletCollider;
	private Rigidbody2D _bulletRigid;
	private WaitForSeconds _lifetime;
	private float _randomRicochetValue;

	private Transform _target;
	private Health _targetsHealth;
	private float _velocity;

	private void Start()
	{
		_lifetime = new WaitForSeconds(_maxLifetime);
		_bulletRigid = GetComponent<Rigidbody2D>();
		_bulletCollider = GetComponent<BoxCollider2D>();
		StartCoroutine(Destroyer());
	}


	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.gameObject == _target.gameObject)
		{
			Damage(_targetsHealth);

			_bulletRigid.gravityScale = 1;
			_randomRicochetValue = Random.Range(-10f, 10f);
			_randomRicochetValue = _randomRicochetValue > -2f && _randomRicochetValue < 2f
				? _minRicochetValue : _randomRicochetValue;

			var velocity = _bulletRigid.velocity;
			var transformVar = _bulletRigid.transform;

			transformVar.up = new Vector3(velocity.x, velocity.y + _randomRicochetValue, 0);
			velocity = transformVar.up * _velocity * 0.7f;
			_bulletRigid.velocity = velocity;
			_bulletRigid.AddTorque(_randomRicochetValue * _torqueAfterHit, ForceMode2D.Force);
		}
	}

	public void SetData(Transform target, float startVelocity)
	{
		_target = target;
		_velocity = startVelocity;
		target.TryGetComponent<Health>(out var targetsHealth);
		_targetsHealth = targetsHealth;
	}

	private void Damage(Health targetsHealth)
	{
		targetsHealth.SetDamage(_damage);
		_bulletCollider.enabled = false;
	}

	/*	private IEnumerator SpinAfterHit()
		{
			while (true)
			{
				_bulletRigidbody.SetRotation(_bulletRigidbody.rotation + _randomRotation);
				_randomRotation -= _randomRotation / 100;
				Mathf.Clamp(_randomRotation, 5, 100);
				yield return new WaitForFixedUpdate();
			}
		}*/

	private IEnumerator Destroyer()
	{
		yield return _lifetime;
		Destroy(gameObject);
	}
}