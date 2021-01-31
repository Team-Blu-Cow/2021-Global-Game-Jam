using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Claw : MonoBehaviour
{
    bool triggeringWithUpgrade = false;
    GameObject triggeringUpgrade;

    public GameObject sub;
    public Transform pickupPos;

    private PlayerStats pStats;
    private PlayerMovement pMovement;

    // Start is called before the first frame update
    void Start()
    {
        pStats = sub.GetComponent<PlayerStats>();
        pMovement = sub.GetComponent<PlayerMovement>();
    }

    // Update is called once per frame
    void Update()
    {
        if(triggeringWithUpgrade == true && triggeringUpgrade)
        {
            triggeringUpgrade.GetComponent<Rigidbody2D>().position = pickupPos.position;

            TreasureControl treasureType = triggeringUpgrade.GetComponent<TreasureControl>();

            if (pMovement.clawMode == true)
            {
                if (treasureType.reward == PlayerUpgrades.Upgrades.torchRange)
                {
                    pStats.UpgradeTorchRange();
                }

                if (treasureType.reward == PlayerUpgrades.Upgrades.torchDuraion)
                {
                    pStats.UpgradeTorchDuration();
                }

                if(treasureType.reward == PlayerUpgrades.Upgrades.hullHealth)
                {
                    pStats.UpgradeHullHealth();
                }

                if (treasureType.reward == PlayerUpgrades.Upgrades.moveSpdMod)
                {
                    pStats.UpgradeMoveSpeed();
                }

                if(treasureType.reward == PlayerUpgrades.Upgrades.sonarRange)
                {
                    pStats.UpgradeSonarRange();
                }

                if(treasureType.reward == PlayerUpgrades.Upgrades.hullDuribilty)
                {
                    pStats.UpgradeHullDurability();
                }

                pMovement.clawMode = false;
            }
        }

    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Treasure")
        {
            Debug.Log("Colliding with treasure");        
            triggeringUpgrade = other.gameObject;
            triggeringWithUpgrade = true;
        }
    }

    public void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Treasure")
        {
            Debug.Log("Leaving treasure");
            triggeringUpgrade = null;
            triggeringWithUpgrade = false;
        }
    }

}
