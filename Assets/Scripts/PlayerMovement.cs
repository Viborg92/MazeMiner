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
    private Vector2 playerInput;
    private Rigidbody2D myRigidbody;

    // Update is called once per frame
    public void Awake()
    {
        myRigidbody = GetComponent<Rigidbody2D>();
    }

    public void Update()
    {
        playerInput = Vector2.zero;
        playerInput.x = Input.GetAxis("Horizontal");
        playerInput.y = Input.GetAxis("Vertical");
    }

    public void FixedUpdate()
    {
        myRigidbody.MovePosition(myRigidbody.position + playerInput * speed * Time.fixedDeltaTime);
    }
}
