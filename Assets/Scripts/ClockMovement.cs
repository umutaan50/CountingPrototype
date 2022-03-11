using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClockMovement : MonoBehaviour
{

    private GameManager gameManager;
    float speed = 15;
    bool leftMovement = true;

    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!gameManager.isLost)
        {
            //  && !gameManager.isFinished
            // It has 180 degrees rotation.
            if (leftMovement)
            {
                transform.Translate(Vector3.right * Time.deltaTime * speed);
                if (transform.position.x < -12)
                {
                    leftMovement = false;
                }
            }
            else if (leftMovement == false)
            {
                transform.Translate(Vector3.left * Time.deltaTime * speed);
                if (transform.position.x > 12)
                {
                    leftMovement = true;
                }
            }
        }
    }
}
