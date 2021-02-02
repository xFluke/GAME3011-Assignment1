using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GridManager : MonoBehaviour
{
    [SerializeField] int sizeX;
    [SerializeField] int sizeY;
    [SerializeField] GameObject tilePrefab;

    public List<Vector2> maxTileLocations = new List<Vector2>();

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

        RandomlySelectMaxPointTilesStartLocations();
    }

    private Tile GetTileAt(int x, int y) {
        if (x < 0 || x > sizeX - 1 || y < 0 || y > sizeY - 1) {
            return null;
        } 

        return grid[x, y];
    }

    public void GetSurroundingTiles3x3(Tile centerTile) {
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

    public void GetSurroundingTiles5x5(Tile centerTile) {
        Vector2Int coordinate = centerTile.GetCoordinate();

        Tile[] tiles = new Tile[25];
        int i = 0;

        for (int x = coordinate.x - 2; x <= coordinate.x + 2; x++) {
            for (int y = coordinate.y - 2; y <= coordinate.y + 2; y++) {
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

    private void RandomlySelectMaxPointTilesStartLocations() {
        int max = FindObjectOfType<GameManager>().GetNumOfMaxPointTiles();

        maxTileLocations = new List<Vector2>();

        for (int i = 0; i < max; i++) {
            int randomX = Random.Range(0, sizeX - 1);
            int randomY = Random.Range(0, sizeY - 1);
            Vector2 randomLocation = new Vector2(randomX, randomY);

            bool found = false;
            while (!found) {
                bool searchAgain = false;
                foreach (Vector2 location in maxTileLocations) {
                    Vector3 resultantLocation = randomLocation - location;

                    if (resultantLocation.magnitude < 5) { 
                        searchAgain = true;
                        break;
                    }
                    else {
                        // (4, 4) cases
                        if (Mathf.Abs(resultantLocation.x) == 4 && Mathf.Abs(resultantLocation.y) == 4) {
                            searchAgain = true;
                            break;
                        }
                        // (3, 4) cases
                        if (Mathf.Abs(resultantLocation.x) == 4 && Mathf.Abs(resultantLocation.y) == 3
                            || Mathf.Abs(resultantLocation.x) == 3 && Mathf.Abs(resultantLocation.y) == 4) {
                            searchAgain = true;
                            break;
                        }
                    }
                }

                if (searchAgain) {
                    randomX = Random.Range(0, sizeX - 1);
                    randomY = Random.Range(0, sizeY - 1);
                    randomLocation = new Vector2(randomX, randomY);
                }
                else {
                    found = true;
                    maxTileLocations.Add(randomLocation);
                }
            }
        
            GetTileAt(randomX, randomY).GetComponent<Image>().color = new Color(0, 255, 0);
        }
    }
}
