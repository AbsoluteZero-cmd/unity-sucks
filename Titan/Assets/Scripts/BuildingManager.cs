using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
using UnityEngine.UI;

public class BuildingManager : MonoBehaviour
{
    public Tilemap tilemap;
    public Tile[] tiles;
    public List<GameObject> UITiles;

    private int selectedTile = -1;

    public Transform tileGridUI;

    public Texture2D cursorTexture;

    private bool placingCursor = false;

    // Array to track occupied cells
    private bool[,] occupiedCells;

    private void Start()
    {
        InitializeOccupiedCells();
        
        int i = 0;

        foreach (Tile tile in tiles)
        {
            GameObject UITile = new GameObject("UI Tile");
            UITile.transform.parent = tileGridUI;
            UITile.transform.localScale = new Vector3(1f, 1f, 1f);

            Image UIImage = UITile.AddComponent<Image>();
            UIImage.sprite = tile.sprite;

            Color tileColor = UIImage.color;
            tileColor.a = 0.5f;

            if (i == selectedTile)
            {
                tileColor.a = 1f;
            }

            UIImage.color = tileColor;
            UITiles.Add(UITile);

            i++;
        }

        ChangeCursor();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            SelectTile(0);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            SelectTile(1);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            SelectTile(2);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            SelectTile(3);
        }

        if (Input.GetMouseButtonDown(0) && selectedTile != -1)
        {
        Vector3 position = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector3Int cellPosition = tilemap.WorldToCell(position);

        // Check if the cell is within the bounds of the Tilemap
        if (tilemap.cellBounds.Contains(cellPosition))
        {
            // Check if the cell is occupied before placing a tile
            if (!occupiedCells[cellPosition.x, cellPosition.y])
            {
                tilemap.SetTile(cellPosition, tiles[selectedTile]);
                occupiedCells[cellPosition.x, cellPosition.y] = true;
            }
        }
        }







        ChangeCursor();
        RenderUITiles();

        if (Input.GetMouseButtonDown(0) && selectedTile != -1)
        {
            Vector3 position = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector3Int cellPosition = tilemap.WorldToCell(position);

            // Check if the cell is occupied before placing a tile
            if (!occupiedCells[cellPosition.x, cellPosition.y])
            {
                tilemap.SetTile(cellPosition, tiles[selectedTile]);
                occupiedCells[cellPosition.x, cellPosition.y] = true;
            }
        }
    }

    private void InitializeOccupiedCells()
    {
        occupiedCells = new bool[tilemap.cellBounds.size.x, tilemap.cellBounds.size.y];
    }

    void SelectTile(int tileIndex)
    {
        if (selectedTile == tileIndex)
        {
            selectedTile = -1;
        }
        else
        {
            selectedTile = tileIndex;
        }
        placingCursor = selectedTile != -1;
    }

    void ChangeCursor()
    {
        if (placingCursor)
        {
            Cursor.SetCursor(cursorTexture, Vector2.zero, CursorMode.ForceSoftware);
        }
        else
        {
            Cursor.SetCursor(null, Vector2.zero, CursorMode.ForceSoftware);
        }
    }

    private void RenderUITiles()
    {
        int i = 0;
        foreach (GameObject tile in UITiles)
        {
            Image UIImage = tile.GetComponent<Image>();

            Color tileColor = UIImage.color;

            if (i == selectedTile)
            {
                tileColor.a = 1f;
            }
            else
            {
                tileColor.a = 0.5f;
            }

            UIImage.color = tileColor;

            i++;
        }
    }
}