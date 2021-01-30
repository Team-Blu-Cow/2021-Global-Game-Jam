using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SonarScan : MonoBehaviour
{
    public int scanRadius = 5;
    public float scanLifetime = 4;

    private MasterInput controls;    

    // Start is called before the first frame update
    void Awake()
    {
        controls = new MasterInput();
        controls.PlayerControls.Sonar.performed += ctx => Scan();
    }
    private void OnEnable()
    {
        controls.Enable();
    }

    private void OnDisable()
    {
        controls.Disable();
    }

    void Scan()
    {
        
        transform.localScale = new Vector3(scanRadius * 2f +2, scanRadius * 2f+2, scanRadius * 2f+2);
        Collider2D[] colliders = Physics2D.OverlapCircleAll(new Vector2(transform.position.x, transform.position.y), scanRadius); // Player pos && size of he scan
        foreach (var hitCollider in colliders)
        {
            if (hitCollider.gameObject.CompareTag("Treasure"))
            {
                Debug.Log(hitCollider.gameObject.name);
                float dist = Vector3.Distance(transform.position, hitCollider.transform.position);
                StartCoroutine(hitCollider.GetComponent<TreasureControl>().Flash(dist/(scanRadius/scanLifetime)));
            }
        }
        GetComponent<ParticleSystem>().Play();
        
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(new Vector2(transform.position.x, transform.position.y), scanRadius);
    }
}
