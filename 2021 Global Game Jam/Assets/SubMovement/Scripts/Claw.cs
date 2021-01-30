using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Claw : MonoBehaviour
{
    public Rigidbody2D rb;

    bool triggeringWithUpgrade = false;
    GameObject triggeringUpgrade;

    public GameObject sub;
    private PlayerStats pStats;
    private PlayerMovement pMovement;
    
    public GameObject iKManagerObject;
    private IKManager iKManager;

    // Start is called before the first frame update
    void Start()
    {
        pStats = sub.GetComponent<PlayerStats>();
        pMovement = sub.GetComponent<PlayerMovement>();
        iKManager = iKManagerObject.GetComponent<IKManager>();
    }

    // Update is called once per frame
    void Update()
    {

        transform.position = GetComponent<Transform>().parent.position;
        

        if(triggeringWithUpgrade == true && triggeringUpgrade)
        {
            Rigidbody2D upgrade_rb = triggeringUpgrade.GetComponent<Rigidbody2D>();
            upgrade_rb.position = rb.position;

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
                iKManager.clawMode = false;
            }
        }

    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Treasure")
        {
            Debug.Log("Colliding with treasure");        
            triggeringUpgrade = other.gameObject;
            triggeringWithUpgrade = true;
        }
    }

    public void OnTriggerExit2D(Collider2D other)
    {
        if(other.tag == "Treasure")
        {
            Debug.Log("Leaving treasure");
            triggeringUpgrade = null;
            triggeringWithUpgrade = false;
        }
    }

}
