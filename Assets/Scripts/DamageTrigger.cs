using UnityEngine;

public class DamageTrigger : MonoBehaviour
{
	[SerializeField] private float _damage;

	private void OnTriggerStay2D(Collider2D collision)
	{
		if (collision.gameObject.TryGetComponent<Health>(out Health enemyHealth))
		{
			Damage(enemyHealth);
		}
	}

	private void Damage(Health enemyHealth)
	{
		enemyHealth.SetDamage(_damage);
	}
}