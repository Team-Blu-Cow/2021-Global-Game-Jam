using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class FadeOut : MonoBehaviour
{

    private Image image;
    // Start is called before the first frame update
    void Start()
    {
        image = GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {       
        image.color = new Color(image.color.r, image.color.g, image.color.b, image.color.a-(0.1f*Time.deltaTime));
    }
}
