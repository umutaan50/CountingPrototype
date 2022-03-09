using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WallThree : MonoBehaviour
{
    public GameManager gameManager;
    public GameObject gameScreenUI;
    public GameObject finishScreenUI;
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
            Destroy(gameObject);
            Debug.Log("Game Over!!!");
            gameScreenUI.SetActive(false);
            finishScreenUI.SetActive(true);
            gameManager.isFinished = true;
            Debug.Log("Game just finished!");

        }
        slider.value = health;
        
    }
}
