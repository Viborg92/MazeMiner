using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UponExit : MonoBehaviour
{
    DungeonJanitor dungeonJanitor;
    DungeonMaster dungeonMaster;

    void Start()
    {
        GameObject SceneManager = GameObject.Find("Scene Manager");
        dungeonJanitor = SceneManager.GetComponent<DungeonJanitor>();
        dungeonMaster = SceneManager.GetComponent<DungeonMaster>();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player" && other.GetType() == typeof(BoxCollider2D))
        {
            dungeonJanitor.ClearDungeon();
            Destroy(other.gameObject);
            Destroy(this.gameObject);
            dungeonMaster.Initialization();
            dungeonMaster.enabled = false;
            dungeonMaster.enabled = true;
        }
    }
}
