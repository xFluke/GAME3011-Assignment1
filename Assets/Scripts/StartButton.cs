using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class StartButton : MonoBehaviour
{
    [SerializeField] GameObject minigamePrefab;
    public void StartGame() {
        PrefabUtility.InstantiatePrefab(minigamePrefab);
    }
}
