using UnityEngine;

public class Switch : MonoBehaviour
{
    public GameObject endPortal; 
    public GameObject leverDown; 
    public GameObject leverUp; 

    void Start()
    {
        // makes the end portal inactive until the switch is touched
        if (endPortal != null)
        {
            endPortal.SetActive(false); 
        }

        // makes sure the lever is down on start
        if (leverDown != null) leverDown.SetActive(true);
        if (leverUp != null) leverUp.SetActive(false);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        // Check if the player touches the switch then activate the endportal gameobject
        if (other.CompareTag("Player"))
        {
            if (endPortal != null)
            {
                endPortal.SetActive(true);
            }

            // changes the switch from down to up. couldnt do it with just sprited because the sprite were way too big.
            if (leverDown != null) leverDown.SetActive(false);
            if (leverUp != null) leverUp.SetActive(true);
        }
    }
}
