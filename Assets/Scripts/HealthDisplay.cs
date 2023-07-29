using UnityEngine;
using UnityEngine.UI;

public class HealthDisplay : MonoBehaviour
{
	[SerializeField] private Image _bar;

	private float _targetBarFullness = 1f;

	private void Update()
	{
		_bar.fillAmount = Mathf.MoveTowards(_bar.fillAmount, _targetBarFullness, 0.002f);
	}

	public void UpdateBar(float health, float maxHealth)
	{
		_targetBarFullness = health / maxHealth;
	}

}
