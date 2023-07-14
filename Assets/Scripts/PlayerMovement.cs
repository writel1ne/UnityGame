using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
	[SerializeField] private float _speed = 6;
	[SerializeField] private float _jumpForce = 17;

    private Rigidbody2D player;

	private void Start()
	{
		player = GetComponent<Rigidbody2D>();
	}

	private void Update()
	{
		if (Input.GetKeyDown(KeyCode.Space) && player.IsTouchingLayers())
			player.AddForce(new Vector2(0, _jumpForce), ForceMode2D.Impulse);		
	}

	private void FixedUpdate()
	{
		float move = Input.GetAxis("Horizontal");
		player.velocity = new Vector2(_speed * move, player.velocity.y);
	}
}
