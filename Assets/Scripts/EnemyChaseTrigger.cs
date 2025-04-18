using UnityEngine;

public class EnemyChaseTrigger : MonoBehaviour
{
    public EnemyAI enemyAI;

    // Called when another collider enters this trigger
    void OnTriggerEnter2D(Collider2D other)
    {
        // If the player enters the trigger, tell the enemy to start chasing
        if (other.CompareTag("Player") && enemyAI != null)
        {
            enemyAI.StartChasing(other.transform);
        }
    }

    // Called every frame while another collider stays within this trigger
    void OnTriggerStay2D(Collider2D other)
    {
        // As long as the player is in the trigger, make sure the enemy is chasing
        if (other.CompareTag("Player") && enemyAI != null)
        {
            enemyAI.StartChasing(other.transform);
        }
    }

    // Called when another collider exits this trigger
    void OnTriggerExit2D(Collider2D other)
    {
        // If the player exits the trigger, tell the enemy to stop chasing
        if (other.CompareTag("Player") && enemyAI != null)
        {
            enemyAI.StopChasing();
        }
    }
}