using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathfindingNode : MonoBehaviour
{
    public int weight = 1;
    bool active = true;
    
    
    public Vector3 getPosition()
    {
        return GetComponent<Transform>().position;
    }

}
