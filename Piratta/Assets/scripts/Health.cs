using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] private float startingHeath;
    public AudioSource Death;
    [SerializeField] private float iFramesDuration;
    [SerializeField] private int numberOfFlashes;
    private SpriteRenderer spriteRend;
    public bool bob;
    public Animator animator;
    public float currenthealth { get; private set; }
    public void Awake()
    {
        currenthealth = startingHeath;
        spriteRend = GetComponent<SpriteRenderer>();
    }

    public void TakeDamage(float _damage)
    {
        
        currenthealth = Mathf.Clamp(currenthealth - _damage, 0, startingHeath);
        /*currenthealth -= _damage;*/
        if (currenthealth > 0)
        {
            
        }
        else
        {

        }
        StartCoroutine(Invunerability());
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
    
}
