using UnityEngine;

public class RunnerController : MonoBehaviour
{
    public float forwardSpeed = 5f;

    public float[] lanePositions = { -2.5f, 0f, 2.5f };

    private int currentLane = 1;

    public float runDistance = 100f;
    private float startX;

    void Start()
    {
        startX = transform.position.x;
    }

    void Update()
    {
        // move forward
        transform.Translate(Vector2.right * forwardSpeed * Time.deltaTime);

        // lane switching
        if (Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.W))
            currentLane = Mathf.Clamp(currentLane + 1, 0, 2);

        if (Input.GetKeyDown(KeyCode.DownArrow) || Input.GetKeyDown(KeyCode.S))
            currentLane = Mathf.Clamp(currentLane - 1, 0, 2);

        Vector3 targetPosition = new Vector3(
            transform.position.x,
            lanePositions[currentLane],
            transform.position.z
        );

        transform.position = Vector3.Lerp(transform.position, targetPosition, Time.deltaTime * 10);

        // check if run finished
        if (transform.position.x >= startX + runDistance)
        {
            RunManager manager = FindFirstObjectByType<RunManager>();

            if (manager != null)
                manager.EndRun();
            else
                Debug.LogError("RunManager not found!");
        }
    }
}