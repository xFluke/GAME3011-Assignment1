using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEditor;

public class GameOver : MonoBehaviour
{
    [SerializeField] Text pointsCounter;
    [SerializeField] GameObject minigamePrefab;


    public void SetPoints(int p) {
        pointsCounter.text = "Points: " + p.ToString();
    }

    public void Replay() {
        //Instantiate(minigamePrefab);
        Instantiate(minigamePrefab);
        Destroy(transform.parent.gameObject);
    }

    public void Quit() {
        Application.Quit();
        EditorApplication.isPlaying = false;
    }
}
