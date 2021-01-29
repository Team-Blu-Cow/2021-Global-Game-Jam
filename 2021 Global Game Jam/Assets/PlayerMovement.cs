using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public float moveSpeed = 5.0f;
    public Rigidbody2D rb;
    public InputManager controls;

    Vector2 movement;

    private void Awake()
    {
        controls.Player.Movement.performed += ctx => Move();
    }

    // Update is called once per frame
    void Update()
    {
        // Input

        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");
    }

    void FixedUpdate()
    {
        // Movement
        //rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
        rb.AddForce(movement * moveSpeed * Time.fixedDeltaTime);
    }

    void Move()
    {

    }

}
