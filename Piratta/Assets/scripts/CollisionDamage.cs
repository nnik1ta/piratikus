using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionDamage : MonoBehaviour
{
    public float collisionDamage;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player" && gameObject.tag != "bullet")
        {
            collision.GetComponent<Health>().TakeDamage(collisionDamage);
        }
        if (collision.gameObject.tag == "box")
        {
            collision.GetComponent<Health>().TakeDamage(collisionDamage);
        }
    }
   
}
