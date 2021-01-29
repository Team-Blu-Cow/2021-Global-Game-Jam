using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;


public class MonsterPathfinderControlScript : MonoBehaviour
{

    public Transform Player;

    public float speed = 200f;
    public float nextWaypointDistance = 3f;

    Path path;
    int currentWaypoint = 0;
    bool reachedEndOfPath = false;

    public GameObject Monster;
    private Seeker seeker;
    private Rigidbody2D rb;
    private Transform transform;


    // Start is called before the first frame update
    void Start()
    {
        seeker = Monster.GetComponent<Seeker>();
        rb = Monster.GetComponent<Rigidbody2D>();
        transform = Monster.GetComponent<Transform>();

        
        InvokeRepeating("UpdatePath", 0f, 1f);
    }

    void UpdatePath()
    {
        if(seeker.IsDone())
        {
            seeker.StartPath(rb.position, Player.position, OnPathComplete);
        }
    }

    private void Update()
    {
        Vector2 direction = (rb.velocity).normalized;
        float angle = Mathf.Atan2(direction.x, direction.y);
        float deg_angle = ((angle / 3.1415f) * 180f);
        rb.rotation = angle;
    }

    void FixedUpdate()
    {
        if (path == null)
            return;

        if(currentWaypoint >= path.vectorPath.Count)
        {
            reachedEndOfPath = true;
            return;
        }else
        {
            reachedEndOfPath = false;
        }

        Vector2 direction = ((Vector2)path.vectorPath[currentWaypoint] - rb.position).normalized;
        Vector2 force = direction * speed * Time.deltaTime;
        rb.AddForce(force);


        float distance = Vector2.Distance(rb.position, path.vectorPath[currentWaypoint]);
        if (distance < nextWaypointDistance)
        {
            currentWaypoint++;
        }


    }


    void OnPathComplete(Path p)
    {
        if(!p.error)
        {
            path = p;
            currentWaypoint = 0;
        }


    }

}
