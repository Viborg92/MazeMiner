using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

/// <summary>
/// Room move checker.
/// The check loops through all rooms to see if any are moving
/// Returns true and disables itself when the rooms are done moving around.
/// </summary>
public class RoomMoveChecker : MonoBehaviour
{
    RoomFactory roomfactory;
    public bool isDone = false;
    public bool StopLoop = false;
    // Use this for initialization
    void Awake()
    {
        roomfactory = GetComponent<RoomFactory>();
    }

    void Update()
    {
        Check();
    }

    public void Check()
    {
        if (roomfactory.rooms.All(obj => !obj.moving))
        {
            isDone = true;
            foreach (Room r in roomfactory.rooms)
            {
                r.enabled = false;
            }
            enabled = false;
        }
    }

}

