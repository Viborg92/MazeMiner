using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Dungeon master.
/// Applies and uses all other functions to generate and setup the map.
/// </summary>
public class DungeonMaster : MonoBehaviour
{
    [SerializeField, Tooltip("The total amount of rooms being spawned")] int numOfRoomsToSpwan = 20;
    [SerializeField, Tooltip("The amount of biggest rooms that should be kept")] int numOfRoomsToKeep = 10;
    [SerializeField, Tooltip("The amount of connections pr. room")] int connectionPrRoom = 2;

    RoomFactory roomfactory;
    NormalDistribution normaldistribution;
    RoomFinder roomfinder;
    // Use this for initialization
    void Awake()
    {
        roomfactory = gameObject.GetComponent<RoomFactory>();
        normaldistribution = gameObject.GetComponent<NormalDistribution>();
        roomfinder = gameObject.GetComponent<RoomFinder>();
    }

    public void Start()
    {
        MineMaker();
        roomfinder.FindClosestRoom(roomfinder.FindTheBiggest(numOfRoomsToKeep), connectionPrRoom);
    }

    void MineMaker()
    {
        for (int i = 0; i < numOfRoomsToSpwan; i++)
        {
            roomfactory.Generate(normaldistribution.Gaussian(), normaldistribution.Gaussian(), Random.Range(-25, 25), Random.Range(-25, 25));
        }
    }
}
