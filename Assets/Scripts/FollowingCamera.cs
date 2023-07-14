using UnityEngine;

public class FollowingCamera : MonoBehaviour
{
	[SerializeField] Transform player;
	[SerializeField] private float _followSpeed = 10;

    void LateUpdate()
    {
		this.transform.position = Vector3.Lerp(transform.position, new Vector3(player.position.x, player.position.y, this.transform.position.z), Time.deltaTime * _followSpeed);
	}
}
