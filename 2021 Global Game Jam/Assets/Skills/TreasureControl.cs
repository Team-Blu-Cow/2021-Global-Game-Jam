using System.Collections;
using System.Collections.Generic;
using UnityEngine.Experimental.Rendering.Universal;
using UnityEngine;

public class TreasureControl : MonoBehaviour
{
    public PlayerUpgrades.Upgrades reward = PlayerUpgrades.Upgrades.torchRange;
    public string customDialog;
    public List<GameObject> ping;
    public SonarScan sonar;
    float timer = 1;

    private void Update()
    {
        Light2D light = GetComponentInChildren<Light2D>();
        if (light.enabled)
        {
            timer -= Time.deltaTime;
            if (timer < 0)
            {
                timer = 1;
                light.enabled = false;
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            foreach (GameObject obj in ping)
            {
                StartCoroutine(sonar.MapDraw(obj.transform.position, 0));
            }

            Destroy(gameObject);
        }
    }

    public IEnumerator Flash(float dist)
    {
        yield return new WaitForSeconds(dist);

        Light2D light = GetComponentInChildren<Light2D>();
        light.enabled = true;
        
    }
}
