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

    // Start is called before the first frame update
    void Start()
    {
        currentMode = Mode.SCAN;
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
}
