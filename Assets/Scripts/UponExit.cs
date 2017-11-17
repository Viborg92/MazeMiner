using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// Upon exit. Is placed on the Exit prefab,
/// Increases the floor count, and reloads the level for the player.
/// </summary>
public class UponExit : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player" && other.GetType() == typeof(BoxCollider2D))
        {
            int currentFloor;
            currentFloor = PlayerPrefs.GetInt("Floor", 0);
            currentFloor++;
            PlayerPrefs.SetInt("Floor", currentFloor);

            SceneManager.LoadScene("TesteScene 1.0");
        }
    }
}
