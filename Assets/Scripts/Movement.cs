using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f; 
    private Animator animator; 
    private Rigidbody2D rb; 
    private bool isGravityInverted = false; 
    private bool adjustPosition = true; 

    void Start()
    {
        rb = GetComponent<Rigidbody2D>(); 
        animator = GetComponent<Animator>(); 
    }

    void Update()
    {
        // Get player input for horizontal movement
        float moveInput = Input.GetAxis("Horizontal");

        rb.linearVelocity = new Vector2(moveInput * moveSpeed, rb.linearVelocity.y);

        CheckAnimations();

        // Check if the Space key is pressed to flip gravity
        if (Input.GetKeyDown(KeyCode.Space))
        {
            isGravityInverted = !isGravityInverted; 
            rb.gravityScale *= -1; 
            FlipSprite(); 
            AdjustPosition(); 
        }
    }

    void FlipSprite()
    {
        // flip the sprite by changing the Y scale
        transform.localScale = new Vector3(transform.localScale.x, transform.localScale.y * -1, transform.localScale.z);
    }

    void AdjustPosition()
    {
        // adjust the player's position up or down so they stay in the same place when the sprite flips
        transform.position += new Vector3(0, adjustPosition ? 1f : -1f, 0);
        adjustPosition = !adjustPosition; 
    }

    public void CheckAnimations()
    {
        // Check input to determine which animation to play
        if (Input.GetAxis("Horizontal") < 0)
        {
            animator.Play("Walk"); 
        }
        else if (Input.GetAxis("Horizontal") > 0)
        {
            animator.Play("Walk"); 
        }
        else
        {
            animator.Play("Idle"); 
        }
    }
}
