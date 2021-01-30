using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;

public class PlayerStats : MonoBehaviour
{

    public float torchRange;
    public float torchDuration;
    public float sonarRange;
    public float sonarSpeed;
    public float hullDurability; // Depth controller for the hull???
    public float hullHealth = 100.0f; // 
    public float moveSpeed;

    public GameObject submarine;
    private PlayerUpgrades upgrades;
    private PlayerMovement pMovement;

    public Light2D pLight;
    private PlayerLight playerLight;

    // Start is called before the first frame update
    void Start()
    {
        pMovement = submarine.GetComponent<PlayerMovement>();
        upgrades = submarine.GetComponent<PlayerUpgrades>();
        playerLight = pLight.GetComponent<PlayerLight>();
    }

    // Update is called once per frame
    void Update()
    {
        torchRange = playerLight.range;
        torchDuration = playerLight.onDuration;
    }

    public void UpgradeTorchRange()
    {
        playerLight.range = 4.5f;
    }

    public void UpgradeTorchDuration()
    {
        playerLight.onDuration = 10.0f;
    }

    public void UpgradeHullHealth()
    {
        hullHealth = 150.0f;
    }
}
