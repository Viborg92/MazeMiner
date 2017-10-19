using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Room.
/// Each rooms adjusts its own collider, creates a list of the rooms it collies with
/// And moves away accordingly
/// </summary>
[SelectionBase]
public class Room : MonoBehaviour
{
    public int width, height;
    public Vector3 sepVector;
    public Vector3 previousPos;
    public bool moving = true;
    [SerializeField] Collider2D[] intersectingRooms = new Collider2D[20];
    public List<Room> closestRooms = new List<Room>();
    public Room PathingRoom;
    BoxCollider2D col;


    public int area
    {
        get{ return width * height; }
    }

    public void Awake()
    {
        col = GetComponent<BoxCollider2D>();
    }

    public void Start()
    {
        SetCollier();
    }

    public void Update()
    {
        Separate();
        if (PathingRoom != null)
        {
            Debug.DrawLine(transform.position, PathingRoom.transform.position, Color.white);
        }
    }

    public void SetCollier()
    {
        col.size = new Vector2(width, height);
    }

    public void Separate()
    {
        sepVector = Vector3.zero;


        intersectingRooms = Physics2D.OverlapBoxAll(transform.position, col.size - Vector2.one, 0);

        foreach (Collider2D coll in intersectingRooms)
        {
            if (coll != this.col)
            {
                moving = true;
                sepVector += transform.position - coll.transform.position;
            }
        }

        sepVector.Normalize();
        float x = (sepVector.x > 0) ? Mathf.Ceil(sepVector.x) : Mathf.Floor(sepVector.x);
        float y = (sepVector.y > 0) ? Mathf.Ceil(sepVector.y) : Mathf.Floor(sepVector.y);
        sepVector = new Vector3(x, y, sepVector.z);
        transform.Translate(sepVector);

        if (intersectingRooms.Length == 1)
        {
            transform.position = new Vector3(Mathf.Round(transform.position.x), Mathf.Round(transform.position.y), Mathf.Round(transform.position.z));
            moving = false;
        }
    }
}
