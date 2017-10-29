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
    public bool isDone = false;

    RoomFactory roomFactory;

    // Use this for initialization
    void Awake()
    {
        roomFactory = GetComponent<RoomFactory>();
    }

    void Update()
    {
        Check();
    }

    public void Check()
    {
        //TODO:Consider if there is a better way to do this.
        if (roomFactory.rooms.All(obj => !obj.moving))
        {
            isDone = true;
            foreach (Room r in roomFactory.rooms)
            {
                r.enabled = false;
            }
            enabled = false;
        }
    }

}

