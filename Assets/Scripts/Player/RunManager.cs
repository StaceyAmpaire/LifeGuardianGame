using UnityEngine;
using UnityEngine.SceneManagement;

public class RunManager : MonoBehaviour
{
    public int totalChoices = 0;
    public int goodChoices = 0;

    void Start()
    {
        Time.timeScale = 1f; // ensure game runs normally
    }

    // Called when player picks food
    public void RegisterChoice(bool healthy)
    {
        totalChoices++;

        if (healthy)
        {
            goodChoices++;
            Debug.Log("Healthy choice!");
        }
        else
        {
            Debug.Log("Unhealthy choice!");
        }
    }

    // Calculate performance %
    public float GetPerformancePercent()
    {
        if (totalChoices == 0) return 0f;

        return (goodChoices / (float)totalChoices) * 100f;
    }

    // Called when run ends
    public void EndRun()
    {
        Time.timeScale = 0f;

        float performance = GetPerformancePercent();

        Debug.Log("Run ended. Performance: " + performance + "%");

        EndRunUI popupUI = FindFirstObjectByType<EndRunUI>();

        if (popupUI != null)
        {
            popupUI.ShowPopup();
        }
        else
        {
            Debug.LogWarning("EndRunUI not found. Loading MainHub.");
            SceneManager.LoadScene("MainHub");
        }
    }
}