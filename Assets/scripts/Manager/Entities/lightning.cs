using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lightning : MonoBehaviour
{
    public int damage = 2;
    
    private void OnCollisionEnter2D(Collision2D other)
    {
        
        if (other.gameObject.CompareTag("wasp"))
        {
            Wasp wasp = other.gameObject.GetComponent<Wasp>();
            if (wasp != null)
            {
                wasp.TakeDamage(damage);
                Debug.Log("wasp was Damaged!");
            }
            Destroy(gameObject);
        }
    }
}
