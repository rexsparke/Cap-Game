using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class BeeWizard : MonoBehaviour
{
    [Header("Bullet Variables")]
    public float bulletSpeed;
    public float fireRate, bulletDamage;

    GlobalManager globalManager;
    lightning lightning;

    [Header("Initial Setup")]
    //public Transform bulletSpawnTransform1;
    //public Transform bulletSpawnTransform2;
    public GameObject lightningPrefab;
    private int bulletNum = 1;
    private float timer;
    private Transform target;              // Current target wasp

    void Awake()
    {
        globalManager = GameObject.Find("main").GetComponent<GlobalManager>();
        lightning = lightningPrefab.GetComponent<lightning>();
        if(lightning == null )
        {
            Debug.LogError("Bee Wizards global manager is null!!!");
        }
    }
    void Update()
    {
        if(globalManager.attackPase == true)
        {
            if (timer > 0)   //Firing rate
            {
                timer -= Time.deltaTime / fireRate;
            }
            //else if (timer > 3)
            //{
            //    timer = 0;
            //    Debug.Log("Wizard Bee Timer is set to 0!!!");
            //}
            if (timer <= 0)
            {
                if (bulletNum % 2 == 0)
                {
                    lightning.Shoot(target.position);
                    bulletNum++;
                }
            }
         }
        // Move toward the honeycomb target
        //Vector2 direction = (target.position - transform.position).normalized;
        //rb.MovePosition(rb.position + direction * moveSpeed * Time.deltaTime);

        //void ShootBarrel1()
        //{
        //    //GameObject bullet = Instantiate(lightningPrefab, gameObject.transform.position, gameObject.transform.rotation, GameObject.FindGameObjectWithTag("WorldObjectHolder").transform);
        //    //bullet.GetComponent<Rigidbody>().AddForce(gameObject.transform.forward * bulletSpeed, ForceMode.Impulse);   //ForceMode.Impulse makes the bullet explode out like a bullet
        //    //Debug.Log("bee wizard Shoots lightning!");
        //    //Debug.Log("Bullet Velocity: " + bullet.GetComponent<Rigidbody>().velocity);
        //    //timer = 1;
        //}
    }
    private void FindClosestHoneyComb()
    {
        GameObject[] combs = GameObject.FindGameObjectsWithTag("wasp");

        if (combs == null || combs.Length == 0)
        {
            target = null;
            return;
        }

        float closestDistance = Mathf.Infinity;
        Transform closestTarget = null;

        foreach (GameObject comb in combs)
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
}
