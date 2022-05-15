using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
   
    public float startingHeath;
    public AudioSource Death;
    [SerializeField] private float iFramesDuration;
    [SerializeField] private int numberOfFlashes;
    private SpriteRenderer spriteRend;
    public bool Hit;
    public Animator animator;
    public float currenthealth; /*{ get; private set; }*/
    
    public void Awake()
    {
        currenthealth = startingHeath;
        spriteRend = GetComponent<SpriteRenderer>();
    }
    private void Update()
    {
        if (currenthealth <= 0)
        {
            Destroy(gameObject);
        }
    }
    public void TakeHeal(float _damage)
    {
        currenthealth += _damage;
       
    }
    public void TakeDamage(float _damage)
    {   
        currenthealth -= _damage;
        StartCoroutine(Invunerability());
    }
    private IEnumerator Invunerability()
    {
        Hit = true;
        Physics2D.IgnoreLayerCollision(10, 11, true);
        for (int i = 0; i < numberOfFlashes; i++)
        {
            spriteRend.color = new Color(1, 0, 0, 0.5f);
            yield return new WaitForSeconds(iFramesDuration / (numberOfFlashes * 2));
            spriteRend.color = Color.white;
            yield return new WaitForSeconds(iFramesDuration / (numberOfFlashes * 2));
        }
        Physics2D.IgnoreLayerCollision(10, 11, false);
        Hit = false;
    }
    
}
