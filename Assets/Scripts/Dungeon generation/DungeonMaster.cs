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
    public float[,] outerBounds = new float[2, 2];
    private float startTime;

    public List<Room> biggestRooms;
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
        Initialization();
    }

    public void Update()
    {
        if (roomMoveChecker.isDone)
        {
            DungeonAndPlayerSetup();
        }
    }

    public void Initialization()
    {
        roomFactory.rooms.Clear();
        startTime = 0;
        startTime = Time.time;
        for (int i = 0; i < numOfRoomsToSpwan; i++)
        {
            roomFactory.Generate(normalDistribution.Gaussian(), normalDistribution.Gaussian(), Random.Range(-25, 25), Random.Range(-25, 25));
        }
        biggestRooms = new List<Room>(roomFinder.FindTheBiggest(numOfRoomsToKeep).ToList());
    }

    void DungeonAndPlayerSetup()
    {
        enabled = false; 
        roomFinder.FindClosestRoom(biggestRooms, numOfRoomsToKeep);
        routeMaker.ChooseRoute(biggestRooms[Random.Range(0, biggestRooms.Count)]);
        corridorCreator.Maker(routeMaker.PathList);
        outerBounds = roomFinder.FindMinAndMax();
        wallMaker.Mason(outerBounds);
        print("Dungeon Generation Finished In: <color=green>" + (Time.time - startTime) + "</color>");
        exitmaker.MineShaft(biggestRooms[Random.Range(0, biggestRooms.Count)]);
        playerManager.spwanPlayer(biggestRooms);
        cameraBehavior.enabled = true;
    }
}