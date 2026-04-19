using UnityEngine;

public class BaobabTreeManager : MonoBehaviour
{
    public GameObject healthyTree;
    public GameObject stableTree;
    public GameObject recoveringTree;
    public GameObject witheringTree;

    void Start()
    {
        UpdateTree(GameManager.instance.lastRunPercent);
    }

    public void UpdateTree(float performance)
    {
        // deactivate all first
        healthyTree.SetActive(false);
        stableTree.SetActive(false);
        recoveringTree.SetActive(false);
        witheringTree.SetActive(false);

        // choose tree based on performance
        if (performance >= 80)
        {
            healthyTree.SetActive(true);
        }
        else if (performance >= 60)
        {
            stableTree.SetActive(true);
        }
        else if (performance >= 40)
        {
            recoveringTree.SetActive(true);
        }
        else
        {
            witheringTree.SetActive(true);
        }
    }
}