using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class MonsterPathfinderControlScript : MonoBehaviour
{

    public GameObject player;
    private Transform playerTransform;

    public float normalSpeed = 200f;
    public float railsSpeed = 500f;
    public float speed;

    public float nextWaypointDistance = 3f;

    public float base_detection = 5f;
    public float noise_multiplier = 0.1f;
    public float loseDetectionMosifier = 1.5f;
    public float max_noise = 5;
    public float noise_bias = 1;

    private int foliage_trigger_count = 0;
    private int safezone_trigger_count = 0;

    Path path;
    int currentWaypoint = 0;

    public GameObject Monster;
    private Seeker monsterSeeker;
    private Rigidbody2D monsterRB;
    private Vector3 monsterPosition;
    private Vector3 investigatePosition = new Vector3();

    Vector3 target_position = new Vector3();

    System.Random rnd = new System.Random();
    public List<PathfindingNode> nodeList;

    private Vector3 RailsOnCompleteteleportPos;
    private bool doRailsTeleport = false;

    float calcDetectionRange(float modifier = 1f)
    {
        float noise = player.GetComponent<Rigidbody2D>().velocity.magnitude;
        noise = noise * noise_multiplier;
        noise = noise - noise_bias;

        if(noise < 0)
        {
            noise = 0;
        }
        else if(noise > max_noise)
        {
            noise = max_noise;
        }

        float foliage_modifier = 1f;
        if(InFoliage())
        {
            foliage_modifier = 0.3f;
        }

        float detect = (base_detection + noise) * modifier * foliage_modifier;
        return detect;
    }

    public enum AIstate
    {
        idle = 0, // stationary
        patrol, // swimming around
        hunting, // hunting player
        investigate, // go towards a point
        sleeping, // not on map
        on_rails // for monster being on rails
    }

    AIstate state = AIstate.sleeping;

    void Start()
    {
        playerTransform = player.GetComponent<Transform>();
        monsterSeeker = Monster.GetComponent<Seeker>();
        monsterRB = Monster.GetComponent<Rigidbody2D>();
        speed = normalSpeed;
        InvokeRepeating("UpdatePath", 0f, 0.5f);
    }

    void UpdatePath()
    {
        if(state != AIstate.sleeping)
        {
            if (monsterSeeker.IsDone())
            {
                monsterSeeker.StartPath(monsterRB.position, target_position, OnPathComplete);
            }
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

        if(!atEndOfPath())
        {
            Vector2 direction = ((Vector2)path.vectorPath[currentWaypoint] - monsterRB.position).normalized;
            Vector2 force = direction * speed * Time.deltaTime;
            monsterRB.AddForce(force);


            float distance = Vector2.Distance(monsterRB.position, path.vectorPath[currentWaypoint]);
            if (distance < nextWaypointDistance)
            {
                currentWaypoint++;
            }
        }

        monsterPosition = Monster.GetComponent<Transform>().position;

        switch (state)
        {
            case AIstate.patrol:
                PatrolUpdate();
                break;
            case AIstate.hunting:
                HuntUpdate();
                break;
            case AIstate.investigate:
                InvestigateUpdate();
                break;
            case AIstate.on_rails:
                OnRailsUpdate();
                break;
            case AIstate.sleeping:
                SleepingUpdate();
                break;
            default:
                state = AIstate.patrol;
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
        

        if(CheckPlayerInRange(calcDetectionRange()) && !InSafezone())
        {
            state = AIstate.hunting;
        }
    }

    void HuntUpdate()
    {
        target_position = playerTransform.position;
        if (!CheckPlayerInRange(calcDetectionRange(loseDetectionMosifier)))
        {
            state = AIstate.patrol;
        }
        if(InSafezone())
        {
            state = AIstate.patrol;
        }
    }

    void InvestigateUpdate()
    {
        target_position = investigatePosition;
        if (CheckPlayerInRange(calcDetectionRange()))
        {
            state = AIstate.hunting;
        }
    }

    public void InitOnRails(GameObject RailsStartPoint, GameObject RailsEndPoint, GameObject RailsTeleportPoint = null)
    {
        if(RailsStartPoint && RailsEndPoint)
        {
            speed = railsSpeed;
            state = AIstate.on_rails;
            Monster.GetComponent<Transform>().position = RailsStartPoint.GetComponent<Transform>().position;
            target_position = RailsEndPoint.GetComponent<Transform>().position;

            if(RailsTeleportPoint)
            {
                RailsOnCompleteteleportPos = RailsTeleportPoint.GetComponent<Transform>().position;
                doRailsTeleport = true;
            }
            else
            {
                doRailsTeleport = false;
            }
        }
    }

    void OnRailsUpdate()
    {
        if (atEndOfPath())
        {
            EndOnRails();
        }
    }

    public void EndOnRails()
    {
        speed = normalSpeed;
        state = AIstate.patrol;
        if (doRailsTeleport)
        {
            Monster.GetComponent<Transform>().position = RailsOnCompleteteleportPos;
        }
        currentWaypoint = int.MaxValue;
    }


    void SleepingUpdate()
    {
        Monster.GetComponent<Transform>().position = new Vector3(1000, 1000, 0);
    }

    bool CheckPlayerInRange(float range)
    {
        float distance = Vector2.Distance(playerTransform.position, monsterPosition);

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
        Gizmos.DrawWireSphere(monsterPosition, calcDetectionRange());
        Gizmos.DrawWireSphere(monsterPosition, calcDetectionRange(loseDetectionMosifier));
    }

    bool InFoliage()
    {
        if(foliage_trigger_count > 0)
            return true;
        else
            return false;
    }

    bool InSafezone()
    {
        if (safezone_trigger_count > 0)
            return true;
        else
            return false;
    }

    //public void SetState(AIstate s)
    //{
    //    state = s;
    //}

    public void InvestigatePosition(Vector2 pos)
    {
        state = AIstate.investigate;
        investigatePosition.x = pos.x;
        investigatePosition.y = pos.y;
        return;
    }

    public void inc_foliage_count() { foliage_trigger_count++; }
    public void dec_foliage_count() { foliage_trigger_count--; }


    public void inc_safezone_count() { safezone_trigger_count++; }
    public void dec_safezone_count() { safezone_trigger_count--; }



}
