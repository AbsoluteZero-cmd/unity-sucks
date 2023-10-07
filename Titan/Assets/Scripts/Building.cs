using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Building
{
    public string buildingName;

    public int energyCost;
    public int turnsTillBuilt;
    public int health = 100;

    public int energyPerTurn;
    public int foodPerTurn;
    public int oxygenPerTurn;

    public GameObject UITile = new GameObject("UI Tile");

    public Building(int energyCost, int turnsTillBuilt, int energyPerTurn, int foodPerTurn, int oxygenPerTurn, GameObject UITile)
    {
        this.energyCost = energyCost;
        this.turnsTillBuilt = turnsTillBuilt;
        this.energyPerTurn = energyPerTurn;
        this.foodPerTurn = foodPerTurn;
        this.oxygenPerTurn = oxygenPerTurn;
    }
}
