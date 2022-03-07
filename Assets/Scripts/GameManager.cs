using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject ball;
    public Quaternion ballRotation;
    public Vector3 spawnPos;

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
        if (spawnNeeded)
        {
            Instantiate(ball, spawnPos, ballRotation);
            spawnNeeded = false;
        }
    }
}
