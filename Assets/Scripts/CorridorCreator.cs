using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CorridorCreator : MonoBehaviour
{
    [SerializeField,Tooltip("The prefab which is used to make the corridors of")] GameObject Brick;

    public void Maker(List<Room> rooms)
    {
        foreach (Room roomA in rooms)
        {
            float corrX = 0;
            //  float corrY = 0;

            corrX = roomA.transform.position.x - roomA.PathingRoom.transform.position.x;
            // corrY = roomA.transform.position.y - roomA.PathingRoom.transform.position.y ;
            if (roomA.PathingRoom.transform.position.x < 0)
            {
                corrX *= -1;
            }

            for (int x = 0; x < corrX; x++)
            {
                Instantiate(Brick, new Vector3(corrX + x - (roomA.height + roomA.PathingRoom.width) / 2, roomA.transform.position.y, 0), Quaternion.identity);
            }/*
            for (int y = 0; y < corrY; y++)
            {
                
                Instantiate(Brick, new Vector3(corrX, corrY + y - (roomA.width + roomA.PathingRoom.width) / 2, 0), Quaternion.identity);
            }*/
        }
    }
}
                