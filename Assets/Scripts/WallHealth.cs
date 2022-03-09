using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WallHealth : MonoBehaviour
{
    public Slider slider;
    public int maxHealth = 10;
    public int minHealth = 0;
    public int health = 10;

    private void Start()
    {
        // Slider initial value assignment
        health = maxHealth;
        slider.value = health;
        slider.minValue = minHealth;
        slider.maxValue = maxHealth;
    }


    public void SetHealth(int value)
    {
        health += value;
        if (health <= 0)
        {
            health = maxHealth;
            slider.value = health;

        }
        slider.value = health;
    }
}
