using UnityEngine;

public class AvatarBounce : MonoBehaviour
{
    public float speed = 2f;
    public float height = 0.1f;
    private Vector3 initialLocalPos;

    void Start()
    {
        initialLocalPos = transform.localPosition;
    }

    void Update()
    {
        float y = Mathf.Sin(Time.time * speed) * height;
        transform.localPosition = initialLocalPos + new Vector3(0, y, 0);
    }
}
