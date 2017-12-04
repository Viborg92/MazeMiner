using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Base enemy behavior context.
/// The base class for all enemies, with the most general variables
/// And functiones needed.
/// </summary>
public class BaseEnemyBehaviorContext : MonoBehaviour
{
    [SerializeField, Tooltip("The health of the enemy")]
    protected float Health = 5;
    [SerializeField, Tooltip("The players position")]
    protected Transform playerPostion;
    [SerializeField, Tooltip("The attack of the enemy")]
    protected float attackPower = 2;
    [SerializeField, Tooltip("Movement speed of a enemy")]
    protected float movementSpeed = 5;

    protected virtual void Awake()
    {
        playerPostion = GameObject.Find("Player").transform;
    }
}
