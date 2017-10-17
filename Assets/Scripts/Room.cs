using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[SelectionBase]
public class Room : MonoBehaviour
{
    public int width, height, area;
    public Vector3 sepVector;
    public Vector3 previousPos;
    public bool RoundedPos = false;
    [SerializeField] Collider2D[] intersectingRooms = new Collider2D[20];
    BoxCollider2D col;

    public void Awake()
    {
        col = GetComponent<BoxCollider2D>();
    }

    public void Start()
    {
        area = width * height;
        SetCollier();
    }

    public void Update()
    {
        Separate();
    }

    public void SetCollier()
    {
        col.size = new Vector2(width, height);
    }

    public void Separate()
    {
        sepVector = Vector3.zero;
  
        if (intersectingRooms.Length == 1)
        {
            transform.position = new Vector3(Mathf.Round(transform.position.x), Mathf.Round(transform.position.y), Mathf.Round(transform.position.z));
            RoundedPos = true;
        }

        intersectingRooms = Physics2D.OverlapBoxAll(transform.position, col.size - Vector2.one, 0);

        foreach (Collider2D col in intersectingRooms)
        {
            if (col != this.col)
            {
                sepVector += col.transform.position - transform.position;
            }
        }

        sepVector *= -1;
        sepVector.Normalize();
        float x = (sepVector.x > 0) ? Mathf.Ceil(sepVector.x) : Mathf.Floor(sepVector.x);
        float y = (sepVector.y > 0) ? Mathf.Ceil(sepVector.y) : Mathf.Floor(sepVector.y);
        sepVector = new Vector3(x, y, sepVector.z);
        transform.Translate(sepVector);

        if (intersectingRooms.Length != 1 && RoundedPos == true)
        {
            RoundedPos = false;
            transform.Translate(transform.position.normalized);
        }
    }
}
