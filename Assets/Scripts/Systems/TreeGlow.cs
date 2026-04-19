using UnityEngine;

public class TreeGlow : MonoBehaviour
{
    float glowSpeed = 2f;
    float glowAmount = 0.2f;
    Vector3 startScale;

    void Start()
    {
        startScale = transform.localScale;
    }

    void Update()
    {
        float scale = 1 + Mathf.Sin(Time.time * glowSpeed) * glowAmount;
        transform.localScale = startScale * scale;
    }
}