using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class Health : MonoBehaviour
{
	private bool _isVulnerable;

	[SerializeField] private float _invulnerableDuration;
	[SerializeField] private float _maxHealth;
	[SerializeField] private float _currentHealth;
	[SerializeField] private UnityEvent<float, float> _healthChanged;

	public float CurrentMaxHealth { get { return _maxHealth; } private set { } }
	public float CurrentHealth { get { return _currentHealth; } private set { } }

	private void Start()
	{
		_isVulnerable = true;
		UpdateHealth();
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
		_healthChanged?.Invoke(_currentHealth, _maxHealth);
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

	public event UnityAction<float, float> HealthChanged
	{
		add => _healthChanged.AddListener(value);
		remove => _healthChanged.RemoveListener(value);
	}
}
