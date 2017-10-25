using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Player manager.
/// Spwans the character and gives the object to the camera.
/// </summary>
public class PlayerManager : MonoBehaviour
{
    [SerializeField, Tooltip("The player prefab")] GameObject player;

    CameraBehavior camerabehavior;

    public void Awake()
    {
        camerabehavior = Camera.main.GetComponent<CameraBehavior>();
    }

    public void spwanPlayer(Vector3 pos)
    {
        pos.z = -1;
        GameObject newPlayer = Instantiate(player, pos, Quaternion.identity);
        camerabehavior.target = newPlayer;
        newPlayer.SetActive(true);
    }
}
