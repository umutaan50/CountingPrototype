using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public TextMeshProUGUI timeText;
    public GameObject ball;
    public Quaternion ballRotation;
    public Vector3 spawnPos;
    public float time = 60f;

    public bool spawnNeeded = true;
    // Start is called before the first frame update
    void Start()
    {
        spawnPos = new Vector3(0, 0, 2.5f);
        ballRotation = new Quaternion(0, 0, 0, 0);

    }

    // Update is called once per frame
    void Update()
    {
        UpdateTimeText();
        if (spawnNeeded)
        {
            Instantiate(ball, spawnPos, ballRotation);
            spawnNeeded = false;
        }
        

    }

    void UpdateTimeText()
    {
        time -= 1 * Time.deltaTime;
        timeText.SetText("Zaman: " + (int)time);
    }
}
