using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UponExit : MonoBehaviour
{
    DungeonJanitor dungeonJanitor;

    void Awake()
    {
        dungeonJanitor = gameObject.GetComponent<DungeonJanitor>();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player" && other.GetType() == typeof(BoxCollider2D))
        {
            Debug.Log("We in");
            dungeonJanitor.ClearDungeon();
            Destroy(gameObject);
            Destroy(this);
        }
       
    }
}
