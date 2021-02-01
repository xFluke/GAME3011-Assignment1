using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GridManager : MonoBehaviour
{

    [SerializeField] int sizeX;
    [SerializeField] int sizeY;
    [SerializeField] GameObject tilePrefab;

    // Start is called before the first frame update
    void Start()
    {
        float tileSize = GetComponent<GridLayoutGroup>().cellSize.x;
        GetComponent<RectTransform>().sizeDelta = new Vector2(sizeX * tileSize, sizeY * tileSize);

        for (int x = 0; x < sizeX; x++) {
            for (int y = 0; y < sizeY; y++) {
                Instantiate(tilePrefab, this.transform);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
