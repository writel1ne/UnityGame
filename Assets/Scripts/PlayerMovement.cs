using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]

public class PlayerMovement : MonoBehaviour
{
	[SerializeField] private float _speed = 6;
	[SerializeField] private float _jumpForce = 17;

	private Rigidbody2D _player;

	private void Start()
	{
		_player = GetComponent<Rigidbody2D>();
	}

	private void Update()
	{
		if (Input.GetKeyDown(KeyCode.Space) && _player.IsTouchingLayers())
			_player.AddForce(new Vector2(0, _jumpForce), ForceMode2D.Impulse);
	}

	private void FixedUpdate()
	{
		float move = Input.GetAxis("Horizontal");
		_player.velocity = new Vector2(_speed * move, _player.velocity.y);
	}
}
