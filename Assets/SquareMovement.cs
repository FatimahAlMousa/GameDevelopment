using UnityEngine;
using UnityEngine.SceneManagement;

public class SquareMovement : MonoBehaviour
{
<<<<<<< Updated upstream
    public Rigidbody2D rg; // Rigidbody2D for physics-based movement

    public float speed = 1;

    public float jumpForce = 300f; // Adjust to control jump height
    public Transform groundCheck; // Empty GameObject to check ground
    public LayerMask groundLayer; // LayerMask to specify the ground layer


    Vector2 velocity;
=======
    public Rigidbody2D rg;
    public float jumpForce = 300f;
    public Transform groundCheck;
    public LayerMask groundLayer;
    public int jump;
    private bool isGrounded;

    private BoxCollider2D boxCollider;
    private Vector2 originalColliderSize;
    private Vector2 slidingColliderSize;
    private bool isSliding = false;

    public float slideDuration = 0.5f;
    private float slideTimer;
>>>>>>> Stashed changes

    void Update()
    {
<<<<<<< Updated upstream
        // Move Right
        if (Input.GetKey(KeyCode.D) || Input.GetAxis("Horizontal") > 0)
=======
        // Horizontal Movement
        if (Input.GetKey(KeyCode.D))
>>>>>>> Stashed changes
        {
            velocity = new Vector2(speed, rg.velocity.y);
        }
<<<<<<< Updated upstream
        // Move Left
        else if (Input.GetKey(KeyCode.A) || Input.GetAxis("Horizontal") < 0)
=======
        else if (Input.GetKey(KeyCode.A))
>>>>>>> Stashed changes
        {
            velocity = new Vector2(-speed, rg.velocity.y);
        }
        else
        {
            velocity = new Vector2(0, rg.velocity.y);
        }

<<<<<<< Updated upstream
        // Jump
        if ((Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.JoystickButton0)) && IsGrounded())

=======
        // Jump if grounded
        isGrounded = Physics2D.OverlapCapsule(groundCheck.position, new Vector2(1.8f, 0.3f), CapsuleDirection2D.Horizontal, 0, groundLayer);
        if (Input.GetButtonDown("Jump") && isGrounded)
>>>>>>> Stashed changes
        {
            velocity = new Vector2(rg.velocity.x, jumpForce);
        }

        rg.velocity = velocity;
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