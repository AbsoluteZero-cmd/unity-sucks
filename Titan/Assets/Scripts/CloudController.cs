using UnityEngine;

public class CloudController : MonoBehaviour
{
    public GameObject[] cloudPrefabs; // Array of cloud prefabs
    public float cloudSpeed = 2.0f; // Speed of cloud movement (horizontal)

    public float startTime;
    public float spawnInterval;
    public float currentTime;

    private void Start()
    {
        // Set initial spawn time
        /*nextSpawnTime = Time.time + spawnInterval;*/
        startTime = Time.time;
        currentTime = Time.time;
        spawnInterval = 100 * Random.Range(10, 15);
    }

    private void Update()
    {
        currentTime = Time.time;
        if(spawnInterval > 0)
        {
            spawnInterval--;
        }
        else
        {
            startTime = Time.time;
            SpawnCloud();
            spawnInterval = 100 * Random.Range(10, 15);
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
