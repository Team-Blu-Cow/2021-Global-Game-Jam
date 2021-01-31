using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReturntoMM : MonoBehaviour
{
    // Start is called before the first frame update
    private void Start()
    {
        StartCoroutine(BackToMM("MainMenu"));
    }

    private IEnumerator BackToMM(string in_Scene)
    {
        yield return new WaitForSeconds(4);
        GameObject.Find("LevelLoader").GetComponent<LevelLoader>().SwitchScene(in_Scene);
    }

    // Update is called once per frame
    private void Update()
    {
    }
}