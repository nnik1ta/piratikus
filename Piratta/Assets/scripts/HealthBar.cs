using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public Image Bar;
    public float fill;
    public Health boo;
    public Image bloood;
    public float boba;



    void Start()
    {
        fill = 1f;
        
    }

    
    /*void Update()
    {
        boba = boo.health;
        Bar.fillAmount = fill;
        fill = boo.health;
        if (boo.health <= 0)
        {
            Destroy(Bar);
        }
        if (boo.health < 0.5f)
        {
            bloood.color = new Color(0.5f, 0.5f, 0.5f, 0.5f - boba);
        }
        else
        {
            bloood.color = new Color(0.5f, 0.5f, 0.5f, 0f);
        }*/

        /*if (boo.health <= 0.5f)
        {
            bloood.color = new Color(0.5f, 0.5f, 0.5f, 0.2f);
            if (boo.health <= 0.3f)
            {
                bloood.color = new Color(0.5f, 0.5f, 0.5f, 0.3f);
                if (boo.health <= 0.1f)
                {
                    bloood.color = new Color(0.5f, 0.5f, 0.5f, 0.5f);
                }
            }
        }*/
        /* else
         {
             bloood.color = new Color(0.5f, 0.5f, 0.5f, 0f);
         }*/
    }

