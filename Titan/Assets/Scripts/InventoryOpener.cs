using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryOpener : MonoBehaviour
{
    public GameObject inventoryPanel;


    public void openInventory()
    {
        if(inventoryPanel != null)
        {
            bool isActive = inventoryPanel.gameObject.activeSelf;
            inventoryPanel.SetActive(!isActive);
        }
        
    }
}
