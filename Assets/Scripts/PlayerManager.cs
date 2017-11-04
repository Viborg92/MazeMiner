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

    CameraBehavior cameraBehavior;

    public void Awake()
    {
        cameraBehavior = Camera.main.GetComponent<CameraBehavior>();
    }


    public void spwanPlayer(List<Room> rooms)
    {
        Room spwaningRoom;

        spwaningRoom = rooms[Random.Range(0, rooms.Count)];
        if (spwaningRoom.tag == "exitRoom")
        {
            spwaningRoom = rooms[Random.Range(0, rooms.Count)];
        }
        else
        {
            Vector3 pos = spwaningRoom.transform.position;
            pos.z = -1;
            GameObject newPlayer = Instantiate(player, pos, Quaternion.identity);
            cameraBehavior.target = newPlayer;
            newPlayer.SetActive(true);
        }
    }
}
