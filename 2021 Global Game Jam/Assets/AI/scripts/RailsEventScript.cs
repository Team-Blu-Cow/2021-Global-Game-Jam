using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RailsEventScript : MonoBehaviour
{
    public GameObject RailsStartPoint;
    public GameObject RailsEndPoint;
    public GameObject RailsTeleportPoint;

    private LayerMask layermask;
    GameObject monsterController;
    MonsterPathfinderControlScript controlScript;

    bool hasBeenTriggered = false;

    void Start()
    {
        monsterController = GameObject.Find("Monster Controller");
        controlScript = monsterController.GetComponent<MonsterPathfinderControlScript>();

        layermask = LayerMask.NameToLayer("Player");
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == layermask && !hasBeenTriggered)
        {
            hasBeenTriggered = true;
            controlScript.InitOnRails(RailsStartPoint, RailsEndPoint, RailsTeleportPoint);
        }
    }
}
