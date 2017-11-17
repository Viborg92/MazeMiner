using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Route maker.
/// Creates takes in a list of rooms, which is assumed to have a roomsByDistance assigned in them.
/// It then creates a linked list of the rooms.
/// </summary>
public class RouteMaker : MonoBehaviour
{
    public List<Room> PathList = new List<Room>();

    public void ChooseRoute(Room room)
    {
        PathList.Add(room);
        int count = 0;
        room.tag = "SelectedRoom";
        foreach (Room r in room.roomsByDistance)
        {
            if (r.tag != "SelectedRoom")
            {
                room.linkingRoom = r;
                ChooseRoute(r);
                break;
            }

            count++;
            if (count > r.roomsByDistance.Count)
            {
                return;
            }
        }
    }
}
