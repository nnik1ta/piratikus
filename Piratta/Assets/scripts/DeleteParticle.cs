using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeleteParticle : MonoBehaviour
{
   public float seconds;
    void Start()
    {
        StartCoroutine(Invunerability());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private IEnumerator Invunerability()
    {
        yield return new WaitForSeconds(seconds);
        Destroy(gameObject);
    }
}
