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
        transform.localPosition = new Vector3();
        transform.localRotation = new Quaternion();

        if(triggeringWithUpgrade == true && triggeringUpgrade)
        {
            triggeringUpgrade.GetComponent<Rigidbody2D>().position = pickupPos.position;

            TreasureControl treasureType = triggeringUpgrade.GetComponent<TreasureControl>();

            switch (treasureType.reward)
            {
                case PlayerUpgrades.Upgrades.torchRange:
                    pStats.UpgradeTorchRange();
                    break;
                case PlayerUpgrades.Upgrades.torchDuraion:
                    pStats.UpgradeTorchDuration();
                    break;
                case PlayerUpgrades.Upgrades.sonarRange:
                    pStats.UpgradeSonarRange();
                    break;
                case PlayerUpgrades.Upgrades.sonarSpeed:
                    break;
                case PlayerUpgrades.Upgrades.hullDuribilty:
                    pStats.UpgradeHullDurability();
                    break;
                case PlayerUpgrades.Upgrades.hullHealth:
                    pStats.UpgradeHullHealth();
                    break;
                case PlayerUpgrades.Upgrades.moveSpdMod:
                    pStats.UpgradeMoveSpeed();
                    break;
                default:
                    break;
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
