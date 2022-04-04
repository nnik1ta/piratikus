using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    public float health;
    public float maxhealth;
    public AudioSource Death;
    public Canvas rem;
    public Canvas poloska;
    [SerializeField] private float iFramesDuration;
    [SerializeField] private int numberOfFlashes;
    private SpriteRenderer spriteRend;
    public bool bob;
    public Animator animator;

    private void Update()
    {
      /* if (bob == true)
        {
            animator.SetBool("IsHit",true);
        }
        else
        {
            animator.SetBool("IsHit", false);

        }*/
    }
    private void Awake()
    {
        spriteRend = GetComponent<SpriteRenderer>();
    }
    public void TakeHit(float damage)
    {
        health -= damage;
        Death.Play();
        if (health <= 0)
        {
            /*poloska.enabled = false;
            rem.enabled = false;*/
            Destroy(gameObject);
        }
        if (health > 0)
        {
            StartCoroutine(Invunerability());
        }
    }
    public void SetHealth(float bonusHealth)
    {
        health += bonusHealth;
        if (health > maxhealth)
        {
            health = maxhealth;
        }
    }
    public void GetHeal(float heal)
    {
        health += heal;
    }
     private IEnumerator Invunerability()
    {
        bob = true;
        Physics2D.IgnoreLayerCollision(10, 11, true);
        for (int i = 0; i < numberOfFlashes; i++)
        {
            spriteRend.color = new Color(1, 0, 0, 0.5f);
            yield return new WaitForSeconds(iFramesDuration / (numberOfFlashes * 2));
            spriteRend.color = Color.white;
            yield return new WaitForSeconds(iFramesDuration / (numberOfFlashes * 2));

        }
        Physics2D.IgnoreLayerCollision(10, 11, false);
        bob = false;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        /*if (collision.gameObject.tag == "enemy")
        {
         animator.SetBool("IsHit",true);
        }
        else
        {
         animator.SetBool("IsHit",false);
        }*/
    }



}
