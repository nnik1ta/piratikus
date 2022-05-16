using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RunningParticle : MonoBehaviour
{
    public bool rn;
    public GameObject particle;
    public Transform particlepos;
    public PlayerMovement pl;
    public bool ic;

    private void Start()
    {

    }
    private void Update()
    {
        rn = pl.IsRunning;
        ic = pl.IsCeiling;

    }
    private IEnumerator Invunerability()
    {
        Instantiate(particle, particlepos.transform.position, transform.rotation);
        yield return new WaitForSeconds(0.1f);
        Instantiate(particle, particlepos.transform.position, transform.rotation);
        yield return new WaitForSeconds(0.1f);

    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "ground" && ic == false)
        {
            if (rn == true)
            {
                StartCoroutine(Invunerability());
            }
        }
    }



}
