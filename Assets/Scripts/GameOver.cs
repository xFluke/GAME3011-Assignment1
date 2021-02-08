using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEditor;

public class GameOver : MonoBehaviour
{
    [SerializeField] Text pointsCounter;

    public void SetPoints(int p) {
        pointsCounter.text = "Points: " + p.ToString();
    }

    public void Replay() {
        Destroy(transform.parent.gameObject);

        GameObject minigame = Instantiate(Resources.Load("TileBasedMinigame")) as GameObject;

    }

    public void Quit() {
        Application.Quit();
        EditorApplication.isPlaying = false;
    }
}
