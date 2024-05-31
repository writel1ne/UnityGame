using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Health))]

public class HealthDisplay : MonoBehaviour
{
    [SerializeField] private Transform _healthBar;
    [SerializeField] private float _fillingStepsDivizor = 10;

    private Image _bar;
    private Health _health;
    private bool _coroutineIsRunning;
    private float _targetBarFullness;

    private void Awake()
    {
        _bar = _healthBar.GetChild(0).GetChild(0).GetComponent<Image>();
        _health = GetComponent<Health>();
        _bar.fillAmount = _health.CurrentHealth / _health.CurrentMaxHealth;
    }
    
    private void OnEnable()
    {
        _health.HealthChanged += StartUpdateBar;
        _healthBar.gameObject.SetActive(true);
    }

    private void OnDisable()
    {
        _health.HealthChanged -= StartUpdateBar;
        _healthBar.gameObject.SetActive(false);
    }

    public void StartUpdateBar(float currentHealth, float maxHealth)
    {
        _targetBarFullness = currentHealth / maxHealth;

        if (_coroutineIsRunning == false) StartCoroutine(UpdateBar());
    }

    private IEnumerator UpdateBar()
    {
        _coroutineIsRunning = true;

        while (Math.Abs(_targetBarFullness - _bar.fillAmount) >= 0.01)
        {
            _bar.fillAmount = Mathf.MoveTowards(_bar.fillAmount, _targetBarFullness,
                Mathf.Abs(_bar.fillAmount - _targetBarFullness) / _fillingStepsDivizor);

            yield return null;
        }

        _bar.fillAmount = _targetBarFullness;
        _coroutineIsRunning = false;
    }
}