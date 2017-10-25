using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
}
