using UnityEngine;
using System.Collections;

public class FoodSpawner : MonoBehaviour
{
    public GameObject healthyFoodPrefab;
    public GameObject junkFoodPrefab;

    public float spawnDistance = 10f;
    public Transform player;

    float[] lanes = { -2.5f, 0f, 2.5f };

    void Start()
    {
        if (healthyFoodPrefab == null || junkFoodPrefab == null)
        {
            Debug.LogError("FoodSpawner: Assign both healthy and junk food prefabs in the Inspector!");
            return;
        }

        if (player == null)
        {
            Debug.LogError("FoodSpawner: Assign the player Transform in the Inspector!");
            return;
        }

        StartCoroutine(SpawnFood());
    }

    IEnumerator SpawnFood()
    {
        while (true)
        {
            // Only spawn if player exists
            if (player != null)
            {
                SpawnChoice();
            }
            else
            {
                Debug.LogWarning("FoodSpawner: Player missing, skipping spawn.");
            }

            // wait before spawning next batch
            yield return new WaitForSeconds(Random.Range(2f, 4f)); // shorter interval for more frequent spawns
        }
    }

    void SpawnChoice()
    {
        if (player == null) return;

        float spawnX = player.position.x + spawnDistance;

        int healthyLane = Random.Range(0, lanes.Length);
        int junkLane = Random.Range(0, lanes.Length);

        while (junkLane == healthyLane)
        {
            junkLane = Random.Range(0, lanes.Length);
        }

        // Use player's base Y (0) or a fixed offset if lanes are relative to player
        Vector3 healthyPos = new Vector3(spawnX, lanes[healthyLane], 0);
        Vector3 junkPos = new Vector3(spawnX, lanes[junkLane], 0);

        try
        {
            if (healthyFoodPrefab != null)
                Instantiate(healthyFoodPrefab, healthyPos, Quaternion.identity);

            if (junkFoodPrefab != null)
                Instantiate(junkFoodPrefab, junkPos, Quaternion.identity);
        }
        catch (System.Exception e)
        {
            Debug.LogError("FoodSpawner: Error instantiating food prefabs: " + e.Message);
        }
    }
}