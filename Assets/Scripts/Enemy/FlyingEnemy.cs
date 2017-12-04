using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// A Flying enemy that flies towards the players
/// And damages the player on collision.
/// </summary>
public class FlyingEnemy : BaseEnemyBehaviorContext
{
    protected override void Awake()
    {
        base.Awake();
    }

    void Update()
    {
        movementTowardsPlayer();
    }

    void movementTowardsPlayer()
    {
        float step = movementSpeed * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, playerPostion.position, step);
    }
}
