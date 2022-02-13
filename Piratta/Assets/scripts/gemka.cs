using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gemka : MonoBehaviour
{


    private void OnCollissionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            Destroy(gameObject);
        }
    }


}
