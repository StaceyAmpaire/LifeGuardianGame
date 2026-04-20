using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelSelectionUI : MonoBehaviour
{
    public void LoadFoodRun()
    {
        // Level 1 always unlocked
        SceneManager.LoadScene("RunnerLevel");
    }

    public void LoadExerciseRun()
    {
        // Need 100 Healing Dew
        if (ProgressManager.instance.totalHealingDew >= 100)
        {
            SceneManager.LoadScene("RunnerLevel");
        }
        else
        {
            Debug.Log("Exercise Run Locked! Need 100 Healing Dew.");
        }
    }

    public void LoadSugarRun()
    {
        // Need 250 Healing Dew
        if (ProgressManager.instance.totalHealingDew >= 250)
        {
            SceneManager.LoadScene("RunnerLevel");
        }
        else
        {
            Debug.Log("Sugar Run Locked! Need 250 Healing Dew.");
        }
    }

    public void BackToHub()
    {
        SceneManager.LoadScene("MainHub");
    }
}