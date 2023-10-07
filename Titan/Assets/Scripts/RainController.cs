using System.Collections;
using UnityEngine;

public class RainController : MonoBehaviour
{
    public ParticleSystem rainParticleSystem;
    public GameObject rainSignPrefab; // Reference to your rain sign prefab

    private GameObject currentRainSign; // The currently displayed rain sign

    public float minDelay = 5f;  // Minimum delay in seconds
    public float maxDelay = 15f; // Maximum delay in seconds

    private void Start()
    {
        // Start the coroutine to spawn rain at random intervals
        StartCoroutine(StartRain());
    }

    IEnumerator StartRain()
    {
        while (true)
        {
            // Wait for a random amount of time before starting rain
            float delay = Random.Range(minDelay, maxDelay);
            yield return new WaitForSeconds(delay);

            // Start the rain particle system
            rainParticleSystem.Play();

            // Instantiate the rain sign
            if (currentRainSign == null)
            {
                currentRainSign = Instantiate(rainSignPrefab, transform.position, Quaternion.identity);
            }

            // Wait for a random duration for the rain to continue
            float rainDuration = Random.Range(5f, 10f); // Adjust the duration as needed
            yield return new WaitForSeconds(rainDuration);

            // Stop the rain particle system
            rainParticleSystem.Stop();

            // Hide the rain sign
            if (currentRainSign != null)
            {
                Destroy(currentRainSign);
                currentRainSign = null;
            }
        }
    }
}
