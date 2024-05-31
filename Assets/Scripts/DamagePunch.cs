using UnityEngine;

[RequireComponent(typeof(Health))]
[RequireComponent(typeof(Rigidbody2D))]
public class DamagePunch : MonoBehaviour
{
	[SerializeField] private float _punchStrenth = 10;

	private float _distance;
	private Rigidbody2D _entity;

	private Health _health;
	private Vector3 _punchDirection;

	private void Start()
	{
		_entity = GetComponent<Rigidbody2D>();
		_health = GetComponent<Health>();
		_health.Damaged += Punch;
	}

	private void Update()
	{
		Debug.DrawRay(transform.position, _punchDirection, Color.green);
	}

	private void OnEnable()
	{
		_health.Damaged += Punch;
	}

	private void OnDisable()
	{
		_health.Damaged -= Punch;
	}

	private void Punch(Vector3 attackerPosition)
	{
		_punchDirection = (transform.position - attackerPosition).normalized;
		_distance = _punchDirection.magnitude;
		Debug.Log(_punchDirection);
		//_entity.AddRelativeForce(_punchDirection, ForceMode2D.Impulse);
		_entity.velocity = _punchDirection;
	}
}