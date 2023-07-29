using System.Collections;
using UnityEngine;

[RequireComponent(typeof(HealthDisplay))]

public class Health : MonoBehaviour
{
	[SerializeField] private float _invulnerableDuration;
	[SerializeField] private float _maxHealth;
	[SerializeField] private float _currentHealth;

	private bool _isInvulnerable;
	private HealthDisplay _healthDisplay;


	private void Start()
	{
		_healthDisplay = GetComponent<HealthDisplay>();
		_isInvulnerable = false;
		_currentHealth = (_currentHealth > 0 && _currentHealth <= _maxHealth) ? _currentHealth : _maxHealth;

		_healthDisplay.UpdateBar(_currentHealth, _maxHealth);
	}

	private void DeathCheck()
	{
		if (_currentHealth <= 0)
		{
			_currentHealth = 0;
			transform.gameObject.SetActive(false);
		}
	}

	private IEnumerator setInvulnerability(float duration)
	{
		_isInvulnerable = true;
		yield return new WaitForSeconds(duration);
		_isInvulnerable = false;
	}

	private void OnValidate()
	{
		_healthDisplay.UpdateBar(_currentHealth, _maxHealth);
	}

	public void GetDamage(float damage)
	{
		if (!_isInvulnerable)
		{
			_currentHealth -= damage;
			StartCoroutine(setInvulnerability(_invulnerableDuration));
		}

		DeathCheck();
		_healthDisplay.UpdateBar(_currentHealth, _maxHealth);
	}

	public void GetHeal(float heal)
	{
		_currentHealth = (_currentHealth + heal <= _maxHealth) ? _currentHealth + heal : _maxHealth;
		_healthDisplay.UpdateBar(_currentHealth, _maxHealth);
	}
}
