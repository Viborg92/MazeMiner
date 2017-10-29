using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
