using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Player2 : MonoBehaviour
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
    private bool winTriggered = false;



    void Update()
    {
        // Move Right
        if (Input.GetKey(KeyCode.RightArrow) || Input.GetAxisRaw("Joystick2_Horizontal") > 0.5)
        {
            velocity = new Vector2(speed, rg.velocity.y);
            SR.flipX = false;
        }
        // Move Left
        else if (Input.GetKey(KeyCode.LeftArrow) || Input.GetAxisRaw("Joystick2_Horizontal") < -0.5)
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
        if ((Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.Joystick2Button0)) && IsGrounded())

        {
            velocity = new Vector2(rg.velocity.x, jumpForce);
        }

        rg.velocity = velocity;
    }


    private bool IsGrounded()
    {

        bool i = Physics2D.OverlapBox(groundCheck.position, groundCheck_size, 1, groundLayer);
        Debug.Log(i);
        return i;
    }

    private void OnDrawGizmos()
    {

        if (groundCheck != null)
        {
            Gizmos.color = Color.red;
            Gizmos.DrawWireCube(groundCheck.position, groundCheck_size);
        }
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



