using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DisplayDialog : MonoBehaviour
{
    TextMeshProUGUI tmp;

    public float textDelay = 0.1f;

    // Start is called before the first frame update
    void Start()
    {
        tmp = GetComponent<TextMeshProUGUI>();       
        StartCoroutine(TypeSentance(tmp.text));
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator TypeSentance(string sentance)
    {
        tmp.text = "";
        foreach(char letter in sentance.ToCharArray())
        {
            tmp.text += letter;
            yield return new WaitForSeconds(textDelay);
        }
    }
}
