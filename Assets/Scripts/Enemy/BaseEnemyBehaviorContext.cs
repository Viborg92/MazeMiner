using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseEnemyBehaviorContext : MonoBehaviour
{
    [SerializeField, Tooltip("The health of the enemy")]
    protected float Health = 5;
    [SerializeField, Tooltip("The players position")]
    protected Transform playerPostion;
}
