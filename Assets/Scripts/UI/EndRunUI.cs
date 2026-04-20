using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class EndRunUI : MonoBehaviour
{
    public GameObject popup;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI healingDewText;
    public TextMeshProUGUI performanceText;

    public Button nextLevelButton;
    public Button closeButton;

    private RunManager runManager;

    void Start()
    {
        runManager = FindFirstObjectByType<RunManager>();

        popup.SetActive(false);

        nextLevelButton.onClick.AddListener(OnNextLevel);
        closeButton.onClick.AddListener(OnClosePopup);
    }

    public void ShowPopup()
    {
        if (runManager == null)
            runManager = FindFirstObjectByType<RunManager>();

        float performance = runManager.GetPerformancePercent();

        int healingDew = Mathf.RoundToInt(performance);

        EcoSystemHealthManager.instance.AddHealingDew(healingDew);

        scoreText.text = "Score: " + Mathf.RoundToInt(performance) + "%";
        performanceText.text = "Performance: " + healingDew + "%";
        healingDewText.text = "Healing Dew: " + healingDew;

        popup.SetActive(true);
    }

    void OnNextLevel()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("LevelSelection");
    }

    void OnClosePopup()
    {
        Time.timeScale = 1f;
        popup.SetActive(false);

        SceneManager.LoadScene("MainHub");
    }
}