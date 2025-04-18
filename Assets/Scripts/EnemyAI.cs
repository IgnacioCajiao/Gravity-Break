using UnityEngine;


public class EnemyAI : MonoBehaviour
{
    public Transform pointA, pointB;
    public float speed = 0.5f;
    public float chaseSpeed = 1f;
    public bool faceRightWhenStuck = true;

    private Transform player;
    private Transform attachmentPoint;
    private Rigidbody2D rb;
    private SpriteRenderer spriteRenderer;
    private PlayerOxygen playerOxygen;
    private bool isStuckToPlayer = false;
    private bool isChasingPlayer = false;
    private bool movingToPointA = true;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        // If stuck, the enemy doesn't move on its own
        if (isStuckToPlayer)
        {
            return; 
        }

        // If not stuck, check if it should be chasing
        if (isChasingPlayer && player != null)
        {
            ChasePlayer(); 
        }
        else
        {
            // If not stuck and not chasing, continue patrolling
            Patrol(); 
        }
    }

    // Handles movement between patrol points
    void Patrol()
    {
        // Don't patrol if already chasing or stuck
        if (isChasingPlayer || isStuckToPlayer) return;

        // Determine the current target point
        Transform target = movingToPointA ? pointA : pointB;

        MoveTowards(target.position, speed);

        // Check if the enemy is close enough to the target point to switch direction
        if (Vector2.Distance(transform.position, target.position) < 0.1f)
        {
            movingToPointA = !movingToPointA; 
        }
    }

    // Handles the chasing behavior
    void ChasePlayer()
    {
        // Only chase if the flag is set and the player reference is valid
        if (isChasingPlayer && player != null)
        {
            MoveTowards(player.position, chaseSpeed);
        }
    }

    // method to move the enemy towards a target position
    void MoveTowards(Vector3 targetPosition, float currentSpeed)
    {
        Vector2 direction = (targetPosition - transform.position).normalized;

        rb.linearVelocity = direction * currentSpeed;

        // Flip the sprite horizontally based on the direction its moving
        spriteRenderer.flipX = rb.linearVelocity.x < 0;
    }

    // Called when the player enters the enemy collider trigger
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && !isStuckToPlayer)
        {
            player = other.transform;
            attachmentPoint = player.Find("AttachmentPoint"); 
            playerOxygen = player.GetComponent<PlayerOxygen>(); 
            StickToPlayer(); 
        }
    }

    // Handles the logic for sticking to the player
    void StickToPlayer()
    {
        if (player != null && attachmentPoint != null)
        {
            isChasingPlayer = false; // Stop any active chasing
            rb.linearVelocity = Vector2.zero; // Immediately stop movement

            transform.SetParent(attachmentPoint); // Attach the enemy under the player's attachment point
            transform.position = attachmentPoint.position; // Snap to the exact attachment position

            rb.bodyType = RigidbodyType2D.Kinematic; // Make the enemy move with the parent

            isStuckToPlayer = true; 

            // Set the sprite to face the oxygen tank so it looks like its sucking out the air
            spriteRenderer.flipX = !faceRightWhenStuck;

            // tell the player's oxygen script that an enemy is attached
            if (playerOxygen != null)
            {
                playerOxygen.SetEnemyAttached(true);
            }
        }
    }

    // Public method called by the separate chase trigger to start chasing
    public void StartChasing(Transform playerTransform)
    {
        // Can only start chasing if not already stuck
        if (!isStuckToPlayer)
        {
            player = playerTransform; 
            isChasingPlayer = true; 
        }
    }

    // Public method called by the separate chase trigger to stop chasing
    public void StopChasing()
    {
        // Can only stop chasing if not stuck
        if (!isStuckToPlayer)
        {
            isChasingPlayer = false; 
        }
    }
}