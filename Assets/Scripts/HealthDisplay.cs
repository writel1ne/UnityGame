using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Health))]

public class HealthDisplay : MonoBehaviour
{
	[SerializeField] private Image _bar;

	private Health _health;
	private float _targetBarFullness;

	private void Start()
	{
		_health = GetComponent<Health>();
		_bar.fillAmount = _health.CurrentHealth / _health.CurrentMaxHealth;
	}

	private void Update()
	{
		if (_targetBarFullness != _health.CurrentHealth / _health.CurrentMaxHealth)
		{
			_targetBarFullness = _health.CurrentHealth / _health.CurrentMaxHealth;
			_bar.fillAmount = Mathf.MoveTowards(_bar.fillAmount, _targetBarFullness, 0.002f);
		}
	}
}
