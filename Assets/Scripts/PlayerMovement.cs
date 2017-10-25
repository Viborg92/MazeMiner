using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Player movement.
/// uses the players rigid to move around the player.
/// </summary>

public class PlayerMovement : MonoBehaviour
{
    [SerializeField, Tooltip("The a multipler for the players movement")]float speed = 5;
    private Rigidbody2D myrigidbody;
    private Vector2 playerInput;

    // Update is called once per frame
    public void Awake()
    {
        myrigidbody = GetComponent<Rigidbody2D>();
    }

    public void Update()
    {
        playerInput = Vector2.zero;
        playerInput.x = Input.GetAxis("Horizontal");
        playerInput.y = Input.GetAxis("Vertical");
    }

    public void FixedUpdate()
    {
        myrigidbody.MovePosition(myrigidbody.position + playerInput * speed * Time.fixedDeltaTime);
    }
}
