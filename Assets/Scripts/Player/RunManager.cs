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
        }
        else
        {
            badChoices++;
            score -= 5;
        }

        score = Mathf.Max(0, score);
    }

    public float GetPerformancePercent()
    {
        if (totalChoices == 0) return 0f;

        return (goodChoices / (float)totalChoices) * 100f;
    }
  private bool runEnded = false;
    public void EndRun()
{
    if (runEnded) return;   // 🔥 STOP DUPLICATES
    runEnded = true;

    Time.timeScale = 0f;

    EndRunUI ui = FindFirstObjectByType<EndRunUI>();

    if (ui != null)
        ui.ShowPopup(score, GetPerformancePercent(), goodChoices, badChoices);
}
}