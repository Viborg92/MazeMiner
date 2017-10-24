using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Corridor creator.
/// Takes in a list of rooms that has a pathing room
/// finds the postions to it different from the room it looks at
/// then makes a corridor depending on its postion.
/// </summary>
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

            float horizontalOffset = 0;
            float verticalOffset = 0;
            int horizontal = (corrX > 0) ? right : left; 
            int vertical = (corrY > 0) ? up : down;

            //Look if the room is within the height of the pathing room.
            if (Mathf.Abs(corrY) <= roomA.PathingRoom.height / 2)
            {
                //Adjust the corrX with the offset depending on if X is negative or postive.
                corrX += (corrX > 0) ? -(roomA.PathingRoom.width / 2) : (roomA.PathingRoom.width / 2);
                //Setting corrY to Y as we don't need to build in Y then.
                corrY = 0;
            }

            if (Mathf.Abs(corrX) <= roomA.width / 2)
            {
                //looking if the other room is within the width of the roomA.
                verticalOffset += (corrY > 0) ? -roomA.height / 2 : roomA.height / 2;
                corrY += verticalOffset;
                horizontalOffset = corrX - horizontal;
                corrX = 0;
            }
            if (corrX != 0)
            {
                if (roomA.transform.position.x < roomA.PathingRoom.transform.position.x)
                {
                    horizontalOffset = (roomA.width) / 2f;
                    corrX -= (roomA.width) / 2;
                    for (int x = 0; x < corrX; x++)
                    {
                        GameObject XCorr = Instantiate(Brick, new Vector3((x + roomA.transform.position.x) + horizontalOffset + 0.5f * horizontal,
                                               roomA.transform.position.y + .5f * vertical, 0), Quaternion.identity);
                        XCorr.transform.parent = roomA.transform;
                    }
                }
                else
                {
                    horizontalOffset = -(roomA.width) / 2f;
                    corrX += (roomA.width) / 2;
                    for (int x = 0; x > corrX; x--)
                    {
                        GameObject XCorr = Instantiate(Brick, new Vector3((x + roomA.transform.position.x) + horizontalOffset + 0.5f * horizontal,
                                               roomA.transform.position.y + .5f * vertical, 0), Quaternion.identity);
                        XCorr.transform.parent = roomA.transform;
                    }
                
                }
            }

            if (roomA.transform.position.y < roomA.PathingRoom.transform.position.y)
            {
                if (corrX == 0)
                {
                    verticalOffset = (roomA.height) / 2f;
                }
              
                corrY -= (roomA.PathingRoom.height) / 2;
                for (int y = 0; y < corrY; y++)
                {
                    GameObject YCorr = Instantiate(Brick, new Vector3(roomA.transform.position.x + corrX + horizontalOffset + 0.5f * horizontal,
                                           y + roomA.transform.position.y + (.5f + verticalOffset) * vertical, 0), Quaternion.identity);
                    YCorr.transform.parent = roomA.transform;
                }
            }
            else
            {
                if (corrX == 0)
                {
                    verticalOffset = (roomA.height) / 2f;
                }
                corrY += (roomA.PathingRoom.height) / 2;
                for (int y = 0; y > corrY; y--)
                {
                    GameObject YCorr = Instantiate(Brick, new Vector3(roomA.transform.position.x + corrX + horizontalOffset + 0.5f * horizontal,
                                           y + roomA.transform.position.y + (.5f + verticalOffset) * vertical, 0), Quaternion.identity);
                    YCorr.transform.parent = roomA.transform;
                }
            }
            roomA.corrX = corrX;
            roomA.corrY = corrY;
        }
    }
}