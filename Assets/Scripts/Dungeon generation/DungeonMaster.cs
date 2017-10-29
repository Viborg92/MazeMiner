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
    private float startTime;

    List<Room> biggestRooms;
    RoomFactory roomFactory;
    NormalDistribution normalDistribution;
    RoomFinder roomFinder;
    RouteMaker routeMaker;
    RoomMoveChecker roomMoveChecker;
    CorridorCreator corridorCreator;
    WallMaker wallMaker;
    PlayerManager playerManager;
    CameraBehavior cameraBehavior;
    ExitMaker exitmaker;

    // Use this for initialization
    void Awake()
    {
        roomFactory = GetComponent<RoomFactory>();
        normalDistribution = GetComponent<NormalDistribution>();
        roomFinder = GetComponent<RoomFinder>();
        routeMaker = GetComponent<RouteMaker>();
        roomMoveChecker = GetComponent<RoomMoveChecker>();
        corridorCreator = GetComponent<CorridorCreator>();
        wallMaker = GetComponent<WallMaker>();
        playerManager = GetComponent<PlayerManager>();
        cameraBehavior = Camera.main.GetComponent<CameraBehavior>();
        exitmaker = GetComponent<ExitMaker>();
    }

    public void Start()
    {
        startTime = Time.time;
        MineMaker();
        biggestRooms = roomFinder.FindTheBiggest(numOfRoomsToKeep).ToList();

    }

    public void Update()
    {
        if (roomMoveChecker.isDone)
        {
            ClosestAndRoute();
        }
    }

    void ClosestAndRoute()
    {
        enabled = false; 
        roomFinder.FindClosestRoom(biggestRooms, connectionPrRoom);
        routeMaker.ChooseRoute(biggestRooms[Random.Range(0, biggestRooms.Count)]);
        corridorCreator.Maker(routeMaker.PathList);
        outerBounds = roomFinder.FindMinAndMax();
        wallMaker.Mason(outerBounds);
        print("Dungeon Generation Finished In: <color=green>" + (Time.time - startTime) + "</color>");
        exitmaker.MineShaft(biggestRooms[Random.Range(0, biggestRooms.Count)]);
        playerManager.spwanPlayer(biggestRooms);
        cameraBehavior.enabled = true;
    }

    void MineMaker()
    {
        for (int i = 0; i < numOfRoomsToSpwan; i++)
        {
            roomFactory.Generate(normalDistribution.Gaussian(), normalDistribution.Gaussian(), Random.Range(-25, 25), Random.Range(-25, 25));
        }
    }
}