using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionDamage : MonoBehaviour
{
    /* public float collisionDamage;
     private void OnTriggerEnter2D(Collider2D collision)
     {
         if (collision.tag == "Player")
         {
             collision.GetComponent<Health>().TakeDamage(collisionDamage);
         }
     }*/
    public float collisionDamage;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Health currenthealth = collision.gameObject.GetComponent<Health>();
            currenthealth.TakeDamage(collisionDamage);
        }
    }
}
