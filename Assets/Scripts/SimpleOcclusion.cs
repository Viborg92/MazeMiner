using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Simple occlusion.
/// looks at all of the triggers and colliers around the player and renderers them if they are close.
/// </summary>
public class SimpleOcclusion : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other)
    {
        MeshRenderer[] renders = other.gameObject.GetComponentsInChildren<MeshRenderer>();
        foreach (var render in renders)
        {
            render.enabled = true;
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        MeshRenderer[] renders = other.gameObject.GetComponentsInChildren<MeshRenderer>();
        foreach (var render in renders)
        {
            render.enabled = false;
        }
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        MeshRenderer[] renders = other.gameObject.GetComponentsInChildren<MeshRenderer>();
        foreach (var render in renders)
        {
            render.enabled = true;
        }
    }

    void OnCollisionExit2D(Collision2D other)
    {
        MeshRenderer[] renders = other.gameObject.GetComponentsInChildren<MeshRenderer>();
        foreach (var render in renders)
        {
            render.enabled = false;
        }
    }
}
