using UnityEngine;

public class AvatarBodyController : MonoBehaviour
{
    public Sprite[] bodyStages; // 6 sprites
    private SpriteRenderer sr;

    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        if (sr == null)
        {
            Debug.LogError("SpriteRenderer missing!");
            return;
        }

        // Only update if EcosystemHealthManager exists
        if (EcoSystemHealthManager.instance != null)
            UpdateBody();
    }

    public void UpdateBody()
    {
        if (EcoSystemHealthManager.instance == null) return;
        if (bodyStages == null || bodyStages.Length == 0) return;

        int dew = EcoSystemHealthManager.instance.totalHealingDew;
        int stage = dew / 80;
        stage = Mathf.Clamp(stage, 0, bodyStages.Length - 1);

        sr.sprite = bodyStages[stage];
    }
}