using UnityEngine;

public class ButtonsOptions : MonoBehaviour
{
	[SerializeField] private Transform _player;
	[SerializeField] private float _damagePoints;
	[SerializeField] private float _healPoints;

	private Health _playerHealth;

	private void Start()
	{
		_damagePoints = _damagePoints > 0 ? _damagePoints : 15;
		_healPoints = _healPoints > 0 ? _healPoints : 15;
		_playerHealth = _player.GetComponent<Health>();
	}

	public void Damage()
	{
		_playerHealth.GetDamage(_damagePoints);
	}

	public void Heal()
	{
		_playerHealth.GetHeal(_healPoints);
	}
}
