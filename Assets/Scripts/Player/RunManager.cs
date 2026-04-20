using UnityEngine;
using UnityEngine.SceneManagement;

public class RunManager : MonoBehaviour
{
    public int totalChoices = 0;
    public int goodChoices = 0;
    public int badChoices = 0;

    public int score = 0;

    void Start()
    {
        Time.timeScale = 1f;
    }

    public void RegisterChoice(bool healthy, string foodName)
    {
        totalChoices++;

        if (healthy)
        {
            goodChoices++;
            score += 10;

            Debug.Log("✔ Healthy choice: " + foodName + " (+10)");
        }
        else
        {
            badChoices++;
            score -= 5;

            Debug.Log("❌ Unhealthy choice: " + foodName + " (-5)");
        }

        score = Mathf.Max(0, score);
    }

    public float GetPerformancePercent()
    {
        if (totalChoices == 0) return 0f;

        return (goodChoices / (float)totalChoices) * 100f;
    }

    public void EndRun()
    {
        Time.timeScale = 0f;

        float performance = GetPerformancePercent();

        Debug.Log("Run ended!");
        Debug.Log("Score: " + score);
        Debug.Log("Performance: " + performance + "%");

        EndRunUI popupUI = FindFirstObjectByType<EndRunUI>();

       if (popupUI != null)
{
    popupUI.ShowPopup();
}
else
{
    SceneManager.LoadScene("MainHub");
}
    }
}