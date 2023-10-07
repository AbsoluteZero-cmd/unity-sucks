using UnityEngine;

public class CloudController : MonoBehaviour
{
    public GameObject[] cloudPrefabs; // Array of cloud prefabs
    public float spawnInterval = 10.0f; // Interval between cloud spawns
    public float cloudSpeed = 2.0f; // Speed of cloud movement (horizontal)

    private float nextSpawnTime = 0.0f;

    private void Start()
    {
        // Set initial spawn time
        nextSpawnTime = Time.time + spawnInterval;
    }

    private void Update()
    {
        // Check if it's time to spawn a new cloud
        if (Time.time >= nextSpawnTime)
        {
            SpawnCloud();
            // Set the next spawn time
            nextSpawnTime = Time.time + spawnInterval;
        }
    }

    private void SpawnCloud()
    {
        // Randomly select a cloud prefab from the array
        GameObject cloudPrefab = cloudPrefabs[Random.Range(0, cloudPrefabs.Length)];

        // Instantiate the selected cloud prefab
        GameObject cloud = Instantiate(cloudPrefab, transform.position, Quaternion.identity);

        // Set the cloud's initial position (e.g., on the right side of the screen)
        Vector3 initialPosition = new Vector3(10.0f, Random.Range(2.0f, 5.0f), 0.0f);
        cloud.transform.position = initialPosition;

        // Set the cloud's speed and direction (move from right to left)
        Rigidbody2D cloudRigidbody = cloud.GetComponent<Rigidbody2D>();
        cloudRigidbody.velocity = new Vector2(-cloudSpeed, 0.0f);

        // Destroy the cloud when it goes offscreen
        Destroy(cloud, 20.0f); // Adjust this value based on your scene size
    }
}
