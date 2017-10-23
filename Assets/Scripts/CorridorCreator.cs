using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CorridorCreator : MonoBehaviour
{
    [SerializeField,Tooltip("The prefab which is used to make the corridors of")] GameObject Brick;
    private int right = 1;
    private int left = -1;
    private int up = 1;
    private int down = -1;

    public void Maker(List<Room> rooms)
    {
        foreach (Room roomA in rooms)
        {
            if (roomA.PathingRoom == null)
            {
                continue;
            }
            float corrX = 0;
            float corrY = 0;

            corrX = (roomA.PathingRoom.transform.position.x - roomA.transform.position.x);
            corrY = (roomA.PathingRoom.transform.position.y - roomA.transform.position.y);

            float roomOffset = 0;

            if (corrY < roomA.PathingRoom.height / 2)
            {
                if (corrX > 0)
                {
                    corrX -= roomA.PathingRoom.width / 2;
                }
                else
                {
                    corrX += roomA.PathingRoom.width / 2;
                }
            }
            if (Mathf.Abs(corrX) < roomA.width / 2)
            {
                corrX = 0;
            }

            int horizontal = (corrX > 0) ? right : left; 
            int vertical = (corrY > 0) ? up : down;

            if (roomA.transform.position.x < roomA.PathingRoom.transform.position.x)
            {
                roomOffset = (roomA.width) / 2f;
                corrX -= (roomA.width) / 2;
                for (int x = 0; x < corrX; x++)
                {
                    GameObject XCorr = Instantiate(Brick, new Vector3((x + roomA.transform.position.x) + roomOffset + 0.5f * horizontal,
                                           roomA.transform.position.y + .5f * vertical, 0), Quaternion.identity);
                    XCorr.transform.parent = roomA.transform;
                }
            }
            else
            {
                roomOffset = -(roomA.width) / 2f;
                corrX += (roomA.width) / 2;
                for (int x = 0; x > corrX; x--)
                {
                    GameObject XCorr = Instantiate(Brick, new Vector3((x + roomA.transform.position.x) + roomOffset + 0.5f * horizontal,
                                           roomA.transform.position.y + .5f * vertical, 0), Quaternion.identity);
                    XCorr.transform.parent = roomA.transform;
                }
                
            }
            if (roomA.transform.position.y < roomA.PathingRoom.transform.position.y)
            {
                corrY -= (roomA.PathingRoom.height) / 2;
                for (int y = 0; y < corrY; y++)
                {
                    GameObject YCorr = Instantiate(Brick, new Vector3(roomA.transform.position.x + corrX + roomOffset + 0.5f * horizontal,
                                           y + roomA.transform.position.y + .5f * vertical, 0), Quaternion.identity);
                    YCorr.transform.parent = roomA.transform;
                }
            }
            else
            {
                corrY += (roomA.PathingRoom.height) / 2;
                for (int y = 0; y > corrY; y--)
                {
                    GameObject YCorr = Instantiate(Brick, new Vector3(roomA.transform.position.x + corrX + roomOffset + .5f * horizontal,
                                           y + roomA.transform.position.y + .5f * vertical, 0), Quaternion.identity);
                    YCorr.transform.parent = roomA.transform;
                }
            }
        }
    }
}