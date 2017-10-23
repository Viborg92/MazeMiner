using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

/// <summary>
/// Dungeon master.
/// Applies and uses all other functions to generate and setup the map.
/// </summary>
public class DungeonMaster : MonoBehaviour
{
    [SerializeField, Tooltip("The total amount of rooms being spawned")] int numOfRoomsToSpwan = 20;
    [SerializeField, Tooltip("The amount of biggest rooms that should be kept")] int numOfRoomsToKeep = 10;
    [SerializeField, Tooltip("The amount of connections pr. room")] int connectionPrRoom = 2;
    List<Room> biggestRooms;
    private bool routeFound = false;

    RoomFactory roomfactory;
    NormalDistribution normaldistribution;
    RoomFinder roomfinder;
    RouteMaker routemaker;
    RoomMoveChecker roommovechecker;
    CorridorCreator corridorcreator;

    // Use this for initialization
    void Awake()
    {
        roomfactory = GetComponent<RoomFactory>();
        normaldistribution = GetComponent<NormalDistribution>();
        roomfinder = GetComponent<RoomFinder>();
        routemaker = GetComponent<RouteMaker>();
        roommovechecker = GetComponent<RoomMoveChecker>();
        corridorcreator = GetComponent<CorridorCreator>();
    }

    public void Start()
    {
        MineMaker();
        biggestRooms = roomfinder.FindTheBiggest(numOfRoomsToKeep).ToList();

    }

    public void Update()
    {
        if (roommovechecker.isDone && !routeFound)
        {
            ClosestAndRoute();
        }
    }

    void ClosestAndRoute()
    {
        roomfinder.FindClosestRoom(biggestRooms, connectionPrRoom);
        routemaker.ChooseRoute(biggestRooms[Random.Range(0, biggestRooms.Count)]);
        corridorcreator.Maker(routemaker.PathList);
        routeFound = true;
    }


    void MineMaker()
    {
        for (int i = 0; i < numOfRoomsToSpwan; i++)
        {
            roomfactory.Generate(normaldistribution.Gaussian(), normaldistribution.Gaussian(), Random.Range(-25, 25), Random.Range(-25, 25));
        }
    }
}
=======
﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

/// <summary>
/// Dungeon master.
/// Applies and uses all other functions to generate and setup the map.
/// </summary>
public class DungeonMaster : MonoBehaviour
{
    [SerializeField, Tooltip("The total amount of rooms being spawned")] int numOfRoomsToSpwan = 20;
    [SerializeField, Tooltip("The amount of biggest rooms that should be kept")] int numOfRoomsToKeep = 10;
    [SerializeField, Tooltip("The amount of connections pr. room")] int connectionPrRoom = 2;
    List<Room> biggestRooms;
    public bool isDoneMoving;


    RoomFactory roomfactory;
    NormalDistribution normaldistribution;
    RoomFinder roomfinder;
    RouteMaker routemaker;
    // Use this for initialization
    void Awake()
    {
        roomfactory = GetComponent<RoomFactory>();
        normaldistribution = GetComponent<NormalDistribution>();
        roomfinder = GetComponent<RoomFinder>();
        routemaker = GetComponent<RouteMaker>();
    }

    public void Start()
    {
        isDoneMoving = false;
        MineMaker();
        biggestRooms = roomfinder.FindTheBiggest(numOfRoomsToKeep).ToList();
    }

    public void Update()
    {
        if (!isDoneMoving)
        {
            RoomMoveChecker();
        }
    }

    void RoomMoveChecker()
    {
        if (roomfactory.rooms.All(obj => !obj.moving))
        {
            isDoneMoving = true;
            roomfinder.FindClosestRoom(biggestRooms, connectionPrRoom);
            routemaker.ChooseRoute(biggestRooms[Random.Range(0, biggestRooms.Count)]);
        }
    }


    void MineMaker()
    {
        for (int i = 0; i < numOfRoomsToSpwan; i++)
        {
            roomfactory.Generate(normaldistribution.Gaussian(), normaldistribution.Gaussian(), Random.Range(-25, 25), Random.Range(-25, 25));
        }
    }
}
>>>>>>> Stashed changes
