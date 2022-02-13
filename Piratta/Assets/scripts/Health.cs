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





    public void TakeHit(float damage)
    {
        
        health -= damage;
        Death.Play();
        if (health <= 0)
        {
            
            poloska.enabled = false;
            rem.enabled = false;
            Destroy(gameObject);

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


}
