using UnityEngine;

[RequireComponent(typeof(HealthSystem))]
public class HoneyComb : MonoBehaviour
{
    private HealthSystem health;

    private void Awake()
    {
        health = GetComponent<HealthSystem>();
    }

    //public void DamageComb(int damage)
    //{
    //    health.TakeDamage(damage);
    //}

}
