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
    public float[,] outerBounds = new float[2, 2];
    List<Room> biggestRooms;

    RoomFactory roomfactory;
    NormalDistribution normaldistribution;
    RoomFinder roomfinder;
    RouteMaker routemaker;
    RoomMoveChecker roommovechecker;
    CorridorCreator corridorcreator;
    WallMaker wallmaker;
    PlayerManager playermanager;
    CameraBehavior camerabehavior;

    private float StartTime;

    // Use this for initialization
    void Awake()
    {
        roomfactory = GetComponent<RoomFactory>();
        normaldistribution = GetComponent<NormalDistribution>();
        roomfinder = GetComponent<RoomFinder>();
        routemaker = GetComponent<RouteMaker>();
        roommovechecker = GetComponent<RoomMoveChecker>();
        corridorcreator = GetComponent<CorridorCreator>();
        wallmaker = GetComponent<WallMaker>();
        playermanager = GetComponent<PlayerManager>();
        camerabehavior = Camera.main.GetComponent<CameraBehavior>();
    }

    public void Start()
    {
        StartTime = Time.time;
        MineMaker();
        biggestRooms = roomfinder.FindTheBiggest(numOfRoomsToKeep).ToList();

    }

    public void Update()
    {
        if (roommovechecker.isDone)
        {
            ClosestAndRoute();
        }
    }

    void ClosestAndRoute()
    {
        enabled = false; 
        roomfinder.FindClosestRoom(biggestRooms, connectionPrRoom);
        routemaker.ChooseRoute(biggestRooms[Random.Range(0, biggestRooms.Count)]);
        corridorcreator.Maker(routemaker.PathList);
        outerBounds = roomfinder.FindMinAndMax();
        wallmaker.Mason(outerBounds);
        print("Dungeon Generation Finished In: <color=green>" + (Time.time - StartTime) + "</color>");
        playermanager.spwanPlayer(biggestRooms[Random.Range(0, biggestRooms.Count)].transform.position);
        camerabehavior.enabled = true;
    }


    void MineMaker()
    {
        for (int i = 0; i < numOfRoomsToSpwan; i++)
        {
            roomfactory.Generate(normaldistribution.Gaussian(), normaldistribution.Gaussian(), Random.Range(-25, 25), Random.Range(-25, 25));
        }
    }
}