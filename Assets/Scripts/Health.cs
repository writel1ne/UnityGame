using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class Health : MonoBehaviour
{
	[SerializeField] private float _invulnerableDuration;
	[SerializeField] private float _maxHealth;
	[SerializeField] private float _currentHealth;
	[SerializeField] private UnityEvent<float, float> _healthChanged;

	private bool _isVulnerable;

	public float CurrentMaxHealth { get { return _maxHealth; } private set { } }
	public float CurrentHealth { get { return _currentHealth; } private set { } }

	public event UnityAction<float, float> HealthChanged
	{
		add => _healthChanged.AddListener(value);
		remove => _healthChanged.RemoveListener(value);
	}

	private void Start()
	{
		_isVulnerable = true;
		UpdateHealth();
	}

	public void SetDamage(float damage)
	{
		if (_isVulnerable)
		{
			_currentHealth -= damage;
			StartCoroutine(SetInvulnerability(_invulnerableDuration));
		}

		UpdateHealth();
	}

	public void SetHeal(float heal)
	{
		_currentHealth += heal;
		UpdateHealth();
	}

	private IEnumerator SetInvulnerability(float duration)
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
}
