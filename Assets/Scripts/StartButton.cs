using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class StartButton : MonoBehaviour
{
    public void StartGame() {
        GameObject minigame = Instantiate(Resources.Load("TileBasedMinigame")) as GameObject;
    }
}
