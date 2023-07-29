using System.Collections;
using UnityEngine;

public class Health : MonoBehaviour
{
	private bool _isVulnerable;

	[SerializeField] private float _invulnerableDuration;
	[SerializeField] private float _maxHealth;
	[SerializeField] private float _currentHealth;

	public float CurrentMaxHealth { get { return _maxHealth; } private set { } }
	public float CurrentHealth { get { return _currentHealth; } private set { } }


	private void Start()
	{
		_isVulnerable = true;
		_currentHealth = (_currentHealth > 0 && _currentHealth < _maxHealth) ? _currentHealth : _maxHealth;
	}

	private IEnumerator setInvulnerability(float duration)
	{
		_isVulnerable = false;
		yield return new WaitForSeconds(duration);
		_isVulnerable = true;
	}

	private void UpdateHealth()
	{
		_currentHealth = Mathf.Clamp(_currentHealth, 0, _maxHealth);
		transform.gameObject.SetActive(_currentHealth > 0);
	}

	public void GetDamage(float damage)
	{
		if (_isVulnerable)
		{
			_currentHealth -= damage;
			StartCoroutine(setInvulnerability(_invulnerableDuration));
		}

		UpdateHealth();
	}

	public void GetHeal(float heal)
	{
		_currentHealth += heal;
		UpdateHealth();
	}
}
