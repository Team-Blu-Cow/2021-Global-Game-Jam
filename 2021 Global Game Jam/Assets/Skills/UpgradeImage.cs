using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class UpgradeImage : MonoBehaviour
{
    public GameObject player;
    public PlayerUpgrades.Upgrades reward = PlayerUpgrades.Upgrades.torchRange;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (player.GetComponent<PlayerUpgrades>().upgrades[(int)reward])
            gameObject.GetComponent<Image>().color = new Color(0,0,0,0.4f);
        else
            gameObject.GetComponent<Image>().color = Color.clear;
    }
}
