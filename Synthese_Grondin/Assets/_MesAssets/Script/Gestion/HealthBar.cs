using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    Slider healthSlider;

    private void Start()
    {
        healthSlider = GetComponent<Slider>();
    }

    public void SetMaxHealth(int Maxhealth)
    { 
        healthSlider.maxValue = Maxhealth;
        healthSlider.value = Maxhealth;
    }

    public void SetHealth(int health)
    { 
        healthSlider.value = health;
    }

    public int GetHealth(int health)
    {
        return health;
    }
}
