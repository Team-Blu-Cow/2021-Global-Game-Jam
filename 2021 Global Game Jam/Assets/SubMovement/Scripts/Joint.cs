using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Joint : MonoBehaviour
{
    public Joint m_child;


    public Joint GetChild()
    {
        return m_child;
    }

    public void Rotate(float angle)
    {
        transform.Rotate(Vector3.forward * angle);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
