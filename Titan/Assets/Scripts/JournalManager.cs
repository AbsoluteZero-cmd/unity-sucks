using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class JournalManager : MonoBehaviour
{
    public TextMeshProUGUI journalText;
    public List<DisasterEvent> disasterEvents = new List<DisasterEvent>();

    public GameObject objectBlockPrefab; // Reference to your object block prefab
    public Transform panelContent; // Reference to the content transform of the panel
    public float spacing = 10f; // Specify the spacing between objects

    void Start()
    {
        if (disasterEvents.Count > 0)
        {
            foreach (var disasterEvent in disasterEvents)
            {
                Debug.Log(disasterEvent.disasterName);
            }
        }

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

            // Adjust the position of the objectBlock prefab
            RectTransform rt = objectBlock.GetComponent<RectTransform>();
            rt.anchoredPosition = new Vector2(rt.anchoredPosition.x, -yOffset); // Set the y position
            yOffset += rt.rect.height + spacing; // Update yOffset with the height of the prefab plus spacing
        }
    }

    public void ShowObjectDescription(DisasterEvent selectedEvent)
    {
        if(journalText != null)
        {
            journalText.text = selectedEvent.disasterDescription;
        }
    }
}

