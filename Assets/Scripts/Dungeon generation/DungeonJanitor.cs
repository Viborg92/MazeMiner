using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DungeonJanitor : MonoBehaviour
{
    [SerializeField] GameObject[] parentObjs;

    public void ClearDungeon()
    {
        for (int i = 0; i < parentObjs.Length; i++)
        {
            int childs = parentObjs[i].transform.childCount;
            for (int j = 0; j < childs; j++)
            {
                Destroy(parentObjs[i].transform.GetChild(j).gameObject.transform);
            }
        }
    }
}
