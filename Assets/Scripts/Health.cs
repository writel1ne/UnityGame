using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class Health : MonoBehaviour
{
    [SerializeField] private float _invulnerableDuration;
    [SerializeField] private float _maxHealth;
    [SerializeField] private float _currentHealth;
    
    private bool _isVulnerable = true;

    public float CurrentMaxHealth => _maxHealth;
    public float CurrentHealth => _currentHealth;

    private void Start()
    {
        UpdateHealth();
    }

    private void OnEnable()
    {
        UpdateHealth();
    }

    public event UnityAction<float, float> HealthChanged;
    public event UnityAction<Vector3> Damaged;

    public void SetDamage(float damage)
    {
        if (_isVulnerable)
        {
            _currentHealth -= damage;

            StartCoroutine(SetInvulnerability(_invulnerableDuration));
            //Damaged.Invoke(attackerPosition);
            UpdateHealth();
        }
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
        HealthChanged?.Invoke(_currentHealth, _maxHealth);
    }
}