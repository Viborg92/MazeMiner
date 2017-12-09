using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Player health context.
/// Holds the health of the player.
/// And is placed on the player prefab.
/// </summary>
public class PlayerHealthContext : MonoBehaviour
{
    [SerializeField, Tooltip("The max Health points of the player")]
    public static int health = 20;
}
