using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// For managing health interaction when the ball hits
public class CylinderHealth : MonoBehaviour
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

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("BallForPlayer"))
        {
           SetHealth(-3);

        }
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
