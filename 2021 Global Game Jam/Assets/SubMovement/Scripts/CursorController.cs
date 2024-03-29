using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorController : MonoBehaviour
{
    [HideInInspector] public MasterInput input;
    [HideInInspector] public Vector3 mousePos;
    [HideInInspector] public Vector3 moveDir;
    [HideInInspector] public Transform thisTransform;
    [HideInInspector] public SpriteRenderer spriteRenderer;

    public float speed;
    public bool render = false;

    void Awake()
    {
        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
        thisTransform = gameObject.GetComponent<Transform>();

        input = new MasterInput();
        input.PlayerControls.MousePos.performed += ctx => TargetMouse(ctx.ReadValue<Vector2>());
        input.PlayerControls.CursorMove.performed += ctx => GamepadMoveCursor(ctx.ReadValue<Vector2>());
        input.PlayerControls.CursorMove.canceled += ctx => OnStopMove();
    }

    void OnEnable()
    {
        input.Enable();
    }

    void OnDisable()
    {
        input.Disable();
    }

    void TargetMouse(Vector2 position)
    {
        Vector2 worldPos;
        worldPos = Camera.main.ScreenToWorldPoint(position);
        mousePos = new Vector3(worldPos.x, worldPos.y, -1);
    }

    void GamepadMoveCursor(Vector2 gamepadAxis)
    {
        moveDir = new Vector3(gamepadAxis.x * Time.deltaTime * speed, gamepadAxis.y * Time.deltaTime * speed, 0);
    }

    private void Update()
    {
        mousePos += moveDir;
        if (render)
            thisTransform.position = mousePos;
    }

    public void setPos(Vector3 pos)
    {
        mousePos = pos;
    }

    public void OnStopMove()
    {
        moveDir = new Vector3(0, 0, 0);
    }

    public void SetRender(bool renderflag)
    {
        render = renderflag;
        spriteRenderer.enabled = renderflag;
    }
}
