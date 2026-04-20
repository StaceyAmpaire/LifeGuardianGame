using UnityEngine;

public class ProgressManager : MonoBehaviour
{
    public static ProgressManager instance;

    public int totalHealingDew;
    private const string HAS_INITIALIZED_KEY = "HasInitialized";

    void Awake()
{
    if (instance != null)
    {
        Destroy(gameObject);
        return;
    }

    instance = this;
    DontDestroyOnLoad(gameObject);

    // 🔥 FIRST TIME INITIALIZATION CHECK
    if (!PlayerPrefs.HasKey(HAS_INITIALIZED_KEY))
    {
        ResetProgress(); // sets Healing Dew to 0
        PlayerPrefs.SetInt(HAS_INITIALIZED_KEY, 1);
        PlayerPrefs.Save();

        Debug.Log("First install detected → Progress reset");
    }

    LoadProgress();
}
    public void AddHealingDew(int amount)
    {
        totalHealingDew += amount;
        SaveProgress();
    }

    public void SaveProgress()
    {
        PlayerPrefs.SetInt("HealingDew", totalHealingDew);
        PlayerPrefs.Save();

        Debug.Log("Saved Healing Dew: " + totalHealingDew);
    }

    public void LoadProgress()
    {
        totalHealingDew = PlayerPrefs.GetInt("HealingDew", 0);

        Debug.Log("Loaded Healing Dew: " + totalHealingDew);
    }

    public void ResetProgress()
{
    totalHealingDew = 0;
    PlayerPrefs.DeleteKey("HealingDew");

    Debug.Log("Progress reset");
    //to reset for lecturer: PlayerPrefs.DeleteAll();
}
}