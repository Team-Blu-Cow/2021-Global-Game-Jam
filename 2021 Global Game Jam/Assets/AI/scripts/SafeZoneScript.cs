using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SafeZoneScript : MonoBehaviour
{
    LayerMask layermask;
    GameObject monsterController;
    MonsterPathfinderControlScript controlScript;

    void Start()
    {
        monsterController = GameObject.Find("Monster Controller");
        controlScript = monsterController.GetComponent<MonsterPathfinderControlScript>();

        layermask = LayerMask.NameToLayer("Player");
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == layermask)
        {
            controlScript.inc_safezone_count();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.layer == layermask)
        {
            controlScript.dec_safezone_count();
        }
    }

}
