using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RouteMaker : MonoBehaviour
{
    public List<Room> PathList = new List<Room>();

    public void ChooseRoute(Room room)
    {
        PathList.Add(room);
        int count = 0;
        room.tag = "SelectedRoom";
        foreach (Room r in room.closestRooms)
        {
            if (r.tag != "SelectedRoom")
            {
                room.PathingRoom = r;
                ChooseRoute(r);
            }
            count++;
            if (count > r.closestRooms.Count)
            {
                return;
            }
        }
    }
}
