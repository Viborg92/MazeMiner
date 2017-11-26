using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSwing : MonoBehaviour
{
    [SerializeField]
    private Rigidbody2D rb2D;
    [SerializeField]
    private float swingSpeed;

    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            Attack();
        }
    }

    void Attack()
    {
        rb2D.MoveRotation(rb2D.rotation + swingSpeed * Time.fixedDeltaTime);
    }

}
