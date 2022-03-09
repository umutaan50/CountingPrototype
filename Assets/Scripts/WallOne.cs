using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WallOne : MonoBehaviour
{

    public WallTwo wallTwo;
    public GameManager gameManager;

    public Slider slider;
    public int maxHealth = 10;
    public int minHealth = 0;
    public int health = 10;

    private void Awake()
    {
        // Slider initial value assignment
        
        slider = GameObject.Find("Health Bar Slider").GetComponent<Slider>();
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
            gameManager.currentLevel++;
            gameManager.level2.SetActive(true);
            gameManager.UpdateLevelText();
            wallTwo.gameObject.SetActive(true);
            Destroy(gameObject);
            return;

        }
        slider.value = health;
    }
    
}
