using System.Collections;
using System.Collections.Generic;
using UnityEngine.Experimental.Rendering.Universal;
using TMPro;
using UnityEngine;

public class TreasureControl : MonoBehaviour
{

    public PlayerUpgrades.Upgrades reward = PlayerUpgrades.Upgrades.torchUpgrade;
    
    [Header("Ping")]
    public List<GameObject> ping;
    public SonarScan sonar;

    [Header("Dialog")]
    public DisplayDialog displayText;
    public string customDialog;

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
            if (displayText)
                StopAllCoroutines();
                StartCoroutine(displayText.TypeSentance(customDialog, 0.1f));

            foreach (GameObject obj in ping)
            {
                Debug.Log(obj.name);
                StartCoroutine(sonar.MapDraw(obj.transform.position, 0));
            }

            GetComponent<BoxCollider2D>().enabled = false;
            GetComponent<SpriteRenderer>().enabled = false;

            Destroy(gameObject,20);
        }
    }

    public IEnumerator Flash(float dist)
    {
        yield return new WaitForSeconds(dist);

        Light2D light = GetComponentInChildren<Light2D>();
        light.enabled = true;
        
    }
}
