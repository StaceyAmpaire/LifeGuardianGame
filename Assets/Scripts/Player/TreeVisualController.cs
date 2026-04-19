using UnityEngine;

public class TreeVisualController : MonoBehaviour
{
    public GameObject healthyTree;
    public GameObject stableTree;
    public GameObject recoveringTree;
    public GameObject witheringTree;

    void Start()
    {
        UpdateTree();
    }

    public void UpdateTree()
    {
        healthyTree.SetActive(false);
        stableTree.SetActive(false);
        recoveringTree.SetActive(false);
        witheringTree.SetActive(false);

        var state = EcoSystemHealthManager.instance.currentTreeState;

        if (state == EcoSystemHealthManager.TreeState.Healthy)
            healthyTree.SetActive(true);

        else if (state == EcoSystemHealthManager.TreeState.Stable)
            stableTree.SetActive(true);

        else if (state == EcoSystemHealthManager.TreeState.Recovering)
            recoveringTree.SetActive(true);

        else
            witheringTree.SetActive(true);
    }
}