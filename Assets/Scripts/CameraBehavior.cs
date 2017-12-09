using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Camera behavior.
/// Looks for the target with smooth movement.
/// </summary>
public class CameraBehavior : MonoBehaviour
{
    public GameObject target;
    [SerializeField, Tooltip("The damping effect on the camera.")] float dampTime = 0.15f;
    private Vector3 velocity = Vector3.zero;
    private Camera mycamera;

    void Awake()
    {
        mycamera = GetComponent<Camera>();
        enabled = false;
    }

    void Update()
    {
        if (target)
        {
            Vector3 point = mycamera.WorldToViewportPoint(target.transform.position);
            Vector3 delta = target.transform.position - mycamera.ViewportToWorldPoint(new Vector3(0.5f, 0.5f, point.z));
            Vector3 destinaion = transform.position + delta;
            transform.position = Vector3.SmoothDamp(transform.position, destinaion, ref velocity, dampTime);
        }
    }
}
