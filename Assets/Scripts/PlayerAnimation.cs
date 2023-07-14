using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(SpriteRenderer))]

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
		_spriteRenderer.flipX = (Input.GetAxis("Horizontal") != 0) ? (!(Input.GetAxis("Horizontal") > 0) && (Input.GetAxis("Horizontal") < 0)) : _spriteRenderer.flipX;

		_playerAnim.SetBool(IsOnGround, _player.IsTouchingLayers());
		_playerAnim.SetBool(IsRunning, Input.GetAxis("Horizontal") != 0);
		_playerAnim.SetFloat(VerticalSpeed, _player.velocity.y);
		_playerAnim.SetFloat(Speed, _player.velocity.x < 0 ? -_player.velocity.x : _player.velocity.x);
	}
}
