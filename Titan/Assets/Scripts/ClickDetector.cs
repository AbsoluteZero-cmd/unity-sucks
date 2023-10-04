using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Clicker : MonoBehaviour
{
    void OnMouseDown()
    {
        if (Input.GetMouseButtonDown(1))
        {
            print("some shit");
        }
    }
}