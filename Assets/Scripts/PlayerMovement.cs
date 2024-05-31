using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(BoxCollider2D))]
public class PlayerMovement : MonoBehaviour
{
	[SerializeField] private float _speed = 6;
	[SerializeField] private float _jumpForce = 17;
	[SerializeField] private float _jumpCooldown = 1;

	private bool _isCooldowned = false;
	private Rigidbody2D _player;
	private BoxCollider2D _playersFeet;

	private void Start()
	{
		_player = GetComponent<Rigidbody2D>();
		_playersFeet = GetComponent<BoxCollider2D>();
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		if (!_isCooldowned) StartCoroutine(DoCooldown(_jumpCooldown));
	}

	private void Update()
	{
		if (Input.GetKeyDown(KeyCode.Space) && _playersFeet.IsTouchingLayers() && !_isCooldowned)
			_player.AddForce(new Vector2(10, _jumpForce), ForceMode2D.Impulse);
	}

	private void FixedUpdate()
	{
		var move = Input.GetAxis("Horizontal");
		_player.velocity = new Vector2(_speed * move, _player.velocity.y);
	}

	private IEnumerator DoCooldown(float duration)
	{
		_isCooldowned = true;
		yield return new WaitForSeconds(duration);
		_isCooldowned = false;
	}
}