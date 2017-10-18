using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

/// <summary>
/// Room finder.
/// Takes in the list of rooms, orders them by area, and returns X amount from biggest to smallest.
/// </summary>
public class RoomFinder : MonoBehaviour
{
    RoomFactory roomfactory;
    //Room room;

    // Use this for initialization
    void Awake()
    {
        roomfactory = gameObject.GetComponent<RoomFactory>();
        // room = gameObject.GetComponent<Room>();
    }

    public IEnumerable<Room> FindTheBiggest(int amountOfRooms)
    {
        return roomfactory.Rooms.OrderByDescending(room => room.area).Take(amountOfRooms);
    }

    public void FindClosestRoom(IEnumerable<Room> selectedRooms, int connectionsPrRoom)
    {
        foreach (Room roomA in selectedRooms)
        {
            List<Room> closest = new List<Room>();
            List<Room> closestA = new List<Room>(selectedRooms);
            closestA.Remove(roomA);
            Vector3 position = roomA.transform.position;
            closest = closestA.OrderBy(roomB => (position - roomB.transform.position).sqrMagnitude).Take(connectionsPrRoom).ToList();
            roomA.ClosestRooms = closest;
        }
    }
}
