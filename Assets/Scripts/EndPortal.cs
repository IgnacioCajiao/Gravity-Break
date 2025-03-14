using UnityEngine;

public class EndPortal : MonoBehaviour
{
    public GameObject winnerText; 

    void Start()
    {
        // Makes sure the winner text is disabled onstart start
        if (winnerText != null)
        {
            winnerText.SetActive(false);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        // Checks if the player touches the end portal
        if (other.CompareTag("Player"))
        {
            // Enable the winner text
            if (winnerText != null)
            {
                winnerText.SetActive(true);
            }

            // Disable the player GameObject
            other.gameObject.SetActive(false);
        }
    }
}
