using UnityEngine;

public class BuildingHealth : MonoBehaviour
{
    public int maxHealth = 10;
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

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Проверяем столкновение с каплей дождя
        if (collision.CompareTag("RainDrop"))
        {
            TakeDamage(10); // Применяем урон от капли дождя
            Destroy(collision.gameObject); // Уничтожаем каплю дождя
        }
    }

    private void DestroyBuilding()
    {
        Destroy(gameObject); // Уничтожаем объект при достижении нулевого здоровья
    }
}
