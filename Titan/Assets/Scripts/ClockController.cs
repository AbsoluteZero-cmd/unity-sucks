using System;
using UnityEngine;
using TMPro;

public class ClockController : MonoBehaviour
{
    public TextMeshProUGUI earthTimeText;
    public TextMeshProUGUI titanTimeText;

    private float earthTimeInSeconds = 01f;
    private float titanTimeInSeconds = 0f;
    private const float earthToTitanTimeDilation = 29f; // 1 year on Titan = 29 Earth years
    private const float secondsInEarthYear = 365f;
 private int initialEarthYears = 3023;
    private const float earthToTitanTimeDilation1 = 16f;

    private void Update()
    {
        // Update Earth time
        earthTimeInSeconds += Time.deltaTime;
        TimeSpan earthTimeSpan = TimeSpan.FromSeconds(earthTimeInSeconds);
        int earthYears = Mathf.FloorToInt(earthTimeInSeconds / secondsInEarthYear) + initialEarthYears;
        earthTimeText.text = string.Format("Earth Time: {0:D4}:{1:D3}",
            earthYears, earthTimeSpan.Seconds);

          titanTimeInSeconds += Time.deltaTime / earthToTitanTimeDilation1;
        TimeSpan titanTimeSpan = TimeSpan.FromSeconds(titanTimeInSeconds);
      float titanYearsFloat = (earthYears - initialEarthYears) / earthToTitanTimeDilation;
        int titanYears = Mathf.FloorToInt(titanYearsFloat);
        titanTimeText.text = string.Format("Titan Time: {0:D4}:{1:D3}",
            titanYears, titanTimeSpan.Seconds);
    }
}
