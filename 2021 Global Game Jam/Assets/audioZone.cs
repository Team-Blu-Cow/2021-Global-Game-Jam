using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class audioZone : MonoBehaviour
{
    public string BGMName;
    private LayerMask layermask;
    // Start is called before the first frame update

    private void Start()
    {
        layermask = LayerMask.NameToLayer("Player");
    }

    // Update is called once per frame
    private void Update()
    {
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.layer == layermask)
        {
            GameObject.Find("AudioManager").GetComponent<AudioManager>().Play(BGMName);
        }
    }

    public void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.layer == layermask)
        {
            GameObject.Find("AudioManager").GetComponent<AudioManager>().Stop(BGMName);
        }
    }
}