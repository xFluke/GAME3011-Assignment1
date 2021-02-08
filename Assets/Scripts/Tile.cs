using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Tile : MonoBehaviour, IPointerClickHandler 
{
    [SerializeField] int points = 0;
    [SerializeField] int x;
    [SerializeField] int y;
    [SerializeField] bool revealed = true;
    [SerializeField] Color color = Color.white;

    // Start is called before the first frame update
    void Start()
    {
        if (revealed) {
            GetComponentInChildren<Text>().text = points.ToString();
        }
        else {
            GetComponentInChildren<Text>().text = "";
        }

        GetComponent<Image>().color = color;
    }

    public void SetColor(Color c) {
        color = c;
    }

    public void SetPoints(int p) {
        points = p;
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
            FindObjectOfType<GridManager>().GetSurroundingTiles5x5(this);
            Debug.Log("Clicked on " + GetCoordinate());
        }

    }

    public Vector2Int GetCoordinate() {
        return new Vector2Int(x, y);
    }
}
