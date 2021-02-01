using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Tile : MonoBehaviour, IPointerClickHandler 
{
    [SerializeField] int points;
    [SerializeField] int x;
    [SerializeField] int y;

    // Start is called before the first frame update
    void Start()
    {

    }

    public void RevealPoints() {
        GetComponentInChildren<Text>().text = points.ToString();
    }

    public void SetCoordinate(int _x, int _y) {
        x = _x;
        y = _y;
    }

    public void OnPointerClick(PointerEventData eventData) {
        if (FindObjectOfType<GameManager>().GetMode() == Mode.EXTRACT) {

        }
        else {
            FindObjectOfType<GridManager>().GetSurroundingTiles(this);
            Debug.Log("Clicked on " + GetCoordinate());
        }

    }

    public Vector2Int GetCoordinate() {
        return new Vector2Int(x, y);
    }
}
