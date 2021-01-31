using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class PlayerUpgrades : MonoBehaviour
{    
    public enum Upgrades
    {
        torchUpgrade ,
        sonarUpgrade,
        hullUpgrade ,
        moveSpdMod ,
        mapZone1,
        mapZone2,
        mapZone3,
        mapZone4
    }

    [Header("Player Upgrades")]
    public bool[] upgrades = new bool[7];

    private void OnCollisionEnter2D(Collision2D collision)
    {
        GameObject collisionGameObj = collision.gameObject;
        if (collisionGameObj.CompareTag("Treasure"))
        {
            switch (collisionGameObj.GetComponent<TreasureControl>().reward)
            {
                case Upgrades.torchUpgrade:
                    upgrades[(int)Upgrades.torchUpgrade] = true;
                    break;
                case Upgrades.sonarUpgrade:
                    upgrades[(int)Upgrades.sonarUpgrade] = true;
                    break;
                case Upgrades.hullUpgrade:
                    upgrades[(int)Upgrades.hullUpgrade] = true;
                    break;
                case Upgrades.moveSpdMod:
                    upgrades[(int)Upgrades.moveSpdMod] = true;
                    break;
                case Upgrades.mapZone1:
                    upgrades[(int)Upgrades.mapZone1] = true;
                    break;
                case Upgrades.mapZone2:
                    upgrades[(int)Upgrades.mapZone2] = true;
                    break;
                case Upgrades.mapZone3:
                    upgrades[(int)Upgrades.mapZone3] = true;
                    break;
                case Upgrades.mapZone4:
                    upgrades[(int)Upgrades.mapZone4] = true;
                    break;
                default:
                    break;
            }
        }
    }
}
