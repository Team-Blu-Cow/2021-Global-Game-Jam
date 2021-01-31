using System.Collections;
using System.Collections.Generic;
using UnityEngine.U2D.IK;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public float moveSpeed = 30.0f;

    public Rigidbody2D rb;

    public MasterInput controls;
    public CursorController cursorObject;
    public Transform clawTarget;

    Vector2 movement;
    Vector2 drag;

    public bool clawMode = false;

    private void Awake()
    {
        controls = new MasterInput();
        controls.PlayerControls.Move.performed += ctx => OnMove(ctx.ReadValue<Vector2>());
        controls.PlayerControls.Move.canceled += ctx => OnStopMove(ctx.ReadValue<Vector2>());
        controls.PlayerControls.Claw.started += ctx => OnEnteringClawMode();
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
        GetComponentInChildren<CCDSolver2D>().solveFromDefaultPose = clawMode;

        clawMode = !clawMode;

        cursorObject.SetRender(clawMode);
        if (!clawMode)
        {
            clawTarget.localPosition = new Vector3(-1.7f,-5.5f,0);            
        }
    }
}
