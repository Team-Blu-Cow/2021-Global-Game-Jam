using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    private float moveSpeed = 30.0f;
    public float hullHealth = 100.0f;

    public Rigidbody2D rb;

    public InputManager controls;

    Vector2 movement;
    Vector2 drag;
    float rotation;

    bool clawMode = false;

    private void Awake()
    {
        controls = new InputManager();
        controls.Player.Movement.performed += ctx => OnMove(ctx.ReadValue<Vector2>());
        controls.Player.Movement.canceled += ctx => OnStopMove(ctx.ReadValue<Vector2>());
        controls.Player.Claw.started += ctx => OnEnteringClawMode();
    }

    private void OnEnable()
    {
        controls.Enable();
    }

    private void OnDisable()
    {
        controls.Disable();
    }

    void FixedUpdate()
    {
        drag = -rb.velocity * 0.5f;

        if (clawMode == false)
        {          
            rb.AddForce((movement * moveSpeed * Time.fixedDeltaTime) + drag);
            rb.SetRotation(rotation);
        }
        else 
        {
            rb.AddForce(drag);
        }
    }

    void OnMove(Vector2 direction)
    {
        movement = direction;
    }

    void OnStopMove(Vector2 direction)
    {
        movement = direction;
    }

    void OnEnteringClawMode()
    {
        clawMode = !clawMode;
    }
}
