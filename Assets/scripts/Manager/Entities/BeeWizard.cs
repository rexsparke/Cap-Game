using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BeeWizard : MonoBehaviour
{
    [Header("Bullet Variables")]
    public float fireRate = 2f;

    GlobalManager globalManager;

    [Header("Initial Setup")]
    public GameObject lightningPrefab;
    private int bulletNum = 1;
    private float timer = 0f;
    public float lifeTime = 5f;  //Destroys bullet afeter 3 secounds
    private Transform target;              // Current target wasp
    float moveSpeed = 25;

    void Awake()
    {
        globalManager = GameObject.Find("main").GetComponent<GlobalManager>();

        if (globalManager == null)
        {
            Debug.LogError("GlobalManager not found! Is your object spelled 'main'?");
        }
        if (lightningPrefab.GetComponent<lightning>() == null )
        {
            Debug.LogError("Lightning prefab is missing the lightning script!");
        }
    }
    void Update()
    {
            if (!globalManager.attackPase)
            {
                return;
            }
            // Find target each frame
            FindClosestHoneyComb();
            if (target == null)
            {
                Debug.Log("No wasp target found.");
                return;
            }
            // Fire rate timer
            timer -= Time.deltaTime;
            if (timer <= 0f)
            {
                Debug.Log("Firing at: " + target.name);
                ShootAtTarget();
                timer = 1f / fireRate;
            }
    }
    void ShootAtTarget()
    {
        // Instantiate bullet
        GameObject bullet = Instantiate(lightningPrefab,transform.position,Quaternion.identity);

        // Shoot toward target
        Shoot(target.position, bullet);
    }
    private void FindClosestHoneyComb()
    {
        GameObject[] wasp = GameObject.FindGameObjectsWithTag("wasp");

        if (wasp == null || wasp.Length == 0)
        {
            target = null;
            return;
        }

        float closestDistance = Mathf.Infinity;
        Transform closestTarget = null;

        foreach (GameObject comb in wasp)
        {
            float distance = Vector2.Distance(transform.position, comb.transform.position);
            if (distance < closestDistance)
            {
                closestDistance = distance;
                closestTarget = comb.transform;
            }
        }

        target = closestTarget;
    }
    public void Shoot(Vector3 waspPos, GameObject bullet)
    {
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        if (rb == null)
        {
            Debug.LogError("Bullet has no Rigidbody2D!");
            return;
        }
        Debug.Log("bullet actually moved!");
        Vector2 direction = (waspPos - transform.position).normalized;
        rb.velocity = direction * moveSpeed;
        Destroy(bullet, lifeTime);
    }
}
