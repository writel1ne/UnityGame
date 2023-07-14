using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
	private Rigidbody2D player;
	private Animator playerAnim;
	private SpriteRenderer spriteRenderer;

	void Start()
    {
		player = GetComponent<Rigidbody2D>();
		playerAnim = GetComponent<Animator>();
		spriteRenderer = GetComponent<SpriteRenderer>();
	}

    private void Update()
    {

		if (player.IsTouchingLayers())
			playerAnim.SetBool("IsOnGround", true);
		else
			playerAnim.SetBool("IsOnGround", false);

		if (Input.GetAxis("Horizontal") < -0.1)
			spriteRenderer.flipX = true;
		else if (Input.GetAxis("Horizontal") > 0.1)
			spriteRenderer.flipX = false;

		playerAnim.SetBool("IsRunning", Input.GetAxis("Horizontal") != 0);
		playerAnim.SetFloat("VerticalSpeed", player.velocity.y);
		playerAnim.SetFloat("Speed", player.velocity.x < 0 ? -player.velocity.x : player.velocity.x);
	}
}
