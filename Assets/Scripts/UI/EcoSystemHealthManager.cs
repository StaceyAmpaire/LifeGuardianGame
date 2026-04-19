using UnityEngine;

public class EcoSystemHealthManager : MonoBehaviour
{
    public static EcoSystemHealthManager instance;

    public int totalHealingDew = 600; // default start (Healthy tree)

    public enum TreeState
    {
        Healthy,
        Stable,
        Recovering,
        Withering
    }

    public TreeState currentTreeState;

    void Awake()
    {
        instance = this;
    }

    void Start()
    {
        UpdateTreeState();
    }

    public void AddHealingDew(int amount)
    {
        totalHealingDew += amount;
        UpdateTreeState();
    }

    void UpdateTreeState()
    {
        if (totalHealingDew >= 600)
            currentTreeState = TreeState.Healthy;
        else if (totalHealingDew >= 300)
            currentTreeState = TreeState.Stable;
        else if (totalHealingDew >= 100)
            currentTreeState = TreeState.Recovering;
        else
            currentTreeState = TreeState.Withering;
    }
}