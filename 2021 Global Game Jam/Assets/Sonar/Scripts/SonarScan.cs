using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SonarScan : MonoBehaviour
{
    [Header("Scan size")]
    public int scanRadius = 5;

    [Header("Instatiate objects")]
    public ParticleSystem particleSystem;
    public GameObject drawObject;
    public Transform canvas;

    public float scanDelay = 2;

    public minimap.MapManager map;

    private MasterInput controls;
    private float time = 2;

    // Start is called before the first frame update
    void Awake()
    {
        controls = new MasterInput();
        controls.PlayerControls.Sonar.performed += ctx => Scan();
    }

    private void Update()
    {
        if (time < scanDelay)
            time += Time.deltaTime;    
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
        if (time >= scanDelay)
        {
            time = 0;
            transform.localScale = new Vector3(scanRadius * 2f + 2, scanRadius * 2f + 2, scanRadius * 2f + 2); // Change scale for the particle to use
            Collider2D[] colliders = Physics2D.OverlapCircleAll(new Vector2(transform.position.x, transform.position.y), scanRadius); // Player pos && size of he scan
            foreach (var hitCollider in colliders)
            {
                if (hitCollider.gameObject.CompareTag("Treasure"))
                {
                    Debug.Log(hitCollider.gameObject.name);
                    float dist = Vector3.Distance(transform.position, hitCollider.transform.position); // dist to treasure
                    float delay = dist / (scanRadius / (float)particleSystem.simulationSpace);
                    StartCoroutine(hitCollider.GetComponent<TreasureControl>().Flash(delay)); // Start a deleyed flash to light up the treasure depending on distance
                    StartCoroutine(MapDraw(hitCollider.transform.position, delay));
                }
            }

            Instantiate(particleSystem, transform.position, transform.rotation, transform); // create a new partcle for the scan

            ///// Can use transform position here o tell monster where the scan took place///////////
        }
    }

    public IEnumerator MapDraw(Vector3 treasurePos, float delay)
    {
        yield return new WaitForSeconds(delay);

        // Draw to miniMap
        Vector3 mapPos = map.TranslateWorldToMapPosition(treasurePos);

        GameObject treasureMap = Instantiate(drawObject, mapPos, transform.rotation, canvas);
        treasureMap.GetComponent<RectTransform>().anchoredPosition = mapPos;
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(new Vector2(transform.position.x, transform.position.y), scanRadius);
    }
}
