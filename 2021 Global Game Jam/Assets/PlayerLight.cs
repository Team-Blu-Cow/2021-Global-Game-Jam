using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.Experimental.Rendering.Universal;
using UnityEngine;

public class PlayerLight : MonoBehaviour
{
    bool lightOn;
    public float time = 5;

    private TestPlayerControls controls;
    // Start is called before the first frame update
    void Awake()
    {
        controls = new TestPlayerControls();
        controls.testplayercontrols.Light.started += ctx => LightOn();
        controls.testplayercontrols.Light.canceled += ctx => LightOff();
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
        if (lightOn)
        {
            time -= Time.deltaTime;
            light.enabled = true;
            if (time < 0)
                lightOn = false;
        }
        else if (time < 5)
        { 
            time += Time.deltaTime;
            light.enabled = false;
        }
    }

    void LightOn()
    {
        lightOn = true;
    }
    
    void LightOff()
    {
        lightOn = false;
    }
}
