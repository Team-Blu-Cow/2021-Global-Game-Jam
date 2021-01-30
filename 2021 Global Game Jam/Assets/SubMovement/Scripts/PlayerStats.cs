using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;

public class PlayerStats : MonoBehaviour
{

    public float torchRange;
    public float torchDuration;
    public int sonarRange;
    public float sonarSpeed;
    public float hullDurability = 10.0f; // Depth controller for the hull???
    public float hullHealth = 100.0f; // 
    public float moveSpeed;

    public GameObject submarine;
    private PlayerUpgrades upgrades;
    private PlayerMovement pMovement;

    public Light2D pLight;
    private PlayerLight playerLight;

    public GameObject sonarSystem;
    private SonarScan sonarScan;

    // Start is called before the first frame update
    void Start()
    {
        pMovement = submarine.GetComponent<PlayerMovement>();
        upgrades = submarine.GetComponent<PlayerUpgrades>();
        playerLight = pLight.GetComponent<PlayerLight>();
        sonarScan = sonarSystem.GetComponent<SonarScan>();
    }

    // Update is called once per frame
    void Update()
    {
        torchRange = playerLight.range;
        torchDuration = playerLight.onDuration;
        moveSpeed = pMovement.moveSpeed;
        sonarRange = sonarScan.scanRadius;
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

    public void UpgradeMoveSpeed()
    {
        pMovement.moveSpeed = 50.0f;
    }

    public void UpgradeSonarRange()
    {
        Debug.Log("fghj");
        sonarScan.scanRadius = 10;
    }

    public void UpgradeHullDurability()
    {
        hullDurability = 20.0f;
    }

}
