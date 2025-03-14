using UnityEngine;

public class OxygenTank : MonoBehaviour
{
    public float oxygenRefillAmount = 100f; 

    void OnTriggerEnter2D(Collider2D other)
    {
        // Using the tags to check if the "Player" has collided with the oxygen tank gameobject 
        if (other.CompareTag("Player"))
        {
            // Reference the playeroxygen script and refill the oxygen meter.
            PlayerOxygen playerOxygen = other.GetComponent<PlayerOxygen>();
            if (playerOxygen != null)
            {
                playerOxygen.RefillOxygen(oxygenRefillAmount);
            }

            Destroy(gameObject); 
        }
    }
}
