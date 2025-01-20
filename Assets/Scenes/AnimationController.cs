using UnityEngine;

public class PlayerWalkAnimationController : MonoBehaviour
{
    public Animator player1Animator;
    public Animator player2Animator;

    public Rigidbody2D player1Rigidbody;
    public Rigidbody2D player2Rigidbody;

    void Update()
    {
        // Player 1 Walk Animation
        if (player1Animator != null && player1Rigidbody != null)
        {
            if (Mathf.Abs(player1Rigidbody.velocity.x) > 0)
            {
                player1Animator.SetBool("isRunning", true);
            }
            else
            {
                player1Animator.SetBool("isRunning", false);
            }
        }

        // Player 2 Walk Animation
        if (player2Animator != null && player2Rigidbody != null)
        {
            if (Mathf.Abs(player2Rigidbody.velocity.x) > 0)
            {
                player2Animator.SetBool("isRunning", true);
            }
            else
            {
                player2Animator.SetBool("isRunning", false);
            }
        }
    }
}
