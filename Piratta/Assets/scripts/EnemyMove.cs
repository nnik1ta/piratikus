using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMove : MonoBehaviour
{
    public Transform pos1, pos2;
    public float speed = 1;
    public Transform startPos;
    Vector3 nextPos;

    void Start()
    {
        nextPos = startPos.position;
    }

    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, nextPos, speed * Time.deltaTime);
        if (transform.position == pos1.position)
        {
            nextPos = pos2.position;
            transform.localScale = new Vector2(1.5f, 1.5f);
        }
        if (transform.position == pos2.position)
        {
            nextPos = pos1.position;
            transform.localScale = new Vector2(-1.5f, 1.5f);
        }
       
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        
    }



}
