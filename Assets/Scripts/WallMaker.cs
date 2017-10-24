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

    public void Mason(float[,] size)
    {
        int maxX = (int)size[0, 0] + 1;
        int minX = (int)size[0, 1] - 1;
        int maxY = (int)size[1, 0] + 1;
        int minY = (int)size[1, 1] - 1;

        for (int x = minX; x < maxX; x++)
        {
            for (int y = minY; y < maxY; y++)
            {
                Instantiate(Wall, new Vector3(x, y, 1), Quaternion.identity);
            }
        }
    }
}
