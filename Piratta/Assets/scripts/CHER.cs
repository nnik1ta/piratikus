using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CHER : MonoBehaviour
{
    public float collisionHeal = 0.1f;
    public string collisionTag;
   


    public void OnCollisionEnter2D(Collision2D collision)
    {
      
      Health health = collision.gameObject.GetComponent<Health>();
     /* health.GetHeal(collisionHeal);*/
      
      Destroy(gameObject);

    }





}



