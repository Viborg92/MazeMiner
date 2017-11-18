using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Look at mouse.
/// Finds the mouse positions and calculates, and rorate shte player to look at it.
/// </summary>
public class LookAtMouse : MonoBehaviour
{
    private Vector3 direction;

    // Update is called once per frame
    void Update()
    {
        FindAndRotate();
    }

    void FindAndRotate()
    {
        Vector3 objcetPosition = Camera.main.WorldToScreenPoint(transform.position);
        direction = Input.mousePosition - objcetPosition;
        float RotationDirection = Mathf.Atan2(direction.y, direction.x);
        transform.rotation = Quaternion.Euler(new Vector3(0, 0, RotationDirection * Mathf.Rad2Deg));
    }
}
