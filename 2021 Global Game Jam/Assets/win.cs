using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class win : MonoBehaviour
{
    private LayerMask layermask;
    private GameObject monsterController;
    private MonsterPathfinderControlScript controlScript;

    private bool hasBeenTriggered = false;

    // Start is called before the first frame update
    private void Start()
    {
        monsterController = GameObject.Find("Monster Controller");
        controlScript = monsterController.GetComponent<MonsterPathfinderControlScript>();

        layermask = LayerMask.NameToLayer("Player");
    }

    // Update is called once per frame
    private void Update()
    {
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == layermask && !hasBeenTriggered)
        {
            GameObject.Find("LevelLoader").GetComponent<LevelLoader>().SwitchScene("WinScreen");
        }
    }
}