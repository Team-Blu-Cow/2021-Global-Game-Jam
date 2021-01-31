using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Claw : MonoBehaviour
{
    bool triggeringWithUpgrade = false;
    public GameObject triggeringUpgrade;

    public GameObject sub;
    public Transform pickupPos;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        transform.localPosition = new Vector3();
        transform.localRotation = new Quaternion();

        if(triggeringWithUpgrade == true && triggeringUpgrade)
        {
            triggeringUpgrade.GetComponent<Rigidbody2D>().position = pickupPos.position;            
        }
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Treasure"))
        {
            triggeringUpgrade = other.gameObject;
            triggeringWithUpgrade = true;
        }
    }

    public void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Treasure"))
        {
            triggeringUpgrade = null;
            triggeringWithUpgrade = false;
        }
    }

}
