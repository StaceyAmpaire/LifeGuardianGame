using UnityEngine;
using UnityEngine.SceneManagement;

public class MainHubButtons : MonoBehaviour
{
    public void StartPreventionRun()
    {
        Time.timeScale = 1f;
       SceneManager.LoadScene("LevelSelection");
    }

    public void StartManagementRun()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("LevelSelection");
    }

    public void OpenDailyQuests()
    {
        Debug.Log("Daily Quests button clicked!");
    }
}