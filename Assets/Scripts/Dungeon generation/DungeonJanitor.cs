using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DungeonJanitor : MonoBehaviour
{
    [SerializeField] GameObject[] parentObjs;

    public void ClearDungeon()
    {
        Debug.Log("Called the script");
        foreach (GameObject item in parentObjs)
        {
            foreach (Transform child in item.transform)
            {
                Destroy(this);
                break;
            }
        }
    }
}
