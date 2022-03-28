using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class weapon : MonoBehaviour
{
    public Transform shotpos;
    public GameObject bullet;
    public AudioSource Shoot;
    void Start()
    {
        
    }
    private void Awake()
    {
        
    }


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            Instantiate(bullet, shotpos.transform.position, transform.rotation);
            Shoot.Play();
           
        }

    }
  
}
