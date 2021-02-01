using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;

public class PlayerStats : MonoBehaviour
{
    [Header("Lights")]
    public GameObject lightUpgrade;

    [Header("Scan")]
    public GameObject sonarUpgrade;

    [Header("Hull")]
    public GameObject sub_shield;
    public float hullMaxHealth;
    public float hullCurrentHealth;

    [Header("Misc")]
    public minimap.MaskComputeShaderObject csObject;
    public MasterInput controls;

    private void Awake()
    {
        controls = new MasterInput();
        controls.PlayerControls.Repair.started += ctx => OnRepair();
    }

    private void OnEnable()
    {
        controls.Enable();
    }

    private void OnDisable()
    {
        controls.Disable();
    }

    public void UpgradeTorch()
    {
        lightUpgrade.GetComponentInChildren<Light2D>().enabled = true;
        lightUpgrade.GetComponentInChildren<SpriteRenderer>().enabled = true;
        
        foreach (PlayerLight light in GetComponentsInChildren<PlayerLight>())
        {
            light.UpgradeLight(50, 10);
        }
    }

    public void UpgradeHullHealth()
    {
        sub_shield.GetComponent<SpriteRenderer>().enabled = true;
        hullCurrentHealth += 50.0f;
        hullMaxHealth = 150.0f;
    }

    public void UpgradeMoveSpeed()
    {
        GetComponent<PlayerMovement>().moveSpeed = 50.0f;
    }

    public void UpgradeSonarRange()
    {
        sonarUpgrade.GetComponentInChildren<SpriteRenderer>().enabled = true;
        GetComponentInChildren<SonarScan>().scanRadius = 10;
    }

    public void UnlockMapArea(int index)
    {
        switch (index)
        {
            case 1:
                csObject.zone1Flag = true;
                break;
            case 2:
                csObject.zone2Flag = true;
                break;
            case 3:
                csObject.zone3Flag = true;
                break;
            case 4:
                csObject.zone4Flag = true;
                break;
        }

        csObject.CreateNewTexture();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Enemy"))
        {
            hullCurrentHealth -= 25;
            if (hullCurrentHealth <= 0)
            {
                GameObject.Find("LevelLoader").GetComponent<LevelLoader>().SwitchScene("Game Over");
            }
        }
        else if (collision.gameObject.CompareTag("Treasure"))
        {
            TreasureControl treasureType = collision.gameObject.GetComponent<TreasureControl>();

            switch (treasureType.reward)
            {
                case PlayerUpgrades.Upgrades.torchUpgrade:
                    UpgradeTorch();
                    break;
                case PlayerUpgrades.Upgrades.sonarUpgrade:
                    UpgradeSonarRange();
                    break;
                case PlayerUpgrades.Upgrades.hullUpgrade:
                    UpgradeHullHealth();
                    break;
                case PlayerUpgrades.Upgrades.mapZone1:
                    UnlockMapArea(1);
                    break;
                case PlayerUpgrades.Upgrades.mapZone2:
                    UnlockMapArea(2);
                    break;
                case PlayerUpgrades.Upgrades.mapZone3:
                    UnlockMapArea(3);
                    break;
                case PlayerUpgrades.Upgrades.mapZone4:
                    UnlockMapArea(4);
                    break;
                case PlayerUpgrades.Upgrades.moveSpdMod:
                    UpgradeMoveSpeed();
                    break;
                default:
                    break;
            }
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
