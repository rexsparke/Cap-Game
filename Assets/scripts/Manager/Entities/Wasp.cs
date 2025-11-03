using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Wasp : MonoBehaviour
{
    [Header("Attack Settings")]
    public int damage = 1;                 // Damage dealt per hit
    public float moveSpeed = 2.5f;         // Movement speed toward honeycomb
    public bool dieOnHit = true;           // Should the wasp die after hitting a honeycomb?

    private Transform target;              // Current target honeycomb
    private Rigidbody2D rb;                // Rigidbody for movement

    private void Start()
    {
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

        // Move toward the honeycomb target
        Vector2 direction = (target.position - transform.position).normalized;
        rb.MovePosition(rb.position + direction * moveSpeed * Time.deltaTime);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Only interact with HoneyCombs
        if (!collision.gameObject.CompareTag("HoneyComb"))
            return;

        Debug.Log($"Wasp collided with {collision.gameObject.name}");

        HealthSystem honeyHealth = collision.gameObject.GetComponent<HealthSystem>();
        if (honeyHealth != null)
        {
            Debug.Log($"Hit a honeycomb! Damaging {collision.gameObject.name}");
            honeyHealth.TakeDamage(damage);

            if (dieOnHit)
            {
                Destroy(gameObject);
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
        GameObject[] combs = GameObject.FindGameObjectsWithTag("HoneyComb");

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
