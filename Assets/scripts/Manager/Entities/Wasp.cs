using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Wasp : MonoBehaviour
{
    [Header("Attack Settings")]
    public int damage = 1;                 // Damage dealt per hit
    public float moveSpeed = 2.5f;         // Movement speed toward honeycomb
    //public bool dieOnHit = true;         // Should the wasp die after hitting a honeycomb?

    private Transform target;              // Current target honeycomb
    private Rigidbody2D rb;                // Rigidbody for movement
    HealthSystem healthSystem;
    public int waspHealth = 10;

    private void Start()
    {
        healthSystem = GameObject.Find("main").GetComponent<HealthSystem>();
        if(healthSystem == null )
        {
            Debug.LogError("No health system commponent!!");
        }
        rb = GetComponent<Rigidbody2D>();
        rb.gravityScale = 0;               // Prevent falling
        rb.freezeRotation = true;

        FindClosestHoneyComb();
    }

    private void Update()
    {
        // Reacquire a target if none exists
        if (target == null)
        {
            FindClosestHoneyComb();
            return;
        }
        if (waspHealth <= 0)
        {
            Destroy(gameObject);
            Debug.Log("Wasp was destroyed!!");
        }

        // Move toward the honeycomb target
        Vector2 direction = (target.position - transform.position).normalized;
        rb.MovePosition(rb.position + direction * moveSpeed * Time.deltaTime);
    }
    //private void OnCollisionStay2D(Collision2D collision)
    //{
    //    Debug.Log($"Wasp collided with {collision.gameObject.name}");
    //}
    private void OnCollisionStay2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "bee")
        {
            collision.gameObject.GetComponent<Bee>().health -= damage;
            Debug.Log("Bee Health: " + collision.gameObject.GetComponent<Bee>().health);
            Debug.Log("Bee was Damaged!!!");

        }
        else
        {
            Debug.Log($"Wasp collided with {collision.gameObject.name}");
            if (healthSystem != null)
            {
                Debug.Log($"Hit a honeycomb! Damaging {collision.gameObject.name}");
                Debug.Log("I made it in if to check collision tag");
                healthSystem.TakeDamage(damage);

                //if (dieOnHit)
                //{
                //    Destroy(gameObject);
                //}
            }
        }
    }

    private void OnMouseDown()
    {
        // Allow player to destroy wasps manually
        Destroy(gameObject);
    }

    private void FindClosestHoneyComb()
    {
        GameObject[] combs = GameObject.FindGameObjectsWithTag("BoardHex");

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
    private void FindClosestBee()
    {

    }
}
