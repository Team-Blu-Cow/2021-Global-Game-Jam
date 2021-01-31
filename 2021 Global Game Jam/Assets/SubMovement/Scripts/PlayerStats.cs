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
    public float hullDurability;
    public float hullMaxHealth;
    public float hullCurrentHealth;
    public float moveSpeed;

    private PlayerUpgrades upgrades;
    private PlayerMovement pMovement;

    public Light2D pLight;
    private PlayerLight playerLight;

    public GameObject sonarSystem;
    private SonarScan sonarScan;

    public MasterInput controls;


    private void Awake()
    {
        controls = new MasterInput();
        controls.PlayerControls.Repair.started += ctx => OnRepair();
    }

    // Start is called before the first frame update
    void Start()
    {
        hullMaxHealth = 100.0f;
        hullCurrentHealth = 100.0f;
        hullDurability = 10.0f;
        pMovement = GetComponent<PlayerMovement>();
        upgrades = GetComponent<PlayerUpgrades>();

        playerLight = pLight.GetComponent<PlayerLight>();
        sonarScan = sonarSystem.GetComponent<SonarScan>();
    }

    private void OnEnable()
    {
        controls.Enable();
    }

    private void OnDisable()
    {
        controls.Disable();
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
        playerLight.onDuration = 100.0f;
    }

    public void UpgradeHullHealth()
    {
        hullCurrentHealth = hullCurrentHealth + 50.0f;
        hullMaxHealth = 150.0f;
    }

    public void UpgradeMoveSpeed()
    {
        pMovement.moveSpeed = 50.0f;
    }

    public void UpgradeSonarRange()
    {
        sonarScan.scanRadius = 10;
    }

    public void UpgradeHullDurability()
    {
        hullDurability = 20.0f;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Enemy")
        {
            Debug.Log("WE HAVE BEEN HIT");
            hullCurrentHealth -= 25;
        }
    }

    void OnRepair()
    {
        Debug.Log("Repairing");
        float repairTime = hullMaxHealth / (hullCurrentHealth * 1.5f);
        StartCoroutine(Repair(repairTime));
    }

    public IEnumerator Repair(float repairTime)
    {
        yield return new WaitForSeconds(repairTime);
        Debug.Log("Repaired");
        hullCurrentHealth = hullMaxHealth;
    }

}
