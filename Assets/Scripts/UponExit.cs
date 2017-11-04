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
            Debug.Log("We got inside the loop");
            dungeonJanitor.ClearDungeon();
            Debug.Log("After the function call");
            Destroy(gameObject);
            Destroy(this);
        }
       
    }
}
