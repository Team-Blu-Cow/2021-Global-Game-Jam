using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Claw : MonoBehaviour
{
    public Rigidbody2D rb;

    bool triggeringWithUpgrade = false;
    GameObject triggeringUpgrade;

    // Start is called before the first frame update
    void Start()
    {
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

            if(treasureType.reward == PlayerUpgrades.Upgrades.torchRange)
            {
                
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
