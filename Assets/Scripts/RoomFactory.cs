using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Room factory.
/// Creates a new room of size X and Y
/// At postions X and Y.
/// </summary>

public class RoomFactory : MonoBehaviour
{
    [SerializeField, Tooltip("The Quad prefab")] GameObject block;
    [SerializeField, Tooltip("The Room prefab")] GameObject aRoom;

    private float corretX, corretY;

    public void Generate(int xSize, int ySize, int xPos, int yPos)
    {
        GameObject newRoom = Instantiate(aRoom, new Vector3(xPos, yPos, 0), Quaternion.identity);
        for (int y = 0; y <= ySize; y++)
        {
            corretY = newRoom.transform.position.y + y - ySize / 2f;
            for (int x = 0; x <= xSize; x++)
            {
                corretX = newRoom.transform.position.x + x - xSize / 2f;
                GameObject newBlock = Instantiate(block, new Vector3(corretX, corretY, 0f), Quaternion.identity);
                newBlock.transform.parent = newRoom.transform;
            }
        }
        Room thisRoom = newRoom.GetComponent<Room>();
        thisRoom.height = ySize;
        thisRoom.width = xSize;
    }
}
