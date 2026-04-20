using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelSelectionUI : MonoBehaviour
{
    public void LoadFoodRun()
    {
        SceneManager.LoadScene("RunnerLevel");
    }

    public void LoadExerciseRun()
    {
        SceneManager.LoadScene("RunnerLevel");
    }

    public void LoadSugarRun()
    {
        SceneManager.LoadScene("RunnerLevel");
    }

    public void BackToHub()
    {
        SceneManager.LoadScene("MainHub");
    }
}