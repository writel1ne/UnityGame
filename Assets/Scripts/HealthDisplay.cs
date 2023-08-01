using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Health))]

public class HealthDisplay : MonoBehaviour
{
	[SerializeField] private Image _bar;
	[SerializeField] private float _fillingStepsDivizor = 10;

	private float _targetBarFullness;
	private Health _health;
	private bool coroutineIsRunning = false;

	private void Start()
	{
		_health = GetComponent<Health>();
		_bar.fillAmount = _health.CurrentHealth / _health.CurrentMaxHealth;
		_health.HealthChanged += StartUpdateBar;
	}

	private void OnEnable()
	{
		_health.HealthChanged += StartUpdateBar;
	}

	private void OnDisable()
	{
		_health.HealthChanged -= StartUpdateBar;
	}

	public void StartUpdateBar(float currentHealth, float maxHealth)
	{
		_targetBarFullness = currentHealth / maxHealth;

		if (coroutineIsRunning == false)
		{
			StartCoroutine(UpdateBar());
		}
	}

	private IEnumerator UpdateBar()
	{
		coroutineIsRunning = true;

		while (Math.Abs(_targetBarFullness - _bar.fillAmount) >= 0.01)
		{
			_bar.fillAmount = Mathf.MoveTowards(_bar.fillAmount, _targetBarFullness, Mathf.Abs(_bar.fillAmount - _targetBarFullness) / _fillingStepsDivizor);
			yield return null;
		}

		_bar.fillAmount = _targetBarFullness;
		coroutineIsRunning = false;
		yield break;
	}
}