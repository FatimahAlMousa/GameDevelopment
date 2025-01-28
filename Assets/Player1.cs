using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player1 : MonoBehaviour
{
    public Rigidbody2D rg;
    public Animator anim;
    public SpriteRenderer SR;

    public float speed = 1;
    public float jumpForce = 300f;
    public Transform groundCheck;
    public Vector2 groundCheck_size;
    public LayerMask groundLayer;
    Vector2 velocity;

    private void Update()
    {
        // Move Right
        if (Input.GetKey(KeyCode.D))
        {
            velocity = new Vector2(speed, rg.velocity.y);
            SR.flipX = false;
        }
        else if (Input.GetKey(KeyCode.A))
        {
            velocity = new Vector2(-speed, rg.velocity.y);
            SR.flipX = true;
        }
        else
        {
            velocity = new Vector2(0, rg.velocity.y);
        }

        anim.SetFloat("move", Mathf.Abs(velocity.x));

        // Jump
        if (Input.GetKeyDown(KeyCode.W) && IsGrounded())
        {
            velocity = new Vector2(rg.velocity.x, jumpForce);
        }

        rg.velocity = velocity;
    }

    private bool IsGrounded()
    {
        return Physics2D.OverlapBox(groundCheck.position, groundCheck_size, 1, groundLayer);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Win"))
        {
            GameManager manager = FindObjectOfType<GameManager>();
            if (manager != null)
            {
                manager.PlayerReachedWinArea(gameObject);
            }
        }
    }
}
