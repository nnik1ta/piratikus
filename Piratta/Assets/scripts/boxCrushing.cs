using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class boxCrushing : MonoBehaviour
{
    public Animator animator;
    public GameObject _thing;
    public Transform _ThingT;
    public Health hl;
    public float _hp;
    public float _hps;


    private void Start()
    {
        _hp = hl.currenthealth;
        _hps = hl.startingHeath;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "bullet")
        {
            if (_hp <= 0)
            {
                StartCoroutine(Invunerability());
            }
            else if (_hp < _hps && _hp > 0 )
            {
                animator.SetBool("IsHit", true);
            }
            else
            {
                animator.SetBool("IsHit", false);
            }
            
        }
        
    }
    private IEnumerator Invunerability()
    {
        animator.SetBool("IsCrushing", true);
        yield return new WaitForSeconds(2);
        Destroy(gameObject);
        yield return new WaitForSeconds(0.5f);
        Instantiate(_thing, _ThingT.transform.position, transform.rotation);

    }
}
