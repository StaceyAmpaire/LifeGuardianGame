using UnityEngine;

public class RunnerController : MonoBehaviour
{
    public float forwardSpeed = 5f;
    public float[] lanePositions = { -2.5f, 0f, 2.5f };

    private int currentLane = 1;
    public float runDistance = 100f;
    private bool hasEnded = false;
    private float startX;

    void Start()
    {
        startX = transform.position.x;
    }

    void Update()
    {
        transform.Translate(Vector2.right * forwardSpeed * Time.deltaTime);

        if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow))
            currentLane = Mathf.Clamp(currentLane + 1, 0, 2);

        if (Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow))
            currentLane = Mathf.Clamp(currentLane - 1, 0, 2);

        Vector3 target = new Vector3(
            transform.position.x,
            lanePositions[currentLane],
            transform.position.z
        );

        transform.position = Vector3.Lerp(transform.position, target, Time.deltaTime * 10);

        if (!hasEnded && transform.position.x >= startX + runDistance)
{
    hasEnded = true;

    RunManager rm = FindFirstObjectByType<RunManager>();
    if (rm != null)
        rm.EndRun();
}
    }
}