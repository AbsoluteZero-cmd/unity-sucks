using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Tilemaps;
using UnityEngine.U2D;
using UnityEngine.UI;

public class BuildingManager : MonoBehaviour
{
    public Tilemap tilemap;
    public Tile[] tiles;
    public List<GameObject> UITiles;

    public int selectedTile = -1;

    public Transform tileGridUI;

    public Texture2D cursorTexture;

    public bool placingCursor = false;

    private void Start()
    {
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

            if(i == selectedTile)
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
        if(Input.GetKeyDown(KeyCode.Alpha1)) {
            if (selectedTile == 0)
            {
                selectedTile = -1;
            }
            else selectedTile = 0;
            placingCursor = !placingCursor;
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            if (selectedTile == 1)
            {
                selectedTile = -1;
            }
            else selectedTile = 1;
            placingCursor = !placingCursor;
        }
        else if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            if (selectedTile == 2)
            {
                selectedTile = -1;
            }
            else selectedTile = 2;
            placingCursor = !placingCursor;
        }
        else if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            if (selectedTile == 3)
            {
                selectedTile = -1;
            }
            else selectedTile = 3;
            placingCursor = !placingCursor;
            
        }

        ChangeCursor();

        RenderUITiles();

        if (Input.GetMouseButtonDown(0) && selectedTile != -1)
        {
            Vector3 position = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            tilemap.SetTile(tilemap.WorldToCell(position), tiles[selectedTile]);
        }
    }

    void ChangeCursor()
    {
        if (placingCursor == true)
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
        foreach(GameObject tile in UITiles)
        {
            Image UIImage = tile.GetComponent<Image>();

            Color tileColor = UIImage.color;

            if (i == selectedTile)
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
        

        Tile tile = tiles[selectedTile];
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
