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

    [SerializeField] int maxExtracts;
    [SerializeField] int currentNumberOfExtracts;

    [SerializeField] Text messageBar;
    [SerializeField] Text pointsCounter;

    [SerializeField] GameObject gameOverPanel;

    public bool scanningDisabled { get; private set; }
    public bool extractingDisabled { get; private set; }

    [SerializeField] int points;

    private void OnEnable() {
        gameOverPanel.SetActive(false);
    }

    // Start is called before the first frame update
    void Start()
    {
        currentMode = Mode.SCAN;
        currentNumberOfScans = 0;
        currentNumberOfExtracts = 0;
        scanningDisabled = false;
        extractingDisabled = false;
        points = 0;
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

    public void AddPoints(int p) {
        points += p;
        pointsCounter.text = "Points: " + points;

        currentNumberOfExtracts++;

        if (currentNumberOfExtracts >= maxExtracts) {
            extractingDisabled = true;
            messageBar.text = "Used up all extracts!";
            gameOverPanel.SetActive(true);
            gameOverPanel.GetComponent<GameOver>().SetPoints(points);

        }
        else {
            messageBar.text = "Extracted " + p + " points!";
            messageBar.text += "\nThe surrounding 5x5 area has been damaged by one level!";
            messageBar.text += "\nNumber of extracts left: " + (maxExtracts - currentNumberOfExtracts);
        }
    }
}
