using UnityEngine;

public class BuildingHealth : MonoBehaviour
{
    public int maxHealth = 100;
    private int currentHealth;

    private void Start()
    {
        currentHealth = maxHealth;
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;

        if (currentHealth <= 0)
        {
            DestroyBuilding();
        }
    }

    private void DestroyBuilding()
    {
        // Perform any cleanup or effects here (e.g., particle effects)
        Destroy(gameObject); // Destroy the GameObject when health reaches zero
    }
}
