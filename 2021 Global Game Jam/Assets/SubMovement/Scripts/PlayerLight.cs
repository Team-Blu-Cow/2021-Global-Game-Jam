using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.Experimental.Rendering.Universal;
using UnityEngine;

public class PlayerLight : MonoBehaviour
{
    [Header ("Skill variables")]
    public float onDuration = 5;
    public float range = 2.5f;

    [Header ("Light variables")]
    public float delayOn = 0.5f;
    public float deadZone = 0.0f;

    bool lightOn;
    float time;

    private MasterInput controls;

    private enum ControlType
    {
        MOUSE,
        JOYSTICK
    }

    // Start is called before the first frame update
    void Awake()
    {
        controls = new MasterInput();
        controls.PlayerControls.Light.started += ctx => LightOn();
        controls.PlayerControls.Light.canceled += ctx => LightOff();
        controls.PlayerControls.MousePos.performed += ctx => AimMouse(ctx.ReadValue<Vector2>());//Aim(ctx.ReadValue<Vector2>(), ControlType.MOUSE);
        controls.PlayerControls.CursorMove.performed += ctx => AimJoystick(ctx.ReadValue<Vector2>());
    }

    public void OnEnable()
    {
        controls.Enable();
    }
    public void OnDisable()
    {
        controls.Disable();
    }

    // Update is called once per frame
    void Update()
    {
        Light2D light = GetComponent<Light2D>();
        if (lightOn && delayOn >= 0.5)
        {
            time -= Time.deltaTime;
            light.enabled = true;
            if (time < 0)
                LightOff();
        }
        else if (time < onDuration)
        { 
            time += Time.deltaTime;
            light.enabled = false;
        }

        if (delayOn < 0.5)
        {
            delayOn += Time.deltaTime;
        }

        if (light.pointLightOuterRadius != range)
        {
            light.pointLightOuterRadius = range;
        }
    }

    void Aim(Vector2 dir, ControlType c_type = ControlType.JOYSTICK)
    {
        switch (c_type)
        {
            case ControlType.JOYSTICK:
                AimJoystick(dir);
                break;

            case ControlType.MOUSE:
                AimMouse(dir);
                break;

            default:
                transform.rotation = new Quaternion(0, 0, 0, 1);
                break;
        }
    }

    void AimJoystick(Vector2 dir)
    {
        if (dir.x > deadZone || dir.y > deadZone || dir.x < -deadZone || dir.y < -deadZone)
        {
            transform.rotation = Quaternion.Euler(0, 0, Mathf.Atan2(-dir.x, dir.y) * Mathf.Rad2Deg);
        }
    }

    void AimMouse(Vector2 dir)
    {
        Vector3 mousepos = Camera.main.ScreenToWorldPoint(new Vector3(dir.x, dir.y, 0));

        float angle = Mathf.Atan2(mousepos.y - transform.transform.position.y, mousepos.x - transform.transform.position.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0f, 0, angle - 90);
    }

    void LightOn()
    {
        lightOn = true;
    }
    
    void LightOff()
    {
        if (lightOn)
            delayOn = 0;
        lightOn = false;       
    }
}
