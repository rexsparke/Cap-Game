using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PollinatorBeeScript : MonoBehaviour
{
    public GameObject flowerTile;

    Vector2 home;
    protected Transform target;
    PlacementManager placementManager;
    GlobalManager globManager;

    int stage = 0;
    float distance;
    bool added = false;

    void Start()
    {
        home = transform.position;
        target = flowerTile.transform;
        placementManager = GameObject.Find("main").GetComponent<PlacementManager>();
        globManager = GameObject.Find("main").GetComponent<GlobalManager>();
    }

    void Update()
    {
        if (stage == 0 && globManager.attackPase)
        {
            transform.position = Vector2.MoveTowards(transform.position, target.position, 1 * Time.deltaTime);
            distance = (transform.position - target.position).magnitude;
            if (distance <= 0)
            {
                StartCoroutine(Gathering());
            }
        }
        else
        {
            transform.position = Vector2.MoveTowards(transform.position, home, 1 * Time.deltaTime);
            
        }
        if(new Vector2(transform.position.x, transform.position.y) == home && stage == 1)
        {
            added = true;
            
        }
        if (globManager.buildPase && added == true)
        {
            placementManager.maxTiles += 1;
            //Debug.Log("")
            stage = 0;
            added = false;
        }
    }

    IEnumerator Gathering()
    {
        yield return new WaitForSeconds(4f);
        stage = 1;
    }
}
