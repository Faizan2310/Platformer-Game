using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody rb; // Rigidbody component for physics interaction
    [SerializeField] private float moveSpeed = 5f; // Speed of the player's movement
    [SerializeField] private float jumpForce = 5f; // Force of the player's jump
    public LayerMask groundLayers; // LayerMask to determine what is considered ground
    public Transform groundCheck; // Transform used to check if player is on the ground
    public float groundCheckDistance = 0.2f; // Distance for the ground check below the player
    private int jumpCount = 0; // Current count of consecutive jumps
    private int maxJumpCount = 2; // Maximum allowed consecutive jumps
    public Animator animator; // Animator component for character animation

    [SerializeField] AudioSource jumpAudio;
    [SerializeField] AudioSource enemyDead;

    // Method to check if the player is currently grounded
    private bool IsGrounded()
    {
        // Uses a raycast to check for ground within a certain distance below the player
        return Physics.Raycast(groundCheck.position, Vector3.down, groundCheckDistance, groundLayers);
    }

    void Start()
    {
        // Get the Rigidbody component attached to this GameObject
        rb = GetComponent<Rigidbody>();
        animator = GetComponentInChildren<Animator>();
    }

    void Update()
    {   
        // Capture player's horizontal and vertical movement based on input
        Vector3 movement = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical")) * moveSpeed;
        
        // Apply the captured movement to the Rigidbody's velocity, maintaining the y component
        rb.velocity = new Vector3(movement.x, rb.velocity.y, movement.z);

        bool isGrounded = IsGrounded();

        // If the player is grounded and has jumped before, reset the jump count
        if (isGrounded && jumpCount != 0)
        {   
            jumpCount = 0;
            animator.SetBool("IsOnGround", true);
        }

        // Check if the player is attempting to jump and if jump conditions are met
        if (Input.GetButtonDown("Jump") && (isGrounded || (!isGrounded && jumpCount < maxJumpCount - 1)))
        {
            Jump();
            jumpCount++;
            animator.SetBool("IsOnGround", false);
        }

        float speed = movement.magnitude;
        animator.SetFloat("Speed", speed);


    }

    // Method to handle the player's jump
    void Jump(){
        rb.velocity = new Vector3(rb.velocity.x, jumpForce, rb.velocity.z);
        jumpAudio.Play();
    }

    // Collision detection with other GameObjects
    private void OnCollisionEnter(Collision collision)
{
    // Check if the collision is with an enemy's head
    if (collision.gameObject.CompareTag("Enemy Head"))
    {
        // Find the Animator component on the enemy GameObject
        Animator enemyAnimator = collision.transform.parent.GetComponentInChildren<Animator>();
        if (enemyAnimator != null)
        {
            // Set the "IsDead" parameter to true
            enemyAnimator.SetBool("IsDead", true);
        }

        // Wait a moment to let the die animation play before destroying the GameObject
        StartCoroutine(DestroyAfterDelay(collision.transform.parent.gameObject, 1f));
        enemyDead.Play();
        // Call the Jump method to bounce the player off after destroying the enemy
        Jump();
        ScoreManager.instance.AddScore(15);

    }
}

IEnumerator DestroyAfterDelay(GameObject target, float delay)
{
    // Wait for the specified delay
    yield return new WaitForSeconds(delay);
    // Destroy the target GameObject
    Destroy(target);
}

}
