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
    [SerializeField]private Collider2D[] intersectingRooms = new Collider2D[20];
    public int width, height;
    public bool moving = true;
    public Vector3 sepVector;
    public List<Room> roomsByDistance = new List<Room>();
    public Room linkingRoom;
    public BoxCollider2D col;

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
        //TODO: Make iterations instead of calling from update.
        Separate();
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
        if (intersectingRooms.Length > 1 && sepVector == Vector3.zero)
        {
            sepVector = (transform.position - Vector3.zero).normalized * Random.Range(-1, 1);
            transform.Translate(sepVector);
        }
    }
}