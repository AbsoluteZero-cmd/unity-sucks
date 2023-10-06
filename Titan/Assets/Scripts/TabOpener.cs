using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TabOpener : MonoBehaviour
{
    public GameObject myPanel;

    public void openTab()
    {
        if(myPanel != null)
        {
            bool isActive = myPanel.gameObject.activeSelf;
            myPanel.SetActive(!isActive);
        }
        
    }
}
