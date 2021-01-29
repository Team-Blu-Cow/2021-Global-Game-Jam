using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreasureControl : MonoBehaviour
{
    public PlayerUpgrades.Upgrades reward = PlayerUpgrades.Upgrades.torchRange;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag.Equals("Player"))
            Destroy(gameObject);        
    }
}
