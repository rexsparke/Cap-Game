using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeeWizard : MonoBehaviour
{
    [Header("Bullet Variables")]
    public float bulletSpeed;
    public float fireRate, bulletDamage;

    GlobalManager globalManager;

    [Header("Initial Setup")]
    //public Transform bulletSpawnTransform1;
    //public Transform bulletSpawnTransform2;
    public GameObject lightningPrefab;
    private int bulletNum = 1;
    private float timer;
    void Awake()
    {
        globalManager = GameObject.Find("main").GetComponent<GlobalManager>();
        if(globalManager == null )
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
            else if (timer > 3)
            {
                timer = 0;
                Debug.Log("Wizard Bee Timer is set to 0!!!");
            }
            //    RaycastHit hit;
            //if (Physics2D.Raycast(transform.position, transform.forward, 10f))
            //{
            //    Debug.Log("NPC 1 is looking at " + hit);
            //    //Debug.DrawRay(transform.position, hit.point, Color.green);
            //}
            //if (hit.transform != null)
            //{
                if (timer <= 0)
                {
                    if (bulletNum % 2 == 0)
                    {
                        ShootBarrel1();
                        bulletNum++;
                    }
                }
         }
        void ShootBarrel1()
        {
            GameObject bullet = Instantiate(lightningPrefab, this.transform.position, this.transform.rotation, GameObject.FindGameObjectWithTag("WorldObjectHolder").transform);
            bullet.GetComponent<Rigidbody>().AddForce(this.transform.forward * bulletSpeed, ForceMode.Impulse);   //ForceMode.Impulse makes the bullet explode out like a bullet
            Debug.Log("bee wizard Shoots lightning!");
            Debug.Log("Bullet Velocity: " + bullet.GetComponent<Rigidbody>().velocity);
            timer = 1;
        }
    }
}
