using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System;

/// <summary>
/// Room finder.
/// FindTheBiggest orders the rooms list by area, and returns X amount from biggest to smallest.
/// FindClosestRoom loops through all rooms, and gives them a list X amount of rooms closest too them.
/// </summary>
public class RoomFinder : MonoBehaviour
{
    RoomFactory roomfactory;

    // Use this for initialization
    void Awake()
    {
        roomfactory = gameObject.GetComponent<RoomFactory>();
    }

    public IEnumerable<Room> FindTheBiggest(int amountOfRooms)
    {
        return roomfactory.rooms.OrderByDescending(room => room.area).Take(amountOfRooms);
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
            roomA.closestRooms = closest;
        }
    }

    public List<Room> FindMinAndMax()
    {
        Room maxX, minX;
        Room maxY, minY;
        List<Room> minMax = new List<Room>();

        maxX = roomfactory.rooms.OrderByDescending(room => room.transform.position.x + room.width / 2f).First();
        minMax.Add(maxX);

        minX = roomfactory.rooms.OrderBy(room => room.transform.position.x - room.width / 2f).First();
        minMax.Add(minX);

        maxY = roomfactory.rooms.OrderByDescending(room => room.transform.position.y + room.height / 2f).First();
        minMax.Add(maxY);

        minY = roomfactory.rooms.OrderBy(room => room.transform.position.y - room.height / 2f).First();
        minMax.Add(minY);

        return minMax;
    }
}
