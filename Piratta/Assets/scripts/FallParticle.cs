using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallParticle : MonoBehaviour
{
    public bool ig;
    public bool rn;
    public GameObject particle;
    public Transform particlepos;
    public PlayerMovement pl;

    private void Start()
    {
        
    }
    private void Update()
    {
        ig = pl.isGround;
        rn = pl.IsRunning;
        
    }
    private IEnumerator Invunerability()
    {
        Instantiate(particle, particlepos.transform.position, transform.rotation);
        yield return new WaitForSeconds(0);
        
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "ground" && rn == false)
        {
            if (ig == true)
            {
                StartCoroutine(Invunerability());
            }
        }
    }



}
