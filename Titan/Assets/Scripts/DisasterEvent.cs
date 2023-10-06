using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class DisasterEvent
{
    public string disasterName; // e.g. acid rain or equipment malfunction
    public string disasterType; // natural or artificial
    public string disasterDescription; // e.g. 

    public double disasterProbability; // random value of [0.00, 1)
    public double disasterIntensity; // 1-10, how much damage it can cause

    public List<string> protectionStructures; // what types of structures will prevent the damage from this type of event

    public DisasterEvent(string disasterName, string disasterType, string disasterDescription)
    {
        this.disasterName = disasterName;
        this.disasterType = disasterType;
        this.disasterDescription = disasterDescription;
    }
}
