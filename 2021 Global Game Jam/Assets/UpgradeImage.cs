using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class UpgradeImage : MonoBehaviour
{
    public GameObject player;
    PlayerUpgrades playerUpgrades;
    
    // Start is called before the first frame update
    void Start()
    {
        playerUpgrades = player.GetComponent<PlayerUpgrades>();
    }

    // Update is called once per frame
    void Update()
    {
        RectTransform imageTransform = GetComponent<RectTransform>();
        
        imageTransform.position.Set(0,10,0);
    }
}
