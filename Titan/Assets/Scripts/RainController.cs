using UnityEngine;
using System.Collections;

public class RainController : MonoBehaviour
{
    public ParticleSystem ParticleSystem;
    public GameObject rainSignPrefab;
    public int rainDamage = 10; // Урон, наносимый дождем

    private GameObject currentRainSign;

    public float minDelay = 5f;
    public float maxDelay = 15f;
    public LayerMask buildingLayer;

    private void Start()
    {
        StartCoroutine(StartRain());
    }

    IEnumerator StartRain()
    {
        while (true)
        {
            float delay = Random.Range(minDelay, maxDelay);
            yield return new WaitForSeconds(delay);

            ParticleSystem.Play();

            if (currentRainSign == null)
            {
                currentRainSign = Instantiate(rainSignPrefab, transform.position, Quaternion.identity);
            }

            float rainDuration = Random.Range(5f, 10f);
            yield return new WaitForSeconds(rainDuration);

            ParticleSystem.Stop();

            if (currentRainSign != null)
            {
                Destroy(currentRainSign);
                currentRainSign = null;
            }
        }
    }

    private void Update()
    {
        Collider2D[] hitColliders = Physics2D.OverlapCircleAll(transform.position, 1f, buildingLayer);

        foreach (Collider2D hitCollider in hitColliders)
        {
            BuildingHealth building = hitCollider.GetComponent<BuildingHealth>();
            if (building != null)
            {
                building.TakeDamage(rainDamage); // Наносим урон зданию
            }
        }
    }
}
