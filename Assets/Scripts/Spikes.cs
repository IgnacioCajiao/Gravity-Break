using UnityEngine;
using UnityEngine.SceneManagement; 

public class SpikeTrap : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other)
    {
        //Using the tags to check if "Player" has collided with the spike gameobject. Then reloading the scene.
        if (other.CompareTag("Player"))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}
