using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public Slider slider;
    private HealthSystem healthSystem;

    public void SetMaxHealth(double maxHealth)
    {
        slider.maxValue= (float)maxHealth; 
        slider.value= (float)maxHealth;
    }

    public void SetHealth(double health)
    {
        slider.value = (float)health;
    }
}
