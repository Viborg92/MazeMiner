using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System;

/// <summary>
/// Room finder.
/// FindTheBiggest orders the rooms list by area, and returns X amount from biggest to smallest.
/// FindClosestRoom loops through all rooms, and gives them a list X amount of rooms closest too them.
/// FindMinAndMax, looks at all rooms to find the room placed at repectlivly max X, Y and min X and Y.
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

    public float[,] FindMinAndMax()
    {
        Room maxX, minX, maxY, minY;
        float[,] minMax = new float[2, 2];

        maxX = roomfactory.rooms.OrderByDescending(room => room.transform.position.x + room.width / 2f).First();
        minMax[0, 0] = maxX.transform.position.x + maxX.width / 2f;

        minX = roomfactory.rooms.OrderBy(room => room.transform.position.x - room.width / 2f).First();
        minMax[0, 1] = minX.transform.position.x - minX.width / 2f;

        maxY = roomfactory.rooms.OrderByDescending(room => room.transform.position.y + room.height / 2f).First();
        minMax[1, 0] = maxY.transform.position.y + maxY.height / 2f;

        minY = roomfactory.rooms.OrderBy(room => room.transform.position.y - room.height / 2f).First();
        minMax[1, 1] = minY.transform.position.y - minY.height / 2f; 

        return minMax;
    }
}
