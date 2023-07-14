using UnityEngine;

public class FollowingCamera : MonoBehaviour
{
	[SerializeField] private Transform _player;
	[SerializeField] private float _followSpeed = 10;

	private void LateUpdate()
	{
		this.transform.position = Vector3.Lerp(transform.position, new Vector3(_player.position.x, _player.position.y, this.transform.position.z), Time.deltaTime * _followSpeed);
	}
}
