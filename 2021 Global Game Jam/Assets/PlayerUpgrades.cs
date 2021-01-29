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
    public int torchRange = 0;
    public int torchDuraion = 0;
    public int sonarRange = 0;
    public int sonarSpeed = 0;
    public int hullDuribilty = 0;
    public int hullHealth = 0;
    public int moveSpdMod = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        GameObject collisionGameObj = collision.gameObject;
        if (collisionGameObj.tag.Equals("Treasure"))
        {
            switch (collisionGameObj.GetComponent<TreasureControl>().reward)
            {
                case Upgrades.torchRange:
                    if (torchRange < 10)
                        torchRange++;
                    break;
                case Upgrades.torchDuraion:
                    if (torchDuraion < 10)
                        torchDuraion++;
                    break;
                case Upgrades.sonarRange:
                    if (sonarRange < 10)
                        sonarRange++;
                    break;
                case Upgrades.sonarSpeed:
                    if (sonarSpeed < 10)
                        sonarSpeed++;
                    break;
                case Upgrades.hullDuribilty:
                    if (hullDuribilty < 10)
                        hullDuribilty++;
                    break;
                case Upgrades.hullHealth:
                    if (hullHealth < 10)
                        hullHealth++;
                    break;
                case Upgrades.moveSpdMod:
                    if (moveSpdMod < 10)
                        moveSpdMod++;
                    break;
                default:
                    break;
            }
        }
    }
}
