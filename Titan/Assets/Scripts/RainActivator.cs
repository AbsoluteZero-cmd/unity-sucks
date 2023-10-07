using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class RainActivator : MonoBehaviour
{
public static event Action ExampleEvent;

public void Update()
{
    if (Input.GetMouseButton(0))
    {
ExampleEvent?.Invoke(); 
}
}
}


