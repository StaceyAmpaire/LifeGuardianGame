using UnityEngine;
using TMPro;

public class DewUI : MonoBehaviour
{
    public TextMeshProUGUI dewText;

    void Update()
    {
        if (ProgressManager.instance != null)
        {
            dewText.text = " Healing Dew: " + ProgressManager.instance.totalHealingDew;
        }
    }
}