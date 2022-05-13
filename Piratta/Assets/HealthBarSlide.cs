using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBarSlide : MonoBehaviour
{
    public Slider slider;
    public Health opa;
    public void Update()
    {
        slider.value = opa.currenthealth; 
    }
    
}
