using UnityEngine;

public class EventManager : MonoBehaviour
{
    public GameObject acidRainPrefab; // Префаб кислотного дождя.
    public float acidRainDuration = 10f; // Длительность кислотного дождя.

    public void StartAcidRainEvent()
    {
        // Запускаем ивент с кислотным дождем.
        StartCoroutine(SpawnAcidRain());
    }

    private IEnumerator SpawnAcidRain()
    {
        // Создаем кислотный дождь и активируем его на сцене.
        GameObject acidRain = Instantiate(acidRainPrefab, transform.position, Quaternion.identity);
        yield return new WaitForSeconds(acidRainDuration);
        // Заканчиваем ивент и убираем кислотный дождь, например, уничтожая его объект.
        Destroy(acidRain);
    }
}
