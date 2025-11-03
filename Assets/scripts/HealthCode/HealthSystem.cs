using UnityEngine;
using UnityEngine.Events;

public class HealthSystem : MonoBehaviour
{
    [Header("UI")]
    [SerializeField] private GameObject healthBarPrefab;

    [Header("Health Settings")]
    public int MaxHealth = 5;
    public int CurrentHealth;

    public UnityEvent<int, int> OnHealthChanged;
    public UnityEvent OnDeath;

    private HealthBar activeBar;
    private bool isDead = false;

    private void Awake()
    {
        // Always start full health
        CurrentHealth = MaxHealth;
    }

    private void Start()
    {
        // Spawn and link a health bar above this object
        if (healthBarPrefab != null)
        {
            GameObject bar = Instantiate(
                healthBarPrefab,
                transform.position + Vector3.up * 1f,
                Quaternion.identity
            );

            activeBar = bar.GetComponent<HealthBar>();
            if (activeBar != null)
                activeBar.Initialize(this);
        }
    }

    public void TakeDamage(int amount)
    {
        if (isDead) return;

        CurrentHealth -= amount;
        CurrentHealth = Mathf.Max(CurrentHealth, 0);

        // Notify any listeners (like HealthBar)
        OnHealthChanged?.Invoke(CurrentHealth, MaxHealth);

        if (CurrentHealth <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        if (isDead) return;
        isDead = true;

        //  Notify global health manager
        GlobalHealthManager globalManager = FindObjectOfType<GlobalHealthManager>();
        if (globalManager != null)
            globalManager.OnHoneycombDestroyed();

        //  Destroy the health bar if one exists
        if (activeBar != null)
            Destroy(activeBar.gameObject);

        //  Trigger any custom events (particle, animation, etc.)
        OnDeath?.Invoke();

        //  Finally destroy the honeycomb itself
        Destroy(gameObject);
    }
}
