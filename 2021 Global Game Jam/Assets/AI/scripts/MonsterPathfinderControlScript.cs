using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class MonsterPathfinderControlScript : MonoBehaviour
{

    public Transform Player;

    public float speed = 200f;
    public float nextWaypointDistance = 3f;
    public float spottingRange = 10f;
    public float loseDetectionRange = 15f;

    Path path;
    int currentWaypoint = 0;
    bool reachedEndOfPath = false;

    public GameObject Monster;
    private Seeker seeker;
    private Rigidbody2D rb;
    private Vector3 position;


    Vector3 target_position = new Vector3();

    System.Random rnd = new System.Random();
    public List<PathfindingNode> nodeList;


    enum AIstate
    {
        idle = 0, // stationary
        patrol, // swimming around
        hunting, // hunting player
        investigate, // go towards a point
        sleeping // not on map
    }

    AIstate state = AIstate.patrol;

    // Start is called before the first frame update
    void Start()
    {
        seeker = Monster.GetComponent<Seeker>();
        rb = Monster.GetComponent<Rigidbody2D>();

        InvokeRepeating("UpdatePath", 0f, 1f);
    }

    void UpdatePath()
    {
        if(seeker.IsDone())
        {
            seeker.StartPath(rb.position, target_position, OnPathComplete);
        }
    }

    private void Update()
    {
        // graphics here
    }

    bool atEndOfPath()
    {
        return currentWaypoint >= path.vectorPath.Count;
    }

    void FixedUpdate()
    {
        if (path == null)
            return;

        if(atEndOfPath())
        {
            reachedEndOfPath = true;
            return;
        }
        else
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

        position = Monster.GetComponent<Transform>().position;

        switch (state)
        {
            case AIstate.patrol:
                PatrolUpdate();
                break;
            case AIstate.hunting:
                HuntUpdate();
                break;
            default:
                break;
        }

    }

    void PatrolUpdate()
    {
        if(atEndOfPath())
        {
            if (nodeList.Count > 0)
            {
                PathfindingNode node = nodeList[rnd.Next(nodeList.Count)];
                target_position = node.getPosition();
            }
            else
            {
                target_position = new Vector3();
            }
        }
        

        if(CheckPlayerInRange(spottingRange))
        {
            state = AIstate.hunting;
        }
    }

    void HuntUpdate()
    {
        target_position = Player.position;
        if (!CheckPlayerInRange(loseDetectionRange))
        {
            state = AIstate.patrol;
        }
    }

    bool CheckPlayerInRange(float range)
    {
        float distance = Vector2.Distance(Player.position, position);

        if(distance < range)
        {
            return true;
        }
        else
        {
            return false;
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

    void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(position, spottingRange);
        Gizmos.DrawWireSphere(position, loseDetectionRange);
    }

}
