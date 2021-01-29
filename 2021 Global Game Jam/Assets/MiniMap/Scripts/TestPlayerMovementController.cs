using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class TestPlayerMovementController : MonoBehaviour
{
    [Header("Movement Settings")]
    [SerializeField] float moveSpeed = 5f;

    private TestPlayerControls controls;
    Vector2 moveDirection;

    void Awake()
    {
        controls = new TestPlayerControls();
        controls.testplayercontrols.Move.performed += ctx => OnMove(ctx.ReadValue<Vector2>());
        controls.testplayercontrols.Move.canceled += ctx => OnStopMove();
    }
    private void OnEnable()
    {
        controls.Enable();
    }

    private void OnDisable()
    {
        controls.Disable();
    }

    void Update()
    {
        Vector3 movement = new Vector3(0, 0, 0);

        movement = new Vector3(moveDirection.x, moveDirection.y, 0);

        transform.position += movement * Time.deltaTime * moveSpeed;
    }

    void OnMove(Vector2 direction)
    {
        moveDirection = direction;
    }

    void OnStopMove()
    {
        moveDirection = new Vector2(0, 0);
    }
}
