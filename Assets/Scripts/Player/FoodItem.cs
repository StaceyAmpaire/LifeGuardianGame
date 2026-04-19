using UnityEngine;

public class FoodItem : MonoBehaviour
{
    public bool isHealthy = true;
    public Transform player; // assign player if possible

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
        if (collision.CompareTag("Player"))
        {
            RunManager manager = Object.FindFirstObjectByType<RunManager>();

            if(manager != null)
            {
                manager.RegisterChoice(isHealthy);
            }

            Destroy(gameObject);
        }
    }

    void Update()
    {
        // If the game is a "runner" where the player moves forward, 
        // the food should stay at its spawned X position.
        // If the player is stationary and food "moves" towards them:
        // transform.Translate(Vector2.left * speed * Time.deltaTime);

        if(player != null && transform.position.x < player.position.x - 10)
        {
            Destroy(gameObject);
        }
    }
}