using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
	private const string IsOnGround = "IsOnGround";
	private const string IsRunning = "IsRunning";
	private const string VerticalSpeed = "VerticalSpeed";
	private const string Speed = "Speed";

	private Rigidbody2D _player;
	private Animator _playerAnim;
	private SpriteRenderer _spriteRenderer;


	private void Start()
    {
		_player = GetComponent<Rigidbody2D>();
		_playerAnim = GetComponent<Animator>();
		_spriteRenderer = GetComponent<SpriteRenderer>();
	}

    private void Update()
    {

		if (_player.IsTouchingLayers())
			_playerAnim.SetBool(IsOnGround, true);
		else
			_playerAnim.SetBool(IsOnGround, false);

		if (Input.GetAxis("Horizontal") < -0.1)
			_spriteRenderer.flipX = true;
		else if (Input.GetAxis("Horizontal") > 0.1)
			_spriteRenderer.flipX = false;

		_playerAnim.SetBool(IsRunning, Input.GetAxis("Horizontal") != 0);
		_playerAnim.SetFloat(VerticalSpeed, _player.velocity.y);
		_playerAnim.SetFloat(Speed, _player.velocity.x < 0 ? -_player.velocity.x : _player.velocity.x);
	}
}
