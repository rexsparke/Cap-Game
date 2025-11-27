using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bee : MonoBehaviour
{
    [Header("Attack Settings")]
    public int damage = 2;                 // Damage dealt per hit
    public float moveSpeed = 2.5f;         // Movement speed toward honeycomb
    public bool dieOnHit = true;           // Should the wasp die after hitting a honeycomb?

    private Transform target;              // Current target honeycomb
    private Rigidbody2D rb;                // Rigidbody for movement
    public int health = 20;
    public int maxHealth = 20;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.gravityScale = 0;               // Prevent falling
        rb.freezeRotation = true;
        health = maxHealth;
        FindClosestWasp();
    }
    private void Update()
    {
        // Reacquire a target if none exists
        if (target == null)
        {
            FindClosestWasp();
            return;
        }
        if(health == 0)
        {
            Destroy(gameObject);
            Debug.Log("Bee was Destoryed!!");
        }

        // Move toward the honeycomb target
        Vector2 direction = (target.position - transform.position).normalized;
        rb.MovePosition(rb.position + direction * moveSpeed * Time.deltaTime);
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
        if (collision.gameObject.tag == "bee")
        {
            collision.gameObject.GetComponent<Wasp>().waspHealth -= damage;
            Debug.Log("Wasp Health: " + collision.gameObject.GetComponent<Wasp>().waspHealth);
            Debug.Log("wasp was Damaged!!!");
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
}
