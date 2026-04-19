using UnityEngine;

public class FoodItem : MonoBehaviour
{
    public bool isHealthy = true;
    public string foodName;

    public Transform player;
    public float destroyDistance = 10f;

    private void Start()
    {
        if (player == null)
        {
            GameObject p = GameObject.FindWithTag("Player");
            if (p != null)
                player = p.transform;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!collision.CompareTag("Player")) return;

        RunManager manager = Object.FindFirstObjectByType<RunManager>();

        if (manager != null)
        {
            manager.RegisterChoice(isHealthy, foodName);
        }

        Destroy(gameObject);
    }

    void Update()
    {
        // Clean up off-screen objects
        if (player != null && transform.position.x < player.position.x - destroyDistance)
        {
            Destroy(gameObject);
        }
    }
}