using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Claw : MonoBehaviour
{
    public Joint _joint;

    public Rigidbody2D rb;
    private Rigidbody joint_rb;

    bool triggeringWithUpgrade = false;

    // Start is called before the first frame update
    void Start()
    {
        joint_rb = _joint.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        rb.position = new Vector2(joint_rb.position.x, joint_rb.position.y);
    }



    public void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Upgrade")
        {
            triggeringWithUpgrade = true;
            Debug.Log("Colliding with Upgrade");
        }
    }

    public void OnTriggerExit2D(Collider2D other)
    {
        if(other.tag == "Upgrade")
        {
            triggeringWithUpgrade = false;
            Debug.Log("Leaving Upgrade");
        }
    }

}
