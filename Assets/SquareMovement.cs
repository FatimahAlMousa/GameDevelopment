using UnityEngine;
using UnityEngine.SceneManagement;

public class SquareMovement : MonoBehaviour
{
    public Rigidbody2D rg; // Rigidbody2D for physics-based movement

    public float speed = 1;

    public float jumpForce = 300f; // Adjust to control jump height
    public Transform groundCheck; // Empty GameObject to check ground
    public LayerMask groundLayer; // LayerMask to specify the ground layer
    public int jump;
    private bool isGrounded;

    Vector2 velocity;

    private BoxCollider2D boxCollider;
    private Vector2 originalColliderSize;
    private Vector2 slidingColliderSize;
    private bool isSliding = false;

    public float slideDuration = 0.5f;
    private float slideTimer;

    void Update()
    {

        // Move Right
        if (Input.GetKey(KeyCode.D))
        {
            velocity = new Vector2(speed, rg.velocity.y);
        }

        // Move Left
        else if (Input.GetKey(KeyCode.A))
        {
            velocity = new Vector2(-speed, rg.velocity.y);
        }
        else
        {
            velocity = new Vector2(0, rg.velocity.y);
        }


        // Jump
        if (Input.GetKeyDown(KeyCode.W) && IsGrounded())
        {
            velocity = new Vector2(rg.velocity.x, jumpForce);
        }

        rg.velocity = velocity;
    }
    private bool IsGrounded()
    {
        // Check if the groundCheck object is touching the ground layer
        return Physics2D.OverlapCircle(groundCheck.position, 0.1f, groundLayer);
    }

    private void StartSliding()
    {
        isSliding = true;
        slideTimer = slideDuration;

        // Reduce collider size for sliding
        boxCollider.size = slidingColliderSize;
        boxCollider.offset = new Vector2(0, -0.25f);
    }

    private void StopSliding()
    {
        isSliding = false;

        // Reset collider to original size
        boxCollider.size = originalColliderSize;
        boxCollider.offset = Vector2.zero;
    }

    private void OnDrawGizmos()
    {
        // Visualize ground check in the Scene view
        if (groundCheck != null)
        {
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(groundCheck.position, 0.1f);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
    
        // Reset stage on collision with obstacle or falling off
        if (collision.gameObject.CompareTag("Obstacle") || transform.position.y < -10)
        {
            ResetStage();
        }
    }

    private void ResetStage()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name); // Reload the current scene
    }
}