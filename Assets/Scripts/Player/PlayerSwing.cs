using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSwing : MonoBehaviour
{
    [SerializeField]
    private GameObject Arm;
    [SerializeField]
    float speed;
    [SerializeField]
    Transform pointA, pointB;
    bool swingLeft = false;

    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            Attack();
        }
    }

    void Attack()
    {
       
        if (swingLeft)
        {
            Arm.transform.LookAt(pointA.transform.position, worldUp: transform.forward);
            swingLeft = true;
        }
        else
        {
            Arm.transform.LookAt(pointB.transform.position, worldUp: transform.forward);
            swingLeft = false;
        }
    }

}
