using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class weaponHold : MonoBehaviour
{
    public bool hold;
    public float distance = 2f;
    RaycastHit2D hit;
    public Transform holdPoint;
    public float throwObject = 3f;
    void Start()
    {
        
    }


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (!hold)
            {
                Physics2D.queriesStartInColliders = false;
                hit = Physics2D.Raycast(transform.position, Vector2.right * transform.localScale.x, distance);
                if (hit.collider != null && hit.collider.tag == "weapon") 
                {
                    hold = true;
                }

            }
            else
            {
                hold = false;
                if (hit.collider.gameObject.GetComponent<Rigidbody2D>() != null)
                {
                    hit.collider.gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(transform.localScale.x, 1) * throwObject;
                }
            }
        }
        if (hold)
        {
            hit.collider.gameObject.transform.position = holdPoint.position;
            if (holdPoint.position.x > transform.position.x && hold == true)
            {
                hit.collider.gameObject.transform.localScale = new Vector2(transform.localScale.x * 1, transform.localScale.y * 1);

            }
            else if (holdPoint.position.x < transform.position.x && hold == true)
            {
                hit.collider.gameObject.transform.localScale = new Vector2(transform.localScale.x + -1, transform.localScale.y * 1);
            }
        }

    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawLine(transform.position, transform.position + Vector3.right * transform.localScale.normalized.x * distance);
    }








}
