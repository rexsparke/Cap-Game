using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PollinatorBeeScript : MonoBehaviour
{
    public GameObject flowerTile;

    Vector2 home;
    protected Transform target;

    int stage = 0;
    float distance;

    void Start()
    {
        home = transform.position;
        target = flowerTile.transform;
    }

    void Update()
    {
        if (stage == 0)
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
    }

    IEnumerator Gathering()
    {
        yield return new WaitForSeconds(4f);
        stage = 1;
    }
}
