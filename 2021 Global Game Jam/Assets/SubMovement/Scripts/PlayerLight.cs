using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.Experimental.Rendering.Universal;
using UnityEngine;

public class PlayerLight : MonoBehaviour
{
    [Header ("Skill variables")]
    public float onDuration = 5;
    public float angle = 25;

    [Header ("Light variables")]
    public float deadZone = 0.0f;

    private float delayOn = 0.5f;

    bool lightOn = false;
    float time;

    private MasterInput controls;

    // Start is called before the first frame update
    void Awake()
    {       
        controls = new MasterInput();
        controls.PlayerControls.Light.started += ctx => LightOn();
        controls.PlayerControls.Light.canceled += ctx => LightOff();
        controls.PlayerControls.MousePos.performed += ctx => AimMouse(ctx.ReadValue<Vector2>());
        controls.PlayerControls.CursorMove.performed += ctx => AimJoystick(ctx.ReadValue<Vector2>());
    }
    private void Start()
    {
        time = onDuration;
        GetComponent<Light2D>().pointLightOuterAngle = angle;
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
    }

    public void UpgradeLight(float angle, float duration)
    {
        GetComponent<Light2D>().pointLightOuterAngle = angle;
        onDuration = duration;
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
