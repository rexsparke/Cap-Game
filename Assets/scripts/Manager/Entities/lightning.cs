using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lightning : MonoBehaviour
{
    [SerializeField] Rigidbody2D _rigidBody;
    [SerializeField] float moveSpeed;

    public int damage = 2;
    public float lifeTime = 3;  //Destroys bullet afeter 3 secounds
    public void Shoot(Vector3 waspPos)
    {
        _rigidBody.velocity = moveSpeed * (waspPos - transform.position);
        Destroy(gameObject, 5f);

        //lifeTime -= Time.deltaTime; //
        //if (lifeTime < 0)
        //{
        //    Destroy(gameObject);
        //}

    }
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
        }

        Destroy(gameObject);
    }
}
