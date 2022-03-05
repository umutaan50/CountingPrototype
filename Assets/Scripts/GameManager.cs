using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject ball;
    public Quaternion ballRotation;
    public Vector3 spawnPos;

    public bool shouldRespawnOne = false;
    // Start is called before the first frame update
    void Start()
    {
        spawnPos = new Vector3(0, 0, 9);
        ballRotation = new Quaternion(0, 0, 0, 0);

    }

    // Update is called once per frame
    void Update()
    {
        if (shouldRespawnOne)
        {
            Instantiate(ball, spawnPos, ballRotation);
            shouldRespawnOne = false;
        }
    }
}