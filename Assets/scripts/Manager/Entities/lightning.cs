using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lightning : MonoBehaviour
{
    public int damage;
    public float lifeTime = 3;  //Destroys bullet afeter 3 secounds


    private void Update()
    {
        lifeTime -= Time.deltaTime; //
        if (lifeTime < 0)
        {
            Destroy(gameObject);
        }

    }
    private void OnCollisionEnter2D(Collision2D other)
    {
        
        if (other.gameObject.GetComponent<Wasp>() != null)
        {
            other.gameObject.GetComponent<Wasp>().waspHealth -= damage;
            Debug.Log("Wasp health: " + other.gameObject.GetComponent<Wasp>().waspHealth);
        }

        Destroy(gameObject);
    }
}
