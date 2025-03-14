using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerOxygen : MonoBehaviour
{
    public float maxOxygen = 100f;
    public float oxygenDepletionRate = 5f;
    public Slider oxygenMeter;

    private float currentOxygen;

    void Start()
    {
        currentOxygen = maxOxygen; // Start with a full oxygen tank
        UpdateOxygenMeter();
    }

    void Update()
    {
        // Deplete oxygen over time and make sure it stays between 0 and 100
        currentOxygen = Mathf.Clamp(currentOxygen - oxygenDepletionRate * Time.deltaTime, 0, maxOxygen);

        UpdateOxygenMeter();

        // Reload the scene if oxygen is depleted aka player dies and level restart
        if (currentOxygen <= 0)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }

    public void RefillOxygen(float amount)
    {
        // Increases the oxygen level
        currentOxygen = Mathf.Clamp(currentOxygen + amount, 0, maxOxygen);
        UpdateOxygenMeter();
    }

    private void UpdateOxygenMeter()
    {
        // Updates the sliders value
        if (oxygenMeter != null)
        {
            oxygenMeter.value = currentOxygen / maxOxygen;
        }
    }
}
