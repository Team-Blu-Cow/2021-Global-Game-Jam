using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DisplayDialog : MonoBehaviour
{
    TextMeshProUGUI tmp;

    // Start is called before the first frame update
    void Start()
    {
        tmp = GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public IEnumerator TypeSentance(string sentance, float delay)
    {
        tmp.text = "";
        foreach(char letter in sentance.ToCharArray())
        {
            tmp.text += letter;
            yield return new WaitForSeconds(delay);
        }
        yield return new WaitForSeconds(10);
        tmp.text = "";
    }
}
