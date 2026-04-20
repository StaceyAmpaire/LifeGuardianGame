using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class EndRunUI : MonoBehaviour
{
    public GameObject popup;

    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI performanceText;
    public TextMeshProUGUI healingDewText;

    public Button nextLevelButton;
    public Button closeButton;
    private bool hasShown = false;

    void Start()
    {
        popup.SetActive(false);

        nextLevelButton.onClick.AddListener(OnNextLevel);
        closeButton.onClick.AddListener(OnClosePopup);
    }

    public void ShowPopup(int score, float performance, int good, int bad)
{
    if (hasShown) return;
    hasShown = true;

    int healingDew = Mathf.RoundToInt(performance);

    ProgressManager.instance.AddHealingDew(healingDew);

    scoreText.text = "Score: " + score;
    performanceText.text = "Performance: " + Mathf.RoundToInt(performance) + "%";
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
        SceneManager.LoadScene("MainHub");
    }
}