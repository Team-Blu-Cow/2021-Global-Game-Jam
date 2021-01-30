using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Claw : MonoBehaviour
{
    public Joint _joint;

    public Rigidbody2D rb;
    private Rigidbody joint_rb;

    bool triggeringWithUpgrade = false;
    GameObject triggeringUpgrade;

    // Start is called before the first frame update
    void Start()
    {
        joint_rb = _joint.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {

        rb.position = new Vector2(joint_rb.position.x, joint_rb.position.y);

        if(triggeringWithUpgrade == true && triggeringUpgrade)
        {
            Rigidbody2D upgrade_rb = triggeringUpgrade.GetComponent<Rigidbody2D>();
            upgrade_rb.position = rb.position;
        }

    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Colliding with treasure");
        if(other.tag == "Treasure")
        {           
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
