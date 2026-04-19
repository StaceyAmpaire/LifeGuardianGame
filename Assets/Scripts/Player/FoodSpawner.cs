using UnityEngine;
using System.Collections;

public class FoodSpawner : MonoBehaviour
{
    public GameObject[] healthyFoodPrefabs;
    public GameObject[] junkFoodPrefabs;

    public float spawnDistance = 10f;
    public Transform player;

    float[] lanes = { -2.5f, 0f, 2.5f };

    void Start()
    {
        if (healthyFoodPrefabs == null || healthyFoodPrefabs.Length == 0)
        {
            Debug.LogError("FoodSpawner: No healthy prefabs assigned!");
            return;
        }

        if (junkFoodPrefabs == null || junkFoodPrefabs.Length == 0)
        {
            Debug.LogError("FoodSpawner: No junk prefabs assigned!");
            return;
        }

        if (player == null)
        {
            Debug.LogError("FoodSpawner: Player not assigned!");
            return;
        }

        StartCoroutine(SpawnFood());
    }

    IEnumerator SpawnFood()
    {
        while (true)
        {
            if (player != null)
            {
                SpawnChoice();
            }
            else
            {
                Debug.LogWarning("FoodSpawner: Player missing, skipping spawn.");
            }

            yield return new WaitForSeconds(Random.Range(2f, 4f));
        }
    }

    void SpawnChoice()
    {
        if (player == null) return;

        float spawnX = player.position.x + spawnDistance;

        // pick random lanes
        int healthyLane = Random.Range(0, lanes.Length);
        int junkLane = Random.Range(0, lanes.Length);

        while (junkLane == healthyLane)
        {
            junkLane = Random.Range(0, lanes.Length);
        }

        Vector3 healthyPos = new Vector3(spawnX, lanes[healthyLane], 0);
        Vector3 junkPos = new Vector3(spawnX, lanes[junkLane], 0);

        // pick random prefabs
        GameObject healthyPrefab =
            healthyFoodPrefabs[Random.Range(0, healthyFoodPrefabs.Length)];

        GameObject junkPrefab =
            junkFoodPrefabs[Random.Range(0, junkFoodPrefabs.Length)];

        Instantiate(healthyPrefab, healthyPos, Quaternion.identity);
        Instantiate(junkPrefab, junkPos, Quaternion.identity);
    }
}