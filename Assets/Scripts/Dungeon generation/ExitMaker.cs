using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Exit maker.
/// Is given a room within dungeonMaster marks it as the exitroom
/// Choosing a random quad within a room to spwan, then instantiating the exit prefab.
/// </summary>
public class ExitMaker : MonoBehaviour
{
    [SerializeField] GameObject exitshaft;

    public void MineShaft(Room room)
    {
        room.tag = "exitRoom";
        Vector3 exitPos;
        exitPos = room.transform.GetChild(Random.Range(0, room.transform.childCount)).transform.position;
        Instantiate(exitshaft, exitPos, Quaternion.identity);
    }
}
