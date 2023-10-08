using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Tilemaps;
using UnityEngine.U2D;
using UnityEngine.UI;

public class BuildingManager : MonoBehaviour
{
    public Tilemap tilemap;
    public Tile[] tiles;
    public List<Building> buildings = new List<Building>();
    public List<GameObject> UITiles;

    public int selectedBuilding = -1;

    public Transform tileGridUI;
    public GameObject buttonPrefab;
    public TextMeshProUGUI escText;

    private bool[,] occupiedCells;

    public Texture2D buildingCursorTexture;
    public Texture2D initialCursorTexture;
    public bool placingCursor = false;

    public TextMeshProUGUI energyText;
    public TextMeshProUGUI foodText;
    public TextMeshProUGUI oxygenText;

    public int energy = 100;
    public int food = 100;
    public int oxygen = 100;

    private void InitializeOccupiedCells()
    {
        occupiedCells = new bool[tilemap.cellBounds.size.x, tilemap.cellBounds.size.y];
    }


    private void Start()
    {

        InitializeOccupiedCells();

        int i = 0;

        foreach (Building building in buildings)
        {
            Tile tile = building.tile;
            /*GameObject UITile = new GameObject("UI Tile");
            UITile.transform.parent = tileGridUI;
            UITile.transform.localScale = new Vector3(1f, 1f, 1f);

            Image UIImage = UITile.AddComponent<Image>();
            UIImage.sprite = tile.sprite;

            Color tileColor = UIImage.color;
            tileColor.a = 0.5f;

            if(i == selectedBuilding)
            {
                tileColor.a = 1f;
            }

            UIImage.color = tileColor;
            UITiles.Add(UITile);*/

            GameObject UIButton = Instantiate(buttonPrefab, tileGridUI);
            Button button = UIButton.GetComponent<Button>();

            int index = i;
            button.onClick.AddListener(() => OnButtonClick(index));

            // Set button image based on the Building object's image
            Image buttonImage = UIButton.GetComponent<Image>();
            buttonImage.sprite = building.tile.sprite; // Assuming Image is a property of the Building class representing the sprite you want to use

            UITiles.Add(UIButton);

            i++;

        }

        ChangeCursor();
    }

    void OnButtonClick(int selectedIndex)
    {
        // Handle button click here, you can use the index
        Debug.Log("Button Clicked, Index: " + selectedIndex);

        if (selectedBuilding == selectedIndex)
        {
            selectedBuilding = -1;
            placingCursor = false;
        }
        else
        {
            selectedBuilding = selectedIndex;
            placingCursor = true;
        }
    }

    private void Update()
    {
        

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            selectedBuilding = -1;
            placingCursor = false;
        }

        ChangeCursor();

        RenderUITiles();

        PutBuilding(selectedBuilding);

        UpdatePoints();
    }

    void UpdatePoints()
    {
        energyText.text = energy.ToString();
        foodText.text = food.ToString();
        oxygenText.text = oxygen.ToString();
    }

    void PutBuilding(int selectedBuilding)
    {
        if (Input.GetMouseButtonDown(0) && this.selectedBuilding != -1)
        {
            energy -= buildings[selectedBuilding].energyCost;
            Vector3 position = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            tilemap.SetTile(tilemap.WorldToCell(position), buildings[this.selectedBuilding].tile);
        }
    }

    void ChangeCursor()
    {
        if (placingCursor == true)
        {
            Cursor.SetCursor(buildingCursorTexture, Vector2.zero, CursorMode.ForceSoftware);
            escText.gameObject.SetActive(true);
        }
        else
        {
            Cursor.SetCursor(initialCursorTexture, Vector2.zero, CursorMode.ForceSoftware);
            escText.gameObject.SetActive(false);
        }
    }

    private void RenderUITiles()
    {
        int i = 0;
        foreach(GameObject tile in UITiles)
        {
            Image UIImage = tile.GetComponent<Image>();

            Color tileColor = UIImage.color;

            if (i == selectedBuilding)
            {
                tileColor.a = 1f;
            }
            else { tileColor.a = 0.5f; }

            UIImage.color = tileColor;

            i++;
        }
    }

    void UpdateCursor()
    {
        

        Tile tile = tiles[selectedBuilding];
        Texture2D cursorTexture = textureFromSprite(tile.sprite);
        
        print(cursorTexture.isReadable ? "True" : "False");

        if (tile != null)
        {
            // Cursor.SetCursor(cursorTexture, Vector2.zero, CursorMode.ForceSoftware);
        }
    }

    public static Texture2D textureFromSprite(Sprite sprite)
    {
        if (sprite.rect.width != sprite.texture.width)
        {
            Texture2D newText = new Texture2D((int)sprite.rect.width, (int)sprite.rect.height);
            Color[] newColors = sprite.texture.GetPixels((int)sprite.textureRect.x,
                                                         (int)sprite.textureRect.y,
                                                         (int)sprite.textureRect.width,
                                                         (int)sprite.textureRect.height);
            newText.SetPixels(newColors);
            newText.Apply();
            return newText;
        }
        else
            return sprite.texture;
    }
}

