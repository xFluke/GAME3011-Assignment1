using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GridManager : MonoBehaviour
{
    [SerializeField] int sizeX;
    [SerializeField] int sizeY;
    [SerializeField] GameObject tilePrefab;

    Tile[,] grid;

    // Start is called before the first frame update
    void Start() {
        GenerateGrid();
    }

    private void GenerateGrid() {
        grid = new Tile[sizeX, sizeY];

        float tileSize = GetComponent<GridLayoutGroup>().cellSize.x;
        GetComponent<RectTransform>().sizeDelta = new Vector2(sizeX * tileSize, sizeY * tileSize);

        for (int y = 0; y < sizeY; y++) {
            for (int x = 0; x < sizeX; x++) {
                GameObject tile = Instantiate(tilePrefab, this.transform);
                tile.GetComponent<Tile>().SetCoordinate(x, y);

                grid[x, y] = tile.GetComponent<Tile>(); 
            }
        }
    }

    private Tile GetTileAt(int x, int y) {
        if (x < 0 || x > sizeX - 1 || y < 0 || y > sizeY - 1) {
            return null;
        } 

        return grid[x, y];
    }

    public void GetSurroundingTiles(Tile centerTile) {
        Vector2Int coordinate = centerTile.GetCoordinate();

        Tile[] tiles = new Tile[9];
        int i = 0;

        for (int x = coordinate.x - 1; x <= coordinate.x + 1; x++) {
            for (int y = coordinate.y - 1; y <= coordinate.y + 1; y++) {
                tiles[i] = GetTileAt(x, y);
                i++;
            }
        }

        foreach (var tile in tiles) {
            if (tile != null) {
                tile.GetComponent<Image>().color = new Color(255, 0, 0);
            }
        }
    }
}
