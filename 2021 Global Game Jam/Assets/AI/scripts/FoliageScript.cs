using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoliageScript : MonoBehaviour
{
    private LayerMask layermask;
    GameObject monsterController;
    MonsterPathfinderControlScript controlScript;

    // Start is called before the first frame update
    void Start()
    {
        monsterController = GameObject.Find("Monster Controller");
        controlScript = monsterController.GetComponent<MonsterPathfinderControlScript>();

        layermask = LayerMask.NameToLayer("Player");
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.layer == layermask)
        {
            controlScript.inc_foliage_count();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.layer == layermask)
        {
            controlScript.dec_foliage_count();
        }
    }

}
