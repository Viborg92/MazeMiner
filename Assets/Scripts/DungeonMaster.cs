using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Dungeon master.
/// Applies and uses all other functions to generate and setup the map.
/// </summary>
public class DungeonMaster : MonoBehaviour
{
    [SerializeField, Tooltip("The total amount of rooms being spawned")] int NumOfRoomsToSpwan = 20;
    RoomFactory roomfactory;
    NormalDistribution normaldistribution;
    // Use this for initialization
    void Awake()
    {
        roomfactory = gameObject.GetComponent<RoomFactory>();
        normaldistribution = gameObject.GetComponent<NormalDistribution>();
    }

    public void Start()
    {
        MineMaker();
    }

    void MineMaker()
    {
        for (int i = 0; i < NumOfRoomsToSpwan; i++)
        {
            roomfactory.Generate(normaldistribution.Gaussian(), normaldistribution.Gaussian(), Random.Range(-25, 25), Random.Range(-25, 25));
        }
    }
}
