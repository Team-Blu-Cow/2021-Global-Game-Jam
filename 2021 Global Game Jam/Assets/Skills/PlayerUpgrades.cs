using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class PlayerUpgrades : MonoBehaviour
{    
    public enum Upgrades
    {
        torchRange ,
        torchDuraion ,
        sonarRange,
        sonarSpeed ,
        hullDuribilty ,
        hullHealth ,
        moveSpdMod 
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
                case Upgrades.torchRange:
                    upgrades[(int)Upgrades.torchRange] = true;
                    break;
                case Upgrades.torchDuraion:
                    upgrades[(int)Upgrades.torchDuraion] = true;
                    break;
                case Upgrades.sonarRange:
                    upgrades[(int)Upgrades.sonarRange] = true;
                    break;
                case Upgrades.sonarSpeed:
                    upgrades[(int)Upgrades.sonarSpeed] = true;
                    break;
                case Upgrades.hullDuribilty:
                    upgrades[(int)Upgrades.hullDuribilty] = true;
                    break;
                case Upgrades.hullHealth:
                    upgrades[(int)Upgrades.hullHealth] = true;
                    break;
                case Upgrades.moveSpdMod:
                    upgrades[(int)Upgrades.moveSpdMod] = true;
                    break;
                default:
                    break;
            }
        }
    }
}
