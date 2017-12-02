using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Hit checking context.
/// Place on the weapon of the playerprefab
/// And checks and handles the subtraction of life
/// Or the destruction of breakable objects.
/// </summary>
public class HitCheckingContext : MonoBehaviour
{
    [SerializeField, Tooltip("The collider of the pickaxe")]
    private Collider2D pickAxeCollider;
    [SerializeField, Tooltip("The attack power of the players attack.")]
    private float attackPower = 5;

    void OnTriggerEnter(Collider col)
    {
        switch (col.gameObject.tag)
        {
            case "Enemy":
                //TODO: Subtract this enemys life points by the 
                break;
            default:
                break;
        }
    }
}