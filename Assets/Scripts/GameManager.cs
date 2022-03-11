using System.Collections;
using Random = UnityEngine.Random;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    // The reason why I couldn't press the button was beacause event system object waas missing!

    // TODO: Solve the issue with time!
    public GameObject clock;
    public TextMeshProUGUI timeText;
    public TextMeshProUGUI levelText;
    public GameObject gameScreenUI;
    public GameObject finishScreenUI;
    public GameObject lostScreenUI;
    public GameObject ball;
    public GameObject level1;
    public GameObject level2;
    public GameObject level3;
    public Quaternion ballRotation;
    public Vector3 spawnPos;
    public float time = 500;
    public int currentLevel = 1;
    public bool isFinished = false;
    public bool isLost = false;
    public int life = 5;

    public AudioClip missSfx1;
    public AudioClip missSfx2;
    public AudioClip missSfx3;
    public AudioClip missSfx4;
    public AudioClip missSfx5;

    public AudioClip winSfx;

    public bool firstClockSpawned = false;
    public bool secondClockSpawned = false;
    public bool thirdClockSpawned = false;
    // Images:

    public AudioClip clockTriggerSound;



    //Vector3 wallOneInstantiatePos = new Vector3(0, 13.5f, 21.5f);
    //Vector3 wallTwoInstantiatePos = new Vector3(-5, 14f, 41.5f);
    //Vector3 wallThreeInstantiatePos = new Vector3(0, 13.5f, 21.5f);

    // Slider variables:

    public Coroutine clockSpawnCoroutine;

    public bool spawnNeeded = true;
    // Start is called before the first frame update
    void Start()
    {
        spawnPos = new Vector3(0, 0, 2.5f);
        ballRotation = new Quaternion(0, 0, 0, 0);
        UpdateLevelText();
        
    }

    // Update is called once per frame
    void Update()
    {
        if (life <= 0 || time <= 0)
        {
            isLost = true;
            gameScreenUI.SetActive(false);
            lostScreenUI.SetActive(true);
            // finishScreenUI.SetActive(true);
            Debug.Log("Game just finished!");
        }
        if (!isFinished && !isLost)
        {
            if (time < 37 && !firstClockSpawned)
            {
                ClockSpawnByLevel();
                firstClockSpawned = true;
            }
            else if (time < 25  && !secondClockSpawned)
            {
                ClockSpawnByLevel();
                secondClockSpawned = true;
            }
            else if (time < 17 && !thirdClockSpawned)
            {
                ClockSpawnByLevel();
                thirdClockSpawned = true;
            }
            UpdateTimeText();
            if (spawnNeeded)
            {
                Instantiate(ball, spawnPos, ballRotation);
                spawnNeeded = false;
            }
        }

    }
    Vector3 clockSpawnPos = new Vector3(0, 8.5f, 13);
    Quaternion clockSpawnRot = new Quaternion(0, 180, 0, 0);

    public IEnumerator ClockSpawnCD()
    {
        yield return new WaitForSeconds(2);
        ClockSpawnByLevel();
    }

    public void ClockSpawnByLevel()
    {
        Instantiate(clock, clockSpawnPos, clockSpawnRot);
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

    public void QuitGame()
    {
        Debug.Log("Quit!");
        Application.Quit();
    }
    // I stucked here just because I forgot to make this function public!
    public void MainMenuReturnal()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }

}
