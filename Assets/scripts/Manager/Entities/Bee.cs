using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bee : MonoBehaviour
{
    [Header("Attack Settings")]
    public int damage = 3;                 // Damage dealt per hit
    public float moveSpeed = 3.5f;         // Movement speed toward honeycomb
    public bool dieOnHit = true;           // Should the wasp die after hitting a honeycomb?

    private Transform target;              // Current target wasp
    private Rigidbody2D rb;                // Rigidbody for movement
    public int health = 20;
    public int maxHealth = 20;
    GlobalManager globManager;
    Vector2 beginPos;
    public float attackSpeed = 1f;
    public float attackCooldown = 0f;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.gravityScale = 0;               // Prevent falling
        rb.freezeRotation = true;
        Physics.IgnoreLayerCollision(9, 11);
        FindClosestWasp();
        health = maxHealth;
        beginPos = gameObject.transform.position;
        globManager = GameObject.Find("main").GetComponent<GlobalManager>();
    }
    private void Update()
    {
        // Reacquire a target if none exists
        if(globManager.attackPase == true)
        {
            if (target == null)
            {
                FindClosestWasp();
                return;
            }
            if (attackCooldown > 0) //Timer for wasp
            {
                attackCooldown -= Time.deltaTime;
            }
            // Move toward the honeycomb target
            Vector2 direction = (target.position - transform.position).normalized;
            rb.MovePosition(rb.position + direction * moveSpeed * Time.deltaTime);
        }
        else
        {
            gameObject.transform.position = beginPos;
        }
        
    }
    private void OnCollisionStay2D(Collision2D collision)
    {
        //// Only interact with HoneyCombs
        //if (!collision.gameObject.CompareTag("HoneyComb"))
        //    return;

        //Debug.Log($"Wasp collided with {collision.gameObject.name}");

        //HealthSystem honeyHealth = collision.gameObject.GetComponent<HealthSystem>();
        //if (honeyHealth != null)
        //{
        //    Debug.Log($"Hit a honeycomb! Damaging {collision.gameObject.name}");
        //    //honeyHealth.TakeDamage(damage);

        //    if (dieOnHit)
        //    {
        //        Destroy(gameObject);
        //    }
        //}
        if (attackCooldown <= 0)
        {
            if (collision.gameObject.CompareTag("wasp"))
            {
                Wasp wasp = collision.gameObject.GetComponent<Wasp>();
                if(wasp != null)
                {
                    wasp.TakeDamage(damage);
                    Debug.Log("wasp was Damaged!");
                    attackCooldown = attackSpeed;
                    
                }
                else
                {
                    Debug.LogWarning("Object tagged 'wasp' has no Wasp component!");
                }
            }
        }
    }
    private void OnMouseDown()
    {
        // Allow player to destroy bees manually
        Destroy(gameObject);
    }
    private void FindClosestWasp()
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
    public void TakeDamage(int amount)
    {
        // Subtract and clamp between 0 and maxHealth
        health = Mathf.Clamp(health - amount, 0, maxHealth);

        Debug.Log("Bee Health: " + health);

        if (health <= 0)
        {
            Destroy(gameObject);
            Debug.Log("Bee Died!");
        }
    }
}
