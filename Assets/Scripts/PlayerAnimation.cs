using System;
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
    
    [SerializeField] private float _idlingSpeed = 0.2f;

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
        _spriteRenderer.flipX =
            Math.Abs(_player.velocity.x) > _idlingSpeed ? _player.velocity.x < 0 : _spriteRenderer.flipX;

        _playerAnim.SetBool(IsOnGround, _player.IsTouchingLayers());
        _playerAnim.SetBool(IsRunning, Math.Abs(_player.velocity.x) > _idlingSpeed);
        _playerAnim.SetFloat(VerticalSpeed, _player.velocity.y);
        _playerAnim.SetFloat(Speed, _player.velocity.x < 0 ? -_player.velocity.x : _player.velocity.x);
    }
}