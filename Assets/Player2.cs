using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player2 : MonoBehaviour
{
    public Rigidbody2D rg; // Rigidbody2D for physics-based movement

    public float speed = 1;

    public float jumpForce = 300f; // Adjust to control jump height
    public Transform groundCheck; // Empty GameObject to check ground
    public Vector2 groundCheck_size;
    public LayerMask groundLayer; // LayerMask to specify the ground layer
    Vector2 velocity;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // Move Right
        if (Input.GetKey(KeyCode.RightArrow) || Input.GetAxis("Joystick2_Horizontal") > 0)
        {
            velocity = new Vector2(speed, rg.velocity.y);
        }
        // Move Left
        else if (Input.GetKey(KeyCode.LeftArrow) || Input.GetAxis("Joystick2_Horizontal") < 0)
        {
            velocity = new Vector2(-speed, rg.velocity.y);
        }
        else
        {
            velocity = new Vector2(0, rg.velocity.y);
        }

        // Jump
        if ((Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.JoystickButton0)) && IsGrounded())

        {
            velocity = new Vector2(rg.velocity.x, jumpForce);
        }

        rg.velocity = velocity;
    }

    // Check if the object is on the ground
    private bool IsGrounded()
    {
        // Check if the groundCheck object is touching the ground layer
        bool i = Physics2D.OverlapBox(groundCheck.position, groundCheck_size, 1, groundLayer);
        Debug.Log(i);
        return i;
    }

    private void OnDrawGizmos()
    {
        // Visualize the ground check in the Scene view
        if (groundCheck != null)
        {
            Gizmos.color = Color.red;
            Gizmos.DrawWireCube(groundCheck.position, groundCheck_size);
        }
    }
}
        
    

