using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionDamage : MonoBehaviour
{
   
    public float collisionDamage = 0.1f;
    public string collisionTag;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Health health = collision.gameObject.GetComponent<Health>();
        health.TakeHit(collisionDamage);
        


}
}
