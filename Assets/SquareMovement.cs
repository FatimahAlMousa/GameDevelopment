using UnityEngine;

public class SquareMovement : MonoBehaviour
{
    public Rigidbody2D rg; // Rigidbody2D for physics-based movement
    public float jumpForce = 300f; // Adjust to control jump height
    public Transform groundCheck; // Empty GameObject to check ground
    public LayerMask groundLayer; // LayerMask to specify the ground layer
    [SerializeField] int jump;
    bool isGrounded;

    // Update is called once per frame
    void Update()
    {
        // Move Right
        if (Input.GetKey(KeyCode.D))
        {
            transform.position += Vector3.right * 0.01f;
        }
        // Move Left
        else if (Input.GetKey(KeyCode.A))
        {
            transform.position += Vector3.left * 0.01f;
        }

        // Jump
        isGrounded = Physics2D.OverlapCapsule(groundCheck.position,new Vector2(1.8f,0.3f),CapsuleDirection2D.Horizontal,0,groundLayer);
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            rg.velocity = new Vector2(rg.velocity.x, jump);
        }
    }

    // Check if the object is on the ground
    private bool IsGrounded()
    {
        // Check if the groundCheck object is touching the ground layer
        return Physics2D.OverlapCircle(groundCheck.position, 0.1f, groundLayer);
    }

    private void OnDrawGizmos()
    {
        // Visualize the ground check in the Scene view
        if (groundCheck != null)
        {
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(groundCheck.position, 0.1f);
        }
    }
}
