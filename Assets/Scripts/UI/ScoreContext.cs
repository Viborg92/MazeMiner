using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreContext : MonoBehaviour
{
    [SerializeField]
    Text floor;

    void Awake()
    {
        string currentFloor = PlayerPrefs.GetInt("Floor", 0).ToString();
        floor.text = "Current Floor: " + currentFloor.ToString();
    }
}
