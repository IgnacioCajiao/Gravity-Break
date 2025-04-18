using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerOxygen : MonoBehaviour
{
    public float maxOxygen = 100f;
    public float oxygenDepletionRate = 5f;
    public float oxygenDrainMultiplier = 2f; 
    public Slider oxygenMeter;

    private float currentOxygen;
    private bool enemyAttached = false; 

    void Start()
    {
        currentOxygen = maxOxygen; // Start with a full oxygen tank
        UpdateOxygenMeter();
    }

    void Update()
    {
        float depletionRate = enemyAttached ? oxygenDepletionRate * oxygenDrainMultiplier : oxygenDepletionRate;

        // Deplete oxygen over time with multiplier when enemy is attached
        currentOxygen = Mathf.Clamp(currentOxygen - depletionRate * Time.deltaTime, 0, maxOxygen);

        UpdateOxygenMeter();

        // Reload the scene if oxygen is depleted aka player dies and level restarts
        if (currentOxygen <= 0)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
    // Public method for enemyAI script to call to set the attachment status
    public void SetEnemyAttached(bool isAttached)
    {
        enemyAttached = isAttached; 
    }

    public void RefillOxygen(float amount)
    {
        currentOxygen = Mathf.Clamp(currentOxygen + amount, 0, maxOxygen);
        UpdateOxygenMeter();
    }

    private void UpdateOxygenMeter()
    {
        if (oxygenMeter != null)
        {
            oxygenMeter.value = currentOxygen / maxOxygen;
        }
    }
}