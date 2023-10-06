using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class JournalManager : MonoBehaviour
{
    public List<DisasterEvent> disasterEvents = new List<DisasterEvent>();

    public GameObject objectBlockPrefab; // Reference to your object block prefab
    public Transform panelContent; // Reference to the content transform of the panel
    public float spacing = 10f; // Specify the spacing between objects

    public Transform selectedDetail;

    void Start()
    {
        /*if (disasterEvents.Count > 0)
        {
            foreach (var disasterEvent in disasterEvents)
            {
                Debug.Log(disasterEvent.disasterName);
            }
        }*/

        PopulateObjectList();
    }

    void PopulateObjectList()
    {
        float yOffset = 120f; // Initialize yOffset


        foreach (var disasterEvent in disasterEvents)
        {
            GameObject objectBlock = Instantiate(objectBlockPrefab, panelContent);
            // Set objectBlock UI elements with disasterEvent properties
            objectBlock.GetComponentInChildren<TextMeshProUGUI>().text = disasterEvent.disasterName;
            // Set other UI elements with disasterEvent properties as needed

            Button button = objectBlock.GetComponent<Button>();
            button.onClick.AddListener(() => changeDisplayedInfo(disasterEvent));

            // Adjust the position of the objectBlock prefab
            RectTransform rt = objectBlock.GetComponent<RectTransform>();
            rt.anchoredPosition = new Vector2(rt.anchoredPosition.x, -yOffset); // Set the y position
            yOffset += rt.rect.height + spacing; // Update yOffset with the height of the prefab plus spacing
        }
    }

    void changeDisplayedInfo(DisasterEvent disasterEvent)
    {

        // Debug.Log("You have clicked the button!");

        GameObject infoPanel = selectedDetail.GetChild(0).gameObject;
        var texts = infoPanel.GetComponentsInChildren<TextMeshProUGUI>();
        texts[0].text = disasterEvent.disasterName;
        texts[1].text = "Probability: " + disasterEvent.disasterProbability.ToString();
        texts[2].text = "Intensity: " + disasterEvent.disasterIntensity.ToString();
        texts[3].text = disasterEvent.disasterDescription;

    }
}

