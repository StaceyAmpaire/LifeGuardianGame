using UnityEngine;

public class GameManager : MonoBehaviour
{
    // Singleton instance, so other scripts can access GameManager easily
    public static GameManager instance;

    // Stores the player's last run performance (0–100%)
    public float lastRunPercent;

    private void Awake()
    {
        // If no instance exists, set this as the instance
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject); // keep across scene changes
        }
        else
        {
            Destroy(gameObject); // prevent duplicates
        }
    }

    // Optional: helper method to reset last run percent
    public void ResetLastRun()
    {
        lastRunPercent = 0f;
    }
}