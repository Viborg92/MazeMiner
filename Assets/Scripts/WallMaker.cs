using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Wall maker.
/// The mason functions used the Max and min to create walls around the mine.
/// </summary>
public class WallMaker : MonoBehaviour
{
    [SerializeField, Tooltip("The prefab used")] GameObject Wall;
    [SerializeField, Tooltip("The Wall parent prefab")] GameObject dungeon;


    public void Mason(float[,] size)
    {
        int maxX = (int)size[0, 0] + 2;
        int minX = (int)size[0, 1] - 2;
        int maxY = (int)size[1, 0] + 2;
        int minY = (int)size[1, 1] - 2;

        for (int x = minX; x < maxX; x++)
        {
            for (int y = minY; y < maxY; y++)
            {
                Vector3 pos = new Vector3(x - 0.5f, y - 0.5f, 0);
                if (!Physics2D.OverlapPoint(pos))
                {
                    GameObject newWall = Instantiate(Wall, pos, Quaternion.identity);
                    newWall.transform.parent = dungeon.transform;
                }

            }
        }

    }
}
