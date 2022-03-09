using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    // The reason why I couldn't press the button was beacause event system object waas missing!

    public TextMeshProUGUI timeText;
    public TextMeshProUGUI levelText;
    public GameObject ball;
    public GameObject level1;
    public GameObject level2;
    public GameObject level3;
    public Quaternion ballRotation;
    public Vector3 spawnPos;
    public float time = 60f;
    public int currentLevel = 1;
    public bool isFinished = false;

    //Vector3 wallOneInstantiatePos = new Vector3(0, 13.5f, 21.5f);
    //Vector3 wallTwoInstantiatePos = new Vector3(-5, 14f, 41.5f);
    //Vector3 wallThreeInstantiatePos = new Vector3(0, 13.5f, 21.5f);

    // Slider variables:


    public bool spawnNeeded = true;
    // Start is called before the first frame update
    void Start()
    {
        //rotations = new Quaternion(0, 0, 0, 0);
        //Instantiate(level1, wallOneInstantiatePos, rotations);
        //Instantiate(level2, wallTwoInstantiatePos, rotations);
        //Instantiate(level3, wallThreeInstantiatePos, rotations);
        spawnPos = new Vector3(0, 0, 2.5f);
        ballRotation = new Quaternion(0, 0, 0, 0);
        UpdateLevelText();
    }

    // Update is called once per frame
    void Update()
    {
        if (!isFinished)
        {
            UpdateTimeText();
            if (spawnNeeded)
            {
                Instantiate(ball, spawnPos, ballRotation);
                spawnNeeded = false;
            }
        }

    }

    void UpdateTimeText()
    {
        time -= 1 * Time.deltaTime;
        timeText.SetText("Zaman: " + (int)time);
        
    }

    public void UpdateLevelText()
    {
        levelText.SetText("Seviye: " + currentLevel);
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    
}
