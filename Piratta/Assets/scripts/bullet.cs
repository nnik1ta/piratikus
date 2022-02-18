using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet : MonoBehaviour
{
    private float speed = 4f;
    Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
       rb.velocity = transform.right * speed;
    }

 
    void Update()
    {

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "enemy")
        {
            Destroy(gameObject);
            Destroy(collision.gameObject);
        }
        if (collision.gameObject.tag == "ground")
        {
            Destroy(gameObject);
        }
    }

}
