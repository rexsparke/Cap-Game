using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class HealthSystem : MonoBehaviour
{
    [Header("UI")]
    //[SerializeField] private GameObject healthBarPrefab;

    [Header("Health Settings")]
    //public int MaxHealth = 5;
    //public int CurrentHealth;
    GlobalManager globManager;

    //public UnityEvent<int, int> OnHealthChanged;
    //public UnityEvent OnDeath;

    //private HealthBar activeBar;
    hivHealth hivHealth;

    private void Awake()
    {
    //    // Always start full health
    //    CurrentHealth = MaxHealth;
        globManager = GetComponent<GlobalManager>();
        if(globManager == null )
        {
            Debug.LogError("globManger is null!");
        }
        hivHealth = GameObject.FindGameObjectWithTag("healthBar").GetComponent<hivHealth>();
        if( hivHealth == null )
        {
            Debug.LogError("Their is no hivHealth is null!! in HealthSystem");
        }
    }

    //private void Start()
    //{
    //    // Spawn and link a health bar above this object
    //    if (healthBarPrefab != null)
    //    {
    //        GameObject bar = Instantiate(
    //            healthBarPrefab,
    //            transform.position + Vector3.up * 1f,
    //            Quaternion.identity
    //        );

    //        activeBar = bar.GetComponent<HealthBar>();
    //        if (activeBar != null)
    //            activeBar.Initialize(this);
    //    }
    //}

    public void TakeDamage(int damage)
    {
        Debug.Log("Hex is being damaged");
        //CurrentHealth -= damage;
        //CurrentHealth = Mathf.Max(CurrentHealth, 0);
        //float fraction = Mathf.Clamp01((float)current / max);
        globManager.hiveHealth -= damage;
        globManager.hiveHealth = Mathf.Max(globManager.hiveHealth, 0);
        hivHealth.UpdateHealth(Mathf.Clamp01((float)globManager.hiveHealth / globManager.maxHiveHealth));
        // Notify any listeners (like HealthBar)
        //OnHealthChanged?.Invoke(CurrentHealth, MaxHealth);

        if (globManager.hiveHealth <= 0)
        {
            SceneManager.LoadScene("GameOverScene");
        }
    }

    //private void Die()
    //{
    //    if (isDead) return;
    //    isDead = true;

    //    //  Notify global health manager
    //    GlobalHealthManager globalManager = FindObjectOfType<GlobalHealthManager>();
    //    if (globalManager != null)
    //        globalManager.OnHoneycombDestroyed();

    //    //  Destroy the health bar if one exists
    //    if (activeBar != null)
    //        Destroy(activeBar.gameObject);

    //    //  Trigger any custom events (particle, animation, etc.)
    //    OnDeath?.Invoke();

    //    //  Finally destroy the honeycomb itself
    //    //Destroy(gameObject);
    //}
}
