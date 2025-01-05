using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class SquareMovement : MonoBehaviour
{ public Rigidbody2D rg;
  public float jumpForce = 3f; 
  

    // Start is called before the first frame update
    void Start()
    {
        rg = GetComponent<Rigidbody2D>();

        // Check if Rigidbody2D is missing and log an error if needed
        if (rg == null)
        {
            Debug.LogError("Rigidbody2D component is missing from this object!");
        }

    }

    // Update is called once per frame
    void Update()
    {
        // Move Right
        if (Input.GetKey(KeyCode.D) || Input.GetAxis("Horizontal") > 0)
        {
            transform.position += Vector3.right * 0.01f;
        }
        // Move Left
        else if (Input.GetKey(KeyCode.A) || Input.GetAxis("Horizontal") < 0)
        {
            transform.position += Vector3.left * 0.01f;
        }
        // Jump
        else if (Input.GetKeyDown(KeyCode.W) || Input.GetAxis("Vertical") > 0)
        {
            if (IsGrounded()) // Only jump if grounded
            {
                rg.velocity = new Vector2(rg.velocity.x, jumpForce);
            }
        }
    }

    // Check if the object is on the ground
    private bool IsGrounded()
    {
        // Simple ground check using velocity
        return Mathf.Abs(rg.velocity.y) < 0.01f;
    }
}
