using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum Mode
{
    SCAN,
    EXTRACT
}

public class GameManager : MonoBehaviour
{
    Mode currentMode;

    [SerializeField] Text modeDisplayText;

    public const int MAXPOINTS = 8;
    
    [SerializeField] int numOfMaxPointTiles;
    [SerializeField] int maxScans;
    [SerializeField] int currentNumberOfScans;

    [SerializeField] Text messageBar;

    public bool scanningDisabled;

    // Start is called before the first frame update
    void Start()
    {
        currentMode = Mode.SCAN;
        currentNumberOfScans = 0;
        scanningDisabled = false;
    }

    public void ToggleMode() {
        if (currentMode == Mode.SCAN) {
            currentMode = Mode.EXTRACT;
            modeDisplayText.text = "Current Mode: Extract";
        }
        else {
            currentMode = Mode.SCAN;
            modeDisplayText.text = "Current Mode: Scan";
        }
    }

    public Mode GetMode() {
        return currentMode;
    }

    public int GetNumOfMaxPointTiles() {
        return numOfMaxPointTiles;
    }

    public void IncrementCurrentNumberOfScans() {
        currentNumberOfScans++;

        if (currentNumberOfScans >= maxScans) {
            scanningDisabled = true;
            messageBar.text = "Used up all scans!";
           
        }
        else {
            messageBar.text = "Number of scans left: " + (maxScans - currentNumberOfScans);
        }
    }
}
