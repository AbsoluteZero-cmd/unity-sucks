using UnityEngine;

public class BuildingHealth : MonoBehaviour
{
    public int maxHealth = 100; // Максимальное здоровье здания.
    private int currentHealth;  // Текущее здоровье здания.

    private void Start()
    {
        currentHealth = maxHealth; // Изначально устанавливаем текущее здоровье равным максимальному.
    }

    // Метод для получения урона.
    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        
        if (currentHealth <= 0)
        {
            DestroyBuilding();
        }
    }

    // Метод для восстановления здоровья (например, лечение).
    public void Heal(int amount)
    {
        currentHealth += amount;
        // Проверка, чтобы не превысить максимальное здоровье.
        currentHealth = Mathf.Min(currentHealth, maxHealth);
    }

    // Метод для разрушения здания.
    private void DestroyBuilding()
    {
        // Здесь вы можете воспроизвести анимацию разрушения или выполнить другие действия.
        Destroy(gameObject);
    }
}
